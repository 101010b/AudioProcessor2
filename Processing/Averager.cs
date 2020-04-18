using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioProcessor.Processing
{

    class Averager:RTForm
    {

        public void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Averager));
            this.ioO = new AudioProcessor.RTIO();
            this.ioI = new AudioProcessor.RTIO();
            this.ioT = new AudioProcessor.RTIO();
            this.slAlgo = new AudioProcessor.RTSelector();
            this.bnAC = new AudioProcessor.RTButton();
            this.clTime = new AudioProcessor.RTChoice();
            this.SuspendLayout();
            // 
            // ioO
            // 
            this.ioO.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ioO.contactBackColor = System.Drawing.Color.Black;
            this.ioO.contactColor = System.Drawing.Color.DimGray;
            this.ioO.Location = new System.Drawing.Point(282, 26);
            this.ioO.Name = "ioO";
            this.ioO.orientation = AudioProcessor.RTIO.RTOrientation.East;
            this.ioO.showTitle = true;
            this.ioO.Size = new System.Drawing.Size(50, 20);
            this.ioO.TabIndex = 6;
            this.ioO.Text = "rtio3";
            this.ioO.title = "Avg";
            this.ioO.titleColor = System.Drawing.Color.DimGray;
            this.ioO.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioO.type = AudioProcessor.RTIO.ProcessingIOType.Output;
            // 
            // ioI
            // 
            this.ioI.contactBackColor = System.Drawing.Color.Black;
            this.ioI.contactColor = System.Drawing.Color.DimGray;
            this.ioI.Location = new System.Drawing.Point(0, 26);
            this.ioI.Name = "ioI";
            this.ioI.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.ioI.showTitle = true;
            this.ioI.Size = new System.Drawing.Size(44, 20);
            this.ioI.TabIndex = 5;
            this.ioI.Text = "rtio1";
            this.ioI.title = "In";
            this.ioI.titleColor = System.Drawing.Color.DimGray;
            this.ioI.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioI.type = AudioProcessor.RTIO.ProcessingIOType.Input;
            // 
            // ioT
            // 
            this.ioT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ioT.contactBackColor = System.Drawing.Color.Black;
            this.ioT.contactColor = System.Drawing.Color.DimGray;
            this.ioT.Location = new System.Drawing.Point(282, 52);
            this.ioT.Name = "ioT";
            this.ioT.orientation = AudioProcessor.RTIO.RTOrientation.East;
            this.ioT.showTitle = true;
            this.ioT.Size = new System.Drawing.Size(50, 20);
            this.ioT.TabIndex = 7;
            this.ioT.Text = "rtio3";
            this.ioT.title = "Trig";
            this.ioT.titleColor = System.Drawing.Color.DimGray;
            this.ioT.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioT.type = AudioProcessor.RTIO.ProcessingIOType.Output;
            // 
            // slAlgo
            // 
            this.slAlgo.entries = ((System.Collections.Generic.List<string>)(resources.GetObject("slAlgo.entries")));
            this.slAlgo.frameColor = System.Drawing.Color.DimGray;
            this.slAlgo.Location = new System.Drawing.Point(50, 26);
            this.slAlgo.Name = "slAlgo";
            this.slAlgo.selectedItem = -1;
            this.slAlgo.Size = new System.Drawing.Size(213, 20);
            this.slAlgo.TabIndex = 8;
            this.slAlgo.Text = "rtSelector1";
            this.slAlgo.textColor = System.Drawing.Color.White;
            this.slAlgo.textFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.slAlgo.title = "Algorithm";
            this.slAlgo.titleColor = System.Drawing.Color.DimGray;
            this.slAlgo.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.slAlgo.xdim = 150;
            // 
            // bnAC
            // 
            this.bnAC.buttonDim = new System.Drawing.Size(30, 15);
            this.bnAC.buttonState = false;
            this.bnAC.buttonType = AudioProcessor.RTButton.RTButtonType.ToggleButton;
            this.bnAC.fillOffColor = System.Drawing.Color.Navy;
            this.bnAC.fillOnColor = System.Drawing.Color.DarkRed;
            this.bnAC.frameHoldColor = System.Drawing.Color.Yellow;
            this.bnAC.frameOffColor = System.Drawing.Color.DimGray;
            this.bnAC.frameOnColor = System.Drawing.Color.Red;
            this.bnAC.Location = new System.Drawing.Point(13, 55);
            this.bnAC.Name = "bnAC";
            this.bnAC.offText = "DC";
            this.bnAC.onText = "AC";
            this.bnAC.Size = new System.Drawing.Size(31, 16);
            this.bnAC.TabIndex = 13;
            this.bnAC.Text = "rtButton2";
            this.bnAC.textFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.bnAC.textOffColor = System.Drawing.Color.DimGray;
            this.bnAC.textOnColor = System.Drawing.Color.Red;
            this.bnAC.title = "Button";
            this.bnAC.titleColor = System.Drawing.Color.DimGray;
            this.bnAC.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.bnAC.titlePos = AudioProcessor.RTButton.RTTitlePos.Off;
            // 
            // clTime
            // 
            this.clTime.backColor = System.Drawing.Color.Black;
            this.clTime.frontColor = System.Drawing.Color.DimGray;
            this.clTime.Location = new System.Drawing.Point(76, 52);
            this.clTime.Name = "clTime";
            this.clTime.selectedItem = -1;
            this.clTime.Size = new System.Drawing.Size(108, 20);
            this.clTime.TabIndex = 14;
            this.clTime.Text = "rtChoice1";
            this.clTime.title = "Time";
            this.clTime.titleColor = System.Drawing.Color.DimGray;
            this.clTime.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.clTime.xdim = 60;
            // 
            // Averager
            // 
            this.Controls.Add(this.clTime);
            this.Controls.Add(this.bnAC);
            this.Controls.Add(this.slAlgo);
            this.Controls.Add(this.ioT);
            this.Controls.Add(this.ioO);
            this.Controls.Add(this.ioI);
            this.Name = "Averager";
            this.shrinkSize = new System.Drawing.Size(100, 84);
            this.shrinkTitle = "Avg";
            this.Size = new System.Drawing.Size(332, 84);
            this.title = "Constant Time Average";
            this.ResumeLayout(false);

        }


        List<string> Timings;
        List<double> TimingsD;
        int countTime;
        double countTimeD;
        List<string> Averagers;
        double oval;
        String avgmode;
        Boolean acmode;


        AudioProcessor.Averager averager;
        double[] triglist;
        private RTIO ioO;
        private RTIO ioI;
        private RTIO ioT;
        private RTSelector slAlgo;
        private RTButton bnAC;
        private RTChoice clTime;
        double[] outlist;

        private void init()
        {

            InitializeComponent();

            Timings = new List<string> { "1ms", "2ms", "5ms", "10ms", "20ms", "50ms", "100ms", "200ms", "500ms", "1s", "2s", "5s", "10s" };
            TimingsD = new List<double> { 0.001, 0.002, 0.005, 0.01, 0.02, 0.05, 0.1, 0.2, 0.5, 1, 2, 5, 10 };
            Averagers = AudioProcessor.Averager.getList();

            bnAC.buttonState = acmode;

            slAlgo.entries = Averagers;
            slAlgo.selectedItem = Averagers.FindIndex(r => r.Equals(avgmode));

            List<RTChoice.RTDrawable> drl = new List<RTChoice.RTDrawable>();
            for (int i = 0; i < Timings.Count; i++)
                drl.Add(new RTChoice.RTDrawableText(Timings[i]));
            clTime.setEntries(drl);
            clTime.selectedItem = TimingsD.FindIndex(r => ((r / countTimeD) - 1 < 0.1));

            countTimeD = TimingsD[clTime.selectedItem];

            bnAC.buttonStateChanged += BnAC_buttonStateChanged;
            slAlgo.selectionStateChanged += SlAlgo_selectionStateChanged;
            clTime.choiceStateChanged += ClTime_choiceStateChanged;


            oval = 0;

            processingType = ProcessingType.Processor;
        }

        private void ClTime_choiceStateChanged(object sender, EventArgs e)
        {
            countTimeD = TimingsD[clTime.selectedItem];
            countTime = (int)Math.Floor(countTimeD * owner.sampleRate + 0.5);
            averager.len = countTime;
        }


        private void SlAlgo_selectionStateChanged(object sender, EventArgs e)
        {
            avgmode = Averagers[slAlgo.selectedItem];
            averager.select(avgmode);
        }


        private void BnAC_buttonStateChanged(object sender, EventArgs e)
        {
            acmode = bnAC.buttonState;
        }

        public void AveragerCB(double val, int idx)
        {
            for (int i=idx;i<owner.blockSize;i++)
                outlist[i] = val;
            oval = val;
            triglist[idx] = 1.0;
        }

        public Averager():base()
        {

            countTimeD = 0.1;
            acmode = false;
            avgmode = AudioProcessor.Averager.getList()[0];

            init();
        }

        public Averager(SystemPanel _owner, BinaryReader src):base(_owner,src)
        {
            countTimeD = src.ReadDouble();
            avgmode = src.ReadString();
            acmode = src.ReadBoolean();

            init();
        }

        public override void writeToFile(BinaryWriter tgt)
        {
            base.writeToFile(tgt);

            tgt.Write(countTimeD);
            tgt.Write(avgmode);
            tgt.Write(acmode);
        }

        public override void tick()
        {

            if (averager == null) {
                countTime = (int)Math.Floor(countTimeD * owner.sampleRate + 0.5);
                averager = new AudioProcessor.Averager(owner.sampleRate, countTime, AveragerCB);
                averager.select(avgmode);
            }
            
            if (!_active)
                return;

            DataBuffer dbout = getOutputBuffer(ioO);
            if (dbout == null)
                return;

            if (triglist == null)
                triglist = new double[owner.blockSize];
            if (outlist == null)
                outlist = new double[owner.blockSize];

            Array.Clear(triglist, 0, owner.blockSize);
            for (int i = 0; i < owner.blockSize; i++)
                outlist[i] = oval;


            if (ioI.connectedTo != null)
                averager.process(ioI.connectedTo.output.data,owner.blockSize);
            else
                averager.process(owner.blockSize);

            Array.Copy(outlist, dbout.data, owner.blockSize);
            if (ioT.connectedTo != null)
                Array.Copy(triglist, ioT.connectedTo.input.data, owner.blockSize);
        }

        class RegisterClass : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Arithmetic", "Averager" }; }
            public override RTForm Instantiate() { return new Averager(); }
        }

        public static void Register(List<RTObjectReference> l)
        {
            l.Add(new RegisterClass());
        }

    }
}
