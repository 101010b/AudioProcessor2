using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AudioProcessor.SinkSource
{
    class Sweep : RTForm
    {
        public void InitializeComponent()
        {
            this.bnManual = new AudioProcessor.RTButton();
            this.ledRun = new AudioProcessor.RTLED();
            this.ioTrig = new AudioProcessor.RTIO();
            this.ioGate = new AudioProcessor.RTIO();
            this.ioSig = new AudioProcessor.RTIO();
            this.dlStart = new AudioProcessor.RTDial();
            this.dlStop = new AudioProcessor.RTDial();
            this.dlTime = new AudioProcessor.RTDial();
            this.chMode = new AudioProcessor.RTChoice();
            this.SuspendLayout();
            // 
            // bnManual
            // 
            this.bnManual.buttonDim = new System.Drawing.Size(30, 15);
            this.bnManual.buttonState = false;
            this.bnManual.buttonType = AudioProcessor.RTButton.RTButtonType.HoldButton;
            this.bnManual.fillOffColor = System.Drawing.Color.Black;
            this.bnManual.fillOnColor = System.Drawing.Color.DarkRed;
            this.bnManual.frameHoldColor = System.Drawing.Color.Yellow;
            this.bnManual.frameOffColor = System.Drawing.Color.DimGray;
            this.bnManual.frameOnColor = System.Drawing.Color.Red;
            this.bnManual.Location = new System.Drawing.Point(4, 75);
            this.bnManual.Name = "bnManual";
            this.bnManual.offText = "Off";
            this.bnManual.onText = "On";
            this.bnManual.Size = new System.Drawing.Size(61, 51);
            this.bnManual.TabIndex = 27;
            this.bnManual.Text = "rtButton2";
            this.bnManual.textFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.bnManual.textOffColor = System.Drawing.Color.DimGray;
            this.bnManual.textOnColor = System.Drawing.Color.Red;
            this.bnManual.title = "Manual";
            this.bnManual.titleColor = System.Drawing.Color.DimGray;
            this.bnManual.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.bnManual.titlePos = AudioProcessor.RTButton.RTTitlePos.Above;
            // 
            // ledRun
            // 
            this.ledRun.fillOffColor = System.Drawing.Color.Black;
            this.ledRun.fillOnColor = System.Drawing.Color.DarkRed;
            this.ledRun.frameOffColor = System.Drawing.Color.DimGray;
            this.ledRun.frameOnColor = System.Drawing.Color.Red;
            this.ledRun.LEDDim = new System.Drawing.Size(15, 15);
            this.ledRun.LEDState = false;
            this.ledRun.Location = new System.Drawing.Point(262, 3);
            this.ledRun.Name = "ledRun";
            this.ledRun.offText = "";
            this.ledRun.onText = "";
            this.ledRun.Size = new System.Drawing.Size(100, 26);
            this.ledRun.TabIndex = 26;
            this.ledRun.Text = "rtled1";
            this.ledRun.textFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ledRun.textOffColor = System.Drawing.Color.DimGray;
            this.ledRun.textOnColor = System.Drawing.Color.Red;
            this.ledRun.title = "Running";
            this.ledRun.titleColor = System.Drawing.Color.DimGray;
            this.ledRun.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ledRun.titlePos = AudioProcessor.RTLED.RTTitlePos.Left;
            // 
            // ioTrig
            // 
            this.ioTrig.contactBackColor = System.Drawing.Color.Black;
            this.ioTrig.contactColor = System.Drawing.Color.DimGray;
            this.ioTrig.Location = new System.Drawing.Point(0, 39);
            this.ioTrig.Name = "ioTrig";
            this.ioTrig.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.ioTrig.showTitle = true;
            this.ioTrig.Size = new System.Drawing.Size(61, 20);
            this.ioTrig.TabIndex = 23;
            this.ioTrig.Text = "rtio4";
            this.ioTrig.title = "Trig";
            this.ioTrig.titleColor = System.Drawing.Color.DimGray;
            this.ioTrig.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioTrig.type = AudioProcessor.RTIO.ProcessingIOType.Input;
            // 
            // ioGate
            // 
            this.ioGate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ioGate.contactBackColor = System.Drawing.Color.Black;
            this.ioGate.contactColor = System.Drawing.Color.DimGray;
            this.ioGate.Location = new System.Drawing.Point(321, 65);
            this.ioGate.Name = "ioGate";
            this.ioGate.orientation = AudioProcessor.RTIO.RTOrientation.East;
            this.ioGate.showTitle = true;
            this.ioGate.Size = new System.Drawing.Size(61, 20);
            this.ioGate.TabIndex = 22;
            this.ioGate.Text = "rtio2";
            this.ioGate.title = "gate";
            this.ioGate.titleColor = System.Drawing.Color.DimGray;
            this.ioGate.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioGate.type = AudioProcessor.RTIO.ProcessingIOType.Output;
            // 
            // ioSig
            // 
            this.ioSig.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ioSig.contactBackColor = System.Drawing.Color.Black;
            this.ioSig.contactColor = System.Drawing.Color.DimGray;
            this.ioSig.Location = new System.Drawing.Point(321, 39);
            this.ioSig.Name = "ioSig";
            this.ioSig.orientation = AudioProcessor.RTIO.RTOrientation.East;
            this.ioSig.showTitle = true;
            this.ioSig.Size = new System.Drawing.Size(61, 20);
            this.ioSig.TabIndex = 21;
            this.ioSig.Text = "rtio1";
            this.ioSig.title = "S";
            this.ioSig.titleColor = System.Drawing.Color.DimGray;
            this.ioSig.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioSig.type = AudioProcessor.RTIO.ProcessingIOType.Output;
            // 
            // dlStart
            // 
            this.dlStart.dialColor = System.Drawing.Color.Silver;
            this.dlStart.dialDiameter = 50D;
            this.dlStart.dialMarkColor = System.Drawing.Color.Red;
            this.dlStart.format = "F2";
            this.dlStart.Location = new System.Drawing.Point(79, 26);
            this.dlStart.logScale = false;
            this.dlStart.maxVal = 10D;
            this.dlStart.minVal = -10D;
            this.dlStart.Name = "dlStart";
            this.dlStart.scaleColor = System.Drawing.Color.Gold;
            this.dlStart.showScale = true;
            this.dlStart.showTitle = true;
            this.dlStart.showValue = true;
            this.dlStart.Size = new System.Drawing.Size(75, 100);
            this.dlStart.TabIndex = 28;
            this.dlStart.Text = "rtDial1";
            this.dlStart.title = "Start";
            this.dlStart.titleColor = System.Drawing.Color.DimGray;
            this.dlStart.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.dlStart.unit = "";
            this.dlStart.val = -1D;
            this.dlStart.valueColor = System.Drawing.Color.DimGray;
            this.dlStart.valueFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            // 
            // dlStop
            // 
            this.dlStop.dialColor = System.Drawing.Color.Silver;
            this.dlStop.dialDiameter = 50D;
            this.dlStop.dialMarkColor = System.Drawing.Color.Red;
            this.dlStop.format = "F2";
            this.dlStop.Location = new System.Drawing.Point(160, 26);
            this.dlStop.logScale = false;
            this.dlStop.maxVal = 10D;
            this.dlStop.minVal = -10D;
            this.dlStop.Name = "dlStop";
            this.dlStop.scaleColor = System.Drawing.Color.Gold;
            this.dlStop.showScale = true;
            this.dlStop.showTitle = true;
            this.dlStop.showValue = true;
            this.dlStop.Size = new System.Drawing.Size(75, 100);
            this.dlStop.TabIndex = 29;
            this.dlStop.Text = "rtDial2";
            this.dlStop.title = "Stop";
            this.dlStop.titleColor = System.Drawing.Color.DimGray;
            this.dlStop.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.dlStop.unit = "";
            this.dlStop.val = 1D;
            this.dlStop.valueColor = System.Drawing.Color.DimGray;
            this.dlStop.valueFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            // 
            // dlTime
            // 
            this.dlTime.dialColor = System.Drawing.Color.Silver;
            this.dlTime.dialDiameter = 50D;
            this.dlTime.dialMarkColor = System.Drawing.Color.Red;
            this.dlTime.format = "F2";
            this.dlTime.Location = new System.Drawing.Point(241, 26);
            this.dlTime.logScale = true;
            this.dlTime.maxVal = 100D;
            this.dlTime.minVal = 0.001D;
            this.dlTime.Name = "dlTime";
            this.dlTime.scaleColor = System.Drawing.Color.Gold;
            this.dlTime.showScale = true;
            this.dlTime.showTitle = true;
            this.dlTime.showValue = true;
            this.dlTime.Size = new System.Drawing.Size(75, 100);
            this.dlTime.TabIndex = 30;
            this.dlTime.Text = "rtDial3";
            this.dlTime.title = "Time";
            this.dlTime.titleColor = System.Drawing.Color.DimGray;
            this.dlTime.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.dlTime.unit = "s";
            this.dlTime.val = 1D;
            this.dlTime.valueColor = System.Drawing.Color.DimGray;
            this.dlTime.valueFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            // 
            // chMode
            // 
            this.chMode.backColor = System.Drawing.Color.Black;
            this.chMode.frontColor = System.Drawing.Color.DimGray;
            this.chMode.Location = new System.Drawing.Point(176, 132);
            this.chMode.Name = "chMode";
            this.chMode.selectedItem = -1;
            this.chMode.Size = new System.Drawing.Size(140, 25);
            this.chMode.TabIndex = 31;
            this.chMode.Text = "rtChoice1";
            this.chMode.title = "Mode";
            this.chMode.titleColor = System.Drawing.Color.DimGray;
            this.chMode.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.chMode.xdim = 80;
            // 
            // Sweep
            // 
            this.canShrink = false;
            this.Controls.Add(this.chMode);
            this.Controls.Add(this.dlTime);
            this.Controls.Add(this.dlStop);
            this.Controls.Add(this.dlStart);
            this.Controls.Add(this.bnManual);
            this.Controls.Add(this.ledRun);
            this.Controls.Add(this.ioTrig);
            this.Controls.Add(this.ioGate);
            this.Controls.Add(this.ioSig);
            this.Name = "Sweep";
            this.Size = new System.Drawing.Size(382, 165);
            this.title = "Sweep";
            this.ResumeLayout(false);

        }

        double val;
        double time;
        double start;
        double stop;
        bool triggered;
        double oldtrig;
        private RTButton bnManual;
        private RTLED ledRun;
        private RTIO ioTrig;
        private RTIO ioGate;
        private RTIO ioSig;
        private RTDial dlStart;
        private RTDial dlStop;
        private RTDial dlTime;
        private bool manual;
        private RTChoice chMode;

        enum TriggerMode
        {
            Manual,
            Loop,
            In,
            InWRestart
        }
        TriggerMode triggerMode;

        private void init()
        {
            InitializeComponent();

            ledRun.LEDState = false;
            dlStart.val = start;
            dlStop.val = stop;
            dlTime.val = time;

            chMode.setEntries(new List<RTChoice.RTDrawable>
            {
                new RTChoice.RTDrawableText("Manual"),
                new RTChoice.RTDrawableText("Loop"),
                new RTChoice.RTDrawableText("In"),
                new RTChoice.RTDrawableText("In(R)")
            });
            chMode.selectedItem = (int)triggerMode;

            bnManual.buttonStateChanged += BnManual_buttonStateChanged;
            dlStart.valueChanged += DlStart_valueChanged;
            dlStop.valueChanged += DlStop_valueChanged;
            dlTime.valueChanged += DlTime_valueChanged;
            chMode.choiceStateChanged += ChMode_choiceStateChanged;

            processingType = ProcessingType.Source;
        }

        public Sweep(): base()
        {
            start = -1;
            stop = 1;
            time = 10;
            triggerMode = TriggerMode.Manual;

            init();
        }

        public Sweep(SystemPanel _owner, BinaryReader src):base(_owner, src)
        {
            start = src.ReadDouble();
            stop = src.ReadDouble();
            time = src.ReadDouble();
            triggerMode = (TriggerMode)src.ReadInt32();

            init();
        }

        public override void writeToFile(BinaryWriter tgt)
        {
            base.writeToFile(tgt);

            tgt.Write(start);
            tgt.Write(stop);
            tgt.Write(time);
            tgt.Write((int)triggerMode);
        }

        private void ChMode_choiceStateChanged(object sender, EventArgs e)
        {
            triggerMode = (TriggerMode)chMode.selectedItem;
        }

        private void DlTime_valueChanged(object sender, EventArgs e)
        {
            time = dlTime.val;
        }

        private void DlStop_valueChanged(object sender, EventArgs e)
        {
            stop = dlStop.val;
        }

        private void DlStart_valueChanged(object sender, EventArgs e)
        {
            start = dlStart.val;
        }

        private void BnManual_buttonStateChanged(object sender, EventArgs e)
        {
            manual = bnManual.buttonState;
            if (manual)
            {
                val = start;
                triggered = true;
            }
        }

        public override void tick()
        {
            DataBuffer dbout = getOutputBuffer(ioSig);
            DataBuffer dbtrig = getOutputBuffer(ioGate);
            DataBuffer dbtrigin = getInputBuffer(ioTrig);

            if ((dbout == null) && (dbtrig == null)) return;
            if (!_active) return;

            double slp = (stop - start) / time / owner.sampleRate;

            for (int i=0;i<owner.blockSize;i++)
            {
                if (dbtrigin != null)
                {
                    if ((oldtrig <= 0) && (dbtrigin.data[i] > 0))
                    {
                        // Trigger on if needed
                        switch (triggerMode)
                        {
                            case TriggerMode.Manual: break; // Ignore
                            case TriggerMode.In:
                                if (!triggered)
                                {
                                    val = start;
                                    triggered = true;
                                }
                                break;
                            case TriggerMode.InWRestart:
                                val = start;
                                triggered = true;
                                break;
                        }
                    }
                    oldtrig = dbtrig.data[i];
                }
                if (dbout != null)
                    dbout.data[i] = val;
                if (triggered)
                {
                    val += slp;
                    if (val >= stop)
                    {
                        if (dbtrig != null)
                            dbtrig.data[i] = 0;

                        if (triggerMode == TriggerMode.Loop)
                        {
                            val = start;
                            triggered = true;
                        }
                        else
                        {
                            val = stop;
                            triggered = false;
                        }
                    }
                } else
                {
                    if (dbtrig != null)
                        dbtrig.data[i] = 0;
                }
            }
            if (triggered && !ledRun.LEDState)
                ledRun.LEDState = true;
            if (!triggered && ledRun.LEDState)
                ledRun.LEDState = false;
        }

        class RegisterClass : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Generator", "Sweep" }; }
            public override RTForm Instantiate() { return new Sweep(); }
        }
        public static void Register(List<RTObjectReference> l) { l.Add(new RegisterClass()); }



    }
}
