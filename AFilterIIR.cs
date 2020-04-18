using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioProcessor
{
    public class AFilterIIR
    {

        double _sampleRate;
        public double sampleRate
        {
            set { _sampleRate = value; reCalc(); }
            get { return _sampleRate; }
        }


        // Data for 44.1 kHz
        /*        double[] a =
                {
                    1,
                    11.5076015981588,
                    27.2035602500282,
                    -12.3933688489819,
                    -82.7532268206639,
                    -26.1432798480498,
                    81.6487181729756,
                    45.2048387161928,
                    -28.9439719728098,
                    -19.5962624959289,
                    2.02257498383719,
                    1.43533032615038,
                    -0.189864248643441
                };
                double[] b = 
                {
                    0.0876123724780696,
                    2.36570092608062,
                    12.4787701793635,
                    15.69685906973,
                    -23.2706491667066,
                    -58.0942308188492,
                    -6.0146204834604,
                    56.3786213650555,
                    31.423387338151,
                    -13.1004688741572,
                    -14.6282073715532,
                    -3.24823045080139,
                    -0.0745445212666291
                };
        */

        // Data for 48 kHz
        public class FilterDataset {
            public int fs;
            public double[] a;
            public double[] b;
        }
        public List<FilterDataset> datasets;
        public FilterDataset filterSet;


        // TimeData
        double[] x = new double[13];
        double[] y = new double[13];

        public AFilterIIR(double __sampleRate)
        {
            _sampleRate = __sampleRate;
            createFilters();

            reCalc();
        }

        private void createFilters()
        {
            datasets = new List<FilterDataset>();

            FilterDataset a;
            a = new FilterDataset();
            a.fs = 11025;
            a.b = new double[]
            {
                0.7736721075390028,
                -2.8625867978943105,
                3.7136261161872133,
                -1.7020786365858063,
                -0.1547344215078005,
                0.2321016322617008
            };
            a.a = new double[]
            {
                1.0000000000000000,
                -3.5757337829718345,
                4.7582766196624924,
                -2.7899757644608405,
                0.6085910689326314,
                -0.0011559137053395,
                0.0000005512739116
            };
            datasets.Add(a);

            a = new FilterDataset();
            a.fs = 22050;
            a.b = new double[]
            {
                0.8055484487647923,
                -2.9805292604297318,
                3.8666325540710029,
                -1.7722065872825432,
                -0.1611096897529584,
                0.2416645346294377
            };
            a.a = new double[]
            {
                1.0000000000000000,
                -3.8302763396909523,
                5.5476415277122415,
                -3.6541031162267403,
                0.9871997587068019,
                -0.0512041243503595,
                0.0007424782229829
            };
            datasets.Add(a);

            a = new FilterDataset();
            a.fs = 44100;
            a.b = new double[]
            {
                0.6180020317070465,
                -2.2866075173160723,
                2.9664097521938229,
                -1.3596044697555023,
                -0.1236004063414093,
                0.1854006095121139
            };
            a.a = new double[]
            {
                1.0000000000000000,
                -4.2307872496224137,
                7.0346422059383222,
                -5.7449460002195494,
                2.3363695685698880,
                -0.4225269693894642,
                0.0272484535888349
            }; datasets.Add(a);

            a = new FilterDataset();
            a.fs = 48000;
            a.b = new double[]
            {
                0.5815372712118925,
                -2.1516879034840022,
                2.7913789018170840,
                -1.2793819966661637,
                -0.1163074542423785,
                0.1744611813635678
            };
            a.a = new double[]
            {
                1.0000000000000000,
                -4.2935584346882125,
                7.2834260475956798,
                -6.1242473677395743,
                2.6089701629718975,
                -0.5111053205554470,
                0.0365149183602303
            };
            datasets.Add(a);

            a = new FilterDataset();
            a.fs = 96000;
            a.b = new double[]
            {
                0.2845855585491984,
                -1.0529665666320340,
                1.3660106810361521,
                -0.6260882288082365,
                -0.0569171117098397,
                0.0853756675647595
            };
            a.a = new double[]
            {
                1.0000000000000000,
                -4.8431509604790124,
                9.5812763956502831,
                -9.8758665218481614,
                5.5715967697266429,
                -1.6249444537578395,
                0.1910887708899461
            };
            datasets.Add(a);
        }

        private void reCalc()
        {
            int found = 0;
            int diff = (int)Math.Abs(datasets[0].fs - _sampleRate);
            for (int i = 1; i < datasets.Count; i++)
                if ((int)Math.Abs(datasets[i].fs - _sampleRate) < diff)
                {
                    diff = (int)Math.Abs(datasets[1].fs - _sampleRate);
                    found = i;
                }
            filterSet = datasets[found];
        }

        public double filter(double xin)
        {
            double yout;
            yout = filterSet.b[0] * xin;
            for (int i = 1; i < filterSet.b.Length; i++)
                yout += filterSet.b[i] * x[i - 1];
            for (int i = 1; i < filterSet.a.Length; i++)
                yout -= filterSet.a[i] * y[i - 1];

            for (int i = x.Length-1; i > 0; i--)
                x[i] = x[i - 1];
            x[0] = xin;
            for (int i = y.Length-1; i > 0; i--)
                y[i] = y[i - 1];
            y[0] = yout;

            //double y = b0 * x + b1 * x1 + b2 * x2 - a1 * y1 - a2 * y2;
            //x2 = x1;
            //x1 = x;
            //y2 = y1;
            //y1 = y;
            return yout;//  * scale;
        }
    }
}
