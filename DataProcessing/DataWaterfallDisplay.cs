using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioProcessor.DataProcessing
{
    class DataWaterfallDisplay : RTForm
    {

        public void InitializeComponent()
        {
            this.ioData = new AudioProcessor.RTIO();
            this.wfDisplay = new AudioProcessor.RTWaterfall();
            this.bnLog = new AudioProcessor.RTButton();
            this.bnNorm = new AudioProcessor.RTButton();
            this.bnBipolar = new AudioProcessor.RTButton();
            this.SuspendLayout();
            // 
            // ioData
            // 
            this.ioData.contactBackColor = System.Drawing.Color.Black;
            this.ioData.contactColor = System.Drawing.Color.DimGray;
            this.ioData.contactHighlightColor = System.Drawing.Color.Red;
            this.ioData.highlighted = false;
            this.ioData.IOtype = AudioProcessor.RTIO.ProcessingIOType.DataInput;
            this.ioData.Location = new System.Drawing.Point(0, 30);
            this.ioData.Name = "ioData";
            this.ioData.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.ioData.showTitle = false;
            this.ioData.Size = new System.Drawing.Size(21, 20);
            this.ioData.TabIndex = 13;
            this.ioData.Text = "rtio1";
            this.ioData.title = "FM";
            this.ioData.titleColor = System.Drawing.Color.DimGray;
            this.ioData.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            // 
            // wfDisplay
            // 
            this.wfDisplay.colorSet = "KrYW";
            this.wfDisplay.displaySize = new System.Drawing.Size(100, 100);
            this.wfDisplay.frameColor = System.Drawing.Color.DimGray;
            this.wfDisplay.Location = new System.Drawing.Point(40, 28);
            this.wfDisplay.Name = "wfDisplay";
            this.wfDisplay.Size = new System.Drawing.Size(104, 104);
            this.wfDisplay.TabIndex = 30;
            this.wfDisplay.Text = "rtWaterfall1";
            this.wfDisplay.timeSteps = 100;
            this.wfDisplay.title = "Waterfall";
            this.wfDisplay.titleColor = System.Drawing.Color.DimGray;
            this.wfDisplay.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.wfDisplay.titlePos = AudioProcessor.GraphicsUtil.TextAlignment.off;
            this.wfDisplay.ySteps = 12;
            // 
            // bnLog
            // 
            this.bnLog.buttonDim = new System.Drawing.Size(30, 15);
            this.bnLog.buttonState = false;
            this.bnLog.buttonType = AudioProcessor.RTButton.RTButtonType.ToggleButton;
            this.bnLog.fillOffColor = System.Drawing.Color.Green;
            this.bnLog.fillOnColor = System.Drawing.Color.Navy;
            this.bnLog.frameHoldColor = System.Drawing.Color.Yellow;
            this.bnLog.frameOffColor = System.Drawing.Color.Lime;
            this.bnLog.frameOnColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.bnLog.Location = new System.Drawing.Point(77, 138);
            this.bnLog.Name = "bnLog";
            this.bnLog.offText = "Lin";
            this.bnLog.onText = "Log";
            this.bnLog.Size = new System.Drawing.Size(31, 16);
            this.bnLog.TabIndex = 33;
            this.bnLog.Text = "rtButton2";
            this.bnLog.textFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.bnLog.textOffColor = System.Drawing.Color.Lime;
            this.bnLog.textOnColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.bnLog.title = "Button";
            this.bnLog.titleColor = System.Drawing.Color.DimGray;
            this.bnLog.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.bnLog.titlePos = AudioProcessor.RTButton.RTTitlePos.Off;
            // 
            // bnNorm
            // 
            this.bnNorm.buttonDim = new System.Drawing.Size(30, 15);
            this.bnNorm.buttonState = false;
            this.bnNorm.buttonType = AudioProcessor.RTButton.RTButtonType.ToggleButton;
            this.bnNorm.fillOffColor = System.Drawing.Color.Green;
            this.bnNorm.fillOnColor = System.Drawing.Color.Navy;
            this.bnNorm.frameHoldColor = System.Drawing.Color.Yellow;
            this.bnNorm.frameOffColor = System.Drawing.Color.Lime;
            this.bnNorm.frameOnColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.bnNorm.Location = new System.Drawing.Point(113, 138);
            this.bnNorm.Name = "bnNorm";
            this.bnNorm.offText = "dir";
            this.bnNorm.onText = "norm";
            this.bnNorm.Size = new System.Drawing.Size(31, 16);
            this.bnNorm.TabIndex = 34;
            this.bnNorm.Text = "rtButton2";
            this.bnNorm.textFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.bnNorm.textOffColor = System.Drawing.Color.Lime;
            this.bnNorm.textOnColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.bnNorm.title = "Button";
            this.bnNorm.titleColor = System.Drawing.Color.DimGray;
            this.bnNorm.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.bnNorm.titlePos = AudioProcessor.RTButton.RTTitlePos.Off;
            // 
            // bnBipolar
            // 
            this.bnBipolar.buttonDim = new System.Drawing.Size(30, 15);
            this.bnBipolar.buttonState = false;
            this.bnBipolar.buttonType = AudioProcessor.RTButton.RTButtonType.ToggleButton;
            this.bnBipolar.fillOffColor = System.Drawing.Color.Green;
            this.bnBipolar.fillOnColor = System.Drawing.Color.Navy;
            this.bnBipolar.frameHoldColor = System.Drawing.Color.Yellow;
            this.bnBipolar.frameOffColor = System.Drawing.Color.Lime;
            this.bnBipolar.frameOnColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.bnBipolar.Location = new System.Drawing.Point(41, 138);
            this.bnBipolar.Name = "bnBipolar";
            this.bnBipolar.offText = "pos";
            this.bnBipolar.onText = "bip";
            this.bnBipolar.Size = new System.Drawing.Size(31, 16);
            this.bnBipolar.TabIndex = 35;
            this.bnBipolar.Text = "rtButton2";
            this.bnBipolar.textFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.bnBipolar.textOffColor = System.Drawing.Color.Lime;
            this.bnBipolar.textOnColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.bnBipolar.title = "Button";
            this.bnBipolar.titleColor = System.Drawing.Color.DimGray;
            this.bnBipolar.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.bnBipolar.titlePos = AudioProcessor.RTButton.RTTitlePos.Off;
            // 
            // DataWaterfallDisplay
            // 
            this.canShrink = false;
            this.Controls.Add(this.bnBipolar);
            this.Controls.Add(this.bnNorm);
            this.Controls.Add(this.bnLog);
            this.Controls.Add(this.wfDisplay);
            this.Controls.Add(this.ioData);
            this.Name = "DataWaterfallDisplay";
            this.shrinkSize = new System.Drawing.Size(93, 341);
            this.shrinkTitle = "CG";
            this.Size = new System.Drawing.Size(170, 167);
            this.title = "Waterfall Data";
            this.ResumeLayout(false);

        }

        private RTIO ioData;
        private RTWaterfall wfDisplay;

        private RTButton bnLog;
        private RTButton bnNorm;

        private bool log;
        private RTButton bnBipolar;
        private bool norm;
        private bool bipolar;

        private void init()
        {
            InitializeComponent();

            bnLog.buttonState = log;
            bnNorm.buttonState = norm;
            bnBipolar.buttonState = bipolar;

            bnLog.buttonStateChanged += BnLog_buttonStateChanged;
            bnNorm.buttonStateChanged += BnNorm_buttonStateChanged;
            bnBipolar.buttonStateChanged += BnBipolar_buttonStateChanged;

            processingType = ProcessingType.Processor;
        }
        
        public DataWaterfallDisplay() : base()
        {
            init();
        }

        public DataWaterfallDisplay(SystemPanel _owner, BinaryReader src) : base(_owner, src)
        {
            log = src.ReadBoolean();
            norm = src.ReadBoolean();
            bipolar = src.ReadBoolean();

            init();
        }

        public override void writeToFile(BinaryWriter tgt)
        {
            base.writeToFile(tgt);

            tgt.Write(log);
            tgt.Write(norm);
            tgt.Write(bipolar);
        }

        private void BnBipolar_buttonStateChanged(object sender, EventArgs e)
        {
            if (bnBipolar.buttonState != bipolar)
            {
                bipolar = bnBipolar.buttonState;
                wfDisplay.bipolar = bipolar;
                if (bipolar)
                    wfDisplay.colorSet = "WMbKrYW";
                else
                    wfDisplay.colorSet = "KrYW";
            }
        }

        private void BnNorm_buttonStateChanged(object sender, EventArgs e)
        {
            norm = bnNorm.buttonState;
        }

        private void BnLog_buttonStateChanged(object sender, EventArgs e)
        {
            log = bnLog.buttonState;
        }

        private double[] tempdata;

        public override void tick()
        {
            if (!_active)
                return;

            DataBuffer dbin = getDataInputBuffer(ioData);

            if ((dbin == null) || (dbin.size < 1))
                return;

            int sze = dbin.size;

            if (wfDisplay.ySteps != sze)
                wfDisplay.ySteps = sze;

            if ((tempdata == null) || (tempdata.Length != sze))
                tempdata = new double[sze];

            Array.Copy(dbin.data, tempdata, sze);

            if (log)
            {
                for (int i=0;i<sze;i++)
                {
                    if (tempdata[i] < 1e-6) tempdata[i] = -120;
                    else if (tempdata[i] > 10) tempdata[i] = 20;
                    else tempdata[i] = 20 * Math.Log10(tempdata[i]);
                    tempdata[i] = (tempdata[i] - (-120)) / (20 - (-120));
                }
            }
            if (norm)
            {
                double emin, emax;
                emin = emax = tempdata[0];
                for (int i=1;i<sze;i++)
                {
                    if (tempdata[i] < emin) emin = tempdata[i];
                    if (tempdata[i] > emax) emax = tempdata[i];
                }
                if (emax <= emin)
                    emax = emin + 1;
                if (bipolar)
                {
                    for (int i = 0; i < sze; i++)
                        tempdata[i] = (tempdata[i] - emin) / (emax - emin) * 2.0 - 1.0;
                }
                else
                {
                    for (int i = 0; i < sze; i++)
                        tempdata[i] = (tempdata[i] - emin) / (emax - emin);
                }
            }

            wfDisplay.addColumn(tempdata);
        }

        class RegisterClass1 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Data", "Waterfall Display" }; }
            public override RTForm Instantiate() { return new DataWaterfallDisplay(); }
        }

        public static void Register(List<RTObjectReference> l)
        {
            l.Add(new RegisterClass1());
        }



    }


}
