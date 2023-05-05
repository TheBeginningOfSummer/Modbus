using System;
using System.Linq;
using System.Net.Sockets;
using MyToolkit;
using static MyToolkit.ConnectionToolkit;
using static MyToolkit.DataConverter;

namespace CommunicationsToolkit
{
    public class ModbusTCP
    {
        /// <summary>
        /// 站号
        /// </summary>
        public byte StationID { get; private set; }
        /// <summary>
        /// 数据连接
        /// </summary>
        public SocketTool Connection { get; set; }

        /// <summary>
        /// 保持寄存器区
        /// </summary>
        public byte[] HoldingRegister;
        /// <summary>
        /// 输入寄存器区
        /// </summary>
        public byte[] InputRegister;

        public ModbusTCP(byte stationID, int holdingRegister, int inputRegister)
        {
            StationID = stationID;
            Connection = new SocketTool();
            HoldingRegister = new byte[holdingRegister];
            InputRegister = new byte[inputRegister];
        }

        public ModbusTCP(byte stationID = 1)
        {
            StationID = stationID;
            Connection = new SocketTool();
            HoldingRegister = new byte[20000];
            InputRegister = new byte[20000];
            Connection.ReceiveFromClient += MessageHandling;
        }

        #region 保持寄存器操作
        /// <summary>
        /// 读取寄存器
        /// </summary>
        /// <param name="register">指定寄存器</param>
        /// <param name="address">地址</param>
        /// <param name="amount">地址数</param>
        /// <returns></returns>
        public byte[]? ReadHoldingRegister(ushort address, ushort amount = 1)
        {
            if (address < 0 || address >= 10000) return null;
            if (10000 - address < amount) return null;
            return HoldingRegister.Skip(address * 2).Take(amount * 2).ToArray();
        }
        /// <summary>
        /// 设置寄存器值
        /// </summary>
        /// <param name="register">指定寄存器</param>
        /// <param name="inputData">数据</param>
        /// <param name="address">地址</param>
        public void SetHoldingRegister(byte[] inputData, ushort address)
        {
            if (inputData.Length < 2) return;
            inputData.CopyTo(HoldingRegister, address * 2);
        }
        /// <summary>
        /// 设置寄存器值
        /// </summary>
        /// <param name="register">指定寄存器</param>
        /// <param name="inputData">数据</param>
        /// <param name="address">地址</param>
        public void SetHoldingRegister(ushort inputData, ushort address)
        {
            byte[] data = BitConverter.GetBytes(inputData);
            Array.Reverse(data);
            data.CopyTo(HoldingRegister, address * 2);
        }
        #endregion

        #region 输入寄存器操作
        /// <summary>
        /// 读取寄存器
        /// </summary>
        /// <param name="register">指定寄存器</param>
        /// <param name="address">地址</param>
        /// <param name="amount">地址数</param>
        /// <returns></returns>
        public byte[]? ReadInputRegister(ushort address, ushort amount = 1)
        {
            return ReadRegister(InputRegister, address, amount);
        }
        /// <summary>
        /// 设置寄存器值
        /// </summary>
        /// <param name="register">指定寄存器</param>
        /// <param name="inputData">数据</param>
        /// <param name="address">地址</param>
        public void SetInputRegister(byte[] inputData, ushort address)
        {
            SetRegister(InputRegister, inputData, address);
        }
        /// <summary>
        /// 设置寄存器值
        /// </summary>
        /// <param name="register">指定寄存器</param>
        /// <param name="inputData">数据</param>
        /// <param name="address">地址</param>
        public void SetInputRegister(ushort inputData, ushort address)
        {
            SetRegister(InputRegister, inputData, address);
        }
        #endregion

        /// <summary>
        /// 读取寄存器
        /// </summary>
        /// <param name="register">指定寄存器</param>
        /// <param name="address">地址</param>
        /// <param name="amount">地址数</param>
        /// <returns></returns>
        public static byte[]? ReadRegister(byte[] register, ushort address, ushort amount = 1)
        {
            if (address < 0 || address >= 10000) return null;
            if (10000 - address < amount) return null;
            return register.Skip(address * 2).Take(amount * 2).ToArray();
        }
        /// <summary>
        /// 设置寄存器值
        /// </summary>
        /// <param name="register">指定寄存器</param>
        /// <param name="inputData">数据</param>
        /// <param name="address">地址</param>
        public static void SetRegister(byte[] register, byte[] inputData, ushort address)
        {
            if (inputData.Length < 2) return;
            inputData.CopyTo(register, address * 2);
        }
        /// <summary>
        /// 设置寄存器值
        /// </summary>
        /// <param name="register">指定寄存器</param>
        /// <param name="inputData">数据</param>
        /// <param name="address">地址</param>
        public static void SetRegister(byte[] register, ushort inputData, ushort address)
        {
            byte[] data = BitConverter.GetBytes(inputData);
            Array.Reverse(data);
            data.CopyTo(register, address * 2);
        }

        /// <summary>
        /// 读取的报文
        /// </summary>
        /// <param name="stationID">站号</param>
        /// <param name="address">地址</param>
        /// <param name="amount">读取地址数</param>
        /// <param name="isLittleEndian"></param>
        /// <returns></returns>
        public static byte[] ReadDataMessage(byte stationID, byte code, ushort address, ushort amount, bool isLittleEndian = false)
        {
            byte[] requestMessage = new byte[12];
            requestMessage[5] = 0x06;
            requestMessage[6] = stationID;
            requestMessage[7] = code;
            if (isLittleEndian)
            {
                BitConverter.GetBytes(address).CopyTo(requestMessage, 8);
                BitConverter.GetBytes(amount).CopyTo(requestMessage, 10);
                return requestMessage;
            }
            else
            {
                byte[] addressBytes = BitConverter.GetBytes(address);
                byte[] amountBytes = BitConverter.GetBytes(amount);
                Array.Reverse(addressBytes);
                Array.Reverse(amountBytes);
                addressBytes.CopyTo(requestMessage, 8);
                amountBytes.CopyTo(requestMessage, 10);
                return requestMessage;
            }
        }
        /// <summary>
        /// 写入的报文
        /// </summary>
        /// <param name="stationID">站号</param>
        /// <param name="address">写入的地址</param>
        /// <param name="amount">写入的地址数</param>
        /// <param name="data">写入的数据</param>
        /// <param name="isLittleEndian"></param>
        /// <returns></returns>
        public static byte[] WriteDataMessage(byte stationID, byte code, ushort address, ushort amount, byte[] data, bool isLittleEndian = false)
        {
            byte[] responseMessage = new byte[13];
            ushort dataLength = (ushort)(7 + data.Length);
            BitConverter.GetBytes(dataLength).CopyTo(responseMessage, 4);
            responseMessage[6] = stationID;
            responseMessage[7] = code;
            if (isLittleEndian)
            {
                BitConverter.GetBytes(address).CopyTo(responseMessage, 8);
                BitConverter.GetBytes(amount).CopyTo(responseMessage, 10);
            }
            else
            {
                byte[] addressBytes = BitConverter.GetBytes(address);
                byte[] amountBytes = BitConverter.GetBytes(amount);
                Array.Reverse(addressBytes);
                Array.Reverse(amountBytes);
                addressBytes.CopyTo(responseMessage, 8);
                amountBytes.CopyTo(responseMessage, 10);
            }
            responseMessage[12] = (byte)data.Length;
            return ByteArrayToolkit.SpliceBytes(responseMessage, data);
        }

        /// <summary>
        /// 解析请求报文头
        /// </summary>
        /// <param name="data">报文</param>
        /// <param name="address">地址</param>
        /// <param name="amount">地址数量</param>
        /// <returns>功能码以及之前的报文</returns>
        public static byte[] ParseRequestHeader(byte[] data, out ushort address, out ushort amount)
        {
            byte[] mbap = data.Take(8).ToArray();
            address = (ushort)TwoBytesToUInt(data.Skip(8).Take(2).ToArray());
            amount = (ushort)TwoBytesToUInt(data.Skip(10).Take(2).ToArray());
            return mbap;
        }
        /// <summary>
        /// 读取寄存器的返回报文
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="register">寄存器</param>
        /// <returns>响应报文</returns>
        public static byte[]? ReadResponse(byte[] data, byte[] register)
        {
            byte[] mbap = ParseRequestHeader(data, out ushort address, out ushort amount);
            //截取地址所示的数据范围
            byte[]? returnData = ReadRegister(register, address, amount);
            if (returnData == null) return default;
            byte[] responseData = new byte[returnData.Length + 1];
            responseData[0] = (byte)returnData.Length;//因为只有一个字节所以可以直接转换
            returnData.CopyTo(responseData, 1);
            //计算数据长度
            ushort dataLength = (ushort)(amount * 2 + 3);
            byte[] dataLengthBytes = BitConverter.GetBytes(dataLength);
            Array.Reverse(dataLengthBytes);
            dataLengthBytes.CopyTo(mbap, 4);
            //返回读取响应
            return ByteArrayToolkit.SpliceBytes(mbap, responseData);
        }
        /// <summary>
        /// 写多个寄存器的返回报文
        /// </summary>
        /// <param name="data">报文</param>
        /// <returns>写多个寄存器的返回报文</returns>
        public static byte[] WriteResponse(byte[] data, byte[] register, bool isMultiple)
        {
            _ = ParseRequestHeader(data, out ushort address, out _);
            if (isMultiple)
            {
                byte[] writeMultipleData = data.Skip(13).ToArray();
                writeMultipleData.CopyTo(register, address * 2);

                byte[] response = data.Take(12).ToArray();
                response[4] = 0;
                response[5] = 6;
                return response;
            }
            else
            {
                byte[] writeData = data.Skip(10).ToArray();
                writeData.CopyTo(register, address * 2);
                return data;
            }
        }
        /// <summary>
        /// 解析报文并返回响应报文
        /// </summary>
        /// <param name="data">要解析的报文</param>
        /// <returns>响应报文</returns>
        public byte[]? ParseMessage(byte[] data)
        {
            if (data.Length < 12) return null;
            switch (data[7])
            {
                case 3://读保持寄存器
                    return ReadResponse(data, HoldingRegister);
                case 4://读输入寄存器
                    return ReadResponse(data, InputRegister);
                case 6://写单个保持寄存器
                    return WriteResponse(data, HoldingRegister, false);
                case 16://写多个保持寄存器
                    return WriteResponse(data, HoldingRegister, true);
                default:
                    return default;
            }
        }
        /// <summary>
        /// 数据接收函数
        /// </summary>
        /// <param name="client">客户端</param>
        /// <param name="data">数据</param>
        public void MessageHandling(Socket client, byte[] data)
        {
            byte[]? response = ParseMessage(data);
            if (response != null)
                client.Send(response);
        }

    }
}
