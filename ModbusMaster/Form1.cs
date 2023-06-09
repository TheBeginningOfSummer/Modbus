using static MyToolkit.ConnectionToolkit;

namespace ModbusMaster;

public partial class Form1 : Form
{
    public SocketTool Client = new();

    public Form1()
    {
        InitializeComponent();
    }

    private void BTN_Connection_Click(object sender, EventArgs e)
    {
        try
        {
            Client.Connection("127.0.0.1", 9600, out string error);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void BTN_Send_Click(object sender, EventArgs e)
    {
        try
        {

        }
        catch (Exception)
        {

        }
    }
}