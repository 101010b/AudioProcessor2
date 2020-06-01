using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioProcessor.SinkSource
{
    class MiniXY : RTForm
    {

        public void InitializeComponent()
        {
            this.ioX = new AudioProcessor.RTIO();
            this.bnDCAC = new AudioProcessor.RTButton();
            this.xyDisplay = new AudioProcessor.RTXY();
            this.clXY = new AudioProcessor.RTChoice();
            this.clDecay = new AudioProcessor.RTChoice();
            this.ioY = new AudioProcessor.RTIO();
            this.SuspendLayout();
            // 
            // ioX
            // 
            this.ioX.contactBackColor = System.Drawing.Color.Black;
            this.ioX.contactColor = System.Drawing.Color.DimGray;
            this.ioX.contactHighlightColor = System.Drawing.Color.Red;
            this.ioX.hideOnShrink = false;
            this.ioX.highlighted = false;
            this.ioX.IOtype = AudioProcessor.RTIO.ProcessingIOType.SignalInput;
            this.ioX.Location = new System.Drawing.Point(0, 30);
            this.ioX.Name = "ioX";
            this.ioX.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.ioX.showTitle = false;
            this.ioX.Size = new System.Drawing.Size(21, 20);
            this.ioX.TabIndex = 13;
            this.ioX.Text = "rtio1";
            this.ioX.title = "FM";
            this.ioX.titleColor = System.Drawing.Color.DimGray;
            this.ioX.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
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
            this.bnDCAC.Location = new System.Drawing.Point(185, 82);
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
            // clXY
            // 
            this.clXY.backColor = System.Drawing.Color.Black;
            this.clXY.choiceType = AudioProcessor.RTChoice.ChoiceType.ListDefined;
            this.clXY.frontColor = System.Drawing.Color.DimGray;
            this.clXY.hideOnShrink = true;
            this.clXY.Location = new System.Drawing.Point(137, 56);
            this.clXY.Name = "clXY";
            this.clXY.numericMax = 100;
            this.clXY.numericMin = 0;
            this.clXY.offString = "off";
            this.clXY.selectedItem = -1;
            this.clXY.Size = new System.Drawing.Size(110, 20);
            this.clXY.TabIndex = 38;
            this.clXY.Text = "rtChoice2";
            this.clXY.title = "Scale";
            this.clXY.titleColor = System.Drawing.Color.DimGray;
            this.clXY.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.clXY.valueFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.clXY.xdim = 50;
            // 
            // clDecay
            // 
            this.clDecay.backColor = System.Drawing.Color.Black;
            this.clDecay.choiceType = AudioProcessor.RTChoice.ChoiceType.ListDefined;
            this.clDecay.frontColor = System.Drawing.Color.DimGray;
            this.clDecay.hideOnShrink = true;
            this.clDecay.Location = new System.Drawing.Point(137, 30);
            this.clDecay.Name = "clDecay";
            this.clDecay.numericMax = 100;
            this.clDecay.numericMin = 0;
            this.clDecay.offString = "off";
            this.clDecay.selectedItem = -1;
            this.clDecay.Size = new System.Drawing.Size(110, 20);
            this.clDecay.TabIndex = 39;
            this.clDecay.Text = "rtChoice2";
            this.clDecay.title = "Decay";
            this.clDecay.titleColor = System.Drawing.Color.DimGray;
            this.clDecay.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.clDecay.valueFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.clDecay.xdim = 50;
            // 
            // ioY
            // 
            this.ioY.contactBackColor = System.Drawing.Color.Black;
            this.ioY.contactColor = System.Drawing.Color.DimGray;
            this.ioY.contactHighlightColor = System.Drawing.Color.Red;
            this.ioY.hideOnShrink = false;
            this.ioY.highlighted = false;
            this.ioY.IOtype = AudioProcessor.RTIO.ProcessingIOType.SignalInput;
            this.ioY.Location = new System.Drawing.Point(0, 56);
            this.ioY.Name = "ioY";
            this.ioY.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.ioY.showTitle = false;
            this.ioY.Size = new System.Drawing.Size(21, 20);
            this.ioY.TabIndex = 40;
            this.ioY.Text = "rtio1";
            this.ioY.title = "FM";
            this.ioY.titleColor = System.Drawing.Color.DimGray;
            this.ioY.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            // 
            // MiniXY
            // 
            this.Controls.Add(this.ioY);
            this.Controls.Add(this.clDecay);
            this.Controls.Add(this.clXY);
            this.Controls.Add(this.xyDisplay);
            this.Controls.Add(this.bnDCAC);
            this.Controls.Add(this.ioX);
            this.Name = "MiniXY";
            this.shrinkSize = new System.Drawing.Size(144, 146);
            this.shrinkTitle = "MiniXY";
            this.Size = new System.Drawing.Size(258, 146);
            this.title = "MiniXY";
            this.ResumeLayout(false);

        }

        private RTIO ioX;

        private RTButton bnDCAC;
        private RTXY xyDisplay;
        private RTChoice clXY;
        private bool AC;
        private double xyscale;
        private double decay;
        private RTChoice clDecay;
        private double[] scales = new double[] {
            0.001, 0.002, 0.005,
            0.01, 0.02, 0.05,
            0.1, 0.2, 0.5,
            1, 2, 5,
            10, 20, 50 };
        private RTIO ioY;
        double[] decays = new double[] {
            0.1e-3, 0.2e-3, 0.5e-3,
            1e-3,2e-3,5e-3,
            10e-3, 20e-3, 50e-3,
            100e-3, 200e-3, 500e-3 };

        private void init()
        {
            InitializeComponent();

            List<RTChoice.RTDrawable> timelist = new List<RTChoice.RTDrawable>();
            int selected = 3;
            for (int i = 0; i < decays.Length; i++)
            {
                double ts = decays[i];
                if (Math.Abs(ts / decay - 1.0) < 0.05)
                    selected = i;
                if (ts < 0.001)
                    timelist.Add(new RTChoice.RTDrawableText(string.Format("{0:F1} ms", ts * 1000)));
                else if (ts < 0.1)
                    timelist.Add(new RTChoice.RTDrawableText(string.Format("{0:F0} ms", ts * 1000)));
                else
                    timelist.Add(new RTChoice.RTDrawableText(string.Format("{0:F1} s", ts)));
            }
            clDecay.setEntries(timelist);
            clDecay.selectedItem = selected;

            List<RTChoice.RTDrawable> scalelist = new List<RTChoice.RTDrawable>();
            selected = 9;
            for (int i = 0; i < scales.Length; i++)
            {
                double ys = scales[i];
                if (Math.Abs(ys / xyscale - 1.0) < 0.05)
                    selected = i;
                if (ys < 0.01)
                    scalelist.Add(new RTChoice.RTDrawableText(string.Format("{0:F0} m", ys * 1000)));
                else if (ys < 0.1)
                    scalelist.Add(new RTChoice.RTDrawableText(string.Format("{0:F2}", ys)));
                else if (ys < 1)
                    scalelist.Add(new RTChoice.RTDrawableText(string.Format("{0:F1}", ys)));
                else
                    scalelist.Add(new RTChoice.RTDrawableText(string.Format("{0:F0}", ys)));
            }
            clXY.setEntries(scalelist);
            clXY.selectedItem = selected;

            bnDCAC.buttonState = AC;

            clXY.choiceStateChanged += ClXY_choiceStateChanged;
            clDecay.choiceStateChanged += ClDecay_choiceStateChanged;
            bnDCAC.buttonStateChanged += BnDCAC_buttonStateChanged;


            processingType = ProcessingType.Processor;
        }

        private void ClDecay_choiceStateChanged(object sender, EventArgs e)
        {
            decay = decays[clDecay.selectedItem];
            double ff = Math.Exp((256.0 / 48000) / decay * Math.Log(0.5));
            xyDisplay.fadeFactor = ff;
        }


        private void BnDCAC_buttonStateChanged(object sender, EventArgs e)
        {
            AC = bnDCAC.buttonState;
        }

        private void ClXY_choiceStateChanged(object sender, EventArgs e)
        {
            xyscale = scales[clXY.selectedItem];
        }

        public MiniXY() : base()
        {
            AC = false;
            xyscale = 1;
            decay = 0.001;

            init();
        }

        public MiniXY(SystemPanel _owner, BinaryReader src) : base(_owner, src)
        {
            AC = src.ReadBoolean();
            xyscale = src.ReadDouble();
            decay = src.ReadDouble();

            init();
        }

        public override void writeToFile(BinaryWriter tgt)
        {
            base.writeToFile(tgt);

            tgt.Write(AC);
            tgt.Write(xyscale);
            tgt.Write(decay);
        }

        private double[] xdata;
        private double[] ydata;
        private double acx = 0;
        private double acy = 0;
        private int datafill;


        public override void tick()
        {
            if (!_active)
                return;

            SignalBuffer sx = getSignalInputBuffer(ioX);
            SignalBuffer sy = getSignalInputBuffer(ioY);

            if ((sx == null) && (sy == null))
                return;

            if (xdata == null)
            {
                xdata = new double[256];
                ydata = new double[256];
                datafill = 0;
            }

            for (int i = 0; i < owner.blockSize; i++)
            {
                double x = 0;
                double y = 0;
                if (sx != null)
                    x = sx.data[i] / xyscale;
                if (sy != null)
                    y = sy.data[i] / xyscale;

                acx = acx * 0.99 + x * 0.01;
                acy = acy * 0.99 + y * 0.01;

                if (AC)
                {
                    x -= acx;
                    y -= acy;
                }

                xdata[datafill] = x;
                ydata[datafill] = y;
                datafill++;

                if (datafill >= 256)
                {
                    xyDisplay.addData(xdata, ydata);
                    datafill = 0;
                }
            }
        }

        class RegisterClass1 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Tools", "MiniXY" }; }
            public override RTForm Instantiate() { return new MiniXY(); }
        }

        public static void Register(List<RTObjectReference> l)
        {
            l.Add(new RegisterClass1());
        }



    }


}
