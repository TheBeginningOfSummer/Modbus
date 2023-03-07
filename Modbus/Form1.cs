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
        #endregion

        private bool isAddData = false;
        /// <summary>
        /// 数据添加
        /// </summary>
        public bool IsAddData
        {
            get { return isAddData; }
            set { isAddData = value; if (IsAddData) AddData(); }
        }

        public Form1()
        {
            InitializeComponent();
            //初始化Modbus从站
            modbus = new ModbusTCP(1);
            //初始化数据库
            dataManager = new DataManager("test.db");
            //初始化数据库中的数据表
            dataManager.InitializeDatabase("test", "create table test (ID INTEGER primary key autoincrement,重量 REAL,测量时间 TEXT)");
            //配置管理
            config = new KeyValueLoader("configuration.json", "Config");
            //连接数据初始化
            TSTB_IP.Text = config.Load("IP");
            TSTB_Port.Text = config.Load("Port");
            //设置查询时间上下限
            DTP_Min.Value = Convert.ToDateTime(DateTime.Now.AddDays(-7));
            DTP_Max.Value = Convert.ToDateTime(DateTime.Now.AddDays(1));
        }

        private void AddData()
        {
            MessageBox.Show(IsAddData.ToString());
        }

        #region 连接
        private void TSB_Listening_Click(object sender, EventArgs e)
        {
            if (!IPAddress.TryParse(TSTB_IP.Text, out IPAddress? ipAddress)) return;
            if (!int.TryParse(TSTB_Port.Text.Trim(), out int port)) return;
            server = modbus.Connection;
            if (server.StartListening(ipAddress, port))
            {
                //server.ClientListUpdate = UpdateClient;//客户端列表委托更新绑定
                //server.ReceiveFromClient += FromClient;//服务端数据收发委托绑定
                TSB_Listening.Enabled = false;
                TSB_Stop.Enabled = true;
                MessageBox.Show("监听成功", "服务端");
            }
        }

        private void TSB_Stop_Click(object sender, EventArgs e)
        {
            if (server.StopListening())
            {
                TSB_Listening.Enabled = true;
                TSB_Stop.Enabled = false;
                MessageBox.Show("停止监听成功", "服务端");
            }
        }

        private void TSB_Save_Click(object sender, EventArgs e)
        {
            try
            {
                config.Change("IP", TSTB_IP.Text);
                config.Change("Port", TSTB_Port.Text);
                MessageBox.Show("保存成功", "提示");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示");
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

        private void BTN_Test_Click(object sender, EventArgs e)
        {
            //dataManager.AddData("test", new Models.WeightData(2.33, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
        }
        #endregion

        #region 主界面
        private void BTN_Auto_Click(object sender, EventArgs e)
        {
            IsAddData = true;
        }

        private void BTN_Manual_Click(object sender, EventArgs e)
        {
            IsAddData = false;
        }
        #endregion


    }
}