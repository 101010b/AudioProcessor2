using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioProcessor
{
    public class DataBuffer
    {

        public int size
        {
            get { return (data == null) ? 0 : data.Length; }
        }
        public double[] data;

        public DataBuffer()
        {
            data = null;
        }

        public void clear()
        {
            data = null;
        }

        public void initialize(int _size)
        {
            data = new double[_size];
        }

        public void CopyFrom(DataBuffer d)
        {
            if ((d == null) || (d.data == null))
            {
                data = null;
                return;
            }
            if ((data == null) || (data.Length != d.data.Length))
                data = new double[d.data.Length];
            Array.Copy(d.data, data, data.Length);
        }

        public void set(int i, double d)
        {
            if ((data == null) || (i < 0) || (i >= data.Length)) return;
            data[i] = d;
        }

        public void set(double[] d)
        {
            if ((d == null) || (d.Length == 0)) return;
            if (data.Length != d.Length)
                data = new double[d.Length];
            Array.Copy(d, data, d.Length);
        }

        public void set(double[] d, int start, int len)
        {
            if ((d == null) || (d.Length == 0))
                return;
            if (start >= d.Length)
                return;
            int last = start + len - 1;
            if (last >= d.Length)
                last = d.Length - 1;
            len = last - start + 1;
            if (len < 1)
                return;
            if (len != data.Length)
                data = new double[d.Length];
            Array.Copy(d, start, data, 0, len);
        }

        public double get(int i)
        {
            if ((data == null) || (i < 0) || (i >= data.Length)) return 0.0;
            return data[i];
        }

        public double[] get()
        {
            return data;
        }
        

    }
}
