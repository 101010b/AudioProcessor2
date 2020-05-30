using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioProcessor
{
    public class GridCalculator
    {
        private bool omitReCalc;

        public struct GridTick {
            public double pos;
            public double screen;
            public bool isMajor;
            public string name;
            public bool show;
        }

        public GridTick[] grid;
        public int gridLength;

        public double screenMin; // Screen coordinates in Pixels
        public double screenMax; // Screen coordinates in Pixels
        private double lableWidth; // Width of the lable in Pixels

        private double axisMin; // axis min
        private double axisMax; // axis max
        private bool axisLogScale; // Use logarithmic scale

        private double absMin; // global axis min (axisMin must be >= absMin)
        private double absMax; // global axis max (axisMax must be <= absMax)
        private double logMin; // Minimal value for logarithmic scale

        // Accessible Data
        public double min
        {
            set { setMin(value); }
            get { return axisMin; }
        }

        public double max
        {
            set { setMax(value); }
            get { return axisMax; }
        }

        public bool logScale
        {
            set { setLogScale(value); }
            get { return axisLogScale; }
        }

        public double low
        {
            set { reScreen(value, screenMax); }
            get { return screenMin; }
        }

        public double high
        {
            set { reScreen(screenMin, value); }
            get { return screenMax; }
        }

        private bool _showEndLables = false;
        public bool showEndLables
        {
            set { if (_showEndLables != value) { _showEndLables = value; reSpace(); } }
            get { return _showEndLables; }
        }

        private double absMinDist;
        private double logMinDist;

        public GridCalculator(double _absMin, double _absMax, double _absMinDist, 
            double _logMin, double _logMinDist, 
            double __min, double __max, bool __logScale,
            double __low, double __high, double _lableWidth)
        {
            axisMin = __min;
            axisMax = __max;
            axisLogScale = __logScale;
            absMin = _absMin;
            absMax = _absMax;
            absMinDist = _absMinDist;

            logMin = _logMin;
            logMinDist = _logMinDist;

            screenMin = __low;
            screenMax = __high;
            lableWidth = _lableWidth;

            // Verification
            if (!__logScale)
            {
                if (absMax - absMin < _absMinDist)
                    throw new Exception("abs Min Dist too large for given abs limits");
            } else
            {
                if (absMax < logMin * logMinDist)
                    throw new Exception("log Min Dist too large for given abs limits");
            }

            // Verify current parameters
            omitReCalc = true;
            setMin(axisMin);
            setMax(axisMax);
            omitReCalc = false;

            reGrid();
        }

        public GridCalculator(double __min, double __max, bool __logScale, double width) :
            this(__min,__max,__max-__min,(__logScale)?__min:0,(__logScale)?__max/__min:1,__min,__max,__logScale,0,width,1)
        { }

        private void setMin(double v)
        {
            if (!axisLogScale)
            { // Linear
                axisMin = v;
                if (axisMin < absMin)
                    axisMin = absMin;
                if (axisMin > axisMax-absMinDist)
                {
                    axisMax = axisMin + absMinDist;
                    if (axisMax > absMax)
                    {
                        axisMax = absMax;
                        axisMin = absMax - absMinDist;
                    }
                }
            }
            else
            { // Logarithmic Scale
                axisMin = v;
                if (axisMin < logMin)
                    axisMin = logMin;
                if (axisMin > axisMax/logMinDist)
                {
                    axisMax = axisMin * logMinDist;
                    if (axisMax > absMax)
                    {
                        axisMax = absMax;
                        axisMin = absMax / logMinDist;
                    }
                }
            }
            reGrid();
        }

        private void setMax(double v)
        {
            if (!axisLogScale)
            { // Linear
                axisMax = v;
                if (axisMax > absMax)
                    axisMax = absMax;
                if (axisMax < axisMin + absMinDist)
                {
                    axisMin = axisMax - absMinDist;
                    if (axisMin < absMin)
                    {
                        axisMin = absMin;
                        axisMax = absMin + absMinDist;
                    }
                }
            }
            else
            { // Logarithmic Scale
                axisMax = v;
                if (axisMax > absMax)
                    axisMax = absMax;
                if (axisMax < axisMin * logMinDist)
                {
                    axisMin = axisMax / logMinDist;
                    if (axisMin < logMin)
                    {
                        axisMin = logMin;
                        axisMax = absMin * logMinDist;
                    }
                }
            }
            reGrid();
        }

        private void setLogScale(Boolean v)
        {
            axisLogScale = v;
            if ((axisMin < logMin) || (axisMax < axisMin * logMinDist))
                setMin(logMin);
            else
                reGrid();
        }

        private void resetGrid()
        {
            gridLength = 0;
            if (grid == null)
            {
                grid = new GridTick[32];
            }
        }

        private void addGrid(double val, string lab, bool _isMajor)
        {
            if (gridLength == grid.Length)
            {
                // Extend Arrays
                int oldLength = grid.Length;
                int newLength = oldLength + 32;
                GridTick[] newGrid = new GridTick[newLength];
                Array.Copy(grid, 0, newGrid, 0, oldLength);
                grid = newGrid;
            }
            grid[gridLength].pos = val;
            grid[gridLength].screen = getInterpolatedPos(val);
            grid[gridLength].name = lab;
            grid[gridLength].isMajor = _isMajor;
            grid[gridLength].show = _isMajor;
            gridLength++;
        }

        public void reScreen(double __low, double __high)
        {
            if ((screenMin == __low) && (screenMax == __high)) return;
            screenMin = __low;
            screenMax = __high;
            reGrid();
            for (int i = 0; i < gridLength; i++)
                grid[i].screen = getInterpolatedPos(grid[i].pos);
            reSpace();
        }

        public void reStructure(double __min, double __max, double __low, double __high)
        {
            if ((screenMin == __low) && (screenMax == __high) && (axisMin == __min) && (axisMax == __max)) return;
            screenMin = __low;
            screenMax = __high;
            axisMin = __min;
            axisMax = __max;
            reGrid();
            for (int i = 0; i < gridLength; i++)
                grid[i].screen = getInterpolatedPos(grid[i].pos);
            reSpace();
        }

        bool[] pxSpace;

        private void blockSpace(double screenFrom, double screenTo)
        {
            if (screenMax > screenMin)
            {
                int si = (int)Math.Floor(screenFrom - screenMin + 0.5);
                int sj = (int)Math.Floor(screenTo - screenMin + 0.5);
                for (int i = si; i <= sj; i++)
                    if ((i >= 0) && (i < pxSpace.Length))
                        pxSpace[i] = true;
            } else
            {
                int si = (int)Math.Floor(screenFrom - screenMax + 0.5);
                int sj = (int)Math.Floor(screenTo - screenMax + 0.5);
                for (int i = si; i <= sj; i++)
                    if ((i >= 0) && (i < pxSpace.Length))
                        pxSpace[i] = true;
            }
        }

        private bool isFreeSpace(double screenFrom, double screenTo)
        {
            if (screenMax > screenMin)
            {
                int si = (int)Math.Floor(screenFrom - screenMin + 0.5);
                int sj = (int)Math.Floor(screenTo - screenMin + 0.5);
                if (_showEndLables)
                {
                    for (int i = si; i <= sj; i++)
                        if ((i >= 0) && (i < pxSpace.Length) && pxSpace[i]) return false;
                }
                else
                {
                    if ((si < 0) || (sj >= pxSpace.Length)) return false;
                    for (int i = si; i <= sj; i++)
                        if (pxSpace[i]) return false;
                }
                return true;
            } else
            {
                int si = (int)Math.Floor(screenFrom - screenMax + 0.5);
                int sj = (int)Math.Floor(screenTo - screenMax + 0.5);
                if (_showEndLables)
                {
                    for (int i = si; i <= sj; i++)
                        if ((i >= 0) && (i < pxSpace.Length) && pxSpace[i]) return false;
                }
                else
                {
                    if ((si < 0) || (sj >= pxSpace.Length)) return false;
                    for (int i = si; i <= sj; i++)
                        if (pxSpace[i]) return false;
                }
                return true;
            }
        }

        private void reSpace()
        {
            int screenWidth = 0;
            if (screenMax > screenMin)
                screenWidth = (int)Math.Floor(screenMax - screenMin + 0.5);
            else
                screenWidth = (int)Math.Floor(screenMin - screenMax + 0.5);
            if ((pxSpace == null) || (pxSpace.Length != screenWidth))
                pxSpace = new bool[screenWidth];
            Array.Clear(pxSpace,0,pxSpace.Length);
            for (int i = 0; i < gridLength; i++)
                grid[i].show = false;

            // End Lables
            if (_showEndLables && (gridLength >= 2))
            {
                double si, sj;
                si = grid[0].screen - lableWidth / 2;
                sj = grid[0].screen + lableWidth / 2;
                if (isFreeSpace(si,sj))
                {
                    grid[0].show = true;
                    blockSpace(si, sj);
                }
                si = grid[gridLength-1].screen - lableWidth / 2;
                sj = grid[gridLength-1].screen + lableWidth / 2;
                if (isFreeSpace(si, sj))
                {
                    grid[gridLength-1].show = true;
                    blockSpace(si, sj);
                }
            }

            // round 1: Major Ticks only
            for (int i = 0; i < gridLength; i++)
            {
                double si = grid[i].screen - lableWidth / 2;
                double sj = grid[i].screen + lableWidth / 2;
                if (grid[i].isMajor && isFreeSpace(si, sj))
                {
                    grid[i].show = true;
                    blockSpace(si, sj);
                }
            }

            // round 2: Minor Ticks
            for (int i=0;i<gridLength;i++)
            {
                if (!grid[i].show)
                {
                    double si = grid[i].screen - lableWidth / 2;
                    double sj = grid[i].screen + lableWidth / 2;
                    if (isFreeSpace(si, sj))
                    {
                        grid[i].show = true;
                        blockSpace(si, sj);
                    }
                }
            }
        }

        private string formatENG(double v)
        {
            string erg = "";
            if (v == 0)
                return "0";
            if (v < 0)
            {
                erg = "-";
                v = -v;
            }
            if (v < 1e-15) return erg + string.Format("0");
            if (v < 1e-14) return erg + string.Format("{0:f2}f", v * 1e15);
            if (v < 1e-13) return erg + string.Format("{0:f1}f", v * 1e15);
            if (v < 1e-12) return erg + string.Format("{0:f0}f", v * 1e15);
            if (v < 1e-11) return erg + string.Format("{0:f2}p", v * 1e12);
            if (v < 1e-10) return erg + string.Format("{0:f1}p", v * 1e12);
            if (v < 1e-9) return erg + string.Format("{0:f0}p", v * 1e12);
            if (v < 1e-8) return erg + string.Format("{0:f2}n", v * 1e9);
            if (v < 1e-7) return erg + string.Format("{0:f1}n", v * 1e9);
            if (v < 1e-6) return erg + string.Format("{0:f0}n", v * 1e9);
            if (v < 1e-5) return erg + string.Format("{0:f2}µ", v * 1e6);
            if (v < 1e-4) return erg + string.Format("{0:f1}µ", v * 1e6);
            if (v < 1e-3) return erg + string.Format("{0:f0}µ", v * 1e6);
            if (v < 1e-2) return erg + string.Format("{0:f2}m", v * 1e3);
            if (v < 1e-1) return erg + string.Format("{0:f1}m", v * 1e3);
            if (v < 1) return erg + string.Format("{0:f0}m", v * 1e3);
            if (v < 10) return erg + string.Format("{0:f2}", v);
            if (v < 100) return erg + string.Format("{0:f1}", v);
            if (v < 1000) return erg + string.Format("{0:f0}", v);
            if (v < 1e4) return erg + string.Format("{0:f2}k", v / 1e3);
            if (v < 1e5) return erg + string.Format("{0:f1}k", v / 1e3);
            if (v < 1e6) return erg + string.Format("{0:f0}k", v / 1e3);
            if (v < 1e7) return erg + string.Format("{0:f2}M", v / 1e6);
            if (v < 1e8) return erg + string.Format("{0:f1}M", v / 1e6);
            if (v < 1e9) return erg + string.Format("{0:f0}M", v / 1e6);
            if (v < 1e10) return erg + string.Format("{0:f2}G", v / 1e9);
            if (v < 1e11) return erg + string.Format("{0:f1}G", v / 1e9);
            if (v < 1e12) return erg + string.Format("{0:f0}G", v / 1e9);
            return erg + string.Format("{0:e3}", v);
        }

        private void addLinearGrid()
        {
            double diff = axisMax - axisMin;
            int resn = (int)Math.Floor(Math.Log10(diff) + 0.5);
            double majstep = Math.Pow(10.0, resn);
            double start = Math.Floor(axisMin / majstep) * majstep;
            double stop = Math.Ceiling(axisMax / majstep) * majstep;
            double val = start;
            int stepctr = 0;
            resetGrid();
            while (val <= stop)
            {
                if ((val >= axisMin) && (val <= axisMax))
                    addGrid(val, formatENG(val), (stepctr == 0));
                val += majstep / 10.0;
                stepctr++;
                if (stepctr == 10) stepctr = 0;
            }
        }

        private void addLogarithmicGrid()
        {
            if ((axisMin <= 0) || (axisMax <= 0) || (axisMin >= axisMax)) {
                axisMin = 0.001;
                axisMax = 1;
            }
            int logStart = (int)Math.Floor(Math.Log10(axisMin));
            int logStop = (int)Math.Ceiling(Math.Log10(axisMax));
            int instep = 0;
            if (logStop - logStart <= 2)
                instep = 1;
            else if (logStop - logStart <= 5)
                instep = 2;
            resetGrid();
            for (int i=logStart;i<= logStop;i++)
            {
                if (instep == 0)
                { // Only Major Grid
                    double gv = Math.Pow(10.0, i);
                    if ((gv >= axisMin) && (gv <= axisMax))
                        addGrid(gv, formatENG(gv), (i % 3) == 0);
                }
                else if (instep == 1)
                { // Full 10 Line Grid
                    for (int j = 1; j < 10; j++)
                    {
                        double gv = Math.Pow(10.0, i) * (double)j;
                        if ((gv >= axisMin) && (gv <= axisMax))
                            addGrid(gv, formatENG(gv), (j == 1));
                    }
                } else
                { // 1 2 5 grid
                    double gv = Math.Pow(10.0, i);
                    if ((gv >= axisMin) && (gv <= axisMax))
                        addGrid(gv, formatENG(gv), true);
                    gv = Math.Pow(10.0, i) * 2.0;
                    if ((gv >= axisMin) && (gv <= axisMax))
                        addGrid(gv, formatENG(gv), false);
                    gv = Math.Pow(10.0, i) * 5.0;
                    if ((gv >= axisMin) && (gv <= axisMax))
                        addGrid(gv, formatENG(gv), false);
                }
            }
        }

        private void reGrid()
        {
            if (omitReCalc) return;

            if (axisLogScale)
            {
                double ratio = axisMax / axisMin;
                if (ratio < 10)
                    addLinearGrid();
                else
                    addLogarithmicGrid();
            } else
            {
                addLinearGrid();
            }
            reSpace();
        }


        public string getLongestTick()
        {
            if (gridLength < 1) return "";
            int slen = grid[0].name.Length;
            int idx = 0;
            for (int i = 1; i < gridLength; i++)
                if (grid[i].name.Length > slen)
                {
                    slen = grid[i].name.Length;
                    idx = i;
                }
            return grid[idx].name;
        }


        public double getInterpolatedPos(double data)
        { // from data space to screen
            if (logScale)
            {
                if (data <= axisMin/2) data = axisMin/2;
                if (data >= axisMax*2) data = axisMax*2;
                return screenMin + Math.Log(data / axisMin) / Math.Log(axisMax / axisMin) * (screenMax - screenMin);
            }
            else
                return screenMin + (data - axisMin) / (axisMax - axisMin) * (screenMax - screenMin);
        }

        public double getAbsolutePos(double screen)
        { // From screen to data space
            if (logScale)
                return Math.Exp((screen - screenMin) / (screenMax - screenMin) * Math.Log(axisMax / axisMin)) * axisMin;
            else
                return (screen - screenMin) / (screenMax - screenMin) * (axisMax - axisMin) + axisMin;
        }

        public double getRelativePos(double data)
        { // From data to relative (0..1)
            if (logScale)
            {
                if (data < axisMin / 2) data = axisMin / 2;
                if (data > axisMax * 2) data = axisMax * 2;
                return Math.Log(data / axisMin) / Math.Log(axisMax / axisMin);
            }
            else
                return (data- axisMin) / (axisMax - axisMin);
        }

        public void newRange(double newMin, double newMax)
        {
            if (!logScale)
            { // Linear
                if (newMax - newMin < absMinDist)
                { // Range bad
                    double ctr = (newMax + newMin) / 2;
                    newMin = ctr - absMinDist / 2;
                    newMax = ctr + absMinDist / 2;                    
                }
                if ((newMin < absMin) || (newMax > absMax) || (newMax - newMin < absMinDist))
                { // must realign
                    if (newMin < absMin)
                    {
                        newMax = (newMax - newMin) + absMin;
                        newMin = absMin;
                        if (newMax - newMin < absMinDist)
                            newMax = newMin + absMinDist;
                    }
                    if (newMax > absMax)
                    {
                        newMin = absMax - (newMax - newMin);
                        newMax = absMax;
                        if (newMax - newMin < absMinDist)
                            newMin = newMax - absMinDist;
                    }
                }
                axisMin = newMin;
                axisMax = newMax;
                reGrid();
            }
            else
            { // Logarithmic
                if (newMin <= 0) newMin = logMin / 100; // Make sure to avoid Div-by-Zero
                if ((newMin < logMin) || (newMax > absMax) || (newMax/newMin < logMinDist))
                { // must realign
                    if (newMin < logMin)
                    {
                        newMax = (newMax/newMin) * logMin;
                        newMin = logMin;
                        if (newMax/newMin < logMinDist)
                            newMax = newMin * logMinDist;
                    }
                    if (newMax > absMax)
                    {
                        newMin = absMax/(newMax/newMin);
                        newMax = absMax;
                        if (newMax/newMin < logMinDist)
                            newMin = newMax / logMinDist;
                    }
                }
                axisMin = newMin;
                axisMax = newMax;
                reGrid();
            }
        }

    }
}
