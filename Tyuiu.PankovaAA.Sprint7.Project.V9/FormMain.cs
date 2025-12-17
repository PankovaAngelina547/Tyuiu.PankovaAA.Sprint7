using System;
using System.IO;
using System.Windows.Forms;

namespace Tyuiu.PankovaPAA.Sprint7.App
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            string dataFolder = Path.Combine(AppContext.BaseDirectory, "Data");
            if (!Directory.Exists(dataFolder))
                Directory.CreateDirectory(dataFolder);

            labelStatus_PAA.Text = $"Data folder: {dataFolder}";
        }

        private void buttonExit_PAA_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}