using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioProcessor
{
    public class DynamicDelay
    {
        UInt32 bufferlen;
        double[] buffer;
        UInt32 write;

        public DynamicDelay():this(1024)
        {
        }
        
        public DynamicDelay(UInt32 _bufferlen)
        {
            if (_bufferlen < 1)
                throw new Exception("Bad Paremeter for Dynamic Buffer");
            bufferlen = _bufferlen;
            write = 0;
            buffer = new double[bufferlen];
        }

        public void Store(double d)
        {
            write++;
            if (write >= bufferlen) write -= bufferlen;
            buffer[write] = d;
        }

        public double Fetch(UInt32 delay)
        {
            if (delay >= bufferlen)
                extendBuffer(delay + 1024);
            UInt32 read = (write + bufferlen - delay) % bufferlen;
            return buffer[read];
        }

        private void extendBuffer(UInt32 newLen)
        {
            double[] newbuf = new double[newLen];
            UInt32 backcopy = bufferlen - write - 1;
            if (backcopy > 0)
                Array.Copy(buffer, write + 1, newbuf, 0, backcopy);
            if (bufferlen > backcopy)
                Array.Copy(buffer, 0, newbuf, backcopy, bufferlen - backcopy);
            buffer = newbuf;
            write = bufferlen - 1;
            bufferlen = newLen;
        }


    }
}
