using System;
using System.Windows.Forms;

namespace frontend
{
    internal class NumberedButton
    {
        public int id;
        public Button button;
        public NumberedButton(int id)
        {
            this.id = id;
            button = new Button();
            button.MouseDown += MouseDown;
            button.MouseUp += MouseUp;
            button.Click += Click;
        }
        public NumberedButton(int id, Button button)
        {
            this.id = id;
            this.button = button;
        }

        void MouseDown(object sender, MouseEventArgs e)
        {
            if (!ButtonEmulatorConfiguration.is_switches)
            {
                ButtonEmulatorConfiguration.serialPort.Write((id+1).ToString() + "H");
                button.BackColor = ButtonEmulatorConfiguration.active_backcolor;
                ButtonEmulatorConfiguration.signal_state[id+1] = true;
            }
        }

        void MouseUp(object sender, MouseEventArgs e)
        {
            if (!ButtonEmulatorConfiguration.is_switches)
            {
                ButtonEmulatorConfiguration.serialPort.Write((id+1).ToString() + "L");
                button.BackColor = ButtonEmulatorConfiguration.default_backcolor;
                ButtonEmulatorConfiguration.signal_state[id+1] = false;
            }
        }

        void Click(object sender, EventArgs e)
        {
            if (ButtonEmulatorConfiguration.is_switches)
            {
                if (!ButtonEmulatorConfiguration.signal_state[id + 1])
                {
                    ButtonEmulatorConfiguration.serialPort.Write((id + 1).ToString() + "H");
                    button.BackColor = ButtonEmulatorConfiguration.active_backcolor;
                    ButtonEmulatorConfiguration.signal_state[id + 1] = true;
                }
                else
                {
                    ButtonEmulatorConfiguration.serialPort.Write((id + 1).ToString() + "L");
                    button.BackColor = ButtonEmulatorConfiguration.default_backcolor;
                    button.UseVisualStyleBackColor = true;
                    ButtonEmulatorConfiguration.signal_state[id + 1] = false;
                }
            }
        }
    }
}
