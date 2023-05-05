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
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Animation;
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

    #endregion

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

    public ObservableCollection<WeightData> Weights { get; } = new ObservableCollection<WeightData>();
    
    [AllowNull]
    SocketTool? _server;
    readonly ModbusTCP _modbus = new();
    readonly SQLiteService _sqlite = new("Weight.db", "Database");

    public MainVM()
    {
        _sqlite.InitializeTableAsync<WeightData>();
        InitializeData();

        Task.Run(DataRefreshSwitch);
        Task.Run(DataRefresh);
    }

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

    private void AddData()
    {
        try
        {
            _modbus.SetHoldingRegister(BitConverter.GetBytes(2.336f), 205);
            float weight = BitConverter.ToSingle(_modbus.ReadHoldingRegister(205, 2)!, 0);
            _sqlite.SQLConnection.InsertAsync(new WeightData(weight.ToString(), DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
            _modbus.SetHoldingRegister(0, 204);
        }
        catch (Exception)
        {

        }
    }
    /// <summary>
    /// 数据更新
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
        ushort alarmCode;
        while (true)
        {
            Thread.Sleep(500);
            ConnectionStatus = (ushort)DataConverter.TwoBytesToUInt(_modbus.ReadHoldingRegister(1)!);
            DeviceStatus = (ushort)DataConverter.TwoBytesToUInt(_modbus.ReadHoldingRegister(202)!);
            AlarmStatus = (ushort)DataConverter.TwoBytesToUInt(_modbus.ReadHoldingRegister(208)!);
            alarmCode = (ushort)DataConverter.TwoBytesToUInt(_modbus.ReadHoldingRegister(209)!);
        }
    }

}
