using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.Wave;
using NAudio.Wave.Asio;
using System.IO;


namespace AudioProcessor.RealtimeSinkSource
{
    public class GenericNAudioSinkSource : RTForm
    {
        /* General Architecture of this abstract class which manages the synchronization basics 
         * Nomenclature:
         * fromDriver* - Functions and Variables that deal with the direction from the HW driver towards this Software 
         * toDriver* -  Functions and Variables that deal with the direction from this Software towards the HW driver
         */

        protected int fromDriverChannels;
        protected int toDriverChannels;

        public int overrun;
        Boolean prevstate = false;
        Boolean fromDriverStarted = false;
        Boolean toDriverStarted = false;

        private RTIO[] IOfromDriver;
        private RTIO[] IOtoDriver;

        public enum SinkSourceMode
        {
            Offline,
            Error,
            GoOnline,
            Online,
            Disconnect
        }

        protected SinkSourceMode sinkSourceMode;
        FIFO[] fromDriver;
        FIFO[] toDriver;
        double[] tempBuf;

        public RTLED overflowLED = null;

        public void setChannels(RTIO[] _fromDriverChannels, RTIO[] _toDriverChannels)
        {
            if (_fromDriverChannels == null)
                fromDriverChannels = 0;
            else
               fromDriverChannels = _fromDriverChannels.Count();
            if (_toDriverChannels == null)
                toDriverChannels = 0;
            else
                toDriverChannels = _toDriverChannels.Count();

            if (fromDriverChannels == 0)
            {
                fromDriver = null;
                IOfromDriver = null;
                // ioRefFromDriver = null;
            } else
            {
                fromDriver = new FIFO[fromDriverChannels];
                for (int i = 0; i < fromDriverChannels; i++)
                    fromDriver[i] = new FIFO(16384);
                IOfromDriver = _fromDriverChannels;
                // ioRefFromDriver = new int[fromDriverChannels];
                // for (int i = 0; i < fromDriverChannels; i++)
                //    ioRefFromDriver[i] = -1;
            }

            if (toDriverChannels == 0)
            {
                toDriver = null;
                IOtoDriver = null;
                // ioRefToDriver = null;
            } else
            {
                toDriver = new FIFO[toDriverChannels];
                for (int i = 0; i < toDriverChannels; i++)
                    toDriver[i] = new FIFO(16384);
                IOtoDriver = _toDriverChannels;
                // ioRefToDriver = new int[toDriverChannels];
                // for (int i = 0; i < toDriverChannels; i++)
                //     ioRefToDriver[i] = -1;
            }

        }

        public GenericNAudioSinkSource():base()
        {
            setChannels(null, null);
            overrun = 0;
            prevstate = false;
            fromDriverStarted = false;
            toDriverStarted = false;
            sinkSourceMode = SinkSourceMode.Offline;
        }

        public GenericNAudioSinkSource(SystemPanel _owner, BinaryReader src) : base(_owner, src)
        {
            setChannels(null, null);
            overrun = 0;
            prevstate = false;
            fromDriverStarted = false;
            toDriverStarted = false;
            sinkSourceMode = SinkSourceMode.Offline;
        }

        public override void writeToFile(BinaryWriter tgt)
        {
            base.writeToFile(tgt);
        }

        protected class NAudioShortWaveProvider : WaveProvider16
        {
            GenericNAudioSinkSource src;
            double[] buf = new double[16];

            public NAudioShortWaveProvider(GenericNAudioSinkSource _src) : base()
            {
                src = _src;
            }

            private short DoubleToShort(double a)
            {
                a *= 32768;
                if (a > 32767.0) return 32767;
                if (a < -32768.0) return -32768;
                return (short)Math.Floor(a + 0.5);
            }

            public override int Read(short[] buffer, int offset, int sampleCount)
            {
                int ch = src.toDriverChannels;

                int samples = sampleCount / ch;

                if (!src.toDriverStarted)
                {
                    if (src.toDriver[0].fill() >= src.owner.startSinkMinFill)
                        src.toDriverStarted = true;
                }
                if (src.toDriverStarted && (src.toDriver[0].fill() >= samples))
                {
                    int N = 0;
                    int M = 0;

                    while (sampleCount >= ch)
                    {
                        if (sampleCount > 16 * ch)
                            N = 16 * ch;
                        else
                            N = (sampleCount / ch) * ch;
                        int saveoffset = offset;
                        for (int i = 0; i < ch; i++)
                        {
                            offset = saveoffset + i;
                            src.toDriver[i].retrieve(ref buf, N / ch);
                            for (int j = 0; j < N / ch; j++)
                            {
                                buffer[offset] = DoubleToShort(buf[j]); offset += ch;
                            }
                        }
                        offset = saveoffset + N;
                        sampleCount -= N;
                        M += N;
                    }
                    return M;
                }
                else
                {
                    // Fill with zeros
                    Array.Clear(buffer, offset, sampleCount);
                    if (src.toDriverStarted)
                    {
                        src.toDriverStarted = false;
                        src.overrun = src.owner.overrunCounterStart;
                    }
                    return sampleCount;
                }
            }
        }

        protected NAudioShortWaveProvider waveProvider;

        private int min(int a, int b) { return (a < b) ? a : b; }


        // Handle Disconnect form the driver
        protected virtual void driverDisconnect() { }

        // Handle Connection
        protected virtual SinkSourceMode driverConnect() { return SinkSourceMode.Error; }

        public override void tick()
        {
            // Handle Overrun
            if (overrun > 0) overrun--;
            if (overrun > 0)
            {
                if (prevstate == false)
                {
                    if (overflowLED != null)
                        overflowLED.LEDState = true;
                    // ((Controls.LED)ctrl[1]).state = true;
                    // needsDrawingUpdate = true;
                }
                prevstate = true;
            }
            else
            {
                if (prevstate == true)
                {
                    if (overflowLED != null)
                        overflowLED.LEDState = false;
                    // ((Controls.LED)ctrl[1]).state = false;
                    // needsDrawingUpdate = true;

                }
                prevstate = false;
            }

            if (sinkSourceMode == SinkSourceMode.Disconnect)
            {
                driverDisconnect();
                sinkSourceMode = SinkSourceMode.Offline;
            }

            if (sinkSourceMode == SinkSourceMode.GoOnline)
            {
                fromDriverStarted = toDriverStarted = false;
                sinkSourceMode = driverConnect();
            }

            if (sinkSourceMode == SinkSourceMode.Online)
            {
                if (fromDriverChannels > 0)
                {
                    if (!fromDriverStarted)
                    {
                        if (fromDriver[0].fill() > owner.startSourceMinFill)
                            fromDriverStarted = true;
                    }

                    if (fromDriverStarted && (fromDriver[0].fill() >= owner.blockSize))
                    {
                        for (int i = 0; i < fromDriverChannels; i++)
                            if (IOfromDriver[i] != null)
                            {
                                if (_active && (IOfromDriver[i].connectedTo != null))
                                    fromDriver[i].retrieve(IOfromDriver[i].connectedTo.input, 0.0);
                                else
                                    fromDriver[i].flush(owner.blockSize);
                            }
                    }
                    else
                    {
                        if (fromDriverStarted)
                        {
                            fromDriverStarted = false;
                            overrun = owner.overrunCounterStart;
                        }
                    }
                }

                if (toDriverChannels > 0)
                {
                    if (toDriver[0].space() < owner.blockSize)
                    {
                        overrun = owner.overrunCounterStart;
                        toDriverStarted = false;
                        for (int i = 0; i < toDriverChannels; i++)
                            toDriver[i].flush();
                    }
                    else
                    {
                        for (int i = 0; i < toDriverChannels; i++)
                            if (IOtoDriver[i] != null)
                            {
                                if (_active && (IOtoDriver[i].connectedTo != null))
                                    toDriver[i].insert(IOtoDriver[i].connectedTo.output);
                                else
                                    toDriver[i].insert(0, owner.blockSize);
                            }
                    }
                }

            }
        }

        public override double inQueueLow()
        {
            if (fromDriverChannels <= 0)
                return 0.0;
            if (fromDriver[0].fill() < owner.startInSleepFill)
                // return (double)owner.startInSleepFill / (double)owner.sampleRate / 2;
                return (double)fromDriver[0].fill() / (double)owner.sampleRate / 4;
            return 0.0;
        }

        public override double outQueueHigh()
        {
            if (toDriverChannels <= 0)
                return 0.0;
            if (toDriver[0].fill() > owner.startOutSleepFill)
                // return (double)owner.startOutSleepFill / (double)owner.sampleRate / 2;
                return (double)toDriver[0].fill() / (double)owner.sampleRate / 4;
            return 0.0;
        }

        protected WaveFormatEncoding WASAPIDataFormat;

        protected void WASAPI_DataAvailable(object sender, WaveInEventArgs e)
        {
            int samples = 0;
            switch (WASAPIDataFormat)
            {
                case WaveFormatEncoding.IeeeFloat:
                    samples = e.BytesRecorded / 8;
                    break;
                case WaveFormatEncoding.Pcm:
                    samples = e.BytesRecorded / 4;
                    break;
            }
            if (samples == 0)
                return;

            if ((tempBuf == null) || (tempBuf.Length != samples))
                tempBuf = new double[samples];

            if (fromDriver[0].space() < samples)
            {
                fromDriverStarted = false;
                if (owner != null)
                    overrun = owner.overrunCounterStart;
                return;
            }


            switch (WASAPIDataFormat)
            {
                case WaveFormatEncoding.IeeeFloat:
                    for (int i = 0; i < samples; i++)
                        tempBuf[i] = (double)BitConverter.ToSingle(e.Buffer, i * 8) / 1.0;
                    fromDriver[0].insert(tempBuf);
                    for (int i = 0; i < samples; i++)
                        tempBuf[i] = (double)BitConverter.ToSingle(e.Buffer, i * 8 + 4) / 1.0;
                    fromDriver[1].insert(tempBuf);
                    break;
                case WaveFormatEncoding.Pcm:
                    for (int i = 0; i < samples; i++)
                        tempBuf[i] = (double)BitConverter.ToInt16(e.Buffer, i * 4) / 32767.0;
                    fromDriver[0].insert(tempBuf);
                    for (int i = 0; i < samples; i++)
                        tempBuf[i] = (double)BitConverter.ToInt16(e.Buffer, i * 4 + 2) / 32767.0;
                    fromDriver[1].insert(tempBuf);
                    break;
            }
        }

        protected void WaveIn_DataAvailable(object sender, WaveInEventArgs e)
        {
            if (owner == null) return;
            int smps = e.BytesRecorded / 2 / fromDriverChannels;
            if (smps == 0)
                return;

            if ((tempBuf == null) || (tempBuf.Length != smps))
                tempBuf = new double[smps];

            if (fromDriver[0].space() < smps)
            {
                fromDriverStarted = false;
                overrun = owner.overrunCounterStart;
                return;
            }

            for (int j = 0; j < fromDriverChannels; j++)
            {
                int ofs = 2 * j;
                for (int i = 0; i < smps; i++)
                    tempBuf[i] = (double)BitConverter.ToInt16(e.Buffer, i * 2 * fromDriverChannels + ofs) / 32767.0;
                fromDriver[j].insert(tempBuf);
            }
        }

        private float[] ASIOinputSMPS;
        protected void ASIO_AudioAvailable(object sender, AsioAudioAvailableEventArgs e)
        {
            if (owner == null)
                return;
            int samples = e.SamplesPerBuffer;
            if (ASIOinputSMPS != null)
                e.GetAsInterleavedSamples(ASIOinputSMPS);
            else
                ASIOinputSMPS = e.GetAsInterleavedSamples();

            int offset = 0;
            if (tempBuf == null)
                tempBuf = new double[32];

            if (fromDriver[0].space() < samples)
            {
                fromDriverStarted = false;
                overrun = owner.overrunCounterStart;
                return;
            }

            while (samples > 0)
            {
                int N = 32;
                if (samples < N) N = samples;
                for (int j = 0; j < fromDriverChannels; j++)
                {
                    for (int i = 0; i < N; i++)
                        tempBuf[i] = ASIOinputSMPS[offset + j + i * fromDriverChannels];
                    fromDriver[j].insert(tempBuf, N);
                }
                offset += N * fromDriverChannels;
                samples -= N;
            }
        }

        public override void WorkDisconnect()
        {
            driverDisconnect();
        }

        public override void Disconnect()
        {
            base.Disconnect();
            owner.CallElementWorkDisconnect(this); // This will call WorkDisconnect in the Work Thread
        }


    }
}
