using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AudioProcessor.SinkSource
{
    class ShapeGen : RTForm
    {

        public void InitializeComponent()
        {
            this.ioSig = new AudioProcessor.RTIO();
            this.ioGateOut = new AudioProcessor.RTIO();
            this.ioGateIn = new AudioProcessor.RTIO();
            this.ioTrig = new AudioProcessor.RTIO();
            this.dlAttack = new AudioProcessor.RTDial();
            this.dlDecay = new AudioProcessor.RTDial();
            this.dlSustain = new AudioProcessor.RTDial();
            this.dlFade = new AudioProcessor.RTDial();
            this.dlAttackLevel = new AudioProcessor.RTDial();
            this.dlDecayLevel = new AudioProcessor.RTDial();
            this.bnGated = new AudioProcessor.RTButton();
            this.ledRun = new AudioProcessor.RTLED();
            this.bnTest = new AudioProcessor.RTButton();
            this.spMain = new AudioProcessor.RTShape();
            this.SuspendLayout();
            // 
            // ioSig
            // 
            this.ioSig.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ioSig.contactBackColor = System.Drawing.Color.Black;
            this.ioSig.contactColor = System.Drawing.Color.DimGray;
            this.ioSig.contactHighlightColor = System.Drawing.Color.Red;
            this.ioSig.highlighted = false;
            this.ioSig.Location = new System.Drawing.Point(571, 34);
            this.ioSig.Name = "ioSig";
            this.ioSig.orientation = AudioProcessor.RTIO.RTOrientation.East;
            this.ioSig.showTitle = true;
            this.ioSig.Size = new System.Drawing.Size(50, 20);
            this.ioSig.TabIndex = 0;
            this.ioSig.Text = "rtio1";
            this.ioSig.title = "S";
            this.ioSig.titleColor = System.Drawing.Color.DimGray;
            this.ioSig.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioSig.type = AudioProcessor.RTIO.ProcessingIOType.Output;
            // 
            // ioGateOut
            // 
            this.ioGateOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ioGateOut.contactBackColor = System.Drawing.Color.Black;
            this.ioGateOut.contactColor = System.Drawing.Color.DimGray;
            this.ioGateOut.contactHighlightColor = System.Drawing.Color.Red;
            this.ioGateOut.highlighted = false;
            this.ioGateOut.Location = new System.Drawing.Point(571, 60);
            this.ioGateOut.Name = "ioGateOut";
            this.ioGateOut.orientation = AudioProcessor.RTIO.RTOrientation.East;
            this.ioGateOut.showTitle = true;
            this.ioGateOut.Size = new System.Drawing.Size(50, 20);
            this.ioGateOut.TabIndex = 1;
            this.ioGateOut.Text = "rtio2";
            this.ioGateOut.title = "gate";
            this.ioGateOut.titleColor = System.Drawing.Color.DimGray;
            this.ioGateOut.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioGateOut.type = AudioProcessor.RTIO.ProcessingIOType.Output;
            // 
            // ioGateIn
            // 
            this.ioGateIn.contactBackColor = System.Drawing.Color.Black;
            this.ioGateIn.contactColor = System.Drawing.Color.DimGray;
            this.ioGateIn.contactHighlightColor = System.Drawing.Color.Red;
            this.ioGateIn.highlighted = false;
            this.ioGateIn.Location = new System.Drawing.Point(0, 60);
            this.ioGateIn.Name = "ioGateIn";
            this.ioGateIn.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.ioGateIn.showTitle = true;
            this.ioGateIn.Size = new System.Drawing.Size(50, 20);
            this.ioGateIn.TabIndex = 3;
            this.ioGateIn.Text = "rtio3";
            this.ioGateIn.title = "gate";
            this.ioGateIn.titleColor = System.Drawing.Color.DimGray;
            this.ioGateIn.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioGateIn.type = AudioProcessor.RTIO.ProcessingIOType.Input;
            // 
            // ioTrig
            // 
            this.ioTrig.contactBackColor = System.Drawing.Color.Black;
            this.ioTrig.contactColor = System.Drawing.Color.DimGray;
            this.ioTrig.contactHighlightColor = System.Drawing.Color.Red;
            this.ioTrig.highlighted = false;
            this.ioTrig.Location = new System.Drawing.Point(0, 34);
            this.ioTrig.Name = "ioTrig";
            this.ioTrig.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.ioTrig.showTitle = true;
            this.ioTrig.Size = new System.Drawing.Size(50, 20);
            this.ioTrig.TabIndex = 2;
            this.ioTrig.Text = "rtio4";
            this.ioTrig.title = "Trig";
            this.ioTrig.titleColor = System.Drawing.Color.DimGray;
            this.ioTrig.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioTrig.type = AudioProcessor.RTIO.ProcessingIOType.Input;
            // 
            // dlAttack
            // 
            this.dlAttack.dialColor = System.Drawing.Color.Silver;
            this.dlAttack.dialDiameter = 50D;
            this.dlAttack.dialMarkColor = System.Drawing.Color.Red;
            this.dlAttack.format = "F2";
            this.dlAttack.Location = new System.Drawing.Point(56, 34);
            this.dlAttack.logScale = true;
            this.dlAttack.maxVal = 100D;
            this.dlAttack.minVal = 0.01D;
            this.dlAttack.Name = "dlAttack";
            this.dlAttack.scaleColor = System.Drawing.Color.Gold;
            this.dlAttack.showScale = true;
            this.dlAttack.showTitle = true;
            this.dlAttack.showValue = true;
            this.dlAttack.Size = new System.Drawing.Size(80, 80);
            this.dlAttack.TabIndex = 12;
            this.dlAttack.Text = "rtDial1";
            this.dlAttack.title = "Attack";
            this.dlAttack.titleColor = System.Drawing.Color.DimGray;
            this.dlAttack.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.dlAttack.unit = "ms";
            this.dlAttack.val = 1D;
            this.dlAttack.valueColor = System.Drawing.Color.DimGray;
            this.dlAttack.valueFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            // 
            // dlDecay
            // 
            this.dlDecay.dialColor = System.Drawing.Color.Silver;
            this.dlDecay.dialDiameter = 50D;
            this.dlDecay.dialMarkColor = System.Drawing.Color.Red;
            this.dlDecay.format = "F2";
            this.dlDecay.Location = new System.Drawing.Point(228, 34);
            this.dlDecay.logScale = true;
            this.dlDecay.maxVal = 1000D;
            this.dlDecay.minVal = 0.01D;
            this.dlDecay.Name = "dlDecay";
            this.dlDecay.scaleColor = System.Drawing.Color.Gold;
            this.dlDecay.showScale = true;
            this.dlDecay.showTitle = true;
            this.dlDecay.showValue = true;
            this.dlDecay.Size = new System.Drawing.Size(80, 80);
            this.dlDecay.TabIndex = 13;
            this.dlDecay.Text = "rtDial2";
            this.dlDecay.title = "Decay";
            this.dlDecay.titleColor = System.Drawing.Color.DimGray;
            this.dlDecay.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.dlDecay.unit = "ms";
            this.dlDecay.val = 1D;
            this.dlDecay.valueColor = System.Drawing.Color.DimGray;
            this.dlDecay.valueFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            // 
            // dlSustain
            // 
            this.dlSustain.dialColor = System.Drawing.Color.Silver;
            this.dlSustain.dialDiameter = 50D;
            this.dlSustain.dialMarkColor = System.Drawing.Color.Red;
            this.dlSustain.format = "F2";
            this.dlSustain.Location = new System.Drawing.Point(314, 34);
            this.dlSustain.logScale = true;
            this.dlSustain.maxVal = 1000D;
            this.dlSustain.minVal = 1D;
            this.dlSustain.Name = "dlSustain";
            this.dlSustain.scaleColor = System.Drawing.Color.Gold;
            this.dlSustain.showScale = true;
            this.dlSustain.showTitle = true;
            this.dlSustain.showValue = true;
            this.dlSustain.Size = new System.Drawing.Size(80, 80);
            this.dlSustain.TabIndex = 14;
            this.dlSustain.Text = "rtDial3";
            this.dlSustain.title = "Sustain";
            this.dlSustain.titleColor = System.Drawing.Color.DimGray;
            this.dlSustain.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.dlSustain.unit = "ms";
            this.dlSustain.val = 100D;
            this.dlSustain.valueColor = System.Drawing.Color.DimGray;
            this.dlSustain.valueFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            // 
            // dlFade
            // 
            this.dlFade.dialColor = System.Drawing.Color.Silver;
            this.dlFade.dialDiameter = 50D;
            this.dlFade.dialMarkColor = System.Drawing.Color.Red;
            this.dlFade.format = "F2";
            this.dlFade.Location = new System.Drawing.Point(486, 34);
            this.dlFade.logScale = true;
            this.dlFade.maxVal = 10000D;
            this.dlFade.minVal = 1D;
            this.dlFade.Name = "dlFade";
            this.dlFade.scaleColor = System.Drawing.Color.Gold;
            this.dlFade.showScale = true;
            this.dlFade.showTitle = true;
            this.dlFade.showValue = true;
            this.dlFade.Size = new System.Drawing.Size(80, 80);
            this.dlFade.TabIndex = 15;
            this.dlFade.Text = "rtDial4";
            this.dlFade.title = "Fade";
            this.dlFade.titleColor = System.Drawing.Color.DimGray;
            this.dlFade.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.dlFade.unit = "ms";
            this.dlFade.val = 100D;
            this.dlFade.valueColor = System.Drawing.Color.DimGray;
            this.dlFade.valueFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            // 
            // dlAttackLevel
            // 
            this.dlAttackLevel.dialColor = System.Drawing.Color.Silver;
            this.dlAttackLevel.dialDiameter = 50D;
            this.dlAttackLevel.dialMarkColor = System.Drawing.Color.Red;
            this.dlAttackLevel.format = "F2";
            this.dlAttackLevel.Location = new System.Drawing.Point(142, 34);
            this.dlAttackLevel.logScale = false;
            this.dlAttackLevel.maxVal = 10D;
            this.dlAttackLevel.minVal = -10D;
            this.dlAttackLevel.Name = "dlAttackLevel";
            this.dlAttackLevel.scaleColor = System.Drawing.Color.Gold;
            this.dlAttackLevel.showScale = true;
            this.dlAttackLevel.showTitle = true;
            this.dlAttackLevel.showValue = true;
            this.dlAttackLevel.Size = new System.Drawing.Size(80, 80);
            this.dlAttackLevel.TabIndex = 16;
            this.dlAttackLevel.Text = "rtDial5";
            this.dlAttackLevel.title = "Level";
            this.dlAttackLevel.titleColor = System.Drawing.Color.DimGray;
            this.dlAttackLevel.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.dlAttackLevel.unit = "";
            this.dlAttackLevel.val = 1D;
            this.dlAttackLevel.valueColor = System.Drawing.Color.DimGray;
            this.dlAttackLevel.valueFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            // 
            // dlDecayLevel
            // 
            this.dlDecayLevel.dialColor = System.Drawing.Color.Silver;
            this.dlDecayLevel.dialDiameter = 50D;
            this.dlDecayLevel.dialMarkColor = System.Drawing.Color.Red;
            this.dlDecayLevel.format = "F2";
            this.dlDecayLevel.Location = new System.Drawing.Point(400, 34);
            this.dlDecayLevel.logScale = false;
            this.dlDecayLevel.maxVal = 10D;
            this.dlDecayLevel.minVal = -10D;
            this.dlDecayLevel.Name = "dlDecayLevel";
            this.dlDecayLevel.scaleColor = System.Drawing.Color.Gold;
            this.dlDecayLevel.showScale = true;
            this.dlDecayLevel.showTitle = true;
            this.dlDecayLevel.showValue = true;
            this.dlDecayLevel.Size = new System.Drawing.Size(80, 80);
            this.dlDecayLevel.TabIndex = 17;
            this.dlDecayLevel.Text = "rtDial6";
            this.dlDecayLevel.title = "Level";
            this.dlDecayLevel.titleColor = System.Drawing.Color.DimGray;
            this.dlDecayLevel.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.dlDecayLevel.unit = "";
            this.dlDecayLevel.val = 0.5D;
            this.dlDecayLevel.valueColor = System.Drawing.Color.DimGray;
            this.dlDecayLevel.valueFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            // 
            // bnGated
            // 
            this.bnGated.buttonDim = new System.Drawing.Size(50, 15);
            this.bnGated.buttonState = false;
            this.bnGated.buttonType = AudioProcessor.RTButton.RTButtonType.ToggleButton;
            this.bnGated.fillOffColor = System.Drawing.Color.Navy;
            this.bnGated.fillOnColor = System.Drawing.Color.DarkRed;
            this.bnGated.frameHoldColor = System.Drawing.Color.Yellow;
            this.bnGated.frameOffColor = System.Drawing.Color.DimGray;
            this.bnGated.frameOnColor = System.Drawing.Color.Red;
            this.bnGated.Location = new System.Drawing.Point(339, 120);
            this.bnGated.Name = "bnGated";
            this.bnGated.offText = "Fix";
            this.bnGated.onText = "Gated";
            this.bnGated.Size = new System.Drawing.Size(51, 16);
            this.bnGated.TabIndex = 18;
            this.bnGated.Text = "rtButton2";
            this.bnGated.textFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.bnGated.textOffColor = System.Drawing.Color.DimGray;
            this.bnGated.textOnColor = System.Drawing.Color.Red;
            this.bnGated.title = "Button";
            this.bnGated.titleColor = System.Drawing.Color.DimGray;
            this.bnGated.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.bnGated.titlePos = AudioProcessor.RTButton.RTTitlePos.Off;
            // 
            // ledRun
            // 
            this.ledRun.fillOffColor = System.Drawing.Color.Black;
            this.ledRun.fillOnColor = System.Drawing.Color.DarkRed;
            this.ledRun.frameOffColor = System.Drawing.Color.DimGray;
            this.ledRun.frameOnColor = System.Drawing.Color.Red;
            this.ledRun.LEDDim = new System.Drawing.Size(15, 15);
            this.ledRun.LEDState = false;
            this.ledRun.Location = new System.Drawing.Point(466, 3);
            this.ledRun.Name = "ledRun";
            this.ledRun.offText = "";
            this.ledRun.onText = "";
            this.ledRun.Size = new System.Drawing.Size(100, 26);
            this.ledRun.TabIndex = 19;
            this.ledRun.Text = "rtled1";
            this.ledRun.textFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ledRun.textOffColor = System.Drawing.Color.DimGray;
            this.ledRun.textOnColor = System.Drawing.Color.Red;
            this.ledRun.title = "Running";
            this.ledRun.titleColor = System.Drawing.Color.DimGray;
            this.ledRun.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ledRun.titlePos = AudioProcessor.RTLED.RTTitlePos.Left;
            // 
            // bnTest
            // 
            this.bnTest.buttonDim = new System.Drawing.Size(30, 15);
            this.bnTest.buttonState = false;
            this.bnTest.buttonType = AudioProcessor.RTButton.RTButtonType.HoldButton;
            this.bnTest.fillOffColor = System.Drawing.Color.Black;
            this.bnTest.fillOnColor = System.Drawing.Color.DarkRed;
            this.bnTest.frameHoldColor = System.Drawing.Color.Yellow;
            this.bnTest.frameOffColor = System.Drawing.Color.DimGray;
            this.bnTest.frameOnColor = System.Drawing.Color.Red;
            this.bnTest.Location = new System.Drawing.Point(8, 86);
            this.bnTest.Name = "bnTest";
            this.bnTest.offText = "Off";
            this.bnTest.onText = "On";
            this.bnTest.Size = new System.Drawing.Size(42, 51);
            this.bnTest.TabIndex = 20;
            this.bnTest.Text = "rtButton2";
            this.bnTest.textFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.bnTest.textOffColor = System.Drawing.Color.DimGray;
            this.bnTest.textOnColor = System.Drawing.Color.Red;
            this.bnTest.title = "Test";
            this.bnTest.titleColor = System.Drawing.Color.DimGray;
            this.bnTest.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.bnTest.titlePos = AudioProcessor.RTButton.RTTitlePos.Above;
            // 
            // spMain
            // 
            this.spMain.anchorColor = System.Drawing.Color.RoyalBlue;
            this.spMain.anchorSize = 8;
            this.spMain.attack = 1D;
            this.spMain.attackLevel = 1D;
            this.spMain.attackLevelMax = 10D;
            this.spMain.attackLevelMin = -10D;
            this.spMain.attackMax = 100D;
            this.spMain.attackMin = 0.01D;
            this.spMain.decay = 10D;
            this.spMain.decayMax = 1000D;
            this.spMain.decayMin = 0.01D;
            this.spMain.fade = 100D;
            this.spMain.fadeMax = 10000D;
            this.spMain.fadeMin = 1D;
            this.spMain.frameColor = System.Drawing.Color.DimGray;
            this.spMain.hold = 100D;
            this.spMain.holdFix = false;
            this.spMain.holdLevel = 0.5D;
            this.spMain.holdLevelMax = 10D;
            this.spMain.holdLevelMin = -10D;
            this.spMain.holdMax = 1000D;
            this.spMain.holdMin = 1D;
            this.spMain.Location = new System.Drawing.Point(8, 142);
            this.spMain.majorGridColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.spMain.minorGridColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.spMain.Name = "spMain";
            this.spMain.scaleColor = System.Drawing.Color.DimGray;
            this.spMain.scaleFont = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spMain.shapeColor = System.Drawing.Color.White;
            this.spMain.shapeDim = new System.Drawing.Size(560, 50);
            this.spMain.showMajorXGrid = true;
            this.spMain.showMajorYGrid = true;
            this.spMain.showMinorXGrid = true;
            this.spMain.showMinorYGrid = true;
            this.spMain.showXScale = false;
            this.spMain.showYScale = true;
            this.spMain.Size = new System.Drawing.Size(600, 71);
            this.spMain.TabIndex = 21;
            this.spMain.Text = "rtShape1";
            this.spMain.title = "Shape";
            this.spMain.titleColor = System.Drawing.Color.DimGray;
            this.spMain.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.spMain.titlePos = AudioProcessor.RTShape.RTTitlePos.Off;
            // 
            // ShapeGen
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.spMain);
            this.Controls.Add(this.bnTest);
            this.Controls.Add(this.ledRun);
            this.Controls.Add(this.bnGated);
            this.Controls.Add(this.dlDecayLevel);
            this.Controls.Add(this.dlAttackLevel);
            this.Controls.Add(this.dlFade);
            this.Controls.Add(this.dlSustain);
            this.Controls.Add(this.dlDecay);
            this.Controls.Add(this.dlAttack);
            this.Controls.Add(this.ioGateIn);
            this.Controls.Add(this.ioTrig);
            this.Controls.Add(this.ioGateOut);
            this.Controls.Add(this.ioSig);
            this.Name = "ShapeGen";
            this.shrinkSize = new System.Drawing.Size(115, 117);
            this.shrinkTitle = "Shape";
            this.Size = new System.Drawing.Size(621, 221);
            this.title = "Shape";
            this.ResumeLayout(false);

        }

        double attack, attacklevel, decay, decaylevel, sustain, fade;
        bool gated;
        bool testgate;

        private RTIO ioSig;
        private RTIO ioGateOut;
        private RTIO ioGateIn;
        private RTIO ioTrig;
        private RTDial dlAttack;
        private RTDial dlDecay;
        private RTDial dlSustain;
        private RTDial dlFade;
        private RTDial dlAttackLevel;
        private RTDial dlDecayLevel;
        private RTButton bnGated;
        private RTLED ledRun;
        private RTShape spMain;
        private RTButton bnTest;

        private void init()
        {
            InitializeComponent();

            dlAttack.val = attack;
            dlAttackLevel.val = attacklevel;
            dlDecay.val = decay;
            dlDecayLevel.val = decaylevel;
            dlSustain.val = sustain;
            dlFade.val = fade;
            bnGated.buttonState = gated;

            spMain.attack = attack;
            spMain.attackMin = dlAttack.minVal;
            spMain.attackMax = dlAttack.maxVal;

            spMain.attackLevel = attacklevel;
            spMain.attackLevelMin = dlAttackLevel.minVal;
            spMain.attackLevelMax = dlAttackLevel.maxVal;

            spMain.decay = decay;
            spMain.decayMin = dlDecay.minVal;
            spMain.decayMax = dlDecay.maxVal;

            spMain.holdLevel = decaylevel;
            spMain.holdLevelMin = dlDecayLevel.minVal;
            spMain.holdLevelMax = dlDecayLevel.maxVal;

            spMain.hold = sustain;
            spMain.holdMin = dlSustain.minVal;
            spMain.holdMax = dlSustain.maxVal;

            spMain.holdFix = !gated;

            spMain.fade = fade;
            spMain.fadeMin = dlFade.minVal;
            spMain.fadeMax = dlFade.maxVal;

            ledRun.LEDState = false;

            dlAttack.valueChanged += DlAttack_valueChanged;
            dlAttackLevel.valueChanged += DlAttackLevel_valueChanged;
            dlDecay.valueChanged += DlDecay_valueChanged;
            dlDecayLevel.valueChanged += DlDecayLevel_valueChanged;
            dlSustain.valueChanged += DlSustain_valueChanged;
            dlFade.valueChanged += DlFade_valueChanged;
            bnGated.buttonStateChanged += BnGated_buttonStateChanged;
            bnTest.buttonStateChanged += BnTest_buttonStateChanged;
            spMain.shapeStateChanged += SpMain_shapeStateChanged;

            processingType = ProcessingType.Source;
        }

        private void SpMain_shapeStateChanged(object sender, EventArgs e)
        {
            dlAttack.val = spMain.attack;
            dlAttackLevel.val = spMain.attackLevel;
            dlDecay.val = spMain.decay;
            dlDecayLevel.val = spMain.holdLevel;
            if (!gated)
                dlSustain.val = spMain.hold;
            dlFade.val = spMain.fade;
        }

        private void BnTest_buttonStateChanged(object sender, EventArgs e)
        {
            testgate = bnTest.buttonState;
        }

        private void BnGated_buttonStateChanged(object sender, EventArgs e)
        {
            gated = bnGated.buttonState;
            spMain.holdFix = !gated;
        }

        private void DlFade_valueChanged(object sender, EventArgs e)
        {
            fade = dlFade.val;
            spMain.fade = fade;
        }

        private void DlSustain_valueChanged(object sender, EventArgs e)
        {
            sustain = dlSustain.val;
            spMain.hold = sustain;
        }

        private void DlDecayLevel_valueChanged(object sender, EventArgs e)
        {
            decaylevel = dlDecayLevel.val;
            spMain.holdLevel= decaylevel;
        }

        private void DlDecay_valueChanged(object sender, EventArgs e)
        {
            decay = dlDecay.val;
            spMain.decay = decay;
        }

        private void DlAttackLevel_valueChanged(object sender, EventArgs e)
        {
            attacklevel = dlAttackLevel.val;
            spMain.attackLevel = attacklevel;
        }

        private void DlAttack_valueChanged(object sender, EventArgs e)
        {
            attack = dlAttack.val;
            spMain.attack = attack;
        }

        public ShapeGen():base()
        {
            attack = 1;
            attacklevel = 1.0;
            decay = 1;
            decaylevel = 1.0;
            sustain = 100;
            gated = false;
            fade = 200;

            init();
        }

        public ShapeGen(SystemPanel _owner, BinaryReader src) : base(_owner, src)
        {
            attack = src.ReadDouble();
            attacklevel = src.ReadDouble();
            decay = src.ReadDouble();
            decaylevel = src.ReadDouble();
            sustain = src.ReadDouble();
            fade = src.ReadDouble();
            gated = src.ReadBoolean();

            init();
        }

        public override void writeToFile(BinaryWriter tgt)
        {
            base.writeToFile(tgt);

            tgt.Write(attack);
            tgt.Write(attacklevel);
            tgt.Write(decay);
            tgt.Write(decaylevel);
            tgt.Write(sustain);
            tgt.Write(fade);
            tgt.Write(gated);
        }
        
        private double trig(double p)
        {
            return (p < 0.5) ? 1 : 0;
        }

        private bool running = false;
        private double lasttrig = 0;
        private UInt32 sample = 0;
        private double gatestop = 0;

        private bool lastTestGate = false;

        public override void tick()
        {
            DataBuffer dbTrig = getInputBuffer(ioTrig);
            DataBuffer dbGateIn = getInputBuffer(ioGateIn);
            DataBuffer dbSig = getOutputBuffer(ioSig);
            DataBuffer dbGateOut = getOutputBuffer(ioGateOut);

            if (!_active) return;
            if ((dbSig == null) && (dbGateOut == null)) return;

            for (int i = 0; i < owner.blockSize; i++)
            {
                Boolean triggered = false;
                if (dbTrig != null) {
                    if ((lasttrig <= 0) && (dbTrig.data[i] > 0))
                        triggered = true;
                    lasttrig = dbTrig.data[i];
                }
                else
                {
                    lasttrig = 0;
                }
                if (testgate && !lastTestGate)
                {
                    triggered = true;
                }
                lastTestGate = testgate;
                if (triggered)
                {
                    running = true;
                    sample = 0;
                }
                Boolean exgate = false;
                if ((dbGateIn != null) && dbGateIn.data[i] > 0)
                    exgate = true;
                if (testgate)
                    exgate = true;
                double time = (double)sample / owner.sampleRate * 1000.0;
                sample++;
                double oval = 0;
                double oon = (running)?1:0;
                if (running)
                {
                    if (time < attack)
                    {
                        oval = (time / attack) * attacklevel;
                    }
                    else if (time < attack + decay)
                    {
                        oval = attacklevel + ((time - attack) / decay) * (decaylevel - attacklevel);
                        gatestop = time;
                    }
                    else
                    {
                        if (gated)
                        {
                            if (exgate)
                            {
                                oval = decaylevel;
                                gatestop = time;
                            }
                            else
                            {
                                if (time < (gatestop + fade))
                                    oval = decaylevel - (time - gatestop) / fade * decaylevel;
                                else
                                {
                                    oval = 0;
                                    running = false;
                                }
                            }
                        } else
                        {
                            if (time < (attack + decay + sustain))
                            {
                                oval = decaylevel;
                            } else if (time < (attack + decay + sustain + fade))
                            {
                                oval = decaylevel - (time - attack - decay - sustain) / fade * decaylevel;
                            } else
                            {
                                oval = 0;
                                running = false;
                            }
                        }
                    }
                }

                if (dbSig != null)
                    dbSig.data[i] = oval;
                if (dbGateOut != null)
                    dbGateOut.data[i] = oon;
            }
            if (running && !ledRun.LEDState)
                ledRun.LEDState = true;
            if (!running && ledRun.LEDState)
                ledRun.LEDState = false;
        }

        class RegisterClass : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Generator", "Shape" }; }
            public override RTForm Instantiate() { return new ShapeGen(); }
        }
        public static void Register(List<RTObjectReference> l) { l.Add(new RegisterClass()); }


    }
}
