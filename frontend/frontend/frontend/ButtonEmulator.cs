using System;
using System.IO.Ports;
using System.Windows.Forms;
using System.Drawing;

namespace frontend
{
    public partial class ButtonEmulator : Form
    {

        NumberedButton[] numberedButtons;
        public ButtonEmulator()
        {
            ButtonEmulatorConfiguration.serialPort = new SerialPort();

            InitializeComponent();

            InitializeButtons(10);

            SetButtonsState(false);

            UpdatePorts();
        }

        void UpdatePorts()
        {
            string[] ports = GetPorts();
            comComboBox.Items.Clear();
            for (int i = 0; i < ports.Length; i++)
            {
                comComboBox.Items.Add(ports[i]);
            }
        }

        string[] GetPorts()
        {
            string[] ports = SerialPort.GetPortNames();

            foreach (string port in ports)
            {
                Console.WriteLine(port);
            }
            return ports;
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            UpdatePorts();
        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            if(ButtonEmulatorConfiguration.serialPort.IsOpen)
            {
                try
                {
                    ButtonEmulatorConfiguration.serialPort.Close();
                    MessageBox.Show("Устройство отключено");
                    connectButton.Text = "Подключить";
                    SetButtonsState(false);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Возникла ошибка при отключении устройства" + ex.Message);
                }
            }
            else
            {
                if (comComboBox.Text != "")
                {
                    ButtonEmulatorConfiguration.serialPort.PortName = comComboBox.Text;
                    try
                    {
                        ButtonEmulatorConfiguration.serialPort.Open();
                        ButtonEmulatorConfiguration.serialPort.ReadTimeout = 1000;
                        ButtonEmulatorConfiguration.serialPort.Write("Hello");
                        char[] buffer = new char[5];
                        ButtonEmulatorConfiguration.serialPort.Read(buffer, 0, 1);
                        ButtonEmulatorConfiguration.serialPort.Read(buffer, 1, 1);
                        ButtonEmulatorConfiguration.serialPort.Read(buffer, 2, 1);
                        ButtonEmulatorConfiguration.serialPort.Read(buffer, 3, 1);
                        ButtonEmulatorConfiguration.serialPort.Read(buffer, 4, 1);

                        string serialPortResponse = new string(buffer);
                        MessageBox.Show("Устройство подключено");

                        if (serialPortResponse == "ardok")
                        {
                            connectButton.Text = "Отключить";
                            SetButtonsState(true);
                        }
                        else
                        {
                            throw new Exception("Нет ответа от устройства");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Проблемы с подключением.\nВыбран неправильный порт или устройство не подключено.\n" + ex.Message);
                        ButtonEmulatorConfiguration.serialPort.Close();
                    }
                }
            }
        }

        private void switchesCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            ButtonEmulatorConfiguration.is_switches= switchesCheckBox.Checked;
        }

        void SetButtonsState(bool state)
        {
            for (int i = 0; i < numberedButtons.Length; i++)
            {
                numberedButtons[i].button.Enabled = state;
            }
        }

        void InitializeButtons(int count)
        {
            ButtonEmulatorConfiguration.signal_state = new bool[count];
            for (int i = 0; i < ButtonEmulatorConfiguration.signal_state.Length; i++)
            {
                ButtonEmulatorConfiguration.signal_state[i] = false;
            }

            numberedButtons = new NumberedButton[count];
            for (int i = 0; i < numberedButtons.Length; i++)
            {
                numberedButtons[i] = new NumberedButton(i);
                numberedButtons[i].button.Location = new Point(Size.Width / 2 - 50, 50 * i);
                numberedButtons[i].button.Size = new Size(80, 20);
                numberedButtons[i].button.Text = "Кнопка " + (i + 1).ToString();
                splitContainer.Panel2.Controls.Add(numberedButtons[i].button);
            }
        }
    }
}
