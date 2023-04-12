using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace frontend
{
    public partial class Form1 : Form
    {
        List<CheckBox> lightsCheckBoxes;
        InputInformation inputInformation;
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
            for (int i = 0; i < inputInformation.info.Length && i < lightsCheckBoxes.Count; i++)
            {
                lightsCheckBoxes[i].Checked = Convert.ToBoolean(inputInformation.info[i]);
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
