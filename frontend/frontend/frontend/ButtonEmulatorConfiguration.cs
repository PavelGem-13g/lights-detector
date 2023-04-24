using System.Drawing;
using System.IO.Ports;

namespace frontend
{
    public static class ButtonEmulatorConfiguration
    {
        public static SerialPort serialPort;
        public static bool is_switches;
        public static bool[] signal_state;
        public static Color default_backcolor = SystemColors.Control;
        public static Color active_backcolor = Color.Red;
    }
}
