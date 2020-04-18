using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioProcessor.SinkSource
{
    public class OsciFIFO
    {

        public int maxSize;
        public double[] data;
        public int fill;
        public int write;
        public double[] tempBuf;

        public Boolean ACmode;
        public double ACavg;
        public Boolean searchTrigger;
        public Boolean triggerRising;
        public double triggerLevel;
        public double triggerHyst;
        public Boolean triggered;
        public int lastTriggerPos;
        public Boolean trigAC;
        private int trigMaxWait;
        public int noTriggerTime;

        private enum TrigState
        {
            Waiting,
            Armed
        }
        TrigState trigState;

        public OsciFIFO(int _maxSize)
        {
            maxSize = _maxSize;
            data = new double[maxSize];
            ACmode = false;
            ACavg = 0;
            searchTrigger = false;
            triggerLevel = 0;
            trigAC = false;
            triggerHyst = 0.01;
            triggered = false;
            lastTriggerPos = -1;
            trigMaxWait = 0;
            noTriggerTime = 0;
            write = 0;
            fill = 0;
            tempBuf = new double[32];
            triggerRising = true;
        }

        public void insert(double [] buffer, int pos, int len)
        {
            while (len > 0) {
                double val = buffer[pos];
                pos++;len--;

                data[write] = val;
                ACavg = ACavg * 0.999 + val * 0.001; // Low Pass
                if (fill < maxSize) fill++;

                trigMaxWait++;
                if (searchTrigger && !triggered)
                {
                    if (trigAC)
                        val = val - ACavg;
                    if (triggerRising)
                        val = val - triggerLevel;
                    else
                        val = triggerLevel - val;
                    switch (trigState)
                    {
                        case TrigState.Waiting:
                            if (val < -triggerHyst)
                                trigState = TrigState.Armed;
                            break;
                        case TrigState.Armed:
                            if (val > 0)
                            {
                                triggered = true;
                                trigMaxWait = 0;
                                lastTriggerPos = 0;
                                trigState = TrigState.Waiting;
                            }
                            break;                                    
                    }
                    if (!triggered && noTriggerTime > 0)
                    {
                        // Auto Trigger
                        if (trigMaxWait > noTriggerTime)
                        {
                            triggered = true;
                            lastTriggerPos = 0;
                            trigMaxWait = 0;
                            trigState = TrigState.Waiting;
                        }

                    }
                }
                write++;
                if (triggered)
                {
                    lastTriggerPos--;
                    if (lastTriggerPos <= -maxSize) {
                        lastTriggerPos = 0;
                        triggered = false;
                    }
                }
                if (write >= maxSize) write = 0;
            }
        }

        public void reTrigger()
        {
            trigMaxWait = 0;
            triggered = false;
        }

        public void insert(double [] buffer, int len)
        {
            insert(buffer, 0, len);
        }

        public void insert(FIFO f, int len)
        {
            if (f.fill() >= len)
            {
                if (len > 32)
                {
                    f.retrieve(ref tempBuf, 32);
                    insert(tempBuf, 0, 32);
                    len -= 32;
                }
                else
                {
                    f.retrieve(ref tempBuf, len);
                    insert(tempBuf, 0, 32);
                    len = 0;
                }
            }
        }

        private double getFrom(int v)
        {
            if (-v >= fill) return 0.0;
            int a = (write -1 + v + 2 * maxSize) % maxSize;
            return data[a];            
        }

        public Boolean retrieve(ref double[] bufMax, ref double[] bufMin, int bufLen, int from, int len)
        {
            if (bufLen > len)
            {
                // extrapolate
                for (int i=0;i < bufLen;i++)
                {
                    int j = from + (i * (len - 1) / (bufLen - 1));
                    if (ACmode)
                        bufMax[i] = bufMin[i] = getFrom(j) - ACavg;
                    else
                        bufMax[i] = bufMin[i] = getFrom(j);
                }
                return false;
            } else if (bufLen == len)
            {
                // copy
                for (int i=0;i<bufLen;i++)
                {
                    int j = from + i;
                    if (ACmode)
                        bufMax[i] = bufMin[i] = getFrom(j) - ACavg;
                    else
                        bufMax[i] = bufMin[i] = getFrom(j);
                }
                return false;
            } else
            {
                // interpolate
                for (int i=0;i<bufLen;i++)
                {
                    int j1 = from + (i * (len - 1) / (bufLen - 1));
                    int j2 = from + ((i+1) * (len - 1) / (bufLen - 1))-1;
                    double smin = getFrom(j1);
                    if (ACmode) smin -= ACavg;
                    double smax = smin;
                    if (j1 != j2) {
                        int j = j1 + 1;
                        while (j != j2)
                        {
                            double d = getFrom(j);
                            if (ACmode) d -= ACavg;
                            if (d < smin) smin = d;
                            if (d > smax) smax = d;
                            j++; 
                        }
                    }
                    if (ACmode)
                    {
                        bufMax[i] = smax-ACavg;
                        bufMin[i] = smin-ACavg;
                    } else
                    {
                        bufMax[i] = smax;
                        bufMin[i] = smin;
                    }
                }
                return true;
            }
        }
    }
}
