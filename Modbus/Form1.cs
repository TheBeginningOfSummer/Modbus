using CommunicationsToolkit;
using MyToolkit;
using System.Diagnostics.CodeAnalysis;
using System.Net;
using static MyToolkit.ConnectionToolkit;


namespace Modbus
{
    public partial class Form1 : Form
    {
        #region 应用类
        [AllowNull]
        SocketTool server;
        readonly ModbusTCP modbus;
        readonly DataManager dataManager;
        readonly KeyValueLoader config;
        readonly AutoResetEvent dataRefreshSwitch = new(false);
        readonly SetForm setForm = new();
        #endregion

        #region 控制变量
        private bool isAddData = false;
        /// <summary>
        /// 数据添加
        /// </summary>
        public bool IsAddData
        {
            get { return isAddData; }
            set { isAddData = value; if (IsAddData) AddData(); }
        }
        #endregion

        public Form1()
        {
            InitializeComponent();
            //初始化Modbus从站
            modbus = new ModbusTCP(1);
            //初始化数据库
            dataManager = new DataManager("test.db");
            //初始化数据库中的数据表
            dataManager.InitializeDatabase("test", "create table test (ID INTEGER primary key autoincrement,重量 REAL,测量时间 TEXT)");
            //配置管理加载
            config = new KeyValueLoader("configuration.json", "Config");
            //连接数据初始化
            setForm.TB_IP.Text = config.Load("IP");
            setForm.TB_Port.Text = config.Load("Port");
            //设置查询时间上下限
            DTP_Min.Value = Convert.ToDateTime(DateTime.Now.AddDays(-7));
            DTP_Max.Value = Convert.ToDateTime(DateTime.Now.AddDays(1));

            Task.Run(DataUpdate);
            Task.Run(DataRefresh);
        }

        private void AddData()
        {
            try
            {
                float weight = BitConverter.ToSingle(ModbusTCP.ReadRegister(modbus.HoldingRegister, 205, 2)!, 0);
                dataManager.AddData("test", new Models.WeightData(weight, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
                ModbusTCP.SetRegister(modbus.HoldingRegister, 0, 204);
                dataRefreshSwitch.Set();
            }
            catch (Exception)
            {

            }
        }
        /// <summary>
        /// 数据更新
        /// </summary>
        private void DataUpdate()
        {
            byte[] checkBytes = new byte[] { 0x00, 0x00 };
            while (true)
            {
                Thread.Sleep(500);
                byte[] flag = ModbusTCP.ReadRegister(modbus.HoldingRegister, 204)!;
                if (ByteArrayToolkit.CheckEquals(flag, checkBytes))
                    IsAddData = false;
                else
                    IsAddData = true;
                if (isAddData) dataRefreshSwitch.WaitOne();
            }
        }
        /// <summary>
        /// 其他数据刷新
        /// </summary>
        private void DataRefresh()
        {
            ushort connectionStatus;
            ushort deviceStatus;
            ushort alarmStatus;
            ushort alarmCode;
            while (true)
            {
                Thread.Sleep(500);
                connectionStatus = (ushort)DataConverter.TwoBytesToUInt(ModbusTCP.ReadRegister(modbus.HoldingRegister, 1)!);
                deviceStatus = (ushort)DataConverter.TwoBytesToUInt(ModbusTCP.ReadRegister(modbus.HoldingRegister, 202)!);
                alarmStatus = (ushort)DataConverter.TwoBytesToUInt(ModbusTCP.ReadRegister(modbus.HoldingRegister, 208)!);
                alarmCode = (ushort)DataConverter.TwoBytesToUInt(ModbusTCP.ReadRegister(modbus.HoldingRegister, 209)!);
                switch (connectionStatus)
                {
                    case 0:
                        SetLabelColor(LB_ConnectionStatus, Color.White);
                        break;
                    case 1:
                        SetLabelColor(LB_ConnectionStatus, Color.Lime);
                        ModbusTCP.SetRegister(modbus.HoldingRegister, 0, 1);
                        break;
                    default:
                        SetLabelColor(LB_AlarmStatus, Color.Silver);
                        break;
                }
                switch (deviceStatus)
                {
                    case 0:
                        SetLabelText(LB_DeviceStatus, "设备未准备好");
                        break;
                    case 1:
                        SetLabelText(LB_DeviceStatus, "设备运行准备OK");
                        break;
                    case 2:
                        SetLabelText(LB_DeviceStatus, "手动模式");
                        break;
                    case 3:
                        SetLabelText(LB_DeviceStatus, "原点复位中");
                        break;
                    case 4:
                        SetLabelText(LB_DeviceStatus, "自动运行中");
                        break;
                    case 8:
                        SetLabelText(LB_DeviceStatus, "异常中");
                        break;
                    case 9:
                        SetLabelText(LB_DeviceStatus, "急停中");
                        break;
                    default:
                        SetLabelText(LB_DeviceStatus, "Default");
                        break;
                }
                switch (alarmStatus)
                {
                    case 1:
                        SetLabelColor(LB_AlarmStatus, Color.Green);
                        break;
                    case 2:
                        SetLabelColor(LB_AlarmStatus, Color.Yellow);
                        break;
                    case 3:
                        SetLabelColor(LB_AlarmStatus, Color.Red);
                        break;
                    default:
                        SetLabelColor(LB_AlarmStatus, Color.Silver);
                        break;
                }
            }
        }

        /// <summary>
        /// 更改标签text
        /// </summary>
        /// <typeparam name="T">值类型</typeparam>
        /// <param name="label">标签</param>
        /// <param name="variable">值</param>
        public static void SetLabelText<T>(Label label, T variable)
        {
            if (variable != null)
                label.Invoke(new Action(() => label.Text = variable.ToString()));
        }
        /// <summary>
        /// 更改标签颜色
        /// </summary>
        /// <param name="indicator">指示器</param>
        /// <param name="color">颜色</param>
        public static void SetLabelColor(Label indicator, Color color)
        {
            indicator.Invoke(new Action(() => indicator.BackColor = color));
        }

        #region 连接
        private void TSB_Listening_Click(object sender, EventArgs e)
        {
            if (!IPAddress.TryParse(setForm.TB_IP.Text, out IPAddress? ipAddress)) return;
            if (!int.TryParse(setForm.TB_Port.Text.Trim(), out int port)) return;
            server = modbus.Connection;
            if (server.StartListening(ipAddress, port))
            {
                //server.ClientListUpdate = UpdateClient;//客户端列表委托更新绑定
                //server.ReceiveFromClient += FromClient;//服务端数据收发委托绑定
                MessageBox.Show("监听成功", "服务端");
            }
        }
        #endregion

        #region 数据库
        private void BTN_Inquire_Click(object sender, EventArgs e)
        {
            DGV_InquireData.DataSource = dataManager.InquireData("test", DTP_Min.Value.ToString("yyyy-MM-dd HH:mm:ss"), DTP_Max.Value.ToString("yyyy-MM-dd HH:mm:ss"));
            //DGV_InquireData.DataSource = dataManager.InquireAllData("test");
            //DGV_InquireData.DataSource = dataManager.InquireTables();
        }
        #endregion

        #region 主界面
        private void BTN_Auto_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("是否切换自动模式？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
                ModbusTCP.SetRegister(modbus.HoldingRegister, 2, 2);
        }

        private void BTN_Manual_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("是否切换手动模式？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
                ModbusTCP.SetRegister(modbus.HoldingRegister, 1, 2);
        }

        private void BTN_Start_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("是否启动？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
                ModbusTCP.SetRegister(modbus.HoldingRegister, 1, 3);
        }

        private void BTN_Stop_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("是否停止？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
                ModbusTCP.SetRegister(modbus.HoldingRegister, 2, 3);
        }
        
        private void TSB_Set_Click(object sender, EventArgs e)
        {
            setForm.ShowDialog();
        }

        private void BTN_Test_Click(object sender, EventArgs e)
        {
            //BTN_Test.Enabled = false;
            //Task.Run(() =>
            //{
            //    ModbusTCP.SetRegister(modbus.HoldingRegister, 1, 202);
            //    Thread.Sleep(2000);
            //    ModbusTCP.SetRegister(modbus.HoldingRegister, 2, 202);
            //    Thread.Sleep(2000);
            //    ModbusTCP.SetRegister(modbus.HoldingRegister, 3, 202);
            //    Thread.Sleep(2000);
            //    ModbusTCP.SetRegister(modbus.HoldingRegister, 4, 202);
            //    Thread.Sleep(2000);
            //    ModbusTCP.SetRegister(modbus.HoldingRegister, 8, 202);
            //    Thread.Sleep(2000);
            //    ModbusTCP.SetRegister(modbus.HoldingRegister, 9, 202);
            //    Thread.Sleep(2000);
            //    ModbusTCP.SetRegister(modbus.HoldingRegister, 1, 208);
            //    Thread.Sleep(2000);
            //    ModbusTCP.SetRegister(modbus.HoldingRegister, 2, 208);
            //    Thread.Sleep(2000);
            //    ModbusTCP.SetRegister(modbus.HoldingRegister, 3, 208);
            //    Thread.Sleep(2000);
            //    Invoke(new Action(() => BTN_Test.Enabled = true));
            //});

            //ModbusTCP.SetRegister(modbus.HoldingRegister, 1, 204);
            ModbusTCP.SetRegister(modbus.HoldingRegister, 1, 1);
        }
        #endregion


    }
}