using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace frontend
{
    public partial class ScriptInput : Form
    {
        public ScriptInput()
        {
            InitializeComponent();

            textBox1.Text = ConfigurationManager.AppSettings.Get("serverCommand");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            RunPython.sciptCommand = textBox1.Text;
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["serverCommand"].Value = textBox1.Text;
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }
    }
}
