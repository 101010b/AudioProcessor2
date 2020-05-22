using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using System.Drawing;

namespace AudioProcessor.DataProcessing
{
    public class DataViewer : RTForm
    {

        public void InitializeComponent()
        {
            this.ioData1 = new AudioProcessor.RTIO();
            this.bnDisplayWin = new AudioProcessor.RTButton();
            this.SuspendLayout();
            // 
            // ioData1
            // 
            this.ioData1.contactBackColor = System.Drawing.Color.Black;
            this.ioData1.contactColor = System.Drawing.Color.DimGray;
            this.ioData1.contactHighlightColor = System.Drawing.Color.Red;
            this.ioData1.highlighted = false;
            this.ioData1.IOtype = AudioProcessor.RTIO.ProcessingIOType.DataInput;
            this.ioData1.Location = new System.Drawing.Point(0, 25);
            this.ioData1.Name = "ioData1";
            this.ioData1.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.ioData1.showTitle = false;
            this.ioData1.Size = new System.Drawing.Size(21, 20);
            this.ioData1.TabIndex = 13;
            this.ioData1.Text = "rtio1";
            this.ioData1.title = "Data";
            this.ioData1.titleColor = System.Drawing.Color.DimGray;
            this.ioData1.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
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
            this.bnDisplayWin.Location = new System.Drawing.Point(48, 23);
            this.bnDisplayWin.Name = "bnDisplayWin";
            this.bnDisplayWin.offText = "Display";
            this.bnDisplayWin.onText = "Display";
            this.bnDisplayWin.Size = new System.Drawing.Size(61, 22);
            this.bnDisplayWin.TabIndex = 14;
            this.bnDisplayWin.Text = "rtButton1";
            this.bnDisplayWin.textFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.bnDisplayWin.textOffColor = System.Drawing.Color.DimGray;
            this.bnDisplayWin.textOnColor = System.Drawing.Color.Red;
            this.bnDisplayWin.title = "Button";
            this.bnDisplayWin.titleColor = System.Drawing.Color.DimGray;
            this.bnDisplayWin.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.bnDisplayWin.titlePos = AudioProcessor.RTButton.RTTitlePos.Off;
            // 
            // DataViewer
            // 
            this.canShrink = false;
            this.Controls.Add(this.bnDisplayWin);
            this.Controls.Add(this.ioData1);
            this.Name = "DataViewer";
            this.shrinkSize = new System.Drawing.Size(86, 236);
            this.shrinkTitle = "M";
            this.Size = new System.Drawing.Size(142, 56);
            this.title = "Viewer";
            this.ResumeLayout(false);

        }

        private RTIO ioData1;

        private RTButton bnDisplayWin;

        private DataViewerWin win;
        public ConcurrentQueue<DataBlock> dataBlocks;

        public int[] timerangesms = { 100, 200, 500, 1000, 2000, 5000, 10000, 20000, 50000, 100000 };

        public class DataBlock
        {
            public double[] data;
            public Int64 timestamp;

            public DataBlock(double[] _data, Int64 _timestamp)
            {
                data = new double[_data.Length];
                Array.Copy(_data, data, _data.Length);
                timestamp = _timestamp;
            }

        }

        private void init()
        {
            InitializeComponent();

            bnDisplayWin.buttonStateChanged += BnDisplayWin_buttonStateChanged;

            processingType = ProcessingType.Processor;
        }
        
        public class DataViewerConfig
        {

            // Colors and On/off
            public int traces;
            public List<Color> traceColor;
            public List<bool> traceOn;

            // X-Axis
            public int xrange; // in owner.blocks

            // Y-Axis
            public double ymin;
            public double ymax;
            public bool yautoscale;
            public bool ylog;

            public  DataViewerConfig()
            {
                traces = 0;
                traceColor = new List<Color>();
                traceOn = new List<bool>();
                xrange = 1000;
                ymin = -1;
                ymax = 1;
                yautoscale = true;
                ylog = false;
            }

            public DataViewerConfig(BinaryReader src)
            {
                traces = src.ReadInt32();
                if (traces < 1)
                {
                    traceColor = new List<Color>();
                    traceOn = new List<bool>();
                } else
                {
                    for (int i=0;i<traces;i++)
                    {
                        traceColor.Add(Color.FromArgb(src.ReadInt32()));
                        traceOn.Add(src.ReadBoolean());
                    }
                }
                xrange = src.ReadInt32();
                ymin = src.ReadDouble();
                ymax = src.ReadDouble();
                yautoscale = src.ReadBoolean();
                ylog = src.ReadBoolean();
            }

            public void Store(BinaryWriter tgt)
            {
                tgt.Write(traces);
                if (traces >= 1)
                {
                    for (int i=0;i<traces;i++)
                    {
                        tgt.Write((int)traceColor[i].ToArgb());
                        tgt.Write(traceOn[i]);
                    }
                }
                tgt.Write(xrange);
                tgt.Write(ymin);
                tgt.Write(ymax);
                tgt.Write(yautoscale);
                tgt.Write(ylog);
            }
        }

        public DataViewerConfig config;

        public DataViewer() : base()
        {
            config = new DataViewerConfig();

            init();
        }

        public DataViewer(SystemPanel _owner, BinaryReader src) : base(_owner, src)
        {

            config = new DataViewerConfig(src);
            init();
        }

        public override void writeToFile(BinaryWriter tgt)
        {
            base.writeToFile(tgt);

            config.Store(tgt);
        }

        private void BnDisplayWin_buttonStateChanged(object sender, EventArgs e)
        {
            if (win == null)
            {
                win = new DataViewerWin();
                win.setOwner(this);
            }
            win.Show();
        }

        public override void tick()
        {

            if (!_active)
                return;

            if (dataBlocks == null)
                dataBlocks = new ConcurrentQueue<DataBlock>();

            DataBuffer db = getDataInputBuffer(ioData1);
            if ((db != null) && (db.size > 0))
            {
                dataBlocks.Enqueue(new DataBlock(db.data, owner.timeStamp));
            }

        }

        public override void Disconnect()
        {
            base.Disconnect();
            if (win != null)
            {
                win.DoClose();
                win = null;
            }
        }



        class RegisterClass1 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Data", "Viewer" }; }
            public override RTForm Instantiate() { return new DataViewer(); }
        }

        public static void Register(List<RTObjectReference> l)
        {
            l.Add(new RegisterClass1());
        }

    }


}
