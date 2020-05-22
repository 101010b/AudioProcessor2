using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioProcessor
{
    public class SignalBuffer
    {

        public int size;
        public double[] data;

        public SignalBuffer(int _size)
        {
            size = _size;
            data = new double[size];
        }

        public void zero()
        {
            Array.Clear(data, 0, size);
        }

        public void one()
        {
            for (int i = 0; i < size; i++) data[i] = 1.0;
        }

        public void CopyFrom(SignalBuffer ip)
        {
            Array.Copy(ip.data, data, size);
        }

        public void SetTo(double val)
        {
            if (val == 0)
                Array.Clear(data, 0, size);
            else
                for (int i = 0; i < size; i++) data[i] = val;
        }

    }
}
