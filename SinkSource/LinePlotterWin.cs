using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AudioProcessor.SinkSource
{
    public partial class LinePlotterWin : Form
    {

        public Boolean CanClose;
        public LinePlotter linePlotter;
        public int channels;
        public Timer timer;
        public int selectedChannel;

        public int integrationCounter;

        public FIFO[] inputs;
        public Line[] line;

        Boolean run;

        private double _integrationTime;
        public double integrationTime
        {
            set
            {
                if (value != _integrationTime)
                {
                    _integrationTime = value;
                    integrationCounter = (int)Math.Floor(_integrationTime * linePlotter.owner.sampleRate+0.5);
                    for (int i=0;i<channels;i++)
                        line[i].intMax = integrationCounter;
                }
            }
            get
            {
                return _integrationTime;
            }
        }
 
        public class Line
        {

            private LinePlotterWin root;

            public int len;
            public double[] data;
            public Color color;
            private Pen drawPen;

            public int useScreen;

            public double valMin;
            public double valMax;
            private int valMinPos;
            private int valMaxPos;

            // Config
            double _offset;
            public double offset
            {
                set { if (_offset != value) { _offset = value; root.LpScreen.Invalidate(); }  }
                get { return _offset; }
            }
            double _scale;
            public double scale
            {
                set { if (_scale != value) { _scale = value; root.LpScreen.Invalidate(); }  }
                get { return _scale; }
            }
            Boolean _on;
            public Boolean on
            {
                set { if (_on != value) { _on = value; root.Invalidate(); } }
                get { return _on; }
            }
            Boolean _acIn;
            public Boolean acIn
            {
                set { if (_acIn != value) { _acIn = value; _averager.removeDC = value; root.Invalidate(); } }
                get { return _acIn; }
            }

            private double acOutOfs;
            Boolean _acOut;
            public Boolean acOut
            {
                set { if (_acOut != value) { _acOut = value; root.Invalidate(); } }
                get { return _acOut; }
            }

            private PointF[] linecache;

            private double[] inbuf;

            public Boolean newdata;

            public List<string> averagers;
            public string averager
            {
                set
                {
                    if (_averager != null)
                        _averager.select(value);
                }
                get
                {
                    if (_averager != null)
                        return _averager.averagerName;
                    return null;
                }
            }
            private Averager _averager;

            private int _intMax;
            public int intMax
            {
                set
                {
                    if (_intMax != value)
                    {
                        _intMax = value;
                        _averager.len = _intMax;
                        reset();
                    }
                }
                get { return _intMax;  }
            }

            public Line(LinePlotterWin _root, int _len, int __intMax, Color _col)
            {
                root = _root;
                data = new double[_len];
                len = _len;
                inbuf = new double[32];
                color = _col;
                drawPen = new Pen(color);
                _scale = 1.0;
                _offset = 0.0;
                _on = true;
                _acIn = false;
                _acOut = false;
                acOutOfs = 0;
                _intMax = __intMax;
                useScreen = 0;
                valMax = 0.0;
                valMaxPos = 0;
                valMin = 0.0;
                valMinPos = 0;

                _averager = new Averager(root.linePlotter.owner.sampleRate, __intMax, averagerCallback);
                averagers = Averager.getList();
                newdata = false;
            }

            public void averagerCallback(double v, int idx)
            {
                if (!root.run) return;

                valMaxPos++;
                valMinPos++;
                acOutOfs -= data[len - 1];
                acOutOfs += v;
                Array.Copy(data, 0, data, 1, len - 1);
                data[0] = v;
                if (v > valMax)
                {
                    valMax = v;
                    valMaxPos = 0;
                }
                if (v < valMin)
                {
                    valMin = v;
                    valMinPos = 0;
                }
                if ((valMaxPos >= len) || (valMinPos >= len))
                { // ReRange needed
                    if ((valMaxPos >= len) && (valMinPos >= len))
                    { // Both needed
                        valMaxPos =valMinPos = 0;
                        valMax = valMin = data[0];
                        for (int i=1;i<len;i++)
                        {
                            if (data[i] > valMax) { valMax = data[i]; valMaxPos = i; }
                            if (data[i] < valMin) { valMin = data[i]; valMinPos = i; }
                        }
                    } else if (valMaxPos >= len)
                    {
                        valMaxPos = 0;
                        valMax = data[0];
                        for (int i = 1; i < len; i++)
                            if (data[i] > valMax) { valMax = data[i]; valMaxPos = i; }
                    } else
                    {
                        valMinPos = 0;
                        valMin = data[0];
                        for (int i = 1; i < len; i++)
                            if (data[i] < valMin) { valMin = data[i]; valMinPos = i; }
                    }
                }
                newdata = true;
            }

            public void reset()
            {
                Array.Clear(data, 0, len);
                acOutOfs = 0;
                if (_averager != null)
                    _averager.reset();
                newdata = true;
            }

            public void addFromFIFO(FIFO f)
            {
                int n = f.fill();
                while (n >= 32)
                {
                    f.retrieve(ref inbuf, 32);
                    if (_averager != null)
                        _averager.process(inbuf, 32);
                    n -= 32;
                }
            }

            public void draw(Graphics g, GridCalculator X, GridCalculator Y)
            {
                if (!_on) return;
                if ((linecache == null) || (linecache.Length != len))
                {
                    // Reallocate
                    linecache = new PointF[len];
                }
                double tstep = (double) intMax / root.linePlotter.owner.sampleRate;
                for (int i=0;i<len;i++)
                {
                    linecache[i].X = (float)X.getInterpolatedPos(-(double)i * tstep);
                    double y = data[i];
                    if (_acOut)
                        y -= acOutOfs / len;
                    y = Y.getInterpolatedPos(y * _scale + _offset);
                    linecache[i].Y = (float)y;
                }
                g.DrawLines(drawPen, linecache);
            }

        }


        public LinePlotterWin()
        {
            InitializeComponent();
            channels = 0;
            linePlotter = null;
            FormClosing += LinePlotterWin_FormClosing;
            CanClose = false;
            timer = new Timer();
            timer.Interval = 100; // ms
            timer.Tick += Timer_Tick;
            run = true;

            selectedChannel = -1;

            timer.Enabled = true;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (channels == 0) return;
            Boolean redrawNeeded = false;
            for (int i=0;i<channels;i++)
            {
                line[i].addFromFIFO(inputs[i]);
                if (line[i].newdata)
                    redrawNeeded = true;
                line[i].newdata = false;
            }
            if (redrawNeeded)
                LpScreen.Invalidate();
        }

        private void LinePlotterWin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!CanClose)
            {
                Hide();
                e.Cancel = true;
            }
        }

        string[] VertScales = new string[] {
                "0.001","0.002","0.005",
                "0.01","0.02","0.05",
                "0.1","0.2","0.5",
                "1","2","5",
                "10","20","50",
                "100","200","500",
                "1000","2000","5000",
                "10000","20000","50000",
                "100000"
            };
        double[] VertScalesD;


        public void initLinePlotterWin(LinePlotter _linePlotter, int _channels)
        {
            linePlotter = _linePlotter;
            inputs = new FIFO[_channels];
            line = new Line[_channels];

            integrationCounter = (int)Math.Floor(0.1 * linePlotter.owner.sampleRate + 0.5);

            for (int i = 0; i < _channels; i++)
            {
                Color col = Color.Red;
                inputs[i] = new FIFO(linePlotter.owner.sampleRate / 4);
                switch (i % 4)
                {
                    case 0: col = Color.Red; break;
                    case 1: col = Color.Green; break;
                    case 2: col = Color.Cyan; break;
                    case 3: col = Color.Magenta; break;
                }
                line[i] = new Line(this,1024,integrationCounter,col);
                line[i].averager = line[i].averagers[0];
            }

            lpDisplays.Items.Add("1");
            lpDisplays.Items.Add("2");
            lpDisplays.Items.Add("3");
            lpDisplays.Items.Add("4");

            lpSelectDisplay.Items.Add("1");
            lpSelectDisplay.Items.Add("2");
            lpSelectDisplay.Items.Add("3");
            lpSelectDisplay.Items.Add("4");

            List<String> ls = line[0].averagers;
            for (int i = 0; i < ls.Count; i++)
                LpVertMode.Items.Add(ls[i]);
            LpVertMode.SelectedIndex = 0;
            LpVertMode.SelectedIndexChanged += LpVertMode_SelectedIndexChanged;

            LpHorzScale.Items.Add("1ms");
            LpHorzScale.Items.Add("2ms");
            LpHorzScale.Items.Add("5ms");
            LpHorzScale.Items.Add("10ms");
            LpHorzScale.Items.Add("20ms");
            LpHorzScale.Items.Add("50ms");
            LpHorzScale.Items.Add("100ms");
            LpHorzScale.Items.Add("200ms");
            LpHorzScale.Items.Add("500ms");
            LpHorzScale.Items.Add("1000ms");
            LpHorzScale.SelectedIndex = 6;
            _integrationTime = 0.1;
            LpHorzScale.SelectedIndexChanged += LpHorzScale_SelectedIndexChanged;
            LpHorzScaleP.Click += LpHorzScaleP_Click;
            LpHorzScaleM.Click += LpHorzScaleM_Click;

            LpChannelSelectA.Checked = true;
            LpChannelSelectA.CheckedChanged += LpChannelSelect_CheckedChanged;
            LpChannelSelectB.CheckedChanged += LpChannelSelect_CheckedChanged;
            LpChannelSelectC.CheckedChanged += LpChannelSelect_CheckedChanged;
            LpChannelSelectD.CheckedChanged += LpChannelSelect_CheckedChanged;

            LpChannelOnA.Checked = line[0].on;
            LpChannelOnB.Checked = line[1].on;
            LpChannelOnC.Checked = line[2].on;
            LpChannelOnD.Checked = line[3].on;

            lpRun.Checked = run;

            LpChannelOnA.CheckedChanged += LpChannelOnA_CheckedChanged;
            LpChannelOnB.CheckedChanged += LpChannelOnB_CheckedChanged;
            LpChannelOnC.CheckedChanged += LpChannelOnC_CheckedChanged;
            LpChannelOnD.CheckedChanged += LpChannelOnD_CheckedChanged;

            LpVertAC.CheckedChanged += LpVertAC_CheckedChanged;

            VertScalesD = new double[VertScales.Length];
            for (int i=0;i<VertScales.Length;i++)
            {
                LpVertScale.Items.Add(VertScales[i]);
                VertScalesD[i] = Convert.ToDouble(VertScales[i]);
            }
            LpVertScale.SelectedIndexChanged += LpVertScale_SelectedIndexChanged;

            LpVertScaleM.Click += LpVertScaleM_Click;
            LpVertScaleP.Click += LpVertScaleP_Click;

            LpVertOfs.ValueChanged += LpVertOfs_ValueChanged;
            LpVertOfs0.Click += LpVertOfs0_Click;
            LpVertOfsP.Click += LpVertOfsP_Click;
            LpVertOfsPP.Click += LpVertOfsPP_Click;
            LpVertOfsM.Click += LpVertOfsM_Click;
            LpVertOfsMM.Click += LpVertOfsMM_Click;

            LpOffsetDCremove.CheckedChanged += LpOffsetDCremove_CheckedChanged;

            lpAutoScale.Click += LpAutoScale_Click;

            selectedChannel = 0;
            updateChannelInfo();

            channels = _channels;
         
            LpScreen.initLinePlotterScreen(this, channels, line);

            lpDisplays.SelectedIndex = LpScreen.useGrids-1;

            lpScaleYMin.Value = Convert.ToDecimal(LpScreen.gridY[0].min);
            lpScaleYMax.Value = Convert.ToDecimal(LpScreen.gridY[0].max);

            lpDisplays.SelectedIndexChanged += LpDisplays_SelectedIndexChanged;

            lpSelectDisplay.SelectedIndexChanged += LpSelectDisplay_SelectedIndexChanged;

            lpScaleYMin.ValueChanged += LpScaleYMin_ValueChanged;
            lpScaleYMax.ValueChanged += LpScaleYMax_ValueChanged;
            lpAutoScaleY.CheckedChanged += LpAutoScaleY_CheckedChanged;

        }

        private void LpAutoScaleY_CheckedChanged(object sender, EventArgs e)
        {
            LpScreen.autoScale[selectedChannel] = lpAutoScaleY.Checked;
            LpScreen.Invalidate();
        }

        private void LpScaleYMax_ValueChanged(object sender, EventArgs e)
        {
            double vmin = Convert.ToDouble(lpScaleYMin.Value);
            double vmax = Convert.ToDouble(lpScaleYMax.Value);
            LpScreen.gridY[selectedChannel].newRange(vmin, vmax);
            LpScreen.Invalidate();
        }

        private void LpScaleYMin_ValueChanged(object sender, EventArgs e)
        {
            double vmin = Convert.ToDouble(lpScaleYMin.Value);
            double vmax = Convert.ToDouble(lpScaleYMax.Value);
            LpScreen.gridY[selectedChannel].newRange(vmin, vmax);
            LpScreen.Invalidate();
        }

        private void LpSelectDisplay_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (channels <= 0) return;
            line[selectedChannel].useScreen = lpSelectDisplay.SelectedIndex;
            LpScreen.Invalidate();
        }

        private void LpDisplays_SelectedIndexChanged(object sender, EventArgs e)
        {
            LpScreen.useGrids = lpDisplays.SelectedIndex + 1;
            LpScreen.arrangeGrids();
            LpScreen.Invalidate();
        }

        private void LpVertAC_CheckedChanged(object sender, EventArgs e)
        {
            if (channels <= 0) return;
            line[selectedChannel].acIn = LpVertAC.Checked;
        }

        private void LpChannelOnA_CheckedChanged(object sender, EventArgs e)
        {
            line[0].on = LpChannelOnA.Checked;
        }

        private void LpChannelOnB_CheckedChanged(object sender, EventArgs e)
        {
            line[1].on = LpChannelOnB.Checked;
        }

        private void LpChannelOnC_CheckedChanged(object sender, EventArgs e)
        {
            line[2].on = LpChannelOnC.Checked;
        }

        private void LpChannelOnD_CheckedChanged(object sender, EventArgs e)
        {
            line[3].on = LpChannelOnD.Checked;
        }

        private void LpAutoScale_Click(object sender, EventArgs e)
        {
            double tmax = line[0].len * integrationTime;
            LpScreen.gridX.newRange(-tmax, 0);
            LpScreen.Invalidate();
        }

        private void LpHorzScaleM_Click(object sender, EventArgs e)
        {
            if (LpHorzScale.SelectedIndex > 0)
                LpHorzScale.SelectedIndex--;
        }

        private void LpHorzScaleP_Click(object sender, EventArgs e)
        {
            if (LpHorzScale.SelectedIndex < LpHorzScale.Items.Count - 1)
                LpHorzScale.SelectedIndex++;
        }

        private void LpOffsetDCremove_CheckedChanged(object sender, EventArgs e)
        {
            line[selectedChannel].acOut = LpOffsetDCremove.Checked;
        }

        private void LpVertOfsMM_Click(object sender, EventArgs e)
        {
            if (LpVertOfs.Value > -100000 + 10)
                LpVertOfs.Value -= 10;
            else
                LpVertOfs.Value = -100000;
        }

        private void LpVertOfsM_Click(object sender, EventArgs e)
        {
            if (LpVertOfs.Value > -100000 + 1)
                LpVertOfs.Value -= 1;
            else
                LpVertOfs.Value = -100000;
        }

        private void LpVertOfsPP_Click(object sender, EventArgs e)
        {
            if (LpVertOfs.Value < 100000 - 10)
                LpVertOfs.Value += 10;
            else
                LpVertOfs.Value = 100000;
        }

        private void LpVertOfsP_Click(object sender, EventArgs e)
        {
            if (LpVertOfs.Value < 100000 - 1)
                LpVertOfs.Value += 1;
            else
                LpVertOfs.Value = 100000;
        }

        private void LpVertOfs0_Click(object sender, EventArgs e)
        {
            LpVertOfs.Value = 0;
        }

        private void LpVertOfs_ValueChanged(object sender, EventArgs e)
        {
            line[selectedChannel].offset = Convert.ToDouble(LpVertOfs.Value)/10.0;
            LpVertOfsVal.Text = String.Format("{0:F1}", line[selectedChannel].offset);
        }

        private void LpVertScaleP_Click(object sender, EventArgs e)
        {
            if (LpVertScale.SelectedIndex < VertScalesD.Length - 1)
                LpVertScale.SelectedIndex++;
        }

        private void LpVertScaleM_Click(object sender, EventArgs e)
        {
            if (LpVertScale.SelectedIndex >0)
                LpVertScale.SelectedIndex--;
        }

        private void LpVertScale_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (channels <= 0) return;
            line[selectedChannel].scale = VertScalesD[LpVertScale.SelectedIndex];
        }

        private void updateChannelInfo()
        {
            string chname = string.Format("Channel {0}", selectedChannel + 1);
            switch (selectedChannel)
            {
                case 0: chname = "Channel A"; break;
                case 1: chname = "Channel B"; break;
                case 2: chname = "Channel C"; break;
                case 3: chname = "Channel D"; break;
            }
            LpVertChannelLabel.Text = chname;
            LpVertMode.SelectedItem = line[selectedChannel].averager;
            LpVertAC.Checked = line[selectedChannel].acIn;
            LpOffsetDCremove.Checked = line[selectedChannel].acOut;
            int scl = -1;
            for (int i = 0; i < VertScales.Length; i++)
                if (Math.Abs(line[selectedChannel].scale / VertScalesD[i] - 1.0) < 0.01)
                    scl = i;
            if (scl >= 0)
                LpVertScale.SelectedIndex = scl;
            LpVertOfs.Value = (int) Math.Floor(line[selectedChannel].offset*10.0+0.5);
            LpVertOfsVal.Text = String.Format("{0:F1}", line[selectedChannel].offset);

            lpSelectDisplay.SelectedIndex = line[selectedChannel].useScreen;

            if (channels <= 0)
            {
                lpScaleYMin.Value = -5;
                lpScaleYMax.Value = 5;
            } else
            {
                lpScaleYMin.Value = Convert.ToDecimal(LpScreen.gridY[line[selectedChannel].useScreen].min);
                lpScaleYMax.Value = Convert.ToDecimal(LpScreen.gridY[line[selectedChannel].useScreen].max);
            }

        }

        private void LpChannelSelect_CheckedChanged(object sender, EventArgs e)
        {
            if (channels <= 0) return;
            if (LpChannelSelectA.Checked) selectedChannel = 0;
            if (LpChannelSelectB.Checked) selectedChannel = 1;
            if (LpChannelSelectC.Checked) selectedChannel = 2;
            if (LpChannelSelectD.Checked) selectedChannel = 3;
            updateChannelInfo();
        }

        private void LpHorzScale_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (channels <= 0) return;
            switch (LpHorzScale.SelectedIndex)
            {
                case 0: integrationTime = 0.001; break;
                case 1: integrationTime = 0.002; break;
                case 2: integrationTime = 0.005; break;
                case 3: integrationTime = 0.010; break;
                case 4: integrationTime = 0.020; break;
                case 5: integrationTime = 0.050; break;
                case 6: integrationTime = 0.100; break;
                case 7: integrationTime = 0.200; break;
                case 8: integrationTime = 0.500; break;
                case 9: integrationTime = 1.000; break;
            }
        }

        private void LpVertMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (channels <= 0) return;
            if (selectedChannel < 0) return;
            line[selectedChannel].averager = (String)LpVertMode.Items[LpVertMode.SelectedIndex];
        }
    }
}
