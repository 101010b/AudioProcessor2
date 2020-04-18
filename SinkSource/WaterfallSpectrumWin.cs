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
    public partial class WaterfallSpectrumWin : Form
    {

        public Boolean CanClose;
        public WaterfallSpectrum waterfallSpectrum; // Pointer to the corresponding Element
        public Boolean ready = false;
        public int FIFOdepth;
        public FIFO input;
        public Boolean inputActive;
        public Boolean overlapFFT;
        public Boolean run;
        
        private Boolean noRangeUpdate;

        private double[] inputData;

        private Timer timer;

        FFTProcessor fftProcessor;
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
                    // spectrumAnalyzerScreen.reCalcF();
                    if ((waterfallSpectrumScreen != null) && (waterfallSpectrumScreen.ready)) {
                        double bst = (double)_blockSize / waterfallSpectrum.owner.sampleRate;
                        waterfallSpectrumScreen.gridY.max = (waterfallSpectrumScreen.gridY.low - waterfallSpectrumScreen.gridY.high) * bst;
                        waterfallSpectrumScreen.Invalidate();
                    }
                }
            }
            get { return _blockSize; }
        }

        public class WaterfallLine
        {
            public WaterfallSpectrumScreen root;

            public int size;
            public float[] data; // Save some Memory
            double fmax;
            public Boolean empty;

            public WaterfallLine(WaterfallSpectrumScreen _root, int _size, double _fmax)
            {
                empty = true;
                root = _root;
                size = _size;
                data = new float[size];
                fmax = _fmax;
            }

            public void setSize(int _size, double _fmax)
            {
                if (_size == size) return;
                size = _size;
                data = new float[size];
                empty = true;
                fmax = _fmax;
            }

            public void drawToMap(ColorTable colorTable, GridCalculator gridF, GridCalculator gridCol, int[] mapdata, int ofs, int width)
            {
                for (int i=0;i<width;i++)
                {
                    double f = gridF.getAbsolutePos(i+gridF.low);
                    int idx = (int)Math.Floor(f / fmax * size + 0.5);
                    if (idx < 0) idx = 0;
                    if (idx >= size) idx = size - 1;
                    double cv = gridCol.getRelativePos(data[idx]);
                    int col = colorTable.col(cv).ToArgb();
                    mapdata[ofs + i] = col;                   
                }
            }
        }

        public class WaterfallLineFIFO
        {
            WaterfallSpectrumScreen root;
            public int size;
            WaterfallLine[] lines;

            private Bitmap map;
            private System.Drawing.Imaging.BitmapData bitmapData;
            private int mapstride;
            private int[] mapdata;

            public int missingLines;
            int write;
            int fill;

            public WaterfallLineFIFO(WaterfallSpectrumScreen _root, int _size, int _initialblocksize, double _initialfmax,int _width, int _height)
            {
                size = _size;
                root = _root;
                lines = new WaterfallLine[size];
                for (int i = 0; i < size; i++)
                    lines[i] = new WaterfallLine(_root, _initialblocksize, _initialfmax);
                write = 0;
                fill = 0;
                newBitmap(_width, _height);
                missingLines = 0;
            }

            public WaterfallLine NewforWrite()
            {
                int wrx = write;
                write = (write + 1) % size;
                if (fill < size) fill++;
                if (missingLines < size) missingLines++;
                return lines[wrx];
            }

            public WaterfallLine get(int step)
            {
                if (step >= fill) return null;
                return lines[(write - 1 - step + size) % size];
            }

            private double gridFMin, gridFMax;
            private double gridColMin, gridColMax;
            private Boolean gridFLogScale;

            private void newBitmap(int _width, int _height)
            {
                if (map != null)
                {
                    map.Dispose();
                }
                map = new Bitmap(_width, _height, System.Drawing.Imaging.PixelFormat.Format32bppRgb);
                bitmapData = map.LockBits(new Rectangle(0, 0, map.Width, map.Height),
                    System.Drawing.Imaging.ImageLockMode.ReadWrite, System.Drawing.Imaging.PixelFormat.Format32bppRgb);
                mapstride = bitmapData.Stride / 4;
                mapdata = new int[mapstride * bitmapData.Height];
                map.UnlockBits(bitmapData);
                bitmapData = null;
                GC.Collect();
            }

            public void redrawBitmap(ColorTable colorTable, GridCalculator gridF, GridCalculator gridY, GridCalculator gridCol)
            {
                int newWidth = (int)Math.Floor(gridF.high - gridF.low + 0.5);
                int newHeight = (int)Math.Floor(gridY.low - gridY.high + 0.5);
                if ((newWidth != map.Width) || (newHeight != map.Height))
                    newBitmap(newWidth, newHeight);

                gridFMin = gridF.min;
                gridFMax = gridF.max;
                gridFLogScale = gridF.logScale;
                gridColMin = gridCol.min;
                gridColMax = gridCol.max;
                colorTable.changed = false;

                // Clear Map
                System.Array.Clear(mapdata, 0, mapdata.Length);

                int y = map.Height - 1;
                int f = fill;
                int i = 0;
                while ((y >= 0) && (f > 0))
                {
                    WaterfallLine wfl = get(i);
                    if (wfl !=null)
                        wfl.drawToMap(colorTable, gridF, gridCol, mapdata, y * mapstride, map.Width);
                    i++;
                    y--;
                    f--;
                }
                missingLines = 0;
            }

            public void updateBitmap(ColorTable colortable, GridCalculator gridF, GridCalculator gridY, GridCalculator gridCol) 
            {
                // Check whethter there is really something new
                if (missingLines == 0)
                    return;

                // Check whether complete redo is necessary
                Boolean redo = false;
                int newWidth = (int)Math.Floor(gridF.high - gridF.low + 0.5);
                int newHeight = (int)Math.Floor(gridY.low - gridY.high + 0.5);
                if ((newWidth != map.Width) || (newHeight != map.Height))
                    redo = true;
                if (colortable.changed)
                    redo = true;
                if ((gridF.min != gridFMin) || (gridF.max != gridFMax) || (gridF.logScale != gridFLogScale))
                    redo = true;
                if ((gridCol.min != gridColMin) || (gridCol.max != gridColMax))
                    redo = true;

                if (redo)
                {
                    redrawBitmap(colortable, gridF, gridY, gridCol);
                    return;
                }
                
                // Just an update
                // Shift Content
                Array.Copy(mapdata, missingLines * mapstride, mapdata, 0, (map.Height - missingLines) * mapstride);
                int y = map.Height - 1;
                int f = missingLines;
                int i = 0;
                while (f > 0)
                {
                    WaterfallLine wfl = get(i);
                    if (wfl != null)
                        wfl.drawToMap(colortable, gridF, gridCol, mapdata, y * mapstride, map.Width);
                    i++;
                    y--;
                    f--;
                }
                missingLines = 0;                
            }

            public void drawBitmap(Graphics g, int x, int y)
            {
                bitmapData = map.LockBits(new Rectangle(0, 0, map.Width, map.Height),
                    System.Drawing.Imaging.ImageLockMode.ReadWrite, System.Drawing.Imaging.PixelFormat.Format32bppRgb);
                System.Runtime.InteropServices.Marshal.Copy(mapdata, 0, bitmapData.Scan0, mapstride * map.Height);
                map.UnlockBits(bitmapData);
                bitmapData = null;
                g.DrawImageUnscaled(map, x, y);
            }

        }

        private WaterfallLineFIFO waterfallLines;
        public void drawWaterfallBitmap(Graphics g, int x, int y)
        {
            if (!ready) return;
            waterfallLines.drawBitmap(g, x, y);
        }

        public WaterfallSpectrumWin()
        {
            InitializeComponent();

            waterfallSpectrum = null;
            ready = false;

            timer = new Timer();

            CanClose = false;
            FormClosing += WaterfallSpectrumWin_FormClosing;

        }

        public void initWaterfallSpectrum(WaterfallSpectrum _waterfallSpectrum)
        {
            FIFOdepth = 32768;
            input = new FIFO(FIFOdepth);

            _blockSize = 4096;
            _windowType = FFTProcessor.WindowType.Hann;
            waterfallSpectrum = _waterfallSpectrum;

            timer.Interval = 50; // ms
            timer.Tick += Timer_Tick;


            fftProcessor = new FFTProcessor(_blockSize, waterfallSpectrum.owner.sampleRate, _windowType);
            fftBlockSizes = new List<int>();
            for (int i = 2048; i <= 8192; i *= 2)
            {
                waterfallSpectrumBlockSize.Items.Add(String.Format("{0} --> {1:f1}ms",
                    i, 1000.0 * i / waterfallSpectrum.owner.sampleRate));
                fftBlockSizes.Add(i);
            }
            waterfallSpectrumBlockSize.SelectedIndex = fftBlockSizes.IndexOf(_blockSize);
            waterfallSpectrumBlockSize.SelectedIndexChanged += waterfallSpectrumBlockSize_SelectedIndexChanged;

            string[] windows = Enum.GetNames(typeof(FFTProcessor.WindowType));
            fftWindows = new List<FFTProcessor.WindowType>();
            for (int i = 0; i < windows.Length; i++)
            {
                fftWindows.Add((FFTProcessor.WindowType)i);
                waterfallSpectrumWindow.Items.Add(windows[i]);
            }
            waterfallSpectrumWindow.SelectedIndex = fftWindows.IndexOf(_windowType);
            waterfallSpectrumWindow.SelectedIndexChanged += waterfallSpectrumWindow_SelectedIndexChanged;

            waterfallSpectrumScreen.initWaterfallSpectrumScreen(this);

            double bst = (double) _blockSize / waterfallSpectrum.owner.sampleRate;
            waterfallSpectrumScreen.gridY.max = (waterfallSpectrumScreen.gridY.low - waterfallSpectrumScreen.gridY.high) * bst;

            if (waterfallSpectrumScreen.gridF.logScale)
                waterfallSpectrumFLog.Checked = true;
            waterfallSpectrumFLog.Click += waterfallSpectrumFLog_Click;

            waterfallSpectrumFMin.Value = Convert.ToDecimal(waterfallSpectrumScreen.gridF.min);
            waterfallSpectrumFMax.Value = Convert.ToDecimal(waterfallSpectrumScreen.gridF.max);
            waterfallSpectrumFMin.ValueChanged += WaterfallSpectrumFMin_ValueChanged;
            waterfallSpectrumFMax.ValueChanged += WaterfallSpectrumFMax_ValueChanged; 

            waterfallSpectrumAutoScale.Click += WaterfallSpectrumAutoScale_Click;

            waterfallSpectrumShowGrid.Checked = waterfallSpectrumScreen.drawGrid;
            waterfallSpectrumShowGrid.Click += WaterfallSpectrumShowGrid_Click;

            waterfallSpectrumRun.Click += WaterfallSpectrumRun_Click;

            waterfallSpectrumColorScheme.Items.Add("KrYW");
            waterfallSpectrumColorScheme.Items.Add("KbBW");
            waterfallSpectrumColorScheme.Items.Add("KrgBW");
            waterfallSpectrumColorScheme.Items.Add("KW");
            waterfallSpectrumColorScheme.Items.Add("KmryGCBW");
            waterfallSpectrumColorScheme.Text = waterfallSpectrumScreen.colorTable.scheme;
            waterfallSpectrumColorScheme.TextChanged += WaterfallSpectrumColorScheme_TextChanged;

            waterfallLines = new WaterfallLineFIFO(waterfallSpectrumScreen, 1024, _blockSize/2, waterfallSpectrum.owner.sampleRate/2,
                waterfallSpectrumScreen.Width, waterfallSpectrumScreen.Height);


            ready = true;
            run = true;
            timer.Enabled = true;

        }

        private void WaterfallSpectrumRun_Click(object sender, EventArgs e)
        {
            if (!ready)
                return;
            if (waterfallSpectrumRun.Checked)
                run = true;
            else
                run = false;
        }

        private void WaterfallSpectrumColorScheme_TextChanged(object sender, EventArgs e)
        {
            waterfallSpectrumScreen.colorTable.scheme = waterfallSpectrumColorScheme.Text;
            waterfallSpectrumScreen.Invalidate();
        }

        private void WaterfallSpectrumFMax_ValueChanged(object sender, EventArgs e)
        {
            if (noRangeUpdate) return;
            waterfallSpectrumScreen.gridF.max = Convert.ToDouble(waterfallSpectrumFMax.Value);
        }

        private void WaterfallSpectrumFMin_ValueChanged(object sender, EventArgs e)
        {
            if (noRangeUpdate) return;
            waterfallSpectrumScreen.gridF.min = Convert.ToDouble(waterfallSpectrumFMin.Value);
        }

        private void WaterfallSpectrumShowGrid_Click(object sender, EventArgs e)
        {
            if (waterfallSpectrumShowGrid.Checked)
                waterfallSpectrumScreen.drawGrid = true;
            else
                waterfallSpectrumScreen.drawGrid = false;
            waterfallSpectrumScreen.Invalidate();
        }

        private void waterfallSpectrumFLog_Click(object sender, EventArgs e)
        {
            if (waterfallSpectrumFLog.Checked)
                waterfallSpectrumScreen.gridF.logScale = true;
            else
                waterfallSpectrumScreen.gridF.logScale = false;
            waterfallSpectrumScreen.Invalidate();
        }

        private void WaterfallSpectrumAutoScale_Click(object sender, EventArgs e)
        {
            noRangeUpdate = true;
            waterfallSpectrumFMin.Value = Convert.ToDecimal(100);
            waterfallSpectrumFMax.Value = Convert.ToDecimal(20000);
            noRangeUpdate = false;
            waterfallSpectrumScreen.gridF.newRange(100, 20000);
            waterfallSpectrumScreen.Invalidate();
        }

        private void waterfallSpectrumWindow_SelectedIndexChanged(object sender, EventArgs e)
        {
            windowType = fftWindows[waterfallSpectrumWindow.SelectedIndex];
        }

        private void waterfallSpectrumBlockSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            blockSize = fftBlockSizes[waterfallSpectrumBlockSize.SelectedIndex];
        }

        public void updateRanges()
        {
            noRangeUpdate = true;
            waterfallSpectrumFMin.Value = Convert.ToDecimal(waterfallSpectrumScreen.gridF.min);
            waterfallSpectrumFMax.Value = Convert.ToDecimal(waterfallSpectrumScreen.gridF.max);
            noRangeUpdate = false;
        }
        
        private void Timer_Tick(object sender, EventArgs e)
        {
            if (!ready) return;
            if (waterfallSpectrum == null) return;
            if (waterfallSpectrum.owner == null) return;

            int ipfill = input.fill();
            while (ipfill >= _blockSize)
            {
                if ((inputData == null) || (inputData.Length != _blockSize))
                    inputData = new double[_blockSize];
                input.retrieve(ref inputData);

                if (run)
                {
                    WaterfallLine l = waterfallLines.NewforWrite();
                    l.setSize(_blockSize/2, waterfallSpectrum.owner.sampleRate/2);
                    fftProcessor.runFFTdBFS(ref inputData, ref l.data);
                }

                ipfill -= _blockSize;
            }
            if (waterfallLines.missingLines > 0)
            {
                waterfallLines.updateBitmap(waterfallSpectrumScreen.colorTable,
                    waterfallSpectrumScreen.gridF, waterfallSpectrumScreen.gridY,
                    waterfallSpectrumScreen.gridCol);

                waterfallSpectrumScreen.Invalidate();
            }
        }

        private void WaterfallSpectrumWin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!CanClose)
            {
                Hide();
                e.Cancel = true;
            }
        }

    }
}
