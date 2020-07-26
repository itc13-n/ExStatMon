using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exchange_Statistics_Monitor
{
    public partial class LoadingScreen : Form
    {
        public LoadingScreen()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            this.TopMost = false;
        }

        private void LoadingScreen_Load(object sender, EventArgs e)
        {
            timer1.Interval = 2000;
            timer1.Start();
        }
    }
}
