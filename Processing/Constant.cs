using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioProcessor.Processing
{
    public class Constant:RTForm
    {

        public void InitializeComponent()
        {
            this.fiConst = new AudioProcessor.RTFlexInput();
            this.ioOut = new AudioProcessor.RTIO();
            this.SuspendLayout();
            // 
            // fiConst
            // 
            this.fiConst.drawFrame = true;
            this.fiConst.floatVal = 0D;
            this.fiConst.format = "F2";
            this.fiConst.frameColor = System.Drawing.Color.DimGray;
            this.fiConst.inputType = AudioProcessor.RTFlexInput.RTFlexInputType.Float;
            this.fiConst.intVal = 0;
            this.fiConst.Location = new System.Drawing.Point(3, 22);
            this.fiConst.maxVal = 1E+99D;
            this.fiConst.minVal = -1E+99D;
            this.fiConst.Name = "fiConst";
            this.fiConst.Size = new System.Drawing.Size(115, 32);
            this.fiConst.stringVal = "";
            this.fiConst.TabIndex = 0;
            this.fiConst.Text = "rtFlexInput1";
            this.fiConst.title = "Input";
            this.fiConst.titleColor = System.Drawing.Color.DimGray;
            this.fiConst.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.fiConst.titlePos = AudioProcessor.GraphicsUtil.TextAlignment.off;
            this.fiConst.unit = "dB";
            this.fiConst.valueColor = System.Drawing.Color.DimGray;
            this.fiConst.valueFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.fiConst.valueSize = new System.Drawing.Size(100, 20);
            // 
            // ioOut
            // 
            this.ioOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ioOut.contactBackColor = System.Drawing.Color.Black;
            this.ioOut.contactColor = System.Drawing.Color.DimGray;
            this.ioOut.Location = new System.Drawing.Point(122, 29);
            this.ioOut.Name = "ioOut";
            this.ioOut.orientation = AudioProcessor.RTIO.RTOrientation.East;
            this.ioOut.showTitle = false;
            this.ioOut.Size = new System.Drawing.Size(21, 20);
            this.ioOut.TabIndex = 1;
            this.ioOut.Text = "rtio1";
            this.ioOut.title = "IO";
            this.ioOut.titleColor = System.Drawing.Color.DimGray;
            this.ioOut.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioOut.type = AudioProcessor.RTIO.ProcessingIOType.Output;
            // 
            // Constant
            // 
            this.canShrink = false;
            this.Controls.Add(this.ioOut);
            this.Controls.Add(this.fiConst);
            this.hasActiveSwitch = false;
            this.Name = "Constant";
            this.Size = new System.Drawing.Size(143, 61);
            this.title = "Const";
            this.ResumeLayout(false);

        }

        public enum ConstantType
        {
            linear,
            logarithmic,
            dB
        }

        ConstantType constantType;
        private RTFlexInput fiConst;
        private RTIO ioOut;
        double value;

        private void init()
        {
            InitializeComponent();

            switch (constantType)
            {
                case ConstantType.linear:
                    fiConst.inputType = RTFlexInput.RTFlexInputType.Float;
                    fiConst.format = "F3";
                    fiConst.unit = null;
                    break;
                case ConstantType.logarithmic:
                    fiConst.inputType = RTFlexInput.RTFlexInputType.Float;
                    fiConst.format = "E3";
                    fiConst.unit = null;
                    break;
                case ConstantType.dB:
                    fiConst.inputType = RTFlexInput.RTFlexInputType.Float;
                    fiConst.format = "F2";
                    fiConst.unit = "dB";
                    break;
            }
            fiConst.floatVal = value;
            fiConst.valueChanged += FiConst_valueChanged;

            /*
            size.set(200, 50);
            io.Add(new ProcessingIO(owner, this, ProcessingIO.ProcessingIOType.Output, false, "=", false,
                ProcessingIO.ProcessingIOAlign.RightFromTop, Vector.V(25, 0)));

            if (constantType == ConstantType.dB)
                ctrl.Add(new Controls.RawNumericIn(owner, this, Vector.V(10, 15), 10,
                    null, "dB", value, "{0}", false, 150));
            else
                ctrl.Add(new Controls.RawNumericIn(owner, this, Vector.V(10, 15), 10, 
                null, null, value, "{0}", constantType == ConstantType.logarithmic, 170));
            */
            processingType = ProcessingType.Processor;
        }

        private void FiConst_valueChanged(object sender, EventArgs e)
        {
            value = fiConst.floatVal;
        }

        public Constant(ConstantType _constantType):base()
        {
            constantType = _constantType;
            if (constantType == ConstantType.logarithmic)
                value = 1.0;
            else
                value = 0;
            init();
        }

        public Constant(SystemPanel _owner, BinaryReader src):base(_owner,src)
        {
            constantType = (ConstantType) src.ReadInt32();
            value = src.ReadDouble();
            init();
        }

        public override void writeToFile(BinaryWriter tgt)
        {
            base.writeToFile(tgt);
            tgt.Write((int) constantType);
            tgt.Write(value);
        }

        public override void tick()
        {
            if (ioOut.connectedTo == null)
                return;
            if (constantType == ConstantType.dB)
                ioOut.connectedTo.input.SetTo(Math.Pow(10.0,value/20.0));
            else
                ioOut.connectedTo.input.SetTo(value);
        }

        class RegisterClass1 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Control", "Constant", "Linear" }; }
            public override RTForm Instantiate() { return new Constant(ConstantType.linear); }
        }
        class RegisterClass2 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Control", "Constant", "Logarithmic" }; }
            public override RTForm Instantiate() { return new Constant(ConstantType.logarithmic); }
        }
        class RegisterClass3 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Control", "Constant", "dB" }; }
            public override RTForm Instantiate() { return new Constant(ConstantType.dB); }
        }

        public static void Register(List<RTObjectReference> l)
        {
            l.Add(new RegisterClass1());
            l.Add(new RegisterClass2());
            l.Add(new RegisterClass3());
        }

    }
}
