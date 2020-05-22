using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioProcessor
{
    public class GridCalculator
    {
        private Boolean omitReCalc;

        public struct GridTick {
            public double pos;
            public double screen;
            public bool isMajor;
            public string name;
            public bool show;
        }

        public GridTick[] grid;
        public int gridLength;

        public double _low; // Screen coordinates
        public double _high; // Screen coordinates
        private double lableWidth;

        private double _min;
        private double _max;
        private Boolean _logScale;

        private double absMin;
        private double absMax;
        private double logMin;

        public double min
        {
            set { setMin(value); }
            get { return _min; }
        }

        public double max
        {
            set { setMax(value); }
            get { return _max; }
        }

        public Boolean logScale
        {
            set { setLogScale(value); }
            get { return _logScale; }
        }

        public double low
        {
            set { reScreen(value, _high); }
            get { return _low; }
        }
        public double high
        {
            set { reScreen(_low, value); }
            get { return _high; }
        }

        private double absMinDist;
        private double logMinDist;

        public GridCalculator(double _absMin, double _absMax, double _absMinDist, 
            double _logMin, double _logMinDist, 
            double __min, double __max, Boolean __logScale,
            double __low, double __high, double _lableWidth)
        {
            _min = __min;
            _max = __max;
            _logScale = __logScale;
            absMin = _absMin;
            absMax = _absMax;
            absMinDist = _absMinDist;

            logMin = _logMin;
            logMinDist = _logMinDist;

            _low = __low;
            _high = __high;
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
            setMin(_min);
            setMax(_max);
            omitReCalc = false;

            reGrid();
        }

        public GridCalculator(double __min, double __max, Boolean __logScale, double width) :
            this(__min,__max,__max-__min,(__logScale)?__min:0,(__logScale)?__max/__min:1,__min,__max,__logScale,0,width,1)
        { }

        private void setMin(double v)
        {
            if (!_logScale)
            { // Linear
                _min = v;
                if (_min < absMin)
                    _min = absMin;
                if (_min > _max-absMinDist)
                {
                    _max = _min + absMinDist;
                    if (_max > absMax)
                    {
                        _max = absMax;
                        _min = absMax - absMinDist;
                    }
                }
            }
            else
            { // Logarithmic Scale
                _min = v;
                if (_min < logMin)
                    _min = logMin;
                if (_min > _max/logMinDist)
                {
                    _max = _min * logMinDist;
                    if (_max > absMax)
                    {
                        _max = absMax;
                        _min = absMax / logMinDist;
                    }
                }
            }
            reGrid();
        }

        private void setMax(double v)
        {
            if (!_logScale)
            { // Linear
                _max = v;
                if (_max > absMax)
                    _max = absMax;
                if (_max < _min + absMinDist)
                {
                    _min = _max - absMinDist;
                    if (_min < absMin)
                    {
                        _min = absMin;
                        _max = absMin + absMinDist;
                    }
                }
            }
            else
            { // Logarithmic Scale
                _max = v;
                if (_max > absMax)
                    _max = absMax;
                if (_max < _min * logMinDist)
                {
                    _min = _max / logMinDist;
                    if (_min < logMin)
                    {
                        _min = logMin;
                        _max = absMin * logMinDist;
                    }
                }
            }
            reGrid();
        }

        private void setLogScale(Boolean v)
        {
            _logScale = v;
            if ((_min < logMin) || (_max < _min * logMinDist))
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

        private void addGrid(double val, string lab, Boolean _isMajor)
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
            if ((_low == __low) && (_high == __high)) return;
            _low = __low;
            _high = __high;
            reGrid();
            for (int i = 0; i < gridLength; i++)
                grid[i].screen = getInterpolatedPos(grid[i].pos);
            reSpace();
        }

        public void reStructure(double __min, double __max, double __low, double __high)
        {
            if ((_low == __low) && (_high == __high) && (_min == __min) && (_max == __max)) return;
            _low = __low;
            _high = __high;
            _min = __min;
            _max = __max;
            reGrid();
            for (int i = 0; i < gridLength; i++)
                grid[i].screen = getInterpolatedPos(grid[i].pos);
            reSpace();
        }

        bool[] pxSpace;

        private void blockSpace(double screenFrom, double screenTo)
        {
            if (_high > _low)
            {
                int si = (int)Math.Floor(screenFrom - _low + 0.5);
                int sj = (int)Math.Floor(screenTo - _low + 0.5);
                for (int i = si; i <= sj; i++)
                    if ((i >= 0) && (i < pxSpace.Length))
                        pxSpace[i] = true;
            } else
            {
                int si = (int)Math.Floor(screenFrom - _high + 0.5);
                int sj = (int)Math.Floor(screenTo - _high + 0.5);
                for (int i = si; i <= sj; i++)
                    if ((i >= 0) && (i < pxSpace.Length))
                        pxSpace[i] = true;
            }
        }

        private bool isFreeSpace(double screenFrom, double screenTo)
        {
            if (_high > _low)
            {
                int si = (int)Math.Floor(screenFrom - _low + 0.5);
                int sj = (int)Math.Floor(screenTo - _low + 0.5);
                if ((si < 0) || (sj >= pxSpace.Length)) return false;
                for (int i = si; i <= sj; i++)
                    if (pxSpace[i]) return false;
                return true;
            } else
            {
                int si = (int)Math.Floor(screenFrom - _high + 0.5);
                int sj = (int)Math.Floor(screenTo - _high + 0.5);
                if ((si < 0) || (sj >= pxSpace.Length)) return false;
                for (int i = si; i <= sj; i++)
                    if (pxSpace[i]) return false;
                return true;
            }
        }

        private void reSpace()
        {
            int screenWidth = 0;
            if (_high > _low)
                screenWidth = (int)Math.Floor(_high - _low + 0.5);
            else
                screenWidth = (int)Math.Floor(_low - _high + 0.5);
            if ((pxSpace == null) || (pxSpace.Length != screenWidth))
                pxSpace = new bool[screenWidth];
            Array.Clear(pxSpace,0,pxSpace.Length);
            // round 1: Major Ticks only
            for (int i = 0; i < gridLength; i++)
            {
                double si = grid[i].screen - lableWidth / 2;
                double sj = grid[i].screen + lableWidth / 2;
                if (grid[i].isMajor && isFreeSpace(si, sj))
                {
                    grid[i].show = true;
                    blockSpace(si, sj);
                } else
                    grid[i].show = false;
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
            double diff = _max - _min;
            int resn = (int)Math.Floor(Math.Log10(diff) + 0.5);
            double majstep = Math.Pow(10.0, resn);
            double start = Math.Floor(_min / majstep) * majstep;
            double stop = Math.Ceiling(_max / majstep) * majstep;
            double val = start;
            int stepctr = 0;
            resetGrid();
            while (val <= stop)
            {
                if ((val >= _min) && (val <= _max))
                    addGrid(val, formatENG(val), (stepctr == 0));
                val += majstep / 10.0;
                stepctr++;
                if (stepctr == 10) stepctr = 0;
            }
        }

        private void addLogarithmicGrid()
        {
            if ((_min <= 0) || (_max <= 0) || (_min >= _max)) {
                _min = 0.001;
                _max = 1;
            }
            int logStart = (int)Math.Floor(Math.Log10(_min));
            int logStop = (int)Math.Ceiling(Math.Log10(_max));
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
                    if ((gv >= _min) && (gv <= _max))
                        addGrid(gv, formatENG(gv), (i % 3) == 0);
                }
                else if (instep == 1)
                { // Full 10 Line Grid
                    for (int j = 1; j < 10; j++)
                    {
                        double gv = Math.Pow(10.0, i) * (double)j;
                        if ((gv >= _min) && (gv <= _max))
                            addGrid(gv, formatENG(gv), (j == 1));
                    }
                } else
                { // 1 2 5 grid
                    double gv = Math.Pow(10.0, i);
                    if ((gv >= _min) && (gv <= _max))
                        addGrid(gv, formatENG(gv), true);
                    gv = Math.Pow(10.0, i) * 2.0;
                    if ((gv >= _min) && (gv <= _max))
                        addGrid(gv, formatENG(gv), false);
                    gv = Math.Pow(10.0, i) * 5.0;
                    if ((gv >= _min) && (gv <= _max))
                        addGrid(gv, formatENG(gv), false);
                }
            }
        }

        private void reGrid()
        {
            if (omitReCalc) return;

            if (_logScale)
            {
                double ratio = _max / _min;
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
                if (data <= _min/2) data = _min/2;
                if (data >= _max*2) data = _max*2;
                return _low + Math.Log(data / _min) / Math.Log(_max / _min) * (_high - _low);
            }
            else
                return _low + (data - _min) / (_max - _min) * (_high - _low);
        }

        public double getAbsolutePos(double screen)
        { // From screen to data space
            if (logScale)
                return Math.Exp((screen - _low) / (_high - _low) * Math.Log(_max / _min)) * _min;
            else
                return (screen - _low) / (_high - _low) * (_max - _min) + _min;
        }

        public double getRelativePos(double data)
        { // From data to relative (0..1)
            if (logScale)
            {
                if (data < _min / 2) data = _min / 2;
                if (data > _max * 2) data = _max * 2;
                return Math.Log(data / _min) / Math.Log(_max / _min);
            }
            else
                return (data- _min) / (_max - _min);
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
                _min = newMin;
                _max = newMax;
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
                _min = newMin;
                _max = newMax;
                reGrid();
            }
        }

    }
}
