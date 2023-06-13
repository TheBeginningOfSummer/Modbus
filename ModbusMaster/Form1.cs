using CommunicationsToolkit;
using MyToolkit;

namespace ModbusMaster;

public partial class Form1 : Form
{
    ModbusTCP _master = new();
    ushort _register = 3;

    public Form1()
    {
        InitializeComponent();
        _master.Connection.ReceiveFromServer += MessageHandling;
    }

    private void MessageHandling(byte[] data)
    {
        var message = ModbusTCP.ParseResponse(data, out ushort code);
        switch (code)
        {
            case 3:
                TB_Info.Invoke(new Action(() =>
                {
                    TB_Info.Text = $"[{DateTime.Now}] 读取到的保持寄存器数据{Environment.NewLine}{ShowData(message!, ushort.Parse(TB_StartAddress.Text))}";
                }));
                break;
            case 6:
                TB_Info.Invoke(new Action(() =>
                {
                    TB_Info.Text = $"[{DateTime.Now}] 写入保持寄存器的数据（单个）{Environment.NewLine}{ShowData(message!, ushort.Parse(TB_Address.Text))}";
                }));
                break;
            default:
                TB_Info.Invoke(new Action(() =>
                {
                    TB_Info.Text = $"没有数据";
                }));
                break;
        }
    }

    private static string ShowData(byte[] data, ushort startAddress = 0)
    {
        string message = "";
        for (int i = 0; i < data.Length; i += 2)
        {
            message += $"{startAddress + i / 2:D4}:{DataConverter.BytesToHexString(new byte[2] { data[i], data[i + 1] })}    ";
        }
        return message + Environment.NewLine;
    }

    private void TSB_Connect_Click(object sender, EventArgs e)
    {
        try
        {
            _master.Connection.Connection(TSTB_IP.Text, int.Parse(TSTB_Port.Text), out string error);
            MessageBox.Show("连接成功");
        }
        catch (Exception)
        {
            MessageBox.Show("连接失败");
        }
    }

    private void TSB_Disconnect_Click(object sender, EventArgs e)
    {
        try
        {
            _master.Connection.Disconnection();
        }
        catch (Exception)
        {

        }
    }

    private void CB_Register_SelectedValueChanged(object sender, EventArgs e)
    {
        switch (CB_Register.Text)
        {
            case "保持寄存器":
                _register = 3;
                break;
            case "输入寄存器":
                _register = 4;
                break;
            default:
                break;
        }
    }

    private void BTN_Modify_Click(object sender, EventArgs e)
    {
        try
        {
            if (!ushort.TryParse(TB_Address.Text, out ushort address)) return;
            if (!short.TryParse(TB_Value.Text, out short value)) return;
            if (address < 0) return;
            byte[] command = ModbusTCP.WriteDataMessage(1, address, BitConverter.GetBytes(value));
            _master.Connection.SocketItem.Send(command);
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
            if (!ushort.TryParse(TB_StartAddress.Text, out ushort startAddress)) return;
            if (!ushort.TryParse(TB_AddressLength.Text, out ushort addressLength)) return;
            byte[] command = ModbusTCP.ReadDataMessage(1, (byte)_register, startAddress, addressLength);
            _master.Connection.SocketItem.Send(command);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
}