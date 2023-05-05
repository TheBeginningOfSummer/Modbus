using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace ModbusWpf.Converters
{
    public class DeviceStatusConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            ushort deviceStatus = (ushort)value;
            return deviceStatus switch
            {
                0 => "设备未准备好",
                1 => "设备运行准备OK",
                2 => "手动模式",
                3 => "原点复位中",
                4 => "自动运行中",
                8 => "异常中",
                9 => "急停中",
                _ => "Default",
            };
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
