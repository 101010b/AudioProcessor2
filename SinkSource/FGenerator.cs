using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioProcessor.SinkSource
{
    public class FGenerator : RTForm
    {

        private bool isLFO;
        private double genF;
        private double genAmp;
        private double genPWM;
        private bool inAmp;
        private bool FMlog;
        private bool AMnoOfs;
        MathUtils.WaveForm genWaveForm;

        private double genPhi = 0;

        private RTIO ioFM;
        private RTIO ioAM;
        private RTDial dlFreq;
        private RTDial dlAmp;
        private RTIO io0;
        private RTIO ioSyncOut;
        private RTIO ioPWM;
        private RTChoice chWaveForm;
        private RTIO io90;
        private RTDial dlPWM;
        private RTButton bnRMSAMP;
        private RTButton bnFLog;
        private RTButton bnANoOfs;
        private RTIO ioSyncIn;

        private void InitializeComponent()
        {
            this.ioFM = new AudioProcessor.RTIO();
            this.ioAM = new AudioProcessor.RTIO();
            this.dlFreq = new AudioProcessor.RTDial();
            this.dlAmp = new AudioProcessor.RTDial();
            this.io0 = new AudioProcessor.RTIO();
            this.ioSyncOut = new AudioProcessor.RTIO();
            this.ioPWM = new AudioProcessor.RTIO();
            this.ioSyncIn = new AudioProcessor.RTIO();
            this.chWaveForm = new AudioProcessor.RTChoice();
            this.io90 = new AudioProcessor.RTIO();
            this.dlPWM = new AudioProcessor.RTDial();
            this.bnRMSAMP = new AudioProcessor.RTButton();
            this.bnFLog = new AudioProcessor.RTButton();
            this.bnANoOfs = new AudioProcessor.RTButton();
            this.SuspendLayout();
            // 
            // ioFM
            // 
            this.ioFM.contactBackColor = System.Drawing.Color.Black;
            this.ioFM.contactColor = System.Drawing.Color.DimGray;
            this.ioFM.contactHighlightColor = System.Drawing.Color.Red;
            this.ioFM.highlighted = false;
            this.ioFM.Location = new System.Drawing.Point(0, 28);
            this.ioFM.Name = "ioFM";
            this.ioFM.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.ioFM.showTitle = true;
            this.ioFM.Size = new System.Drawing.Size(48, 20);
            this.ioFM.TabIndex = 0;
            this.ioFM.Text = "rtio1";
            this.ioFM.title = "FM";
            this.ioFM.titleColor = System.Drawing.Color.DimGray;
            this.ioFM.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioFM.type = AudioProcessor.RTIO.ProcessingIOType.Input;
            // 
            // ioAM
            // 
            this.ioAM.contactBackColor = System.Drawing.Color.Black;
            this.ioAM.contactColor = System.Drawing.Color.DimGray;
            this.ioAM.contactHighlightColor = System.Drawing.Color.Red;
            this.ioAM.highlighted = false;
            this.ioAM.Location = new System.Drawing.Point(0, 54);
            this.ioAM.Name = "ioAM";
            this.ioAM.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.ioAM.showTitle = true;
            this.ioAM.Size = new System.Drawing.Size(48, 20);
            this.ioAM.TabIndex = 1;
            this.ioAM.Text = "rtio2";
            this.ioAM.title = "AM";
            this.ioAM.titleColor = System.Drawing.Color.DimGray;
            this.ioAM.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioAM.type = AudioProcessor.RTIO.ProcessingIOType.Input;
            // 
            // dlFreq
            // 
            this.dlFreq.dialColor = System.Drawing.Color.Silver;
            this.dlFreq.dialDiameter = 50D;
            this.dlFreq.dialMarkColor = System.Drawing.Color.Red;
            this.dlFreq.format = "F0";
            this.dlFreq.Location = new System.Drawing.Point(92, 20);
            this.dlFreq.logScale = true;
            this.dlFreq.maxVal = 100000D;
            this.dlFreq.minVal = 1D;
            this.dlFreq.Name = "dlFreq";
            this.dlFreq.scaleColor = System.Drawing.Color.Gold;
            this.dlFreq.showScale = true;
            this.dlFreq.showTitle = true;
            this.dlFreq.showValue = true;
            this.dlFreq.Size = new System.Drawing.Size(60, 80);
            this.dlFreq.TabIndex = 2;
            this.dlFreq.Text = "rtDial1";
            this.dlFreq.title = "Frequ.";
            this.dlFreq.titleColor = System.Drawing.Color.DimGray;
            this.dlFreq.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.dlFreq.unit = "Hz";
            this.dlFreq.val = 440D;
            this.dlFreq.valueColor = System.Drawing.Color.DimGray;
            this.dlFreq.valueFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            // 
            // dlAmp
            // 
            this.dlAmp.dialColor = System.Drawing.Color.Silver;
            this.dlAmp.dialDiameter = 50D;
            this.dlAmp.dialMarkColor = System.Drawing.Color.Red;
            this.dlAmp.format = "F1";
            this.dlAmp.Location = new System.Drawing.Point(224, 20);
            this.dlAmp.logScale = false;
            this.dlAmp.maxVal = 100D;
            this.dlAmp.minVal = -100D;
            this.dlAmp.Name = "dlAmp";
            this.dlAmp.scaleColor = System.Drawing.Color.Gold;
            this.dlAmp.showScale = true;
            this.dlAmp.showTitle = false;
            this.dlAmp.showValue = true;
            this.dlAmp.Size = new System.Drawing.Size(60, 80);
            this.dlAmp.TabIndex = 3;
            this.dlAmp.Text = "rtDial2";
            this.dlAmp.title = "RMS";
            this.dlAmp.titleColor = System.Drawing.Color.DimGray;
            this.dlAmp.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.dlAmp.unit = "dB";
            this.dlAmp.val = -20D;
            this.dlAmp.valueColor = System.Drawing.Color.DimGray;
            this.dlAmp.valueFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            // 
            // io0
            // 
            this.io0.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.io0.contactBackColor = System.Drawing.Color.Black;
            this.io0.contactColor = System.Drawing.Color.DimGray;
            this.io0.contactHighlightColor = System.Drawing.Color.Red;
            this.io0.highlighted = false;
            this.io0.Location = new System.Drawing.Point(295, 37);
            this.io0.Name = "io0";
            this.io0.orientation = AudioProcessor.RTIO.RTOrientation.East;
            this.io0.showTitle = true;
            this.io0.Size = new System.Drawing.Size(51, 20);
            this.io0.TabIndex = 4;
            this.io0.Text = "rtio3";
            this.io0.title = "0°";
            this.io0.titleColor = System.Drawing.Color.DimGray;
            this.io0.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.io0.type = AudioProcessor.RTIO.ProcessingIOType.Output;
            // 
            // ioSyncOut
            // 
            this.ioSyncOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ioSyncOut.contactBackColor = System.Drawing.Color.Black;
            this.ioSyncOut.contactColor = System.Drawing.Color.DimGray;
            this.ioSyncOut.contactHighlightColor = System.Drawing.Color.Red;
            this.ioSyncOut.highlighted = false;
            this.ioSyncOut.Location = new System.Drawing.Point(295, 89);
            this.ioSyncOut.Name = "ioSyncOut";
            this.ioSyncOut.orientation = AudioProcessor.RTIO.RTOrientation.East;
            this.ioSyncOut.showTitle = true;
            this.ioSyncOut.Size = new System.Drawing.Size(51, 20);
            this.ioSyncOut.TabIndex = 5;
            this.ioSyncOut.Text = "rtio4";
            this.ioSyncOut.title = "Sync";
            this.ioSyncOut.titleColor = System.Drawing.Color.DimGray;
            this.ioSyncOut.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioSyncOut.type = AudioProcessor.RTIO.ProcessingIOType.Output;
            // 
            // ioPWM
            // 
            this.ioPWM.contactBackColor = System.Drawing.Color.Black;
            this.ioPWM.contactColor = System.Drawing.Color.DimGray;
            this.ioPWM.contactHighlightColor = System.Drawing.Color.Red;
            this.ioPWM.highlighted = false;
            this.ioPWM.Location = new System.Drawing.Point(0, 80);
            this.ioPWM.Name = "ioPWM";
            this.ioPWM.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.ioPWM.showTitle = true;
            this.ioPWM.Size = new System.Drawing.Size(56, 20);
            this.ioPWM.TabIndex = 6;
            this.ioPWM.Text = "rtio5";
            this.ioPWM.title = "PWM";
            this.ioPWM.titleColor = System.Drawing.Color.DimGray;
            this.ioPWM.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioPWM.type = AudioProcessor.RTIO.ProcessingIOType.Input;
            // 
            // ioSyncIn
            // 
            this.ioSyncIn.contactBackColor = System.Drawing.Color.Black;
            this.ioSyncIn.contactColor = System.Drawing.Color.DimGray;
            this.ioSyncIn.contactHighlightColor = System.Drawing.Color.Red;
            this.ioSyncIn.highlighted = false;
            this.ioSyncIn.Location = new System.Drawing.Point(0, 106);
            this.ioSyncIn.Name = "ioSyncIn";
            this.ioSyncIn.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.ioSyncIn.showTitle = true;
            this.ioSyncIn.Size = new System.Drawing.Size(56, 20);
            this.ioSyncIn.TabIndex = 8;
            this.ioSyncIn.Text = "rtio5";
            this.ioSyncIn.title = "Sync";
            this.ioSyncIn.titleColor = System.Drawing.Color.DimGray;
            this.ioSyncIn.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioSyncIn.type = AudioProcessor.RTIO.ProcessingIOType.Input;
            // 
            // chWaveForm
            // 
            this.chWaveForm.backColor = System.Drawing.Color.Black;
            this.chWaveForm.frontColor = System.Drawing.Color.DimGray;
            this.chWaveForm.Location = new System.Drawing.Point(109, 106);
            this.chWaveForm.Name = "chWaveForm";
            this.chWaveForm.selectedItem = -1;
            this.chWaveForm.Size = new System.Drawing.Size(129, 20);
            this.chWaveForm.TabIndex = 9;
            this.chWaveForm.Text = "rtChoice1";
            this.chWaveForm.title = "Waveform";
            this.chWaveForm.titleColor = System.Drawing.Color.DimGray;
            this.chWaveForm.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.chWaveForm.xdim = 50;
            // 
            // io90
            // 
            this.io90.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.io90.contactBackColor = System.Drawing.Color.Black;
            this.io90.contactColor = System.Drawing.Color.DimGray;
            this.io90.contactHighlightColor = System.Drawing.Color.Red;
            this.io90.highlighted = false;
            this.io90.Location = new System.Drawing.Point(295, 63);
            this.io90.Name = "io90";
            this.io90.orientation = AudioProcessor.RTIO.RTOrientation.East;
            this.io90.showTitle = true;
            this.io90.Size = new System.Drawing.Size(51, 20);
            this.io90.TabIndex = 11;
            this.io90.Text = "rtio3";
            this.io90.title = "90°";
            this.io90.titleColor = System.Drawing.Color.DimGray;
            this.io90.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.io90.type = AudioProcessor.RTIO.ProcessingIOType.Output;
            // 
            // dlPWM
            // 
            this.dlPWM.dialColor = System.Drawing.Color.Silver;
            this.dlPWM.dialDiameter = 50D;
            this.dlPWM.dialMarkColor = System.Drawing.Color.Red;
            this.dlPWM.format = "F2";
            this.dlPWM.Location = new System.Drawing.Point(158, 20);
            this.dlPWM.logScale = false;
            this.dlPWM.maxVal = 1D;
            this.dlPWM.minVal = -1D;
            this.dlPWM.Name = "dlPWM";
            this.dlPWM.scaleColor = System.Drawing.Color.Gold;
            this.dlPWM.showScale = true;
            this.dlPWM.showTitle = true;
            this.dlPWM.showValue = true;
            this.dlPWM.Size = new System.Drawing.Size(60, 80);
            this.dlPWM.TabIndex = 12;
            this.dlPWM.Text = "rtDial2";
            this.dlPWM.title = "PWM";
            this.dlPWM.titleColor = System.Drawing.Color.DimGray;
            this.dlPWM.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.dlPWM.unit = "";
            this.dlPWM.val = 0D;
            this.dlPWM.valueColor = System.Drawing.Color.DimGray;
            this.dlPWM.valueFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            // 
            // bnRMSAMP
            // 
            this.bnRMSAMP.buttonDim = new System.Drawing.Size(30, 15);
            this.bnRMSAMP.buttonState = false;
            this.bnRMSAMP.buttonType = AudioProcessor.RTButton.RTButtonType.ToggleButton;
            this.bnRMSAMP.fillOffColor = System.Drawing.Color.Green;
            this.bnRMSAMP.fillOnColor = System.Drawing.Color.Navy;
            this.bnRMSAMP.frameHoldColor = System.Drawing.Color.Yellow;
            this.bnRMSAMP.frameOffColor = System.Drawing.Color.Lime;
            this.bnRMSAMP.frameOnColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.bnRMSAMP.Location = new System.Drawing.Point(238, 19);
            this.bnRMSAMP.Name = "bnRMSAMP";
            this.bnRMSAMP.offText = "RMS";
            this.bnRMSAMP.onText = "Amp";
            this.bnRMSAMP.Size = new System.Drawing.Size(31, 16);
            this.bnRMSAMP.TabIndex = 13;
            this.bnRMSAMP.Text = "rtButton1";
            this.bnRMSAMP.textFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.bnRMSAMP.textOffColor = System.Drawing.Color.Lime;
            this.bnRMSAMP.textOnColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.bnRMSAMP.title = "Button";
            this.bnRMSAMP.titleColor = System.Drawing.Color.DimGray;
            this.bnRMSAMP.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.bnRMSAMP.titlePos = AudioProcessor.RTButton.RTTitlePos.Off;
            // 
            // bnFLog
            // 
            this.bnFLog.buttonDim = new System.Drawing.Size(30, 15);
            this.bnFLog.buttonState = false;
            this.bnFLog.buttonType = AudioProcessor.RTButton.RTButtonType.ToggleButton;
            this.bnFLog.fillOffColor = System.Drawing.Color.Green;
            this.bnFLog.fillOnColor = System.Drawing.Color.Navy;
            this.bnFLog.frameHoldColor = System.Drawing.Color.Yellow;
            this.bnFLog.frameOffColor = System.Drawing.Color.Lime;
            this.bnFLog.frameOnColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.bnFLog.Location = new System.Drawing.Point(55, 30);
            this.bnFLog.Name = "bnFLog";
            this.bnFLog.offText = "Lin";
            this.bnFLog.onText = "Log";
            this.bnFLog.Size = new System.Drawing.Size(31, 16);
            this.bnFLog.TabIndex = 18;
            this.bnFLog.Text = "rtButton2";
            this.bnFLog.textFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.bnFLog.textOffColor = System.Drawing.Color.Lime;
            this.bnFLog.textOnColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.bnFLog.title = "Button";
            this.bnFLog.titleColor = System.Drawing.Color.DimGray;
            this.bnFLog.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.bnFLog.titlePos = AudioProcessor.RTButton.RTTitlePos.Off;
            // 
            // bnANoOfs
            // 
            this.bnANoOfs.buttonDim = new System.Drawing.Size(30, 15);
            this.bnANoOfs.buttonState = false;
            this.bnANoOfs.buttonType = AudioProcessor.RTButton.RTButtonType.ToggleButton;
            this.bnANoOfs.fillOffColor = System.Drawing.Color.Green;
            this.bnANoOfs.fillOnColor = System.Drawing.Color.Navy;
            this.bnANoOfs.frameHoldColor = System.Drawing.Color.Yellow;
            this.bnANoOfs.frameOffColor = System.Drawing.Color.Lime;
            this.bnANoOfs.frameOnColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.bnANoOfs.Location = new System.Drawing.Point(55, 55);
            this.bnANoOfs.Name = "bnANoOfs";
            this.bnANoOfs.offText = "+1";
            this.bnANoOfs.onText = "0";
            this.bnANoOfs.Size = new System.Drawing.Size(31, 16);
            this.bnANoOfs.TabIndex = 19;
            this.bnANoOfs.Text = "rtButton2";
            this.bnANoOfs.textFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.bnANoOfs.textOffColor = System.Drawing.Color.Lime;
            this.bnANoOfs.textOnColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.bnANoOfs.title = "Button";
            this.bnANoOfs.titleColor = System.Drawing.Color.DimGray;
            this.bnANoOfs.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.bnANoOfs.titlePos = AudioProcessor.RTButton.RTTitlePos.Off;
            // 
            // FGenerator
            // 
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.bnANoOfs);
            this.Controls.Add(this.bnFLog);
            this.Controls.Add(this.bnRMSAMP);
            this.Controls.Add(this.dlPWM);
            this.Controls.Add(this.io90);
            this.Controls.Add(this.chWaveForm);
            this.Controls.Add(this.ioSyncIn);
            this.Controls.Add(this.ioPWM);
            this.Controls.Add(this.ioSyncOut);
            this.Controls.Add(this.io0);
            this.Controls.Add(this.dlAmp);
            this.Controls.Add(this.dlFreq);
            this.Controls.Add(this.ioAM);
            this.Controls.Add(this.ioFM);
            this.Name = "FGenerator";
            this.shrinkSize = new System.Drawing.Size(135, 137);
            this.shrinkTitle = "Fgen";
            this.Size = new System.Drawing.Size(346, 137);
            this.title = "Function Generator";
            this.ResumeLayout(false);

        }

        private void init()
        {
            InitializeComponent();
            chWaveForm.setEntries(new List<RTChoice.RTDrawable>
            {
                new RTChoice.RTDrawableWaveform(RTChoice.RTDrawableWaveform.WaveForm.Sine,0),
                new RTChoice.RTDrawableWaveform(RTChoice.RTDrawableWaveform.WaveForm.Triangle,0),
                new RTChoice.RTDrawableWaveform(RTChoice.RTDrawableWaveform.WaveForm.Saw,0),
                new RTChoice.RTDrawableWaveform(RTChoice.RTDrawableWaveform.WaveForm.Rectangle,0)
            });
            dlFreq.val = genF;
            dlAmp.val = genAmp;
            dlPWM.val = genPWM;
            chWaveForm.selectedItem = (int)genWaveForm;
            bnRMSAMP.buttonState = inAmp;
            bnANoOfs.buttonState = AMnoOfs;
            bnFLog.buttonState = FMlog;

            if (isLFO)
            {
                title = "Low Frequency Oscillator";
                shrinkTitle = "LFO";
                dlFreq.minVal = 0.001;
                dlFreq.maxVal = 1000;
                dlFreq.format = "F3";
            }

            chWaveForm.choiceStateChanged += ChWaveForm_choiceStateChanged;
            dlFreq.valueChanged += DlFreq_valueChanged;
            dlAmp.valueChanged += DlAmp_valueChanged;
            dlPWM.valueChanged += DlPWM_valueChanged;
            bnRMSAMP.buttonStateChanged += BnRMSAMP_buttonStateChanged;
            bnANoOfs.buttonStateChanged += BnANoOfs_buttonStateChanged;
            bnFLog.buttonStateChanged += BnFLog_buttonStateChanged;

            processingType = ProcessingType.Processor;
        }


        public FGenerator(bool _isLFO)
        {
            isLFO = _isLFO;
            if (isLFO)
                genF = 10;
            else
                genF = 440;
            genAmp = -20.0;
            genPWM = 0;
            inAmp = false;
            genWaveForm = MathUtils.WaveForm.Sine;
            AMnoOfs = false;
            FMlog = false;

            init();
        }

        public FGenerator():this(false)
        {
        }

        public FGenerator(SystemPanel _owner, BinaryReader src) : base(_owner, src)
        {
            isLFO = src.ReadBoolean();
            genF = src.ReadDouble();
            genAmp = src.ReadDouble();
            genPWM = src.ReadDouble();
            genWaveForm = (MathUtils.WaveForm)src.ReadInt32();
            inAmp = src.ReadBoolean();
            AMnoOfs = src.ReadBoolean();
            FMlog = src.ReadBoolean();

            init();
        }


        public override void writeToFile(BinaryWriter tgt)
        {
            base.writeToFile(tgt);
            tgt.Write(isLFO);
            tgt.Write(genF);
            tgt.Write(genAmp);
            tgt.Write(genPWM);
            tgt.Write((int)genWaveForm);
            tgt.Write(inAmp);
            tgt.Write(AMnoOfs);
            tgt.Write(FMlog);
        }

        private void ChWaveForm_choiceStateChanged(object sender, EventArgs e)
        {
            genWaveForm = (MathUtils.WaveForm)chWaveForm.selectedItem;
        }

        private void BnFLog_buttonStateChanged(object sender, EventArgs e)
        {
            FMlog = bnFLog.buttonState;
        }

        private void BnANoOfs_buttonStateChanged(object sender, EventArgs e)
        {
            AMnoOfs = bnANoOfs.buttonState;
        }

        private void BnRMSAMP_buttonStateChanged(object sender, EventArgs e)
        {
            inAmp = bnRMSAMP.buttonState;
        }

        private void DlAmp_valueChanged(object sender, EventArgs e)
        {
            genAmp = dlAmp.val;
        }

        private void DlFreq_valueChanged(object sender, EventArgs e)
        {
            genF = dlFreq.val;
        }

        private void DlPWM_valueChanged(object sender, EventArgs e)
        {
            genPWM = dlPWM.val;
        }

        double lastSync;

        public override void tick()
        {
            DataBuffer dbFM = getInputBuffer(ioFM);
            DataBuffer dbAM = getInputBuffer(ioAM);
            DataBuffer dbPWM = getInputBuffer(ioPWM);
            DataBuffer dbSync = getInputBuffer(ioSyncIn);
            DataBuffer dbout = getOutputBuffer(io0);
            DataBuffer dboutninety = getOutputBuffer(io90);
            DataBuffer dbtrig = getOutputBuffer(ioSyncOut);

            if (!_active) return;

            if ((dbout == null) && (dboutninety == null) && (dbtrig == null))
               return;

            double dphi0 = genF / owner.sampleRate;
            double amp = Math.Pow(10.0, genAmp / 20.0);
            if (!inAmp)
                amp *= MathUtils.AmplitudeFromRMS(genWaveForm);

            for (int i = 0; i < owner.blockSize; i++)
            {
                if (dbSync != null)
                {
                    if ((dbSync.data[i] >= 0) && (lastSync < 0))
                    {
                        genPhi = 0;
                    }
                    lastSync = dbSync.data[i];
                }
                else lastSync = 0;

                double zero = 0.0;
                double ninety = 0.0;
                double g = amp;
                if (dbAM != null)
                {
                    if (AMnoOfs)
                        g *= dbAM.data[i];
                    else
                        g *= dbAM.data[i] + 1.0;
                }
                double pw = genPWM;
                if (dbPWM != null)
                    pw+=dbPWM.data[i];

                MathUtils.waveForm(genWaveForm, ref zero, ref ninety, genPhi, pw);

                if (dbout != null)
                    dbout.data[i] = g * zero;
                if (dboutninety != null)
                    dboutninety.data[i] = g * ninety;
                if (dbtrig != null)
                    dbtrig.data[i] = MathUtils.trig(genPhi);

                double dphi = dphi0;
                if (dbFM != null)
                {
                    if (FMlog)
                        dphi *= Math.Pow(2,dbFM.data[i]);
                    else
                        dphi *= (1 + dbFM.data[i]);
                }
                genPhi += dphi;
                if ((genPhi < 0) || (genPhi >= 1))
                    genPhi -= Math.Floor(genPhi);
            }

        }

        class RegisterClass1 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Generator", "Standard Funtion" }; }
            public override RTForm Instantiate() { return new FGenerator(false); }
        }

        class RegisterClass2 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Generator", "Low Frequency" }; }
            public override RTForm Instantiate() { return new FGenerator(true); }
        }

        public static void Register(List<RTObjectReference> l)
        {
            l.Add(new RegisterClass1());
            l.Add(new RegisterClass2());
        }


    }
}
