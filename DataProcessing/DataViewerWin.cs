using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Concurrent;

namespace AudioProcessor.DataProcessing
{
    public partial class DataViewerWin : Form
    {
        public DataViewer owner;
        private Timer timer;
        private bool CanClose;

        private Int64 lasttime;
        private bool running;

        public DataViewerWin()
        {
            InitializeComponent();

            CanClose = true;

            lasttime = -1;
            running = true;

            timer = new Timer();
            timer.Interval = 100;
            timer.Tick += Timer_Tick;
            timer.Start();

        }

        private Color getDefaultColor(int idx)
        {
            Color[] cols = new Color[]
            {
                Color.Red, Color.Green, Color.Blue, 
                Color.Cyan, Color.Magenta, Color.Yellow, Color.White,
                Color.DarkRed, Color.DarkGreen, Color.DarkBlue, 
                Color.DarkCyan, Color.DarkMagenta, Color.Brown, Color.Gray
            };

            return cols[idx % cols.Length];
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (owner == null) return;
            bool updateNeeded = false;

            int tracelength = (int) ((Int64) owner.config.xrange * (Int64)owner.owner.sampleRate / owner.owner.blockSize / 1000);

            if ((tracelength != dv.traceLength) || (owner.config.xrange/1000.0 != dv.traceTime))
                dv.updateTraceTime(tracelength, owner.config.xrange/1000.0);

            while (!owner.dataBlocks.IsEmpty)
            {
                DataViewer.DataBlock db;
                if (owner.dataBlocks.TryDequeue(out db))
                {
                    // Got one block
                    int n = db.data.Length;
                    if (running && (n > 0))
                    {
                        Int64 dt = 1;
                        if (lasttime >= 0)
                            dt = db.timestamp - lasttime;
                        lasttime = db.timestamp;

                        if (n != owner.config.traces)
                        {
                            // Need to adapt traces
                            if (n < owner.config.traces)
                            {
                                // Remove Items
                                int remove = owner.config.traces - n;
                                owner.config.traceOn.RemoveRange(n, remove);
                                owner.config.traceColor.RemoveRange(n, remove);
                                owner.config.traces = n;
                                if (cbList.SelectedIndex >= n)
                                    cbList.SelectedIndex = n - 1;
                                while (cbList.Items.Count > n)
                                    cbList.Items.RemoveAt(cbList.Items.Count - 1);
                            }
                            else
                            {
                                // Add new items
                                int add = n - owner.config.traces;
                                for (int i = 0; i < add; i++)
                                {
                                    owner.config.traceOn.Add(true);
                                    owner.config.traceColor.Add(getDefaultColor(i + owner.config.traces));
                                    cbList.Items.Add(string.Format("Ch {0}", i + owner.config.traces + 1));
                                    cbList.SetItemChecked(i + owner.config.traces, true);
                                }
                                owner.config.traces = n;
                            }
                            dv.updateTraceNumber(owner.config.traces);
                        }
                        for (int i = 0; i < n; i++)
                            dv.addTraceData(i,(int)dt,db.data[i]);
                        updateNeeded = true;
                    }
                }
            }
            if (updateNeeded)
            {
                for (int i = 0; i < owner.config.traces; i++)
                    dv.updateTraceColor(i, owner.config.traceColor[i], owner.config.traceOn[i]);
                dv.Invalidate();
            }
        }

        private int abs(int a) { return (a < 0) ? -a : a; }

        public void setOwner(DataViewer _owner)
        {
            CanClose = false;

            cbList.Items.Clear();

            cbXRange.Items.Clear();
            int found = 0;
            int diff = abs(_owner.timerangesms[0] - _owner.config.xrange);
            for (int i = 0; i < _owner.timerangesms.Length; i++)
            {
                int ms = _owner.timerangesms[i];
                string setname = "";
                if (ms < 1000)
                    setname = string.Format("{0} ms", ms);
                else
                    setname = string.Format("{0} s", ms / 1000);
                cbXRange.Items.Add(setname);
                int ddiff = abs(_owner.timerangesms[i] - _owner.config.xrange);
                if (ddiff < diff)
                {
                    diff = ddiff;
                    found = i;
                }
            }
            cbXRange.SelectedIndex = found;
            cbYAutoscale.Checked = _owner.config.yautoscale;
            cbYLog.Checked = _owner.config.ylog;
            cbRunning.Checked = running;
            tbYMin.Text = string.Format("{0}", _owner.config.ymin);
            tbYMax.Text = string.Format("{0}", _owner.config.ymax);

            int tracelength = _owner.config.xrange * _owner.owner.sampleRate / _owner.owner.blockSize / 1000;
            if ((tracelength != dv.traceLength) || (_owner.config.xrange / 1000.0 != dv.traceTime))
                dv.updateTraceTime(tracelength, _owner.config.xrange / 1000.0);

            dv.updateTraceNumber(_owner.config.traces);

            dv.updateYRange(_owner.config.ymin, _owner.config.ymax, _owner.config.ylog, _owner.config.yautoscale);

            owner = _owner;
        }

        public void DoClose()
        {
            CanClose = true;
            owner = null;
            Close();
        }

        private void DataViewerWin_Load(object sender, EventArgs e)
        {

        }

        private void DataViewerWin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!CanClose)
            {
                Hide();
                e.Cancel = true;
            }
        }

        private void cbList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (owner == null) return;
            for (int i=0;i<owner.config.traces;i++)
                owner.config.traceOn[i] = cbList.GetItemChecked(i);
            if (cbList.SelectedIndex >= 0)
                ctColor.BackColor = owner.config.traceColor[cbList.SelectedIndex];
        }

        private void bnColor_Click(object sender, EventArgs e)
        {
            if (owner == null) return;
            if (owner.config.traces < 1) return;
            int si = cbList.SelectedIndex;
            if ((si < 0) || (si >= owner.config.traces)) return;
            ColorDialog cd = new ColorDialog();
            cd.Color = owner.config.traceColor[si];
            if (cd.ShowDialog() == DialogResult.OK)
            {
                owner.config.traceColor[si] = cd.Color;
                ctColor.BackColor = cd.Color;
            }
        }

        private void cbXRange_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (owner == null) return;
            int idx = cbXRange.SelectedIndex;
            if ((idx < 0) || (idx >= owner.timerangesms.Length)) return;
            owner.config.xrange = owner.timerangesms[idx];
        }

        private void cbRunning_CheckedChanged(object sender, EventArgs e)
        {
            running = cbRunning.Checked;
        }

        private void tbYMin_TextChanged(object sender, EventArgs e)
        {
            if (owner == null) return;
            double d;
            string s = tbYMin.Text;
            try
            {
                d = Convert.ToDouble(s);
                if (d < -1000000) d = -1000000;
                if (d > 1000000) d = 1000000;
                if (d >= owner.config.ymax) return;
                owner.config.ymin = d;
                dv.updateYRange(owner.config.ymin, owner.config.ymax, owner.config.ylog, owner.config.yautoscale);
            }
            catch (Exception ex)
            {
            }
        }

        private void tbYMax_TextChanged(object sender, EventArgs e)
        {
            if (owner == null) return;
            double d;
            string s = tbYMax.Text;
            try
            {
                d = Convert.ToDouble(s);
                if (d < -1000000) d = -1000000;
                if (d > 1000000) d = 1000000;
                if (d <= owner.config.ymin) return;
                owner.config.ymax = d;
                dv.updateYRange(owner.config.ymin, owner.config.ymax, owner.config.ylog, owner.config.yautoscale);
            }
            catch (Exception ex)
            {
            }
        }

        private void cbYLog_CheckedChanged(object sender, EventArgs e)
        {
            if (owner == null) return;
            owner.config.ylog = cbYLog.Checked;
            dv.updateYRange(owner.config.ymin, owner.config.ymax, owner.config.ylog, owner.config.yautoscale);
        }

        private void cbYAutoscale_CheckedChanged(object sender, EventArgs e)
        {
            if (owner == null) return;
            owner.config.yautoscale = cbYAutoscale.Checked;
            dv.updateYRange(owner.config.ymin, owner.config.ymax, owner.config.ylog, owner.config.yautoscale);
        }
    }
}
