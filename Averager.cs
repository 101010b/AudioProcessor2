using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioProcessor
{
    class Averager
    {
        public int sampleRate;

        public delegate void AveragerCallback(double val, int idx);

        AveragerCallback callback;

        BaseAverager averager;
        public String averagerName;

        public Boolean removeDC;
        private BiQuad DCStripper;

        // List<String> list;
        // List<Type> classlist;

        private int _len;
        public int len
        {
            set
            {
                if (value != _len)
                {
                    _len = value;
                    if (averager != null)
                        averager.newLen(_len);
                }
            }
            get
            {
                return _len;
            }
        }

        public Averager(int _sampleRate, int __len, AveragerCallback _callback)
        {
            averager = null;
            averagerName = "";
            callback = _callback;
            sampleRate = _sampleRate;
            _len = __len;
            
            removeDC = false;
            DCStripper = new BiQuad(sampleRate, BiQuad.BiQuadOrder.Second, BiQuad.BiQuadMode.LowPass, 10.0, 0.71);
        }

        public void reset()
        {
            if (averager != null)
                averager.reset();
        }

        public void process(double[] d, int n)
        {
            if (removeDC)
                for (int i = 0; i < n; i++)
                    d[i] = d[i] - DCStripper.filter(d[i]);

            if (averager != null)
                averager.add(d, n);
        }

        public void process(int n)
        {
            if (removeDC)
                for (int i = 0; i < n; i++)
                    DCStripper.filter(0);

            if (averager != null)
                averager.add(null,n);
        }

        static List<Type> classlist = null;
        static List<string> list = null;

        private static void registerAveragers()
        {
            list = new List<string>();
            classlist = new List<Type>();
            LinearAverager.register(list, classlist);
            LinearMin.register(list, classlist);
            LinearMax.register(list, classlist);
            LinearAbsMin.register(list, classlist);
            LinearAbsMax.register(list, classlist);
            LinearPP.register(list, classlist);
            LinearRMS.register(list, classlist);
            LinearRMSA.register(list, classlist);
            LogRMS.register(list, classlist);
            LogRMSA.register(list, classlist);
        }

        public static List<string> getList()
        {
            if (list == null)
                registerAveragers();
            return new List<string>(list);
        }

        public void select(string _selection)
        {
            if (averager != null && _selection.Equals(averagerName))
                return;
            for (int i=0;i<list.Count;i++)
            {
                if (list[i].Equals(_selection))
                {
                    Type T = classlist[i];
                    averagerName = list[i];
                    object[] ol = new object[2] { this, _len };
                    averager = (BaseAverager) Activator.CreateInstance(classlist[i], ol);
                    // averager.len = _len;
                }
            }
        }


        /*public enum LineMode
        {
            linearAverage,
            linearMin,
            linearMax,
            linearAbsMin,
            linearAbsMax,
            linearPP,
            linearRMS,
            logRMS,
            logARMS
        }*/


        public void addFromAverager(double v, int idx)
        {
            callback(v,idx);
        }

        
        private abstract class BaseAverager
        {
            protected Averager root;
            protected int len;

            public BaseAverager(Averager _root, int _len)
            {
                root = _root;
                len = _len;
                reset();
            }
            public abstract void add(double[] buf, int n);

            public void newLen(int _len)
            {
                if (_len == len)
                    return;
                len = _len;
                reset();
            }

            public abstract void reset();
        }

        ////////////////////////////////////////////////////////////////////////////////
        
        private class LinearAverager : BaseAverager
        {
            protected int intcnt;
            protected double val;

            public static void register(List<string> names, List<Type> types)
            {
                names.Add("Linear Averager");
                types.Add(MethodBase.GetCurrentMethod().DeclaringType);
            }

            public LinearAverager(Averager _root, int _len) : base(_root, _len)
            {
                intcnt = 0;
                val = 0;
            }

            public override void add(double[] buf, int n)
            {
                for (int i = 0; i < n; i++)
                {
                    if (buf == null)
                        val += 0;
                    else
                        val += buf[i];
                    intcnt++;
                    if (intcnt >= len)
                    {
                        root.addFromAverager(val / (double)len,i);
                        intcnt = 0;
                        val = 0;
                    }
                }
            }

            public override void reset()
            {
                intcnt = 0;
                val = 0;
            }

        }

        ////////////////////////////////////////////////////////////////////////////////

        private class LinearMin : BaseAverager
        {
            protected int intcnt;
            protected double val;
            public static void register(List<string> names, List<Type> types)
            {
                names.Add("Linear Min");
                types.Add(MethodBase.GetCurrentMethod().DeclaringType);
            }

            public LinearMin(Averager _root, int _len) : base(_root, _len)
            {
                intcnt = 0;
                val = 0;
            }

            public override void add(double[] buf, int n)
            {
                for (int i = 0; i < n; i++)
                {
                    double bi=0;
                    if (buf != null) bi = buf[i];
                    if ((intcnt == 0) || (bi < val))
                        val = bi;
                    intcnt++;
                    if (intcnt >= len)
                    {
                        root.addFromAverager(val,i);
                        intcnt = 0;
                    }
                }
            }
            public override void reset()
            {
                intcnt = 0;
                val = 0;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////

        private class LinearMax : BaseAverager
        {
            protected int intcnt;
            protected double val;
            public static void register(List<string> names, List<Type> types)
            {
                names.Add("Linear Max");
                types.Add(MethodBase.GetCurrentMethod().DeclaringType);
            }

            public LinearMax(Averager _root, int _len) : base(_root, _len)
            {
                intcnt = 0;
                val = 0;
            }

            public override void add(double[] buf, int n)
            {
                for (int i = 0; i < n; i++)
                {
                    double bi = 0;
                    if (buf != null) bi = buf[i];
                    if ((intcnt == 0) || (bi > val))
                        val = bi;
                    intcnt++;
                    if (intcnt >= len)
                    {
                        root.addFromAverager(val,i);
                        intcnt = 0;
                    }
                }
            }
            public override void reset()
            {
                intcnt = 0;
                val = 0;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////

        private class LinearAbsMin : BaseAverager
        {
            protected int intcnt;
            protected double val;
            public static void register(List<string> names, List<Type> types)
            {
                names.Add("Linear Abs Min");
                types.Add(MethodBase.GetCurrentMethod().DeclaringType);
            }

            public LinearAbsMin(Averager _root, int _len) : base(_root, _len)
            {
                intcnt = 0;
                val = 0;
            }

            public override void add(double[] buf, int n)
            {
                for (int i = 0; i < n; i++)
                {
                    double bi = 0;
                    if (buf != null) bi = Math.Abs(buf[i]);
                    if ((intcnt == 0) || (bi < val))
                        val = bi;
                    intcnt++;
                    if (intcnt >= len)
                    {
                        root.addFromAverager(val,i);
                        intcnt = 0;
                    }
                }
            }
            public override void reset()
            {
                intcnt = 0;
                val = 0;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////

        private class LinearAbsMax : BaseAverager
        {
            protected int intcnt;
            protected double val;

            public static void register(List<string> names, List<Type> types)
            {
                names.Add("Linear Abs Max");
                types.Add(MethodBase.GetCurrentMethod().DeclaringType);
            }


            public LinearAbsMax(Averager _root, int _len) : base(_root, _len)
            {
                intcnt = 0;
                val = 0;
            }

            public override void add(double[] buf, int n)
            {
                for (int i = 0; i < n; i++)
                {
                    double bi = 0;
                    if (buf != null) bi = Math.Abs(buf[i]);
                    if ((intcnt == 0) || (bi > val))
                        val = bi;
                    intcnt++;
                    if (intcnt >= len)
                    {
                        root.addFromAverager(val,i);
                        intcnt = 0;
                    }
                }
            }
            public override void reset()
            {
                intcnt = 0;
                val = 0;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////

        private class LinearPP : BaseAverager
        {
            protected int intcnt;
            protected double min;
            protected double max;

            public static void register(List<string> names, List<Type> types)
            {
                names.Add("Linear Peak To Peak");
                types.Add(MethodBase.GetCurrentMethod().DeclaringType);
            }


            public LinearPP(Averager _root, int _len) : base(_root, _len)
            {
                intcnt = 0;
                min = max = 0;
            }

            public override void add(double[] buf, int n)
            {
                for (int i = 0; i < n; i++)
                {
                    double bi = 0;
                    if (buf != null) bi = buf[i];
                    if (intcnt == 0) 
                        min = max = bi;
                    if (bi < min) min = bi;
                    if (bi > max) max = bi;
                    intcnt++;
                    if (intcnt >= len)
                    {
                        root.addFromAverager(max-min,i);
                        intcnt = 0;
                    }
                }
            }
            public override void reset()
            {
                intcnt = 0;
                min = max = 0;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////

        private class LinearRMS : BaseAverager
        {
            protected int intcnt;
            protected double S;
            protected double S2;

            public static void register(List<string> names, List<Type> types)
            {
                names.Add("Linear RMS");
                types.Add(MethodBase.GetCurrentMethod().DeclaringType);
            }


            public LinearRMS(Averager _root, int _len) : base(_root, _len)
            {
                intcnt = 0;
                S = S2 = 0;
            }

            public override void add(double[] buf, int n)
            {
                for (int i = 0; i < n; i++)
                {
                    double bi = 0;
                    if (buf != null) bi = buf[i];
                    S += bi;
                    S2 += bi * bi;
                    intcnt++;
                    if (intcnt >= len)
                    {
                        double v = Math.Sqrt(S2 / (double) len);
                        //if (removeDC)
                        //    v -= Math.Abs(S[j]) / count[j];
                        root.addFromAverager(v,i);
                        intcnt = 0;
                        S = S2 = 0;
                    }
                }
            }
            public override void reset()
            {
                intcnt = 0;
                S = S2 = 0;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////

        private class LogRMS : BaseAverager
        {
            protected int intcnt;
            protected double S;
            protected double S2;

            public static void register(List<string> names, List<Type> types)
            {
                names.Add("Log (dB) RMS");
                types.Add(MethodBase.GetCurrentMethod().DeclaringType);
            }


            public LogRMS(Averager _root, int _len) : base(_root, _len)
            {
                intcnt = 0;
                S = S2 = 0;
            }

            public override void add(double[] buf, int n)
            {
                for (int i = 0; i < n; i++)
                {
                    double bi = 0;
                    if (buf != null) bi = buf[i];
                    S += bi;
                    S2 += bi * bi;
                    intcnt++;
                    if (intcnt >= len)
                    {
                        double v = Math.Sqrt(S2 / (double)len);
                        // v -= Math.Abs(S) / (double)len;
                        if (v < 1e-6)
                            v = -120;
                        else
                            v = 20 * Math.Log10(v);
                        root.addFromAverager(v,i);
                        intcnt = 0;
                        S = S2 = 0;
                    }
                }
            }
            public override void reset()
            {
                intcnt = 0;
                S = S2 = 0;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////

        private class LogRMSA : BaseAverager
        {
            protected int intcnt;
            protected double S;
            protected double S2;
            protected AFilterIIR aFilterIIR;

            public static void register(List<string> names, List<Type> types)
            {
                names.Add("Log (dB) RMS (A)");
                types.Add(MethodBase.GetCurrentMethod().DeclaringType);
            }


            public LogRMSA(Averager _root, int _len) : base(_root, _len)
            {
                intcnt = 0;
                S = S2 = 0;
                aFilterIIR = new AFilterIIR(_root.sampleRate);
            }

            public override void add(double[] buf, int n)
            {
                for (int i = 0; i < n; i++)
                {
                    double d;
                    if (buf == null)
                        d = aFilterIIR.filter(0);
                    else
                        d = aFilterIIR.filter(buf[i]);
                    S += d;
                    S2 += d*d;
                    intcnt++;
                    if (intcnt >= len)
                    {
                        double v = Math.Sqrt(S2 / (double)len);
                        if (v < 1e-6)
                            v = -120;
                        else
                            v = 20 * Math.Log10(v);
                        root.addFromAverager(v,i);
                        intcnt = 0;
                        S = S2 = 0;
                    }
                }
            }
            public override void reset()
            {
                intcnt = 0;
                S = S2 = 0;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////

        private class LinearRMSA : BaseAverager
        {
            protected int intcnt;
            protected double S;
            protected double S2;
            protected AFilterIIR aFilterIIR;

            public static void register(List<string> names, List<Type> types)
            {
                names.Add("Linear RMS (A)");
                types.Add(MethodBase.GetCurrentMethod().DeclaringType);
            }


            public LinearRMSA(Averager _root, int _len) : base(_root, _len)
            {
                intcnt = 0;
                S = S2 = 0;
                aFilterIIR = new AFilterIIR(_root.sampleRate);
            }

            public override void add(double[] buf, int n)
            {
                for (int i = 0; i < n; i++)
                {
                    double d;
                    if (buf == null)
                        d = aFilterIIR.filter(0);
                    else
                        d = aFilterIIR.filter(buf[i]);
                    S += d;
                    S2 += d * d;
                    intcnt++;
                    if (intcnt >= len)
                    {
                        double v = Math.Sqrt(S2 / (double)len);
                        root.addFromAverager(v,i);
                        intcnt = 0;
                        S = S2 = 0;
                    }
                }
            }
            public override void reset()
            {
                intcnt = 0;
                S = S2 = 0;
            }
        }


    }
}
