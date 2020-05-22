using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioProcessor.DataProcessing
{
    class DataSubset : RTForm
    {

        public void InitializeComponent()
        {
            this.ioData = new AudioProcessor.RTIO();
            this.clStart = new AudioProcessor.RTChoice();
            this.clLen = new AudioProcessor.RTChoice();
            this.ioOut = new AudioProcessor.RTIO();
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
            // clStart
            // 
            this.clStart.backColor = System.Drawing.Color.Black;
            this.clStart.choiceType = AudioProcessor.RTChoice.ChoiceType.Numeric;
            this.clStart.frontColor = System.Drawing.Color.DimGray;
            this.clStart.Location = new System.Drawing.Point(31, 28);
            this.clStart.Name = "clStart";
            this.clStart.numericMax = 100000;
            this.clStart.numericMin = 0;
            this.clStart.offString = "off";
            this.clStart.selectedItem = 0;
            this.clStart.Size = new System.Drawing.Size(96, 22);
            this.clStart.TabIndex = 31;
            this.clStart.Text = "rtChoice1";
            this.clStart.title = "Start";
            this.clStart.titleColor = System.Drawing.Color.DimGray;
            this.clStart.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.clStart.valueFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.clStart.xdim = 50;
            // 
            // clLen
            // 
            this.clLen.backColor = System.Drawing.Color.Black;
            this.clLen.choiceType = AudioProcessor.RTChoice.ChoiceType.NumericOff;
            this.clLen.frontColor = System.Drawing.Color.DimGray;
            this.clLen.Location = new System.Drawing.Point(31, 56);
            this.clLen.Name = "clLen";
            this.clLen.numericMax = 100000;
            this.clLen.numericMin = 1;
            this.clLen.offString = "All";
            this.clLen.selectedItem = -1;
            this.clLen.Size = new System.Drawing.Size(96, 22);
            this.clLen.TabIndex = 32;
            this.clLen.Text = "rtChoice2";
            this.clLen.title = "Len";
            this.clLen.titleColor = System.Drawing.Color.DimGray;
            this.clLen.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.clLen.valueFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.clLen.xdim = 50;
            // 
            // ioOut
            // 
            this.ioOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ioOut.contactBackColor = System.Drawing.Color.Black;
            this.ioOut.contactColor = System.Drawing.Color.DimGray;
            this.ioOut.contactHighlightColor = System.Drawing.Color.Red;
            this.ioOut.highlighted = false;
            this.ioOut.IOtype = AudioProcessor.RTIO.ProcessingIOType.DataOutput;
            this.ioOut.Location = new System.Drawing.Point(138, 30);
            this.ioOut.Name = "ioOut";
            this.ioOut.orientation = AudioProcessor.RTIO.RTOrientation.East;
            this.ioOut.showTitle = false;
            this.ioOut.Size = new System.Drawing.Size(21, 20);
            this.ioOut.TabIndex = 33;
            this.ioOut.Text = "rtio1";
            this.ioOut.title = "FM";
            this.ioOut.titleColor = System.Drawing.Color.DimGray;
            this.ioOut.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            // 
            // DataSubset
            // 
            this.Controls.Add(this.ioOut);
            this.Controls.Add(this.clLen);
            this.Controls.Add(this.clStart);
            this.Controls.Add(this.ioData);
            this.Name = "DataSubset";
            this.shrinkSize = new System.Drawing.Size(82, 61);
            this.shrinkTitle = "S";
            this.Size = new System.Drawing.Size(159, 86);
            this.title = "Subset";
            this.ResumeLayout(false);

        }

        private RTIO ioData;
        private RTChoice clStart;
        private RTChoice clLen;

        private int idxStart;
        private RTIO ioOut;
        private int idxLen;

        private void init()
        {
            InitializeComponent();

            clStart.selectedItem = idxStart;
            clLen.selectedItem = idxLen;

            clStart.choiceStateChanged += ClStart_choiceStateChanged;
            clLen.choiceStateChanged += ClLen_choiceStateChanged;

            processingType = ProcessingType.Processor;
        }

        private void ClLen_choiceStateChanged(object sender, EventArgs e)
        {
            idxLen = clLen.selectedItem;
        }

        private void ClStart_choiceStateChanged(object sender, EventArgs e)
        {
            idxStart = clStart.selectedItem;
        }

        public DataSubset() : base()
        {
            idxStart = 0;
            idxLen = -1;

            init();
        }

        public DataSubset(SystemPanel _owner, BinaryReader src) : base(_owner, src)
        {
            idxStart = src.ReadInt32();
            idxLen = src.ReadInt32();

            init();
        }

        public override void writeToFile(BinaryWriter tgt)
        {
            base.writeToFile(tgt);

            tgt.Write(idxStart);
            tgt.Write(idxLen);
        }

        public override void tick()
        {
            if (!_active)
                return;

            DataBuffer dbin = getDataInputBuffer(ioData);
            DataBuffer dbout = getDataOutputBuffer(ioOut);

            if ((dbin == null) || (dbin.size < 1))
                return;

            if (dbout == null)
                return;

            int first = idxStart;
            if ((first < 0) || (first >= dbin.size))
                return;

            int last = 0;
            if (idxLen < 0)
                // All
                last = dbin.size - 1;
            else
            {
                last = first + idxLen + 1 - 1;
                if (last >= dbin.size)
                    last = dbin.size - 1;
            }
            int len = last - first + 1;
            if (len > 0)
            {
                dbout.initialize(len);
                dbout.set(dbin.data, first, len);
            }
        }

        class RegisterClass1 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Data", "Subset" }; }
            public override RTForm Instantiate() { return new DataSubset(); }
        }

        public static void Register(List<RTObjectReference> l)
        {
            l.Add(new RegisterClass1());
        }



    }


}
