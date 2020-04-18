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
    public partial class LogWin : Form
    {
        public LogWin()
        {
            InitializeComponent();
            FormClosing += LogWin_FormClosing;
        }

        private void LogWin_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            e.Cancel = true;
        }

    }
}
