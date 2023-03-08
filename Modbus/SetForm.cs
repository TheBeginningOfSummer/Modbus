using MyToolkit;

namespace Modbus
{
    public partial class SetForm : Form
    {
        readonly KeyValueLoader config;

        public SetForm()
        {
            InitializeComponent();
            config = new KeyValueLoader("configuration.json", "Config");
        }

        private void BTN_Save1_Click(object sender, EventArgs e)
        {
            try
            {
                config.Change("IP", TB_IP.Text);
                config.Change("Port", TB_Port.Text);
                MessageBox.Show("保存成功", "保存设置");
            }
            catch (Exception)
            {

            }
        }
    }
}
