using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace frontend
{
    public partial class Form1 : Form
    {
        List<CheckBox> lightsCheckBoxes;
        InputInformation inputInformation;
        ButtonEmulator buttonEmulator;

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
            pictureBox1.Image = new Bitmap("Y:\\Git\\lights-detector\\frontend\\frontend\\frontend\\design\\DE10Lite копия.jpg");
            Draw();
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
            pictureBox1.Image = new Bitmap("Y:\\Git\\lights-detector\\frontend\\frontend\\frontend\\design\\DE10Lite копия.jpg");
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

        void Draw()
        {
            //Graphics g = Graphics.FromImage(pictureBox1.Image);
            //g.FillRectangle(Brushes.Green, new Rectangle(10, 10, 20, 20));
            //pictureBox1.Invalidate();
        }

        private void buttonEmulatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            buttonEmulator = new ButtonEmulator();
            buttonEmulator.Show();
        }
    }
}
