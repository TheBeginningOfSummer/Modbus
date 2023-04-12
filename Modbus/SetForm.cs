using MyToolkit;

namespace Modbus
{
    public partial class SetForm : Form
    {
        public readonly KeyValueLoader Config;

        public SetForm()
        {
            InitializeComponent();
            Config = new KeyValueLoader("configuration.json", "Config");
            //连接数据初始化
            TB_IP.Text = Config.Load("IP");
            TB_Port.Text = Config.Load("Port");
            TB_DatabaseName.Text = Config.Load("DatabaseName");
            TB_TableName.Text = Config.Load("TableName");
        }

        private void BTN_Save1_Click(object sender, EventArgs e)
        {
            try
            {
                Config.Change("IP", TB_IP.Text);
                Config.Change("Port", TB_Port.Text);
                MessageBox.Show("保存成功", "保存设置");
            }
            catch (Exception)
            {

            }
        }

        private void BTN_Save2_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("是否修改？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    Config.Change("DatabaseName", TB_DatabaseName.Text);
                    Config.Change("TableName", TB_TableName.Text);
                    MessageBox.Show("保存成功，重启后生效。", "保存设置");
                }
            }
            catch (Exception)
            {

            }
        }
    }
}
