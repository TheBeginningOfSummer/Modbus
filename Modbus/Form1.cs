using CommunicationsToolkit;
using MyToolkit;
using System.Diagnostics.CodeAnalysis;
using System.Net;
using static MyToolkit.ConnectionToolkit;


namespace Modbus
{
    public partial class Form1 : Form
    {
        #region Ӧ����
        [AllowNull]
        SocketTool server;
        readonly ModbusTCP modbus;
        readonly DataManager dataManager;
        readonly KeyValueLoader config;
        #endregion

        private bool isAddData = false;
        /// <summary>
        /// �������
        /// </summary>
        public bool IsAddData
        {
            get { return isAddData; }
            set { isAddData = value; if (IsAddData) AddData(); }
        }

        public Form1()
        {
            InitializeComponent();
            //��ʼ��Modbus��վ
            modbus = new ModbusTCP(1);
            //��ʼ�����ݿ�
            dataManager = new DataManager("test.db");
            //��ʼ�����ݿ��е����ݱ�
            dataManager.InitializeDatabase("test", "create table test (ID INTEGER primary key autoincrement,���� REAL,����ʱ�� TEXT)");
            //���ù���
            config = new KeyValueLoader("configuration.json", "Config");
            //�������ݳ�ʼ��
            TSTB_IP.Text = config.Load("IP");
            TSTB_Port.Text = config.Load("Port");
            //���ò�ѯʱ��������
            DTP_Min.Value = Convert.ToDateTime(DateTime.Now.AddDays(-7));
            DTP_Max.Value = Convert.ToDateTime(DateTime.Now.AddDays(1));
        }

        private void AddData()
        {
            MessageBox.Show(IsAddData.ToString());
        }

        #region ����
        private void TSB_Listening_Click(object sender, EventArgs e)
        {
            if (!IPAddress.TryParse(TSTB_IP.Text, out IPAddress? ipAddress)) return;
            if (!int.TryParse(TSTB_Port.Text.Trim(), out int port)) return;
            server = modbus.Connection;
            if (server.StartListening(ipAddress, port))
            {
                //server.ClientListUpdate = UpdateClient;//�ͻ����б�ί�и��°�
                //server.ReceiveFromClient += FromClient;//����������շ�ί�а�
                TSB_Listening.Enabled = false;
                TSB_Stop.Enabled = true;
                MessageBox.Show("�����ɹ�", "�����");
            }
        }

        private void TSB_Stop_Click(object sender, EventArgs e)
        {
            if (server.StopListening())
            {
                TSB_Listening.Enabled = true;
                TSB_Stop.Enabled = false;
                MessageBox.Show("ֹͣ�����ɹ�", "�����");
            }
        }

        private void TSB_Save_Click(object sender, EventArgs e)
        {
            try
            {
                config.Change("IP", TSTB_IP.Text);
                config.Change("Port", TSTB_Port.Text);
                MessageBox.Show("����ɹ�", "��ʾ");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "��ʾ");
            }
        }
        #endregion

        #region ���ݿ�
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

        #region ������
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