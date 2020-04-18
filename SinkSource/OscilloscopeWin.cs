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
    public partial class OscilloscopeWin : Form
    {
        public Boolean CanClose;
        public Oscilloscope oscilloscope; // Pointer to the corresponding Element
        public int channels;
        public int FIFOdepth;
        public FIFO[] inputs;
        public OsciFIFO[] osciFIFO;
        public Boolean[] inputsActive;
        public Boolean xydisplay;
        public Boolean drawGrid;

        public enum TrigSlope
        {
            Rising,
            Falling
        }
        private TrigSlope trigSlope;
        private string getTrigSlopeName(TrigSlope t)
        {
            switch (t)
            {
                case TrigSlope.Rising: return "_/¯"; 
                case TrigSlope.Falling: return "¯\\_";
            }
            return "???";
        }

        public enum YScale
        {
            Div10,
            Div5,
            Div2,
            Div1,
            Div500m,
            Div200m,
            Div100m,
            Div50m,
            Div20m,
            Div10m,
            Div5m,
            Div2m,
            Div1m,
            Div500u,
            Div200u,
            Div100u
        }
        private YScale[] yScale;
        private double getYScale(int i)
        {
            if (channels < 1) return 0.1;
            switch (yScale[i])
            {
                case YScale.Div10: return 100;
                case YScale.Div5: return 50;
                case YScale.Div2: return 20;
                case YScale.Div1: return 10;
                case YScale.Div500m: return 5;
                case YScale.Div200m: return 2;
                case YScale.Div100m: return 1;
                case YScale.Div50m: return 0.5;
                case YScale.Div20m: return 0.2;
                case YScale.Div10m: return 0.1;
                case YScale.Div5m: return 0.05;
                case YScale.Div2m: return 0.02;
                case YScale.Div1m: return 0.01;
                case YScale.Div500u: return 0.005;
                case YScale.Div200u: return 0.002;
                case YScale.Div100u: return 0.001;
            }
            return 1;
        }

        public enum TimeScale
        {
            Div100us,
            Div200us,
            Div500us,
            Div1ms,
            Div2ms,
            Div5ms,
            Div10ms
        }
        private TimeScale _timeScale;
        public TimeScale timeScale {
            set {
                _timeScale = value;
                if (channels == 0) return;
                switch (value)
                {
                    case TimeScale.Div100us: xLen = (int)Math.Floor(oscilloscope.owner.sampleRate * 10.0 * 100e-6 + 0.5); break;
                    case TimeScale.Div200us: xLen = (int)Math.Floor(oscilloscope.owner.sampleRate * 10.0 * 200e-6 + 0.5); break;
                    case TimeScale.Div500us: xLen = (int)Math.Floor(oscilloscope.owner.sampleRate * 10.0 * 500e-6 + 0.5); break;
                    case TimeScale.Div1ms: xLen = (int)Math.Floor(oscilloscope.owner.sampleRate * 10.0 * 1e-3 + 0.5); break;
                    case TimeScale.Div2ms: xLen = (int)Math.Floor(oscilloscope.owner.sampleRate * 10.0 * 2e-3 + 0.5); break;
                    case TimeScale.Div5ms: xLen = (int)Math.Floor(oscilloscope.owner.sampleRate * 10.0 * 5e-3 + 0.5); break;
                    case TimeScale.Div10ms: xLen = (int)Math.Floor(oscilloscope.owner.sampleRate * 10.0 * 10e-3 + 0.5); break;
                }
            }
            get { return _timeScale; }
        }
        private int xLen;

        public double xOffset;

        public enum TriggerMode
        {
            Auto,
            Normal,
            Single,
            Off
        }
        private  TriggerMode _triggerMode;
        public TriggerMode triggerMode {
            set
            {
                _triggerMode = value;
                if (channels == 0) return;
                for (int i=0;i<channels;i++)
                {
                    switch (value)
                    {
                        case TriggerMode.Off: osciFIFO[i].searchTrigger = false; break;
                        case TriggerMode.Single: osciFIFO[i].noTriggerTime = 0; osciFIFO[i].searchTrigger = (i == selectedChannel); break;
                        case TriggerMode.Normal: osciFIFO[i].noTriggerTime = 0; osciFIFO[i].searchTrigger = (i == selectedChannel); break;
                        case TriggerMode.Auto: osciFIFO[i].noTriggerTime = 4 * xLen; osciFIFO[i].searchTrigger = (i == selectedChannel); break;
                    }
                }

            } 
            get { return _triggerMode;  }
        }
        private double _triggerLevel;
        public double triggerLevel
        {
            set
            {
                if (channels == 0) return;
                _triggerLevel = value;
                if (selectedChannel < 0) return;
                osciFIFO[selectedChannel].triggerLevel = value;
                osciFIFO[selectedChannel].triggerHyst = 0.01 * getYScale(selectedChannel);
                /*
                for (int i = 0; i < channels; i++)
                {
                    osciFIFO[i].triggerLevel = value;
                    osciFIFO[i].triggerHyst = 0.01 * getYScale(i);
                }
                */
            }
            get { return _triggerLevel; }
        }

        private Boolean _trigModeAC;
        public Boolean trigModeAC
        {
            set
            {
                _trigModeAC = value;
                for (int i = 0; i < channels; i++) osciFIFO[i].trigAC = value;
            }
            get { return _trigModeAC;  }
        }

        private Boolean _trigRising;
        public Boolean trigRising
        {
            set
            {
                _trigRising = value;
                for (int i = 0; i < channels; i++) osciFIFO[i].triggerRising = value;
            }
            get { return _trigRising; }
        }
        private int _triggerFromChannel;
        public int triggerFromChannel
        {
            set
            {
                if (channels == 0) return;
                if (value == triggerFromChannel) return;
                osciFIFO[_triggerFromChannel].searchTrigger = false;
                osciFIFO[value].searchTrigger = true;
                osciFIFO[value].reTrigger();
                _triggerFromChannel = value;
            } 
            get { return _triggerFromChannel; }
        }

        public enum DecayMode
        {
            off,
            Decay1,
            Decay2,
            Decay3,
            Decay4,
            Decay5,
            Decay6,
            Decay7
        }
        private DecayMode _decay;
        public DecayMode decay
        {
            set
            {
                _decay = value;
                switch (_decay)
                {
                    case DecayMode.off: oscilloscopeScreen.decay = 0; OsciDecayText.Text = "off"; break;
                    case DecayMode.Decay1: oscilloscopeScreen.decay = 128; OsciDecayText.Text = "1"; break;
                    case DecayMode.Decay2: oscilloscopeScreen.decay = 64; OsciDecayText.Text = "2"; break;
                    case DecayMode.Decay3: oscilloscopeScreen.decay = 32; OsciDecayText.Text = "3"; break;
                    case DecayMode.Decay4: oscilloscopeScreen.decay = 16; OsciDecayText.Text = "4"; break;
                    case DecayMode.Decay5: oscilloscopeScreen.decay = 8; OsciDecayText.Text = "5"; break;
                    case DecayMode.Decay6: oscilloscopeScreen.decay = 4; OsciDecayText.Text = "6"; break;
                    case DecayMode.Decay7: oscilloscopeScreen.decay = 2; OsciDecayText.Text = "max"; break;
                }
            }
            get
            {
                return _decay;
            }
        } 


        public class OscilloscopeLine
        {
            public OscilloscopeScreen root;
            public double yScale;
            public double yOffset;
            private Color _color;
            public Color color {
                set {
                    _color = value;
                    penLine = new Pen(_color);
                    brushLine = new SolidBrush(_color);
                }
                get { return _color; }
            }
            public Boolean show;
            public Boolean isRange;
            public double[] dataMax;
            public double[] dataMin;
            public PointF[] points;

            protected Pen penLine;
            protected Brush brushLine;

            public OscilloscopeLine(OscilloscopeScreen _root)
            {
                yScale = 1;
                yOffset = 0;
                color = Color.Red;
                show = true;
                root = _root;
            }

            public void Draw(Graphics g, int w, int h)
            {
                if ((dataMax == null) || (dataMax.Length < 2))
                    return;
                if (!show) return;
                if (isRange)
                {
                    // Draw Area
                    if ((points == null) || (points.Length != 2 * dataMax.Length + 1))
                        points = new PointF[dataMax.Length * 2+1]; // reAlloc
                    for (int i = 0; i < dataMax.Length; i++)
                    {
                        points[i].X = points[2 * dataMax.Length - 1 - i].X =
                            (float)i * (w - 1) / (dataMax.Length - 1);
                        points[i].Y =
                            (float)(h / 2.0 - h * (dataMax[i] / yScale + yOffset));
                        points[2*dataMax.Length-1-i].Y = 
                            (float)(h / 2.0 - h * (dataMin[i] / yScale + yOffset));
                    }
                    points[2 * dataMax.Length] = points[0];
                    g.DrawLines(penLine, points);
                    // g.FillPolygon(brushLine, points);
                }
                else
                {
                    // Draw Line
                    if ((points == null) || (points.Length != dataMax.Length))
                        points = new PointF[dataMax.Length]; // reAlloc
                    for (int i = 0; i < dataMax.Length; i++)
                    {
                        points[i].X = (float)i * (w-1) / (dataMax.Length-1);
                        points[i].Y = (float)(h / 2.0 - h * ( dataMax[i] / yScale + yOffset));
                    }
                    g.DrawLines(penLine, points);
                }

            }

            public void DrawXY(Graphics g, int w, int h, OscilloscopeLine ly)
            {
                if ((dataMax == null) || (dataMax.Length < 2))
                    return;
                if (ly == null) return;
                if (!show || !ly.show) return;
                if ((ly.dataMax == null) || (ly.dataMax.Length < 2))
                    return;
                if (ly.dataMax.Length != dataMax.Length)
                    return;
                if ((points == null) || (points.Length != dataMax.Length))
                    points = new PointF[dataMax.Length]; // reAlloc
                for (int i=0;i<dataMax.Length;i++)
                {
                    points[i].X = (float)(w / 2.0 + w * (dataMax[i] / yScale + yOffset));
                    points[i].Y = (float)(h / 2.0 - h * (ly.dataMax[i] / ly.yScale + ly.yOffset));
                }
                g.DrawLines(penLine, points);

            }

            public void fetchFrom(OsciFIFO src, int from, int len)
            {
                ///int displen = 640;
                int displen = len;
                if ((dataMax == null) || (dataMax.Length != displen))
                {
                    dataMax = new double[displen];
                    dataMin = new double[displen];
                }
                isRange = src.retrieve(ref dataMax, ref dataMin, displen, from, len);
            }
        }

        OscilloscopeLine[] lines;

        private Timer timer;
        int selectedChannel;


        public OscilloscopeWin()
        {
            InitializeComponent();
            channels = 0;
            oscilloscope = null;
            FormClosing += OscilloscopeWin_FormClosing;
            CanClose = false;
            timer = new Timer();

            selectedChannel = -1;


            OsciChannelSelectA.Checked = true;
            OsciChannelSelectA.CheckedChanged += OsciChannelSelect_CheckedChanged;
            OsciChannelSelectB.CheckedChanged += OsciChannelSelect_CheckedChanged;
            OsciChannelSelectC.CheckedChanged += OsciChannelSelect_CheckedChanged;
            OsciChannelSelectD.CheckedChanged += OsciChannelSelect_CheckedChanged;

            OsciChannelTriggerA.Checked = true;
            OsciChannelTriggerA.CheckedChanged += OsciChannelTrigger_CheckedChanged;
            OsciChannelTriggerB.CheckedChanged += OsciChannelTrigger_CheckedChanged;
            OsciChannelTriggerC.CheckedChanged += OsciChannelTrigger_CheckedChanged;
            OsciChannelTriggerD.CheckedChanged += OsciChannelTrigger_CheckedChanged;

            OsciTriggerStop.Checked = true;
            OsciTriggerStop.CheckedChanged += OsciTriggerMode_CheckedChanged;
            OsciTriggerSingle.CheckedChanged += OsciTriggerMode_CheckedChanged;
            OsciTriggerNormal.CheckedChanged += OsciTriggerMode_CheckedChanged;
            OsciTriggerAuto.CheckedChanged += OsciTriggerMode_CheckedChanged;

            foreach (TimeScale tsv in Enum.GetValues(typeof(TimeScale)) )
                OsciHorzScale.Items.Add(getTimeScaleString(tsv));

            OsciHorzScale.SelectedIndexChanged += OsciHorzScale_SelectedIndexChanged;
            OsciHorzScale.SelectedIndex = (int)timeScale;

            OsciHorzScaleP.Click += OsciHorzScaleP_Click;
            OsciHorzScaleM.Click += OsciHorzScaleM_Click;

            foreach (YScale ysv in Enum.GetValues(typeof(YScale)))
                OsciVertScale.Items.Add(getYScaleString(ysv));

            OsciVertScale.SelectedIndexChanged += OsciVertScale_SelectedIndexChanged;

            OsciVertScaleP.Click += OsciVertScaleP_Click;
            OsciVertScaleM.Click += OsciVertScaleM_Click;

            OsciVertAC.CheckedChanged += OsciVertAC_CheckedChanged;
            OsciVertTrigAC.CheckedChanged += OsciVertTrigAC_CheckedChanged;

            OsciVertOfs.ValueChanged += OsciVertOfs_ValueChanged;
            OsciVertOfs0.Click += OsciVertOfs0_Click;
            OsciVertOfsP.Click += OsciVertOfsP_Click;
            OsciVertOfsM.Click += OsciVertOfsM_Click;
            OsciVertOfsPP.Click += OsciVertOfsPP_Click;
            OsciVertOfsMM.Click += OsciVertOfsMM_Click;

            OsciVertTrig.ValueChanged += OsciVertTrig_ValueChanged;
            OsciVertTrig0.Click += OsciVertTrig0_Click;
            OsciVertTrigP.Click += OsciVertTrigP_Click;
            OsciVertTrigM.Click += OsciVertTrigM_Click;
            OsciVertTrigPP.Click += OsciVertTrigPP_Click;
            OsciVertTrigMM.Click += OsciVertTrigMM_Click;

            OsciChannelOnA.CheckedChanged += OsciChannelOnA_CheckedChanged;
            OsciChannelOnB.CheckedChanged += OsciChannelOnB_CheckedChanged;
            OsciChannelOnC.CheckedChanged += OsciChannelOnC_CheckedChanged;
            OsciChannelOnD.CheckedChanged += OsciChannelOnD_CheckedChanged;

            XYDisplay.CheckedChanged += XYDisplay_CheckedChanged;
            EnGrid.CheckedChanged += EnGrid_CheckedChanged;

            OsciDecay.ValueChanged += OsciDecay_ValueChanged;

            OsciVertTrigSlope.Items.Add(getTrigSlopeName((TrigSlope)0));
            OsciVertTrigSlope.Items.Add(getTrigSlopeName((TrigSlope)1));
            OsciVertTrigSlope.SelectedIndex = (int) trigSlope;
            OsciVertTrigSlope.SelectedIndexChanged += OsciVertTrigSlope_SelectedIndexChanged;
        }

        private void OsciVertTrigSlope_SelectedIndexChanged(object sender, EventArgs e)
        {
            trigSlope = (TrigSlope)OsciVertTrigSlope.SelectedIndex;
            if (selectedChannel != -1)
                osciFIFO[selectedChannel].triggerRising = (trigSlope == TrigSlope.Rising);
        }

        private void EnGrid_CheckedChanged(object sender, EventArgs e)
        {
            drawGrid = EnGrid.Checked;
        }

        private void XYDisplay_CheckedChanged(object sender, EventArgs e)
        {
            xydisplay = XYDisplay.Checked;
        }

        private void OsciDecay_ValueChanged(object sender, EventArgs e)
        {
            switch (OsciDecay.Value) {
                case 0: decay = DecayMode.off; break;
                case 1: decay = DecayMode.Decay1; break;
                case 2: decay = DecayMode.Decay2; break;
                case 3: decay = DecayMode.Decay3; break;
                case 4: decay = DecayMode.Decay4; break;
                case 5: decay = DecayMode.Decay5; break;
                case 6: decay = DecayMode.Decay6; break;
                case 7: decay = DecayMode.Decay7; break;
            }
        }

        private void OsciChannelOnA_CheckedChanged(object sender, EventArgs e)
        {
            lines[0].show = OsciChannelOnA.Checked;
        }

        private void OsciChannelOnB_CheckedChanged(object sender, EventArgs e)
        {
            lines[1].show = OsciChannelOnB.Checked;
        }

        private void OsciChannelOnC_CheckedChanged(object sender, EventArgs e)
        {
            lines[2].show = OsciChannelOnC.Checked;
        }

        private void OsciChannelOnD_CheckedChanged(object sender, EventArgs e)
        {
            lines[3].show = OsciChannelOnD.Checked;
        }

        private void OsciVertTrigMM_Click(object sender, EventArgs e)
        {
            newOsciVertTrig(osciFIFO[selectedChannel].triggerLevel - 0.1 * lines[selectedChannel].yScale, true);
        }

        private void OsciVertTrigPP_Click(object sender, EventArgs e)
        {
            newOsciVertTrig(osciFIFO[selectedChannel].triggerLevel + 0.1 * lines[selectedChannel].yScale, true);
        }

        private void OsciVertTrigM_Click(object sender, EventArgs e)
        {
            newOsciVertTrig(osciFIFO[selectedChannel].triggerLevel - 0.01 * lines[selectedChannel].yScale, true);
        }

        private void OsciVertTrigP_Click(object sender, EventArgs e)
        {
            newOsciVertTrig(osciFIFO[selectedChannel].triggerLevel + 0.01 * lines[selectedChannel].yScale, true);
        }

        private void OsciVertTrig0_Click(object sender, EventArgs e)
        {
            newOsciVertTrig(0, true);
        }

        private void newOsciVertTrig(double value, Boolean updateSlider)
        {
            if (channels <= 0) return;
            osciFIFO[selectedChannel].triggerLevel = value;
            osciFIFO[selectedChannel].triggerHyst = lines[selectedChannel].yScale / 100;
            if (updateSlider)
                OsciVertTrig.Value = (int)Math.Floor(value * 10000 + 0.5);
            OsciVertTrigVal.Text = String.Format("{0:f4}", value);
        }

        private void newOsciVertOfs(double value, Boolean updateSlider)
        {
            if (channels <= 0) return;
            lines[selectedChannel].yOffset = value;
            if (updateSlider)
                OsciVertOfs.Value = (int)Math.Floor(value * 10000 + 0.5);
            OsciVertOfsVal.Text = String.Format("{0:f4}", value);
        }
        
        private void OsciVertOfsMM_Click(object sender, EventArgs e)
        {
            newOsciVertOfs(lines[selectedChannel].yOffset - 0.1, true);
        }

        private void OsciVertOfsPP_Click(object sender, EventArgs e)
        {
            newOsciVertOfs(lines[selectedChannel].yOffset + 0.1, true);
        }

        private void OsciVertOfsM_Click(object sender, EventArgs e)
        {
            newOsciVertOfs(lines[selectedChannel].yOffset - 0.01, true);
        }

        private void OsciVertOfsP_Click(object sender, EventArgs e)
        {
            newOsciVertOfs(lines[selectedChannel].yOffset + 0.01,true);
        }

        private void OsciVertOfs0_Click(object sender, EventArgs e)
        {
            newOsciVertOfs(0, true);
        }

        private void OsciVertTrigAC_CheckedChanged(object sender, EventArgs e)
        {
            if (channels <= 0) return;
            osciFIFO[selectedChannel].trigAC = OsciVertTrigAC.Checked;
        }

        private void OsciVertAC_CheckedChanged(object sender, EventArgs e)
        {
            if (channels <= 0) return;
            osciFIFO[selectedChannel].ACmode = OsciVertAC.Checked;
        }

        private void OsciVertTrig_ValueChanged(object sender, EventArgs e)
        {
            newOsciVertTrig(Decimal.ToDouble(OsciVertTrig.Value) / 10000.0, false);
        }

        private void OsciVertOfs_ValueChanged(object sender, EventArgs e)
        {
            newOsciVertOfs(Decimal.ToDouble(OsciVertOfs.Value) / 10000.0, false);
        }
        
        private void OsciVertScaleM_Click(object sender, EventArgs e)
        {
            int ival = OsciVertScale.SelectedIndex;
            if (ival > 0)
                OsciVertScale.SelectedIndex--;
        }

        private void OsciVertScaleP_Click(object sender, EventArgs e)
        {
            int ival = OsciVertScale.SelectedIndex;
            if (ival < OsciVertScale.Items.Count - 1)
                OsciVertScale.SelectedIndex++;
        }

        private void OsciVertScale_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (channels < 1) return;
            YScale ts = (YScale) OsciVertScale.SelectedIndex;
            if (ts != yScale[selectedChannel])
            {
                yScale[selectedChannel] = ts;
                lines[selectedChannel].yScale = getYScale(selectedChannel);
                UpdateChannelScales();
                oscilloscopeScreen.Invalidate();
            }
        }

        private void OsciHorzScaleM_Click(object sender, EventArgs e)
        {
            int ival = OsciHorzScale.SelectedIndex;
            if (ival > 0)
                OsciHorzScale.SelectedIndex--;
        }

        private void OsciHorzScaleP_Click(object sender, EventArgs e)
        {
            int ival = OsciHorzScale.SelectedIndex;
            if (ival < OsciHorzScale.Items.Count - 1)
                OsciHorzScale.SelectedIndex++;
        }
        
        private void OsciHorzScale_SelectedIndexChanged(object sender, EventArgs e)
        {
            timeScale = (TimeScale)OsciHorzScale.SelectedIndex;
        }

        private void OsciTriggerMode_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton s = (RadioButton)sender;
            if ((s == OsciTriggerStop) && s.Checked) triggerMode = TriggerMode.Off;
            if ((s == OsciTriggerSingle) && s.Checked) triggerMode = TriggerMode.Single;
            if ((s == OsciTriggerNormal) && s.Checked) triggerMode = TriggerMode.Normal;
            if ((s == OsciTriggerAuto) && s.Checked) triggerMode = TriggerMode.Auto;
        }

        private string getTimeScaleString(TimeScale t)
        {
            switch (t)
            {
                case TimeScale.Div100us: return "100µs/Div";
                case TimeScale.Div200us: return "200µs/Div";
                case TimeScale.Div500us: return "500µs/Div";
                case TimeScale.Div1ms: return "1ms/Div";
                case TimeScale.Div2ms: return "2ms/Div";
                case TimeScale.Div5ms: return "5ms/Div";
                case TimeScale.Div10ms: return "10ms/Div";
            }
            return "undefined";
        }

        private string getYScaleString(YScale ys)
        {
            switch (ys)
            {
                case YScale.Div10: return "10/Div";
                case YScale.Div5: return "5/Div";
                case YScale.Div2: return "2/Div";
                case YScale.Div1: return "1/Div";
                case YScale.Div500m: return "0.5/Div";
                case YScale.Div200m: return "0.2/Div";
                case YScale.Div100m: return "0.1/Div";
                case YScale.Div50m: return "50m/Div";
                case YScale.Div20m: return "20m/Div";
                case YScale.Div10m: return "10m/Div";
                case YScale.Div5m: return "5m/Div";
                case YScale.Div2m: return "2m/Div";
                case YScale.Div1m: return "1m/Div";
                case YScale.Div500u: return "0.5m/Div";
                case YScale.Div200u: return "0.2m/Div";
                case YScale.Div100u: return "0.1m/Div";
            }
            return "undefined";
        }

        private void UpdateChannelScales()
        {
            OsciChannelScaleA.Text = getYScaleString(yScale[0]);
            OsciChannelScaleB.Text = getYScaleString(yScale[1]);
            OsciChannelScaleC.Text = getYScaleString(yScale[2]);
            OsciChannelScaleD.Text = getYScaleString(yScale[3]);
        }

        private void OsciChannelTrigger_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton s = (RadioButton)sender;
            if ((s == OsciChannelTriggerA) && s.Checked) triggerFromChannel = 0;
            if ((s == OsciChannelTriggerB) && s.Checked) triggerFromChannel = 1;
            if ((s == OsciChannelTriggerC) && s.Checked) triggerFromChannel = 2;
            if ((s == OsciChannelTriggerD) && s.Checked) triggerFromChannel = 3;
        }

        private void selectChannel(int i)
        {
            // if (i == selectedChannel) return;
            selectedChannel = i;
            switch (selectedChannel)
            {
                case 0: OsciVertChannelLabel.Text = "Channel A"; break;
                case 1: OsciVertChannelLabel.Text = "Channel B"; break;
                case 2: OsciVertChannelLabel.Text = "Channel C"; break;
                case 3: OsciVertChannelLabel.Text = "Channel D"; break;
            }

            OsciVertScale.SelectedIndex = (int)yScale[selectedChannel];
            OsciVertAC.Checked = osciFIFO[selectedChannel].ACmode;
            OsciVertTrigAC.Checked = osciFIFO[selectedChannel].trigAC;

            newOsciVertOfs(lines[selectedChannel].yOffset, true);
            newOsciVertTrig(osciFIFO[selectedChannel].triggerLevel,true);

        }

        private void OsciChannelSelect_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton s = (RadioButton)sender;
            if ((s == OsciChannelSelectA) && s.Checked) selectChannel(0);
            if ((s == OsciChannelSelectB) && s.Checked) selectChannel(1);
            if ((s == OsciChannelSelectC) && s.Checked) selectChannel(2);
            if ((s == OsciChannelSelectD) && s.Checked) selectChannel(3);
        }

        public void initOscilloscope(Oscilloscope _oscilloscope, int _channels, int _FIFOdepth)
        {
            inputs = new FIFO[_channels];
            for (int i = 0; i < _channels; i++)
                inputs[i] = new FIFO(_FIFOdepth);
            lines = new OscilloscopeLine[_channels];
            osciFIFO = new OsciFIFO[_channels];
            inputsActive = new Boolean[_channels];
            yScale = new YScale[_channels];
            for (int i = 0; i < _channels; i++)
            {
                lines[i] = new OscilloscopeLine(oscilloscopeScreen);
                switch (i % 4)
                {
                    case 0: lines[i].color = Color.Red; break;
                    case 1: lines[1].color = Color.Green; break;
                    case 2: lines[2].color = Color.Cyan; break;
                    case 3: lines[3].color = Color.Magenta; break;
                }
                osciFIFO[i] = new OsciFIFO(_oscilloscope.owner.sampleRate / 2);
                yScale[i] = YScale.Div100m;
            }
            FIFOdepth = _FIFOdepth;
            oscilloscope = _oscilloscope;
            timer.Interval = 100; // ms
            timer.Tick += Timer_Tick;
            channels = _channels; // Triggers start
            selectedChannel = 0;

            timeScale = TimeScale.Div1ms;
            OsciHorzScale.SelectedIndex = (int)timeScale;


            triggerMode = TriggerMode.Auto;
            OsciTriggerAuto.Checked = true;
            triggerFromChannel = 0;
            triggerLevel = 0;
            trigSlope = TrigSlope.Rising;

            for (int i = 0; i < channels; i++)
            {
                lines[i].yScale = getYScale(i);
            }

            xOffset = 0;
            oscilloscopeScreen.initOscilloscopeScreen(this, channels, lines);
            UpdateChannelScales();

            OsciChannelSelectA.Checked = true;
            selectChannel(selectedChannel);
            OsciVertScale.SelectedIndex = (int)yScale[selectedChannel];

            OsciChannelOnA.Checked = lines[0].show;
            OsciChannelOnB.Checked = lines[1].show;
            OsciChannelOnC.Checked = lines[2].show;
            OsciChannelOnD.Checked = lines[3].show;

            XYDisplay.Checked = false;
            xydisplay = false;

            EnGrid.Checked = true;
            drawGrid = true;

            timer.Enabled = true;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (channels < 1) return;

            int ipfill = inputs[0].fill();
            while (ipfill >= 128)
            {
                for (int i=0;i<channels;i++)
                    osciFIFO[i].insert(inputs[i], 128);
                ipfill -= 128;
            }
            
            if (triggerMode != TriggerMode.Off)
            {
                if ((osciFIFO[_triggerFromChannel].triggered) &&
                    (osciFIFO[_triggerFromChannel].lastTriggerPos < -xLen / 2))
                {
                    // Update
                    int pickrangemin = osciFIFO[_triggerFromChannel].lastTriggerPos - xLen/2;
                    int pickrangemax = pickrangemin + xLen;
                    for (int i = 0; i < channels; i++)
                    {
                        lines[i].fetchFrom(osciFIFO[i], pickrangemin, xLen);
                    }
                    osciFIFO[_triggerFromChannel].reTrigger();
                    oscilloscopeScreen.Invalidate();
                    if (triggerMode == TriggerMode.Single)
                    {
                        triggerMode = TriggerMode.Off;
                        OsciTriggerSingle.Checked = false;
                        OsciTriggerStop.Checked = true;
                    }
                }
            }
        }

        private void OscilloscopeWin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!CanClose)
            {
                Hide();
                e.Cancel = true;
            }
        }



    }
}
