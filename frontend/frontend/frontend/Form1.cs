using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace frontend
{
    public partial class Form1 : Form
    {
        List<CheckBox> lightsCheckBoxes;
        InputInformation inputInformation;
        ButtonEmulator buttonEmulator;
        ScriptInput scriptInput;


        public ButtonEmulator ButtonEmulator 
        {
            get { return buttonEmulator; }
        }

        public Form1()
        {
            lightsCheckBoxes = new List<CheckBox>();
            inputInformation = new InputInformation();
            InitializeComponent();
            for (int i = 0; i < 10; i++)
            {
                var checkbox = new CheckBox();
                checkbox.Location = new Point(i * 23, 0);
                checkbox.Text = (i+1).ToString();
                checkbox.Size = new Size(23, 20);
                lightsCheckBoxes.Add(checkbox);
                lightsPanel.Controls.Add(checkbox);
            }
            lightsPanel.Dispose();
            pictureBox1.Image = new Bitmap("design/DE10Lite копия.jpg");

            buttonEmulator = new ButtonEmulator();
            scriptInput = new ScriptInput();

            RunPython.sciptCommand = ConfigurationManager.AppSettings.Get("serverCommand");
        }

        private async Task get_infoAsync()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync($"http://127.0.0.1:{portTextBox.Text}/");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            Console.WriteLine(responseBody);
            inputInformation = JsonConvert.DeserializeObject<InputInformation>(responseBody);
            UpdateLights();
            Refresh();
            await Task.Delay(100);
            get_infoAsync();
        }

        private void portTextBox_TextChanged(object sender, EventArgs e)
        {
            get_infoAsync();
        }
        void UpdateLights()
        {
            pictureBox1.Image = new Bitmap("design/DE10Lite копия.jpg");
            Graphics g = Graphics.FromImage(pictureBox1.Image);
            for (int i = 0; i < inputInformation.info.Length && i < lightsCheckBoxes.Count; i++)
            {
                lightsCheckBoxes[i].Checked = Convert.ToBoolean(inputInformation.info[i]);
                Brush brush = Brushes.Black;
                switch (inputInformation.info[i])
                {
                    case 0:
                        brush = Brushes.White;
                        break;

                    case 1:
                        brush = Brushes.Red;
                        break;
                }
                g.FillRectangle(brush, new Rectangle(465+42*i, 610, 35, 20));
            }
            pictureBox1.Invalidate();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using(SaveFileDialog dialog = new SaveFileDialog())
            {
                dialog.Filter = "Image files (*.JPG|*.jpg";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    pictureBox1.Image.Save(dialog.FileName, ImageFormat.Jpeg);
                }
            }
        }
        private void buttonEmulatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (buttonEmulator.IsDisposed)
            {
                buttonEmulator = new ButtonEmulator();
            }
            buttonEmulator.Show();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RunPython.Start(new string[1]);
        }

        private void scriptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (scriptInput.IsDisposed)
            {
                scriptInput = new ScriptInput();
            }
            scriptInput.Show();
        }
    }

    public static class RunPython
    {
        static Process process;
        public static string sciptCommand;

        public static void Start(string[] args)
        {
            if (sciptCommand.Length > 0)
            {
                ProcessStartInfo processStartInfo = new ProcessStartInfo
                {
                    FileName = "powershell.exe",
                    Arguments = sciptCommand,//@"cd Y:\Git\lights-detector\backend\ ; .\backend\venv\Scripts\Activate.ps1 ; .\main.py",//sciptCommand,
                    UseShellExecute = false,
                    RedirectStandardOutput = true
                };
                process = new Process() { StartInfo = processStartInfo };
                process.Start();
            }
        }
    }
}
