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
    public partial class SpectrumAnalyzerWin : Form
    {
        public bool CanClose;
        public SpectrumAnalyzer spectrumAnalyzer; // Pointer to the corresponding Element
        public int channels;
        public int FIFOdepth;
        public FIFO[] inputs;
        public bool[] inputsActive;
        public bool run;
        public bool showGrid;

        private bool noRangeUpdate;

        List<int> fftBlockSizes;
        List<FFTProcessor.WindowType> fftWindows;
        FFTProcessor.WindowType _windowType;
        FFTProcessor.WindowType windowType
        {
            set
            {
                _windowType = value;
                if (fftProcessor != null)
                    fftProcessor.windowType = value;
            }
            get { return _windowType; }
        }

        public int _blockSize;
        public int blockSize
        {
            set
            {
                if (value != _blockSize)
                {
                    _blockSize = value;
                    fftProcessor.blockSize = _blockSize;
                    spectrumAnalyzerScreen.reCalcF();
                }
            }
            get { return _blockSize; }
        }

        public class SpectrumAnalyzerLine
        {
            public SpectrumAnalyzerScreen root;
            private Color _color;
            public Color color
            {
                set
                {
                    _color = value;
                    penLine = new Pen(_color);
                    penAvg = new Pen(Color.FromArgb(_color.R / 2, _color.G / 2, _color.B / 2));
                    penMax = new Pen(Color.FromArgb(_color.R / 2, _color.G / 2, _color.B / 2));
                    brushLine = new SolidBrush(_color);
                }
                get { return _color; }
            }
            public Boolean show;
            public Boolean showMax;
            public Boolean showAvg;

            public double[] data;
            public double[] dataAvg;
            public double[] dataMax;
            public PointF[] points;

            public double acf = 0.0;

            protected Pen penLine;
            protected Pen penMax;
            protected Pen penAvg;
            protected Brush brushLine;

            public SpectrumAnalyzerLine(SpectrumAnalyzerScreen _root)
            {
                color = Color.Red;
                show = true;
                showMax = showAvg = false;
                root = _root;
            }

            public void Draw(Graphics g)
            {
                if (!show) return;
                if (data == null) return;
                if ((points == null) || (points.Length != data.Length))
                    points = new PointF[data.Length];
                for (int i = 0; i < data.Length; i++)
                {
                    if (root.gridF.logScale && (i == 0))
                        points[i].X = (float)root.gridF.low;
                    else
                        points[i].X = (float)root.xpos[i];
                    points[i].Y = (float)root.gridY.getInterpolatedPos(data[i]+acf);
                }
                g.DrawLines(penLine, points);
                if (showAvg)
                {
                    for (int i = 0; i < data.Length; i++)
                        points[i].Y = (float)root.gridY.getInterpolatedPos(dataAvg[i]+acf);
                    g.DrawLines(penAvg, points);
                }
                if (showMax)
                {
                    for (int i = 0; i < data.Length; i++)
                        points[i].Y = (float)root.gridY.getInterpolatedPos(dataMax[i]+acf);
                    g.DrawLines(penMax, points);
                }
            }

            public void newDataSize(int newLen)
            {
                if ((data != null) && (newLen == data.Length)) return;
                data = new double[newLen];
                dataAvg = new double[newLen];
                dataMax = new double[newLen];
                for (int i = 0; i < newLen; i++)
                {
                    dataAvg[i] = -200;
                    dataMax[i] = -200;
                }
            }

            public void newData()
            {
                for (int i = 0; i < data.Length; i++)
                {
                    if (dataMax[i] < data[i]) dataMax[i] = data[i];
                    double expavg = Math.Exp(dataAvg[i]);
                    double expnew = Math.Exp(data[i]);
                    double nv = expavg * 0.9 + 0.1 * expnew;
                    if (nv < 1e-86)
                        dataAvg[i] = -200;
                    else
                        dataAvg[i] = Math.Log(nv);
                }
            }

            public void resetMax()
            {
                for (int i = 0; i < data.Length; i++)
                    dataMax[i] = -200;
            }
        }

        SpectrumAnalyzerLine[] lines;

        private Timer timer;

        FFTProcessor fftProcessor;
        double[][] inputData;

        public SpectrumAnalyzerWin()
        {
            InitializeComponent();
            channels = 0;
            spectrumAnalyzer = null;
            FormClosing += SpectrumAnalyzerWin_FormClosing;
            CanClose = false;
            timer = new Timer();

        }
               

        public void initSpectrumAnalyzer(SpectrumAnalyzer _spectrumAnalyzer, int _channels, int _FIFOdepth)
        {
            inputs = new FIFO[_channels];
            for (int i = 0; i < _channels; i++)
                inputs[i] = new FIFO(_FIFOdepth);
            lines = new SpectrumAnalyzerLine[_channels];
            inputsActive = new Boolean[_channels];
            inputData = new double[_channels][];
            for (int i = 0; i < _channels; i++)
            {
                lines[i] = new SpectrumAnalyzerLine(spectrumAnalyzerScreen);
                switch (i % 4)
                {
                    case 0: lines[i].color = Color.Red; break;
                    case 1: lines[1].color = Color.Green; break;
                    case 2: lines[2].color = Color.Cyan; break;
                    case 3: lines[3].color = Color.Magenta; break;
                }
            }
            FIFOdepth = _FIFOdepth;
            spectrumAnalyzer = _spectrumAnalyzer;
            timer.Interval = 100; // ms
            timer.Tick += Timer_Tick;

            _blockSize = 4096;
            _windowType = FFTProcessor.WindowType.Hann;
            for (int i=0;i<_channels;i++)
                lines[i].acf = FFTProcessor.windowAmplitudeCorrectionFactorsdB[(int)_windowType];

            fftProcessor = new FFTProcessor(_blockSize,spectrumAnalyzer.owner.sampleRate,_windowType);

            fftBlockSizes = new List<int>();
            for (int i=64;i<=8192;i*=2)
            {
                SpectrumAnalyzerBlockSize.Items.Add(String.Format("{0} --> {1:f1}ms",
                    i, 1000.0 * i / spectrumAnalyzer.owner.sampleRate));
                fftBlockSizes.Add(i);
            }
            SpectrumAnalyzerBlockSize.SelectedIndex = fftBlockSizes.IndexOf(_blockSize);
            SpectrumAnalyzerBlockSize.SelectedIndexChanged += SpectrumAnalyzerBlockSize_SelectedIndexChanged;

            string[] windows = Enum.GetNames(typeof(FFTProcessor.WindowType));
            fftWindows = new List<FFTProcessor.WindowType>();
            for (int i = 0; i < windows.Length; i++)
            {
                fftWindows.Add((FFTProcessor.WindowType)i);
                SpectrumAnalyzerWindow.Items.Add(windows[i]);
            }
            SpectrumAnalyzerWindow.SelectedIndex = fftWindows.IndexOf(_windowType);
            SpectrumAnalyzerWindow.SelectedIndexChanged += SpectrumAnalyzerWindow_SelectedIndexChanged;

            spectrumAnalyzerScreen.initSpectrumAnalyzerScreen(this, _channels, lines);

            if (spectrumAnalyzerScreen.gridF.logScale)
                SpectrumAnalyzerFLog.Checked = true;
            SpectrumAnalyzerFLog.Click += SpectrumAnalyzerFLog_Click;

            SpectrumAnalyzerFMin.Value = Convert.ToDecimal(spectrumAnalyzerScreen.gridF.min);
            SpectrumAnalyzerFMax.Value = Convert.ToDecimal(spectrumAnalyzerScreen.gridF.max);
            SpectrumAnalyzerYMin.Value = Convert.ToDecimal(spectrumAnalyzerScreen.gridY.min);
            SpectrumAnalyzerYMax.Value = Convert.ToDecimal(spectrumAnalyzerScreen.gridY.max);

            SpectrumAnalyzerFMin.ValueChanged += SpectrumAnalyzerFMin_ValueChanged;
            SpectrumAnalyzerFMax.ValueChanged += SpectrumAnalyzerFMax_ValueChanged;
            SpectrumAnalyzerYMin.ValueChanged += SpectrumAnalyzerYMin_ValueChanged;
            SpectrumAnalyzerYMax.ValueChanged += SpectrumAnalyzerYMax_ValueChanged;

            SpectrumAnalyzerAutoScale.Click += SpectrumAnalyzerAutoScale_Click;

            SpectrumAnalyzerChannelOnA.Checked = lines[0].show;
            SpectrumAnalyzerChannelOnB.Checked = lines[1].show;
            SpectrumAnalyzerChannelOnC.Checked = lines[2].show;
            SpectrumAnalyzerChannelOnD.Checked = lines[3].show;

            SpectrumAnalyzerChannelOnA.Click += SpectrumAnalyzerChannelOnA_Click;
            SpectrumAnalyzerChannelOnB.Click += SpectrumAnalyzerChannelOnB_Click;
            SpectrumAnalyzerChannelOnC.Click += SpectrumAnalyzerChannelOnC_Click;
            SpectrumAnalyzerChannelOnD.Click += SpectrumAnalyzerChannelOnD_Click;

            SpectrumAnalyzerPkHldA.Checked = lines[0].showMax;
            SpectrumAnalyzerPkHldB.Checked = lines[1].showMax;
            SpectrumAnalyzerPkHldC.Checked = lines[2].showMax;
            SpectrumAnalyzerPkHldD.Checked = lines[3].showMax;

            SpectrumAnalyzerPkHldA.Click += SpectrumAnalyzerPkHldA_Click;
            SpectrumAnalyzerPkHldB.Click += SpectrumAnalyzerPkHldB_Click;
            SpectrumAnalyzerPkHldC.Click += SpectrumAnalyzerPkHldC_Click;
            SpectrumAnalyzerPkHldD.Click += SpectrumAnalyzerPkHldD_Click;

            SpectrumAnalyzerAvgA.Checked = lines[0].showAvg;
            SpectrumAnalyzerAvgB.Checked = lines[1].showAvg;
            SpectrumAnalyzerAvgC.Checked = lines[2].showAvg;
            SpectrumAnalyzerAvgD.Checked = lines[3].showAvg;

            SpectrumAnalyzerAvgA.Click += SpectrumAnalyzerAvgA_Click;
            SpectrumAnalyzerAvgB.Click += SpectrumAnalyzerAvgB_Click;
            SpectrumAnalyzerAvgC.Click += SpectrumAnalyzerAvgC_Click;
            SpectrumAnalyzerAvgD.Click += SpectrumAnalyzerAvgD_Click;

            SpectrumAnalyzerSave.Click += SpectrumAnalyzerSave_Click;

            run = true;
            SpectrumAnalyzerRun.Checked = run;
            SpectrumAnalyzerRun.Click += SpectrumAnalyzerRun_Click;

            showGrid = true;
            SpectrumAnalyzerGrid.Checked = showGrid;
            spectrumAnalyzerScreen.drawGrid = showGrid;
            SpectrumAnalyzerGrid.CheckedChanged += SpectrumAnalyzerGrid_CheckedChanged;

            channels = _channels; // Triggers start
            timer.Enabled = true;
        }

        private void SpectrumAnalyzerGrid_CheckedChanged(object sender, EventArgs e)
        {
            showGrid = SpectrumAnalyzerGrid.Checked;
            spectrumAnalyzerScreen.drawGrid = showGrid;
        }

        private void SpectrumAnalyzerSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "XML File|*.xml";
            saveFileDialog1.Title = "Save an XML File";
            saveFileDialog1.ShowDialog();

            // If the file name is not an empty string open it for saving.
            if (saveFileDialog1.FileName != "")
            {
                saveDataToXMLFile(saveFileDialog1.FileName);
            }
        }

        private void saveDataToXMLFile(string fn)
        {
            try
            {
                XMLDataFile xdf = new XMLDataFile(fn);
                xdf.startGroup("SpectralMeasurement");
                xdf.startGroup("Config");
                xdf.writeNumeric("fs", spectrumAnalyzer.owner.sampleRate );
                xdf.writeNumeric("Points", _blockSize);
                xdf.writeNumeric("Channels", channels);
                xdf.writeNumeric("AmplitudeCorrectionFactordB", FFTProcessor.windowAmplitudeCorrectionFactorsdB[(int)windowType]);
                xdf.writeNumeric("PowerCorrectionFactordB", FFTProcessor.windowPowerCorrectionFactorsdB[(int)windowType]);
                string[] windows = Enum.GetNames(typeof(FFTProcessor.WindowType));
                xdf.writeString("Window", windows[(int)windowType]);
                xdf.closeGroup();
                xdf.writeNumericArray("f", fftProcessor.freq);
                for (int j = 0; j < channels; j++)
                {
                    xdf.writeNumericArray(string.Format("raw{0}", j + 1), lines[j].data);
                    xdf.writeNumericArray(string.Format("peak{0}", j + 1), lines[j].dataMax);
                    xdf.writeNumericArray(string.Format("avg{0}", j + 1), lines[j].dataAvg);
                }
                xdf.closeGroup();
                xdf.close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error Writing File", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void SpectrumAnalyzerRun_Click(object sender, EventArgs e)
        {
            run = SpectrumAnalyzerRun.Checked;
        }

        private void SpectrumAnalyzerAvgA_Click(object sender, EventArgs e)
        {
            lines[0].showAvg = SpectrumAnalyzerAvgA.Checked;
            spectrumAnalyzerScreen.Invalidate();
        }

        private void SpectrumAnalyzerAvgB_Click(object sender, EventArgs e)
        {
            lines[1].showAvg = SpectrumAnalyzerAvgB.Checked;
            spectrumAnalyzerScreen.Invalidate();
        }

        private void SpectrumAnalyzerAvgC_Click(object sender, EventArgs e)
        {
            lines[2].showAvg = SpectrumAnalyzerAvgC.Checked;
            spectrumAnalyzerScreen.Invalidate();
        }

        private void SpectrumAnalyzerAvgD_Click(object sender, EventArgs e)
        {
            lines[3].showAvg = SpectrumAnalyzerAvgD.Checked;
            spectrumAnalyzerScreen.Invalidate();
        }


        private void SpectrumAnalyzerPkHldA_Click(object sender, EventArgs e)
        {
            lines[0].showMax = SpectrumAnalyzerPkHldA.Checked;
            lines[0].resetMax();
            spectrumAnalyzerScreen.Invalidate();
        }

        private void SpectrumAnalyzerPkHldB_Click(object sender, EventArgs e)
        {
            lines[1].showMax = SpectrumAnalyzerPkHldB.Checked;
            lines[1].resetMax();
            spectrumAnalyzerScreen.Invalidate();
        }

        private void SpectrumAnalyzerPkHldC_Click(object sender, EventArgs e)
        {
            lines[2].showMax = SpectrumAnalyzerPkHldC.Checked;
            lines[2].resetMax();
            spectrumAnalyzerScreen.Invalidate();
        }

        private void SpectrumAnalyzerPkHldD_Click(object sender, EventArgs e)
        {
            lines[3].showMax = SpectrumAnalyzerPkHldD.Checked;
            lines[3].resetMax();
            spectrumAnalyzerScreen.Invalidate();
        }

        private void SpectrumAnalyzerChannelOnA_Click(object sender, EventArgs e)
        {
            lines[0].show = SpectrumAnalyzerChannelOnA.Checked;
            spectrumAnalyzerScreen.Invalidate();
        }

        private void SpectrumAnalyzerChannelOnB_Click(object sender, EventArgs e)
        {
            lines[1].show = SpectrumAnalyzerChannelOnB.Checked;
            spectrumAnalyzerScreen.Invalidate();
        }

        private void SpectrumAnalyzerChannelOnC_Click(object sender, EventArgs e)
        {
            lines[2].show = SpectrumAnalyzerChannelOnC.Checked;
            spectrumAnalyzerScreen.Invalidate();
        }

        private void SpectrumAnalyzerChannelOnD_Click(object sender, EventArgs e)
        {
            lines[3].show = SpectrumAnalyzerChannelOnD.Checked;
            spectrumAnalyzerScreen.Invalidate();
        }

        public void updateRanges()
        {
            noRangeUpdate = true;
            SpectrumAnalyzerFMin.Value = Convert.ToDecimal(spectrumAnalyzerScreen.gridF.min);
            SpectrumAnalyzerFMax.Value = Convert.ToDecimal(spectrumAnalyzerScreen.gridF.max);
            SpectrumAnalyzerYMin.Value = Convert.ToDecimal(spectrumAnalyzerScreen.gridY.min);
            SpectrumAnalyzerYMax.Value = Convert.ToDecimal(spectrumAnalyzerScreen.gridY.max);
            noRangeUpdate = false;
        }

        private void SpectrumAnalyzerAutoScale_Click(object sender, EventArgs e)
        {
            noRangeUpdate = true;
            SpectrumAnalyzerFMin.Value = Convert.ToDecimal(100);
            SpectrumAnalyzerFMax.Value = Convert.ToDecimal(20000);
            SpectrumAnalyzerYMin.Value = Convert.ToDecimal(-120);
            SpectrumAnalyzerYMax.Value = Convert.ToDecimal(0);
            noRangeUpdate = false;
            spectrumAnalyzerScreen.gridF.newRange(100, 20000);
            spectrumAnalyzerScreen.gridY.newRange(-120, 0);
            spectrumAnalyzerScreen.Invalidate();
        }

        private void SpectrumAnalyzerYMax_ValueChanged(object sender, EventArgs e)
        {
            if (noRangeUpdate) return;
            spectrumAnalyzerScreen.gridY.max = Convert.ToDouble(SpectrumAnalyzerYMax.Value);
        }

        private void SpectrumAnalyzerYMin_ValueChanged(object sender, EventArgs e)
        {
            if (noRangeUpdate) return;
            spectrumAnalyzerScreen.gridY.min = Convert.ToDouble(SpectrumAnalyzerYMin.Value);
        }

        private void SpectrumAnalyzerFMax_ValueChanged(object sender, EventArgs e)
        {
            if (noRangeUpdate) return;
            spectrumAnalyzerScreen.gridF.max = Convert.ToDouble(SpectrumAnalyzerFMax.Value);
        }

        private void SpectrumAnalyzerFMin_ValueChanged(object sender, EventArgs e)
        {
            if (noRangeUpdate) return;
            spectrumAnalyzerScreen.gridF.min = Convert.ToDouble(SpectrumAnalyzerFMin.Value);
        }

        private void SpectrumAnalyzerFLog_Click(object sender, EventArgs e)
        {
            if (SpectrumAnalyzerFLog.Checked)
                spectrumAnalyzerScreen.gridF.logScale = true;
            else
                spectrumAnalyzerScreen.gridF.logScale = false;
            spectrumAnalyzerScreen.Invalidate();
        }

        private void SpectrumAnalyzerWindow_SelectedIndexChanged(object sender, EventArgs e)
        {
            windowType = fftWindows[SpectrumAnalyzerWindow.SelectedIndex];
            for (int i = 0; i < channels; i++)
                lines[i].acf = FFTProcessor.windowAmplitudeCorrectionFactorsdB[(int)windowType];
        }

        private void SpectrumAnalyzerBlockSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            blockSize = fftBlockSizes[SpectrumAnalyzerBlockSize.SelectedIndex];
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (channels < 1) return;

            int ipfill = inputs[0].fill();
            while (ipfill >= _blockSize)
            {
                if ((inputData[0] == null) || (inputData[0].Length != _blockSize))
                    for (int i = 0; i < channels; i++)
                        inputData[i] = new double[_blockSize];
                for (int i=0;i< channels;i++)
                    inputs[i].retrieve(ref inputData[i]);

                if ((lines[0].data == null) || (lines[0].data.Length != _blockSize / 2))
                    for (int i = 0; i < channels; i++)
                        lines[i].newDataSize(_blockSize / 2);

                if (run)
                {
                    for (int i = 0; i < channels; i++)
                    {
                        fftProcessor.runFFTdBRMS(ref inputData[i], ref lines[i].data);
                        lines[i].newData();
                    }
                }

                ipfill -= _blockSize;
            }
            spectrumAnalyzerScreen.Invalidate();

            /*
            if ((osciFIFO[_triggerFromChannel].triggered) &&
                (osciFIFO[_triggerFromChannel].lastTriggerPos < -xLen / 2))
            {
                // Update
                int pickrangemin = osciFIFO[_triggerFromChannel].lastTriggerPos - xLen / 2;
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
            */
        }
        private void SpectrumAnalyzerWin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!CanClose)
            {
                Hide();
                e.Cancel = true;
            }
        }
    }
}
