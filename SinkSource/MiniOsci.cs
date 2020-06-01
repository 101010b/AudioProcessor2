using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioProcessor.SinkSource
{
    class MiniOsci : RTForm
    {

        public void InitializeComponent()
        {
            this.ioS = new AudioProcessor.RTIO();
            this.bnDCAC = new AudioProcessor.RTButton();
            this.xyDisplay = new AudioProcessor.RTXY();
            this.clTime = new AudioProcessor.RTChoice();
            this.clY = new AudioProcessor.RTChoice();
            this.SuspendLayout();
            // 
            // ioS
            // 
            this.ioS.contactBackColor = System.Drawing.Color.Black;
            this.ioS.contactColor = System.Drawing.Color.DimGray;
            this.ioS.contactHighlightColor = System.Drawing.Color.Red;
            this.ioS.hideOnShrink = false;
            this.ioS.highlighted = false;
            this.ioS.IOtype = AudioProcessor.RTIO.ProcessingIOType.SignalInput;
            this.ioS.Location = new System.Drawing.Point(0, 30);
            this.ioS.Name = "ioS";
            this.ioS.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.ioS.showTitle = false;
            this.ioS.Size = new System.Drawing.Size(21, 20);
            this.ioS.TabIndex = 13;
            this.ioS.Text = "rtio1";
            this.ioS.title = "FM";
            this.ioS.titleColor = System.Drawing.Color.DimGray;
            this.ioS.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            // 
            // bnDCAC
            // 
            this.bnDCAC.buttonDim = new System.Drawing.Size(30, 15);
            this.bnDCAC.buttonState = false;
            this.bnDCAC.buttonType = AudioProcessor.RTButton.RTButtonType.ToggleButton;
            this.bnDCAC.fillOffColor = System.Drawing.Color.Green;
            this.bnDCAC.fillOnColor = System.Drawing.Color.Navy;
            this.bnDCAC.frameHoldColor = System.Drawing.Color.Yellow;
            this.bnDCAC.frameOffColor = System.Drawing.Color.Lime;
            this.bnDCAC.frameOnColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.bnDCAC.hideOnShrink = true;
            this.bnDCAC.Location = new System.Drawing.Point(176, 82);
            this.bnDCAC.Name = "bnDCAC";
            this.bnDCAC.offText = "DC";
            this.bnDCAC.onText = "AC";
            this.bnDCAC.Size = new System.Drawing.Size(31, 16);
            this.bnDCAC.TabIndex = 35;
            this.bnDCAC.Text = "rtButton2";
            this.bnDCAC.textFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.bnDCAC.textOffColor = System.Drawing.Color.Lime;
            this.bnDCAC.textOnColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.bnDCAC.title = "Button";
            this.bnDCAC.titleColor = System.Drawing.Color.DimGray;
            this.bnDCAC.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.bnDCAC.titlePos = AudioProcessor.RTButton.RTTitlePos.Off;
            // 
            // xyDisplay
            // 
            this.xyDisplay.colorSet = "KrYW";
            this.xyDisplay.displaySize = new System.Drawing.Size(100, 100);
            this.xyDisplay.fadeFactor = 0.8D;
            this.xyDisplay.frameColor = System.Drawing.Color.DimGray;
            this.xyDisplay.hideOnShrink = false;
            this.xyDisplay.Location = new System.Drawing.Point(27, 30);
            this.xyDisplay.Name = "xyDisplay";
            this.xyDisplay.Size = new System.Drawing.Size(104, 104);
            this.xyDisplay.TabIndex = 36;
            this.xyDisplay.Text = "Test";
            this.xyDisplay.title = "XY";
            this.xyDisplay.titleColor = System.Drawing.Color.DimGray;
            this.xyDisplay.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.xyDisplay.titlePos = AudioProcessor.GraphicsUtil.TextAlignment.off;
            this.xyDisplay.xSteps = 64;
            this.xyDisplay.ySteps = 64;
            // 
            // clTime
            // 
            this.clTime.backColor = System.Drawing.Color.Black;
            this.clTime.choiceType = AudioProcessor.RTChoice.ChoiceType.ListDefined;
            this.clTime.frontColor = System.Drawing.Color.DimGray;
            this.clTime.hideOnShrink = true;
            this.clTime.Location = new System.Drawing.Point(137, 30);
            this.clTime.Name = "clTime";
            this.clTime.numericMax = 100;
            this.clTime.numericMin = 0;
            this.clTime.offString = "off";
            this.clTime.selectedItem = -1;
            this.clTime.Size = new System.Drawing.Size(100, 20);
            this.clTime.TabIndex = 37;
            this.clTime.Text = "rtChoice1";
            this.clTime.title = "time";
            this.clTime.titleColor = System.Drawing.Color.DimGray;
            this.clTime.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.clTime.valueFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.clTime.xdim = 50;
            // 
            // clY
            // 
            this.clY.backColor = System.Drawing.Color.Black;
            this.clY.choiceType = AudioProcessor.RTChoice.ChoiceType.ListDefined;
            this.clY.frontColor = System.Drawing.Color.DimGray;
            this.clY.hideOnShrink = true;
            this.clY.Location = new System.Drawing.Point(137, 56);
            this.clY.Name = "clY";
            this.clY.numericMax = 100;
            this.clY.numericMin = 0;
            this.clY.offString = "off";
            this.clY.selectedItem = -1;
            this.clY.Size = new System.Drawing.Size(100, 20);
            this.clY.TabIndex = 38;
            this.clY.Text = "rtChoice2";
            this.clY.title = "Y";
            this.clY.titleColor = System.Drawing.Color.DimGray;
            this.clY.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.clY.valueFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.clY.xdim = 50;
            // 
            // MiniOsci
            // 
            this.Controls.Add(this.clY);
            this.Controls.Add(this.clTime);
            this.Controls.Add(this.xyDisplay);
            this.Controls.Add(this.bnDCAC);
            this.Controls.Add(this.ioS);
            this.Name = "MiniOsci";
            this.shrinkSize = new System.Drawing.Size(144, 146);
            this.shrinkTitle = "MiniOsci";
            this.Size = new System.Drawing.Size(244, 146);
            this.title = "MiniOsci";
            this.ResumeLayout(false);

        }

        private RTIO ioS;

        private RTButton bnDCAC;
        private RTXY xyDisplay;
        private RTChoice clTime;
        private RTChoice clY;
        private bool AC;
        private double timescale;
        private double yscale;

        double[] timescales = new double[] {
            0.1e-3, 0.2e-3, 0.5e-3,
            1e-3,2e-3,5e-3,
            10e-3, 20e-3, 50e-3,
            100e-3, 200e-3, 500e-3 };
        double[] yscales = new double[] {
            0.001, 0.002, 0.005,
            0.01, 0.02, 0.05,
            0.1, 0.2, 0.5,
            1, 2, 5,
            10, 20, 50 };

        private void init()
        {
            InitializeComponent();

            List<RTChoice.RTDrawable> timelist = new List<RTChoice.RTDrawable>();
            int selected = 3;
            for (int i=0;i<timescales.Length;i++)
            {
                double ts = timescales[i];
                if (Math.Abs(ts / timescale - 1.0) < 0.05)
                    selected = i;
                if (ts < 0.001)
                    timelist.Add(new RTChoice.RTDrawableText(string.Format("{0:F1} ms", ts*1000)));
                else if (ts < 0.1)
                    timelist.Add(new RTChoice.RTDrawableText(string.Format("{0:F0} ms", ts*1000)));
                else
                    timelist.Add(new RTChoice.RTDrawableText(string.Format("{0:F1} s", ts)));
            }
            clTime.setEntries(timelist);
            clTime.selectedItem = selected;

            List<RTChoice.RTDrawable> scalelist = new List<RTChoice.RTDrawable>();
            selected = 9;
            for (int i=0;i<yscales.Length;i++)
            {
                double ys = yscales[i];
                if (Math.Abs(ys / yscale - 1.0) < 0.05)
                    selected = i;
                if (ys < 0.01)
                    scalelist.Add(new RTChoice.RTDrawableText(string.Format("{0:F0} m", ys*1000)));
                else if (ys < 0.1)
                    scalelist.Add(new RTChoice.RTDrawableText(string.Format("{0:F2}", ys)));
                else if (ys < 1)
                    scalelist.Add(new RTChoice.RTDrawableText(string.Format("{0:F1}", ys)));
                else
                    scalelist.Add(new RTChoice.RTDrawableText(string.Format("{0:F0}", ys)));
            }
            clY.setEntries(scalelist);
            clY.selectedItem = selected;

            bnDCAC.buttonState = AC;

            clTime.choiceStateChanged += ClTime_choiceStateChanged;
            clY.choiceStateChanged += ClY_choiceStateChanged;
            bnDCAC.buttonStateChanged += BnDCAC_buttonStateChanged;


            processingType = ProcessingType.Processor;
        }

        private void BnDCAC_buttonStateChanged(object sender, EventArgs e)
        {
            AC = bnDCAC.buttonState;
        }

        private void ClY_choiceStateChanged(object sender, EventArgs e)
        {
            yscale = yscales[clY.selectedItem];
        }

        private void ClTime_choiceStateChanged(object sender, EventArgs e)
        {
            timescale = timescales[clTime.selectedItem];
        }

        public MiniOsci() : base()
        {
            AC = false;
            yscale = 1;
            timescale = 0.001;

            init();
        }

        public MiniOsci(SystemPanel _owner, BinaryReader src) : base(_owner, src)
        {
            AC = src.ReadBoolean();
            yscale = src.ReadDouble();
            timescale = src.ReadDouble();

            init();
        }

        public override void writeToFile(BinaryWriter tgt)
        {
            base.writeToFile(tgt);

            tgt.Write(AC);
            tgt.Write(yscale);
            tgt.Write(timescale);
        }

        private double[] xdata;
        private int xsample,lastn;
        private int waitfortrig;
        private double[] ydata;
        private double ylast;
        private double acy = 0;

        public override void tick()
        {
            if (!_active)
                return;

            SignalBuffer sin = getSignalInputBuffer(ioS);

            if (sin == null)
                return;
            int xsteps = xyDisplay.xSteps;
            int smps = (int)Math.Floor(owner.sampleRate * timescale+0.5);
            if ((xdata == null) || (xdata.Length != xsteps))
            {
                xdata = new double[xsteps];
                for (int i = 0; i < xsteps; i++)
                    xdata[i] = -1.0 + 2.0 * i / xsteps;
                ydata = new double[xsteps];
                lastn = -1;
                xsample = 0;
                waitfortrig = 0;
                ylast = 0;
            }
            for (int i=0;i<owner.blockSize;i++)
            {
                if (waitfortrig >= 0)
                    waitfortrig++;
                double y = sin.data[i] / yscale;
                acy = acy * 0.99 + y * 0.01;
                if (AC)
                    y -= acy;
                if ((y > 0) && (ylast <= 0)) 
                    waitfortrig = -1; // Triggered
                ylast = y;
                if (waitfortrig > 5 * smps)
                    waitfortrig = -1; // Auto Trigger
                if (waitfortrig < 0)
                {
                    int n = xsample * xsteps / smps;
                    if ((lastn >= 0) && (lastn < n - 1))
                    { // Interpolate in x-direction
                        for (int j = lastn + 1; j <= n; j++)
                        {
                            double q = (double)(j - lastn) / (n - lastn);
                            if (j < xsteps)
                                ydata[j] = ydata[lastn] * (1.0 - q) + y * q;
                        }
                    }
                    else
                    {
                        if (n < xsteps)
                            ydata[n] = y;
                    }
                    lastn = n;
                    xsample++;
                    if (n >= xsteps)
                    {
                        xyDisplay.addData(xdata, ydata);
                        Array.Clear(ydata, 0, xdata.Length);
                        xsample = 0;
                        lastn = -1;
                        waitfortrig = 0;
                    }
                }
            }
        }

        class RegisterClass1 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Tools", "MiniOsci" }; }
            public override RTForm Instantiate() { return new MiniOsci(); }
        }

        public static void Register(List<RTObjectReference> l)
        {
            l.Add(new RegisterClass1());
        }



    }


}
