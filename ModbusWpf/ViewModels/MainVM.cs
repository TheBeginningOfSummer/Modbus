using CommunicationsToolkit;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Models;
using MyToolkit;
using Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using static MyToolkit.ConnectionToolkit;

namespace ViewModels;

public class MainVM : ObservableObject
{
    #region 界面绑定的数据
    private string? _ip;
    public string? IP
    {
        get => _ip;
        set => SetProperty(ref _ip, value);
    }

    private string? _port;
    public string? Port
    {
        get => _port;
        set => SetProperty(ref _port, value);
    }

    private ushort _connectionStatus;
    public ushort ConnectionStatus
    {
        get => _connectionStatus;
        set => SetProperty(ref _connectionStatus, value);
    }

    private ushort _deviceStatus;
    public ushort DeviceStatus
    {
        get => _deviceStatus;
        set => SetProperty(ref _deviceStatus, value);
    }

    private ushort _alarmStatus;
    public ushort AlarmStatus
    {
        get => _alarmStatus;
        set => SetProperty(ref _alarmStatus, value);
    }

    private ushort _alarmCode;
    public ushort AlarmCode
    {
        get => _alarmCode;
        set => SetProperty(ref _alarmCode, value);
    }

    private string? _minTime;
    public string? MinTime
    {
        get => _minTime;
        set => SetProperty(ref _minTime, CheckTimeFormat(value));
    }

    private string? _maxTime;
    public string? MaxTime
    {
        get => _maxTime;
        set => SetProperty(ref _maxTime, CheckTimeFormat(value));
    }

    private string? _minDate;
    public string? MinDate
    {
        get => _minDate;
        set => SetProperty(ref _minDate, value);
    }

    private string? _maxDate;
    public string? MaxDate
    {
        get => _maxDate;
        set => SetProperty(ref _maxDate, value);
    }

    public ObservableCollection<WeightData> Weights { get; } = new ObservableCollection<WeightData>();
    #endregion

    #region 命令
    private RelayCommand? _startListen;
    public RelayCommand StartListen => _startListen ??= new RelayCommand(() =>
    {
        if (!IPAddress.TryParse(IP, out IPAddress? ipAddress)) return;
        if (!int.TryParse(Port, out int port)) return;
        _server = _modbus.Connection;
        if (_server.StartListening(ipAddress, port))
        {
            //server.ClientListUpdate = UpdateClient;//客户端列表委托更新绑定
            //server.ReceiveFromClient += FromClient;//服务端数据收发委托绑定
            MessageBox.Show("监听成功", "服务端");
        }
    });

    private RelayCommand? _auto;
    public RelayCommand Auto => _auto ??= new RelayCommand(() =>
    {
        var result = MessageBox.Show("是否切换自动模式？", "提示", MessageBoxButton.YesNo, MessageBoxImage.Question);
        if (result == MessageBoxResult.Yes)
        {
            _modbus.SetHoldingRegister(2, 2);
        }
    });

    private RelayCommand? _manual;
    public RelayCommand Manual => _manual ??= new RelayCommand(() =>
    {
        var result = MessageBox.Show("是否切换手动模式？", "提示", MessageBoxButton.YesNo, MessageBoxImage.Question);
        if (result == MessageBoxResult.Yes)
            _modbus.SetHoldingRegister(1, 2);
    });

    private RelayCommand? _start;
    public RelayCommand Start => _start ??= new RelayCommand(() =>
    {
        var result = MessageBox.Show("是否启动？", "提示", MessageBoxButton.YesNo, MessageBoxImage.Question);
        if (result == MessageBoxResult.Yes)
            _modbus.SetHoldingRegister(1, 3);
    });

    private RelayCommand? _stop;
    public RelayCommand Stop => _stop ??= new RelayCommand(() =>
    {
        var result = MessageBox.Show("是否停止？", "提示", MessageBoxButton.YesNo, MessageBoxImage.Question);
        if (result == MessageBoxResult.Yes)
            _modbus.SetHoldingRegister(2, 3);
    });

    private RelayCommand? _inquire;
    public RelayCommand Inquire => _inquire ??= new RelayCommand(async () =>
    {
        var min = $"{Convert.ToDateTime(MinDate):yyyy-MM-dd} {MinTime}";
        var max = $"{Convert.ToDateTime(MaxDate):yyyy-MM-dd} {MaxTime}";
        var dataSource = await _sqlite.SQLConnection.QueryAsync<WeightData>
        ($"select * from WeightData where Time >='{min}' and Time <='{max}'");
        if (dataSource == null) return; Weights.Clear();
        foreach (var item in dataSource)
        {
            Weights.Add(item);
        }
    });

    private RelayCommand? _timeChanged;
    public RelayCommand TimeChanged => _timeChanged ??= new RelayCommand(() =>
    {
        
    });

    private RelayCommand? _test;
    public RelayCommand Test => _test ??= new RelayCommand(() =>
    {
        _modbus.SetHoldingRegister(1, 1);
        //_modbus.SetHoldingRegister(1, 204);
        //Task.Run(() =>
        //{
        //    for (ushort i = 0; i < 10; i++)
        //    {
        //        Thread.Sleep(1000);
        //        _modbus.SetHoldingRegister(i, 202);
        //    }
        //});
    });

    private RelayCommand? _saveConnectionConfig;
    public RelayCommand SaveConnectionConfig => _saveConnectionConfig ??= new RelayCommand(() =>
    {
        try
        {
            _config.Change("IP", string.IsNullOrEmpty(IP) ? "127.0.0.1" : IP);
            _config.Change("Port", string.IsNullOrEmpty(Port) ? "9600" : Port);
            MessageBox.Show("保存成功", "保存设置");
        }
        catch (Exception)
        {

        }
    });

    #endregion

    #region 实例
    [AllowNull]
    SocketTool? _server;
    readonly ModbusTCP _modbus = new();
    readonly SQLiteService _sqlite = new("Weight.db", "Database");
    readonly KeyValueLoader _config = new("Configuration.json", "Config");
    #endregion

    public MainVM()
    {
        _sqlite.InitializeTableAsync<WeightData>();
        InitializeData();
        IP = _config.Load("IP");
        Port = _config.Load("Port");
        MinTime = DateTime.Now.ToString("HH:mm:ss");
        MaxTime = DateTime.Now.ToString("HH:mm:ss");
        MinDate = Convert.ToDateTime(DateTime.Now.AddDays(-7)).ToString("d");
        MaxDate = Convert.ToDateTime(DateTime.Now.AddDays(1)).ToString("d");
        Task.Run(DataRefreshSwitch);
        Task.Run(DataRefresh);
    }

    #region 方法
    public async void InitializeData()
    {
        try
        {
            List<WeightData>? SourceData = await _sqlite.SQLConnection.Table<WeightData>().ToListAsync();
            if (SourceData != null)
                foreach (var data in SourceData)
                    Weights.Add(data);
        }
        catch (Exception e)
        {
            MessageBox.Show("加载信息失败。" + e.Message);
        }
    }
    /// <summary>
    /// 添加数据库数据
    /// </summary>
    private void AddData()
    {
        try
        {
            //_modbus.SetHoldingRegister(BitConverter.GetBytes(2.336f), 205);
            float weight = BitConverter.ToSingle(_modbus.ReadHoldingRegister(205, 2)!, 0);
            _sqlite.SQLConnection.InsertAsync(new WeightData(weight.ToString(), DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
            //操作完成后标志位置回
            _modbus.SetHoldingRegister(0, 204);
        }
        catch (Exception)
        {
            _modbus.SetHoldingRegister(0, 204);
        }
    }
    /// <summary>
    /// 数据更新标记读取
    /// </summary>
    private void DataRefreshSwitch()
    {
        byte[] checkBytes = new byte[] { 0x00, 0x00 };
        while (true)
        {
            Thread.Sleep(500);
            byte[] flag = _modbus.ReadHoldingRegister(204)!;
            if (!ByteArrayToolkit.CheckEquals(flag, checkBytes)) AddData();
        }
    }
    /// <summary>
    /// 其他数据刷新
    /// </summary>
    private void DataRefresh()
    {
        while (true)
        {
            Thread.Sleep(500);
            ConnectionStatus = (ushort)DataConverter.TwoBytesToUInt(_modbus.ReadHoldingRegister(1)!);
            DeviceStatus = (ushort)DataConverter.TwoBytesToUInt(_modbus.ReadHoldingRegister(202)!);
            AlarmStatus = (ushort)DataConverter.TwoBytesToUInt(_modbus.ReadHoldingRegister(208)!);
            AlarmCode = (ushort)DataConverter.TwoBytesToUInt(_modbus.ReadHoldingRegister(209)!);
            if (ConnectionStatus == 1) _modbus.SetHoldingRegister(0, 1);
        }
    }
    /// <summary>
    /// 时间格式检测
    /// </summary>
    /// <param name="time">时间</param>
    /// <returns></returns>
    private static string CheckTimeFormat(string? time)
    {
        if (string.IsNullOrEmpty(time)) return DateTime.Now.ToString("HH:mm:ss");
        if (!time.Contains(':')) return DateTime.Now.ToString("HH:mm:ss");
        if (time.Split(':').Length != 3) return DateTime.Now.ToString("HH:mm:ss");
        if (!uint.TryParse(time.Split(':')[0], out uint hour)) return DateTime.Now.ToString("HH:mm:ss");
        if (!uint.TryParse(time.Split(':')[1], out uint minute)) return DateTime.Now.ToString("HH:mm:ss");
        if (!uint.TryParse(time.Split(':')[2], out uint second)) return DateTime.Now.ToString("HH:mm:ss");
        if (hour > 23) return DateTime.Now.ToString("HH:mm:ss");
        if (minute > 60) return DateTime.Now.ToString("HH:mm:ss");
        if (second > 60) return DateTime.Now.ToString("HH:mm:ss");
        return time;
    }
    #endregion
}
