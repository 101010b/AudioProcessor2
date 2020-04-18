using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AudioProcessor
{
    public partial class AboutWin : Form
    {
        public AboutWin()
        {
            InitializeComponent();
            AboutVersion.Text = "V 0.2.0";

            AboutClose.Click += AboutClose_Click;
        }

        private void AboutClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
