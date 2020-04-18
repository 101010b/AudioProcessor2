using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioProcessor.AsyncSinkSource
{
    public class ByteFIFO
    {

        byte[] buffer;
        int size;
        int write;
        int read;
        Boolean overflow;

        public ByteFIFO(int _size)
        {
            size = _size;
            buffer = new byte[size];
            read = write = 0;
            overflow = false;
        }

        public Boolean empty()
        {
            return (read == write);
        }

        public void flush()
        {
            read = write = 0;
        }

        public void flush(int len)
        {
            if (fill() < len) return;
            if (read + len >= size)
            {
                len -= (size - read);
                read = 0;
            }
            read += len;
        }

        public int fill()
        {
            return (write - read + size) % size;
        }

        public int space()
        {
            return size - 1 - (write - read + size) % size;
        }

        public void insert(byte[] src, int start, int len)
        {
            if (fill() + len > size - 1)
            {
                overflow = true;
                return;
            }
            if (write + len >= size)
            { // Need to Split
                Array.Copy(src, start, buffer, write, size - write);
                start += (size - write);
                len -= (size - write);
                write = 0;
            }
            Array.Copy(src, start, buffer, write, len);
            write += len;
        }

        public void insert(byte[] src, int len)
        {
            insert(src, 0, len);
        }

        public void insert(byte[] src)
        {
            insert(src, 0, src.Length);
        }

        public void insert(byte cnst, int len)
        {
            if (fill() + len > size - 1)
            {
                overflow = true;
                return;
            }
            if (write + len >= size)
            { // Need to Split
                if (cnst == 0)
                    Array.Clear(buffer, write, size - write);
                else
                    for (int i = write; i < size; i++)
                        buffer[i] = cnst;
                len -= (size - write);
                write = 0;
            }
            if (cnst == 0)
                Array.Clear(buffer, write, len);
            else
                for (int i = write; i < write + len; i++)
                    buffer[i] = cnst;
            write += len;
        }

        public Boolean retrieve(ref byte[] tgt, int start, int len)
        {
            if (fill() < len) return false;
            if (read + len >= size)
            { // Need to Split
                Array.Copy(buffer, read, tgt, start, (size - read));
                start += (size - read);
                len -= (size - read);
                read = 0;
            }
            Array.Copy(buffer, read, tgt, start, len);
            read += len;
            return true;
        }

        public Boolean retrieve(ref byte[] tgt, int len)
        {
            return retrieve(ref tgt, 0, len);
        }

        public Boolean retrieve(ref byte[] tgt)
        {
            return retrieve(ref tgt, 0, tgt.Length);
        }



    }
}
