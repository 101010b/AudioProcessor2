﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AudioProcessor.SinkSource
{
    public class VNA : RTForm
    {

        public void InitializeComponent()
        {
            this.ioB1 = new AudioProcessor.RTIO();
            this.ioB2 = new AudioProcessor.RTIO();
            this.ioB3 = new AudioProcessor.RTIO();
            this.ioB4 = new AudioProcessor.RTIO();
            this.ioB5 = new AudioProcessor.RTIO();
            this.ioB6 = new AudioProcessor.RTIO();
            this.ioB7 = new AudioProcessor.RTIO();
            this.ioB8 = new AudioProcessor.RTIO();
            this.ioA = new AudioProcessor.RTIO();
            this.ioRF = new AudioProcessor.RTIO();
            this.bnDisplayWin = new AudioProcessor.RTButton();
            this.SuspendLayout();
            // 
            // ioB1
            // 
            this.ioB1.contactBackColor = System.Drawing.Color.Black;
            this.ioB1.contactColor = System.Drawing.Color.DimGray;
            this.ioB1.Location = new System.Drawing.Point(0, 55);
            this.ioB1.Name = "ioB1";
            this.ioB1.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.ioB1.showTitle = true;
            this.ioB1.Size = new System.Drawing.Size(54, 20);
            this.ioB1.TabIndex = 0;
            this.ioB1.Text = "rtio1";
            this.ioB1.title = "B1";
            this.ioB1.titleColor = System.Drawing.Color.DimGray;
            this.ioB1.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioB1.IOtype = AudioProcessor.RTIO.ProcessingIOType.SignalInput;
            // 
            // ioB2
            // 
            this.ioB2.contactBackColor = System.Drawing.Color.Black;
            this.ioB2.contactColor = System.Drawing.Color.DimGray;
            this.ioB2.Location = new System.Drawing.Point(0, 81);
            this.ioB2.Name = "ioB2";
            this.ioB2.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.ioB2.showTitle = true;
            this.ioB2.Size = new System.Drawing.Size(54, 20);
            this.ioB2.TabIndex = 1;
            this.ioB2.Text = "rtio2";
            this.ioB2.title = "B2";
            this.ioB2.titleColor = System.Drawing.Color.DimGray;
            this.ioB2.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioB2.IOtype = AudioProcessor.RTIO.ProcessingIOType.SignalInput;
            // 
            // ioB3
            // 
            this.ioB3.contactBackColor = System.Drawing.Color.Black;
            this.ioB3.contactColor = System.Drawing.Color.DimGray;
            this.ioB3.Location = new System.Drawing.Point(0, 107);
            this.ioB3.Name = "ioB3";
            this.ioB3.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.ioB3.showTitle = true;
            this.ioB3.Size = new System.Drawing.Size(54, 20);
            this.ioB3.TabIndex = 2;
            this.ioB3.Text = "rtio3";
            this.ioB3.title = "B3";
            this.ioB3.titleColor = System.Drawing.Color.DimGray;
            this.ioB3.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioB3.IOtype = AudioProcessor.RTIO.ProcessingIOType.SignalInput;
            // 
            // ioB4
            // 
            this.ioB4.contactBackColor = System.Drawing.Color.Black;
            this.ioB4.contactColor = System.Drawing.Color.DimGray;
            this.ioB4.Location = new System.Drawing.Point(0, 133);
            this.ioB4.Name = "ioB4";
            this.ioB4.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.ioB4.showTitle = true;
            this.ioB4.Size = new System.Drawing.Size(54, 20);
            this.ioB4.TabIndex = 3;
            this.ioB4.Text = "rtio4";
            this.ioB4.title = "B4";
            this.ioB4.titleColor = System.Drawing.Color.DimGray;
            this.ioB4.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioB4.IOtype = AudioProcessor.RTIO.ProcessingIOType.SignalInput;
            // 
            // ioB5
            // 
            this.ioB5.contactBackColor = System.Drawing.Color.Black;
            this.ioB5.contactColor = System.Drawing.Color.DimGray;
            this.ioB5.Location = new System.Drawing.Point(0, 159);
            this.ioB5.Name = "ioB5";
            this.ioB5.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.ioB5.showTitle = true;
            this.ioB5.Size = new System.Drawing.Size(54, 20);
            this.ioB5.TabIndex = 4;
            this.ioB5.Text = "rtio5";
            this.ioB5.title = "B5";
            this.ioB5.titleColor = System.Drawing.Color.DimGray;
            this.ioB5.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioB5.IOtype = AudioProcessor.RTIO.ProcessingIOType.SignalInput;
            // 
            // ioB6
            // 
            this.ioB6.contactBackColor = System.Drawing.Color.Black;
            this.ioB6.contactColor = System.Drawing.Color.DimGray;
            this.ioB6.Location = new System.Drawing.Point(0, 185);
            this.ioB6.Name = "ioB6";
            this.ioB6.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.ioB6.showTitle = true;
            this.ioB6.Size = new System.Drawing.Size(54, 20);
            this.ioB6.TabIndex = 5;
            this.ioB6.Text = "rtio6";
            this.ioB6.title = "B6";
            this.ioB6.titleColor = System.Drawing.Color.DimGray;
            this.ioB6.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioB6.IOtype = AudioProcessor.RTIO.ProcessingIOType.SignalInput;
            // 
            // ioB7
            // 
            this.ioB7.contactBackColor = System.Drawing.Color.Black;
            this.ioB7.contactColor = System.Drawing.Color.DimGray;
            this.ioB7.Location = new System.Drawing.Point(0, 211);
            this.ioB7.Name = "ioB7";
            this.ioB7.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.ioB7.showTitle = true;
            this.ioB7.Size = new System.Drawing.Size(54, 20);
            this.ioB7.TabIndex = 6;
            this.ioB7.Text = "rtio7";
            this.ioB7.title = "B7";
            this.ioB7.titleColor = System.Drawing.Color.DimGray;
            this.ioB7.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioB7.IOtype = AudioProcessor.RTIO.ProcessingIOType.SignalInput;
            // 
            // ioB8
            // 
            this.ioB8.contactBackColor = System.Drawing.Color.Black;
            this.ioB8.contactColor = System.Drawing.Color.DimGray;
            this.ioB8.Location = new System.Drawing.Point(0, 237);
            this.ioB8.Name = "ioB8";
            this.ioB8.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.ioB8.showTitle = true;
            this.ioB8.Size = new System.Drawing.Size(54, 20);
            this.ioB8.TabIndex = 7;
            this.ioB8.Text = "rtio8";
            this.ioB8.title = "B8";
            this.ioB8.titleColor = System.Drawing.Color.DimGray;
            this.ioB8.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioB8.IOtype = AudioProcessor.RTIO.ProcessingIOType.SignalInput;
            // 
            // ioA
            // 
            this.ioA.contactBackColor = System.Drawing.Color.Black;
            this.ioA.contactColor = System.Drawing.Color.DimGray;
            this.ioA.Location = new System.Drawing.Point(0, 29);
            this.ioA.Name = "ioA";
            this.ioA.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.ioA.showTitle = true;
            this.ioA.Size = new System.Drawing.Size(54, 20);
            this.ioA.TabIndex = 8;
            this.ioA.Text = "rtio9";
            this.ioA.title = "A";
            this.ioA.titleColor = System.Drawing.Color.DimGray;
            this.ioA.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioA.IOtype = AudioProcessor.RTIO.ProcessingIOType.SignalInput;
            // 
            // ioRF
            // 
            this.ioRF.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ioRF.contactBackColor = System.Drawing.Color.Black;
            this.ioRF.contactColor = System.Drawing.Color.DimGray;
            this.ioRF.Location = new System.Drawing.Point(138, 29);
            this.ioRF.Name = "ioRF";
            this.ioRF.orientation = AudioProcessor.RTIO.RTOrientation.East;
            this.ioRF.showTitle = true;
            this.ioRF.Size = new System.Drawing.Size(56, 20);
            this.ioRF.TabIndex = 9;
            this.ioRF.Text = "rtio1";
            this.ioRF.title = "RF";
            this.ioRF.titleColor = System.Drawing.Color.DimGray;
            this.ioRF.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioRF.IOtype = AudioProcessor.RTIO.ProcessingIOType.SignalOutput;
            // 
            // bnDisplayWin
            // 
            this.bnDisplayWin.buttonDim = new System.Drawing.Size(60, 20);
            this.bnDisplayWin.buttonState = false;
            this.bnDisplayWin.buttonType = AudioProcessor.RTButton.RTButtonType.ClickButton;
            this.bnDisplayWin.fillOffColor = System.Drawing.Color.Black;
            this.bnDisplayWin.fillOnColor = System.Drawing.Color.DarkRed;
            this.bnDisplayWin.frameHoldColor = System.Drawing.Color.Yellow;
            this.bnDisplayWin.frameOffColor = System.Drawing.Color.DimGray;
            this.bnDisplayWin.frameOnColor = System.Drawing.Color.Red;
            this.bnDisplayWin.Location = new System.Drawing.Point(60, 27);
            this.bnDisplayWin.Name = "bnDisplayWin";
            this.bnDisplayWin.offText = "Display";
            this.bnDisplayWin.onText = "Display";
            this.bnDisplayWin.Size = new System.Drawing.Size(70, 22);
            this.bnDisplayWin.TabIndex = 10;
            this.bnDisplayWin.Text = "rtButton1";
            this.bnDisplayWin.textFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.bnDisplayWin.textOffColor = System.Drawing.Color.DimGray;
            this.bnDisplayWin.textOnColor = System.Drawing.Color.Red;
            this.bnDisplayWin.title = "Button";
            this.bnDisplayWin.titleColor = System.Drawing.Color.DimGray;
            this.bnDisplayWin.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.bnDisplayWin.titlePos = AudioProcessor.RTButton.RTTitlePos.Off;
            // 
            // VNA
            // 
            this.canShrink = false;
            this.Controls.Add(this.bnDisplayWin);
            this.Controls.Add(this.ioRF);
            this.Controls.Add(this.ioA);
            this.Controls.Add(this.ioB8);
            this.Controls.Add(this.ioB7);
            this.Controls.Add(this.ioB6);
            this.Controls.Add(this.ioB5);
            this.Controls.Add(this.ioB4);
            this.Controls.Add(this.ioB3);
            this.Controls.Add(this.ioB2);
            this.Controls.Add(this.ioB1);
            this.hasActiveSwitch = false;
            this.Name = "VNA";
            this.Size = new System.Drawing.Size(194, 264);
            this.title = "VNA";
            this.ResumeLayout(false);

        }

        VNAWin ow;

        public int channels;

        public class vnaconfig
        {
            // Display
            public enum PlotMode
            {
                absA, absB, absBA, logA, logB, logBA, phiBA, phiA, phiB
            }
            public readonly string[] PlotModeNames = new string[] 
            {
                "abs(A)", "abs(B)", "abs(B/A)", "A[dBFS]", "B[dBFS]", "B/A[dBFS]","Phi(B/A)","Phi(A)", "Phi(B)"
            };
            public bool displayDual;
            public double displayFMin;
            public double displayFMax;
            public bool displayLogF;
            public PlotMode displayPlotY1;
            public PlotMode displayPlotY2;
            public double displayY1Min;
            public double displayY1Max;
            public double displayY2Min;
            public double displayY2Max;


            // Sweep
            public bool sweepLogF;
            public double sweepFMin;
            public double sweepFMax;
            public int sweepPoints;
            public double sweepLoopDelay;
            public int sweepMPeriods;

            // Corrections
            public int compPhaseBlocks;

            public vnaconfig()
            {
                displayDual = false;
                displayFMin = 100;
                displayFMax = 10000;
                displayLogF = true;
                displayPlotY1 = PlotMode.logBA;
                displayPlotY2 = PlotMode.phiBA;
                displayY1Min = -120;
                displayY1Max = 20;
                displayY2Min = -180;
                displayY2Max = 180;
                sweepLogF = true;
                sweepFMin = 100;
                sweepFMax = 10000;
                sweepPoints = 61;
                sweepLoopDelay = 0.7;
                sweepMPeriods = 20;
                compPhaseBlocks = 0;
            }

            public vnaconfig(BinaryReader src)
            {
                displayDual = src.ReadBoolean();
                displayFMin = src.ReadDouble();
                displayFMax = src.ReadDouble();
                displayLogF = src.ReadBoolean();
                displayPlotY1 = (PlotMode)src.ReadInt32();
                displayPlotY2 = (PlotMode)src.ReadInt32();
                displayY1Min = src.ReadDouble();
                displayY1Max = src.ReadDouble();
                displayY2Min = src.ReadDouble();
                displayY2Max = src.ReadDouble();
                sweepLogF = src.ReadBoolean();
                sweepFMin = src.ReadDouble();
                sweepFMax = src.ReadDouble();
                sweepPoints = src.ReadInt32();
                sweepLoopDelay = src.ReadDouble();
                sweepMPeriods = src.ReadInt32();
                compPhaseBlocks = src.ReadInt32();
            }

            public void write(BinaryWriter tgt)
            {
                tgt.Write(displayDual);
                tgt.Write(displayFMin);
                tgt.Write(displayFMax);
                tgt.Write(displayLogF);
                tgt.Write((int)displayPlotY1);
                tgt.Write((int)displayPlotY2);
                tgt.Write(displayY1Min);
                tgt.Write(displayY1Max);
                tgt.Write(displayY2Min);
                tgt.Write(displayY2Max);
                tgt.Write(sweepLogF);
                tgt.Write(sweepFMin);
                tgt.Write(sweepFMax);
                tgt.Write(sweepPoints);
                tgt.Write(sweepLoopDelay);
                tgt.Write(sweepMPeriods);
                tgt.Write(compPhaseBlocks);
            }
        }

        public bool running;
        private bool stopnow;
        public vnaconfig config;

        // Current sweep setup
        private double fstart;
        private double fstop;
        private bool logsweep;
        private int periods;
        private int step;
        private int steps;
        private int substep;
        private double f;
        private enum VNAState
        {
            Idle,
            WaitDelay,
            Measuring
        }
        private VNAState vnaState;
        private double ASINint;
        private double ACOSint;
        private double[] BSINint;
        private double[] BCOSint;
        private int delaySamples;
        private int intCount;
        private double phi;
        private RTIO ioB1;
        private RTIO ioB2;
        private RTIO ioB3;
        private RTIO ioB4;
        private RTIO ioB5;
        private RTIO ioB6;
        private RTIO ioB7;
        private RTIO ioB8;
        private RTIO ioA;
        private RTIO ioRF;
        private RTButton bnDisplayWin;

        public class DataPoint
        {
            public double f;
            public Complex A;
            public Complex[] B;

            public DataPoint(int channels)
            {
                B = new Complex[channels];
            }

        }

        public class DataPointFifo
        {
            int size;
            DataPoint[] data;
            int write;
            int read;

            public DataPointFifo(int _size)
            {
                size = _size;
                data = new DataPoint[size];
                write = read = 0;
            }

            public void put(DataPoint dp)
            {
                if ((write + 1) % size == read) 
                    return; // FULL
                data[write] = dp;
                write = (write + 1) % size;
            }

            public DataPoint get()
            {
                DataPoint d = null;
                if (write == read)
                    return d; // Empty
                d = data[read];
                data[read] = null;
                read = (read + 1) % size;
                return d;
            }

            public void flush()
            {
                write = read = 0;
            }

            public Boolean empty()
            {
                return (write == read);
            }
        }

        public DataPointFifo dataFifo;

        private void init()
        {
            InitializeComponent();

            int h = Height;
            if (channels < 8) { ioB8.Hide(); h = ioB8.Location.Y; }
            if (channels < 7) { ioB7.Hide(); h = ioB7.Location.Y; }
            if (channels < 6) { ioB6.Hide(); h = ioB6.Location.Y; }
            if (channels < 5) { ioB5.Hide(); h = ioB5.Location.Y; }
            if (channels < 4) { ioB4.Hide(); h = ioB4.Location.Y; }
            if (channels < 3) { ioB3.Hide(); h = ioB3.Location.Y; }
            if (channels < 2) { ioB2.Hide(); h = ioB2.Location.Y; }
            if (channels == 1)
                ioB1.title = "B";
            Height = h;

            bnDisplayWin.buttonStateChanged += BnDisplayWin_buttonStateChanged;

            ow = null;

            vnaState = VNAState.Idle;
            running = false;
            step = 0;
            phi = 0;

            BSINint = new double[channels];
            BCOSint = new double[channels];

            dataFifo = new DataPointFifo(32);

            processingType = ProcessingType.Sink;
        }


        public VNA() : this(4)
        {
        }

        public VNA(int _channels): base()
        {
            channels = _channels;
            config = new vnaconfig();
            init();
        }

        public VNA(SystemPanel _owner, BinaryReader src):base(_owner, src)
        {
            channels = src.ReadInt32();
            config = new vnaconfig(src);

            init();
        }

        public override void writeToFile(BinaryWriter tgt)
        {
            base.writeToFile(tgt);

            tgt.Write(channels);

            config.write(tgt);
        }

        private void BnDisplayWin_buttonStateChanged(object sender, EventArgs e)
        {
            if (ow == null)
            {
                ow = new VNAWin();
                ow.initVNA(this);
                ow.Show();
            }
            else
            {
                ow.Show();
            }
        }

        // public void runSweep(double _fstart, double _fstop, bool _logsweep, int _steps, double delay, int _periods)
        public void runSweep()
        {
            if (running)
            {
                stop();
                dataFifo.flush();
            }

            fstart = config.sweepFMin;
            fstop = config.sweepFMax;
            logsweep = config.sweepLogF;
            steps = config.sweepPoints;
            periods = config.sweepMPeriods;
            delaySamples = (int)Math.Floor(config.sweepLoopDelay * owner.sampleRate + 0.5);

            //fstart = _fstart;
            //fstop = _fstop;
            //logsweep = _logsweep;
            //steps = _steps;
            step = 0;
            substep = 0;
            f = fstart;

            dataFifo.flush();

            // delaySamples = (int) Math.Floor(delay * owner.sampleRate + 0.5);
            stopnow = false;
            vnaState = VNAState.WaitDelay;
            running = true;
        }

        public void stop()
        {
            if (!running) return;
            stopnow = true;
            while (running)
            {
                System.Threading.Thread.Sleep(1);
            }
            stopnow = false;
        }

        private double windowFunc(int idx, int max)
        {
            // Amplitude corrected Hann Window
            return 2.0 * 0.5 * (1.0 - Math.Cos(2 * Math.PI * idx / max));
        }

        public override void tick()
        {
            if (stopnow)
            {
                vnaState = VNAState.Idle;
                running = false;
                return;
            }
            if (ow == null) return;
            if (!ow.initialized) return;

            if (vnaState == VNAState.Idle) return;

            SignalBuffer RF = getSignalOutputBuffer(ioRF);
            SignalBuffer A = getSignalInputBuffer(ioA);
            // DataBuffer B = null;
            SignalBuffer[] B = new SignalBuffer[channels];
            if (channels > 0) B[0] = getSignalInputBuffer(ioB1);
            if (channels > 1) B[1] = getSignalInputBuffer(ioB2);
            if (channels > 2) B[2] = getSignalInputBuffer(ioB3);
            if (channels > 3) B[3] = getSignalInputBuffer(ioB4);
            if (channels > 4) B[4] = getSignalInputBuffer(ioB5);
            if (channels > 5) B[5] = getSignalInputBuffer(ioB6);
            if (channels > 6) B[6] = getSignalInputBuffer(ioB7);
            if (channels > 7) B[7] = getSignalInputBuffer(ioB8);

            double phisave = phi;
            double dphi = 2.0 * Math.PI * f / owner.sampleRate;
            phi = phisave;
            int stepsave = substep;
            
            // Input Processing
            switch (vnaState)
            {
                case VNAState.WaitDelay:
                    substep+=owner.blockSize;
                    if (substep > delaySamples)
                    {
                        ASINint = ACOSint = 0;
                        for (int j=0;j<channels;j++)
                            BSINint[j] = BCOSint[j] = 0;
                        vnaState = VNAState.Measuring;
                        substep = 0;
                        intCount = (int)Math.Floor((double)periods * (double)owner.sampleRate / f + 0.5);
                    }
                    break;
                case VNAState.Measuring:
                    phi = phisave;
                    substep = stepsave;
                    if (A != null)
                    {
                        for (int i=0;i<owner.blockSize;i++)
                        {
                            if (substep < intCount)
                            {
                                double win = windowFunc(substep, intCount);
                                ASINint += A.data[i] * Math.Sin(phi) * win;
                                ACOSint += A.data[i] * Math.Cos(phi) * win;
                            }
                            substep++;
                            phi += dphi;
                        }
                    }
                    for (int j=0;j<channels;j++)
                    {
                        phi = phisave;
                        substep = stepsave;
                        if (B[j] != null)
                        {
                            for (int i = 0; i < owner.blockSize; i++)
                            {
                                if (substep < intCount)
                                {
                                    double win = windowFunc(substep, intCount);
                                    BSINint[j] += B[j].data[i] * Math.Sin(phi) * win;
                                    BCOSint[j] += B[j].data[i] * Math.Cos(phi) * win;
                                }
                                substep++;
                                phi += dphi;
                            }
                        }
                    }

                    substep = stepsave + owner.blockSize;
                    if (substep >= intCount)
                    {
                        // Process
                        DataPoint dp = new DataPoint(channels);

                        dp.f = f;
                        double scalef = 2.0 / ((double)intCount);
                        dp.A = new Complex(ASINint * scalef, ACOSint * scalef);
                        for (int j=0;j<channels;j++)
                            dp.B[j] = new Complex(BSINint[j] * scalef, BCOSint[j] * scalef);
                        // Phase Correction
                        if (config.compPhaseBlocks != 0)
                        {
                            double delay = (double)config.compPhaseBlocks * owner.blockSize / owner.sampleRate; // in s
                            double phase = -2.0 * Math.PI * delay * f;
                            Complex corr = new Complex(Math.Cos(phase), Math.Sin(phase));
                            dp.A *= corr;
                        }
                        dataFifo.put(dp);

                        substep = 0;
                        step++;
                        if (step < steps)
                        {
                            // Continue
                            if (logsweep)
                                f = fstart * Math.Pow(fstop/ fstart, (double)step / (steps - 1));
                            else
                                f = fstart + (double)step / (steps - 1) * (fstop - fstart);
                            vnaState = VNAState.WaitDelay;
                        } else
                        {
                            // FInish
                            vnaState = VNAState.Idle;
                            running = false;
                        }
                    }
                    break;
            }

            // Generator
            phi = phisave;
            if (RF != null)
            {
                if (vnaState != VNAState.Idle)
                {
                    for (int i = 0; i < owner.blockSize; i++)
                    {
                        RF.data[i] = Math.Sin(phi);
                        phi += dphi;
                        if (phi > 2.0 * Math.PI) phi -= 2 * Math.PI;
                    }
                } else
                {
                    for (int i = 0; i < owner.blockSize; i++)
                    {
                        RF.data[i] = 0;
                        phi += dphi;
                        if (phi > 2.0 * Math.PI) phi -= 2 * Math.PI;
                    }

                }
            }
        }

        public override void Disconnect()
        {
            base.Disconnect();
            if (ow != null)
            {
                ow.CanClose = true;
                ow.Close();
                ow.vna = null;
                ow = null;
            }
        }

        class RegisterClass1 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Tools", "Vector Network Analyzer", "1x" }; }
            public override RTForm Instantiate() { return new VNA(1); }
        }
        class RegisterClass2 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Tools", "Vector Network Analyzer", "2x" }; }
            public override RTForm Instantiate() { return new VNA(2); }
        }
        class RegisterClass3 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Tools", "Vector Network Analyzer", "4x" }; }
            public override RTForm Instantiate() { return new VNA(4); }
        }
        class RegisterClass4 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Tools", "Vector Network Analyzer", "8x" }; }
            public override RTForm Instantiate() { return new VNA(8); }
        }

        public static void Register(List<RTObjectReference> l)
        {
            l.Add(new RegisterClass1());
            l.Add(new RegisterClass2());
            l.Add(new RegisterClass3());
            l.Add(new RegisterClass4());
        }


    }
}
