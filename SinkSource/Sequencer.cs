using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace AudioProcessor.SinkSource
{
    public class Sequencer:RTForm
    {
        private RTDial dlBPM;
        private RTIO ioPitch;
        private RTIO ioGate;
        private RTChoice rtChoice1;
        private RTSequencerField sfMain;
        private RTIO ioAmp;
        private RTDial dloct;
        private RTDial dlGain;
        private RTIO ioSync;

        private void InitializeComponent()
        {
            this.dlBPM = new AudioProcessor.RTDial();
            this.ioPitch = new AudioProcessor.RTIO();
            this.ioGate = new AudioProcessor.RTIO();
            this.rtChoice1 = new AudioProcessor.RTChoice();
            this.sfMain = new AudioProcessor.RTSequencerField();
            this.ioSync = new AudioProcessor.RTIO();
            this.ioAmp = new AudioProcessor.RTIO();
            this.dloct = new AudioProcessor.RTDial();
            this.dlGain = new AudioProcessor.RTDial();
            this.SuspendLayout();
            // 
            // dlBPM
            // 
            this.dlBPM.dialColor = System.Drawing.Color.DimGray;
            this.dlBPM.dialDiameter = 50D;
            this.dlBPM.dialMarkColor = System.Drawing.Color.Red;
            this.dlBPM.format = "F2";
            this.dlBPM.Location = new System.Drawing.Point(61, 23);
            this.dlBPM.logScale = false;
            this.dlBPM.maxVal = 600D;
            this.dlBPM.minVal = 1D;
            this.dlBPM.Name = "dlBPM";
            this.dlBPM.scaleColor = System.Drawing.Color.Gold;
            this.dlBPM.showScale = true;
            this.dlBPM.showTitle = true;
            this.dlBPM.showValue = true;
            this.dlBPM.Size = new System.Drawing.Size(80, 80);
            this.dlBPM.TabIndex = 0;
            this.dlBPM.Text = "control1";
            this.dlBPM.title = "Rate";
            this.dlBPM.titleColor = System.Drawing.Color.DimGray;
            this.dlBPM.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.dlBPM.unit = "BPM";
            this.dlBPM.val = 80D;
            this.dlBPM.valueColor = System.Drawing.Color.DimGray;
            this.dlBPM.valueFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            // 
            // ioPitch
            // 
            this.ioPitch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ioPitch.contactBackColor = System.Drawing.Color.DimGray;
            this.ioPitch.contactColor = System.Drawing.Color.DimGray;
            this.ioPitch.contactHighlightColor = System.Drawing.Color.Red;
            this.ioPitch.highlighted = false;
            this.ioPitch.Location = new System.Drawing.Point(312, 23);
            this.ioPitch.Name = "ioPitch";
            this.ioPitch.orientation = AudioProcessor.RTIO.RTOrientation.East;
            this.ioPitch.showTitle = true;
            this.ioPitch.Size = new System.Drawing.Size(53, 20);
            this.ioPitch.TabIndex = 3;
            this.ioPitch.Text = "rtio1";
            this.ioPitch.title = "Pitch";
            this.ioPitch.titleColor = System.Drawing.Color.DimGray;
            this.ioPitch.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioPitch.IOtype = AudioProcessor.RTIO.ProcessingIOType.SignalOutput;
            // 
            // ioGate
            // 
            this.ioGate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ioGate.contactBackColor = System.Drawing.Color.DimGray;
            this.ioGate.contactColor = System.Drawing.Color.DimGray;
            this.ioGate.contactHighlightColor = System.Drawing.Color.Red;
            this.ioGate.highlighted = false;
            this.ioGate.Location = new System.Drawing.Point(312, 75);
            this.ioGate.Name = "ioGate";
            this.ioGate.orientation = AudioProcessor.RTIO.RTOrientation.East;
            this.ioGate.showTitle = true;
            this.ioGate.Size = new System.Drawing.Size(53, 20);
            this.ioGate.TabIndex = 4;
            this.ioGate.Text = "rtio2";
            this.ioGate.title = "Gate";
            this.ioGate.titleColor = System.Drawing.Color.DimGray;
            this.ioGate.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioGate.IOtype = AudioProcessor.RTIO.ProcessingIOType.SignalOutput;
            // 
            // rtChoice1
            // 
            this.rtChoice1.backColor = System.Drawing.Color.Black;
            this.rtChoice1.frontColor = System.Drawing.Color.White;
            this.rtChoice1.Location = new System.Drawing.Point(0, 0);
            this.rtChoice1.Name = "rtChoice1";
            this.rtChoice1.selectedItem = -1;
            this.rtChoice1.Size = new System.Drawing.Size(100, 100);
            this.rtChoice1.TabIndex = 0;
            this.rtChoice1.title = "Choice";
            this.rtChoice1.titleColor = System.Drawing.Color.DimGray;
            this.rtChoice1.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.rtChoice1.xdim = 50;
            // 
            // sfMain
            // 
            this.sfMain.colHeadColor = System.Drawing.Color.DarkGray;
            this.sfMain.colHeadFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.sfMain.colHeadHeight = 16;
            this.sfMain.columns = 16;
            this.sfMain.fillOffColor = System.Drawing.Color.Black;
            this.sfMain.fillOnColor = System.Drawing.Color.DarkRed;
            this.sfMain.frameColor = System.Drawing.Color.SeaGreen;
            this.sfMain.highLightColor = System.Drawing.Color.DarkOliveGreen;
            this.sfMain.hlCol = -1;
            this.sfMain.Location = new System.Drawing.Point(28, 109);
            this.sfMain.Name = "sfMain";
            this.sfMain.rowHeadColor = System.Drawing.Color.DarkGray;
            this.sfMain.rowHeadFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.sfMain.rowHeadWidth = 30;
            this.sfMain.rows = 12;
            this.sfMain.selectColor = System.Drawing.Color.Aqua;
            this.sfMain.showColHeads = true;
            this.sfMain.showRowHeads = true;
            this.sfMain.Size = new System.Drawing.Size(289, 206);
            this.sfMain.TabIndex = 5;
            this.sfMain.takt = 4;
            this.sfMain.Text = "rtSequencerField1";
            // 
            // ioSync
            // 
            this.ioSync.contactBackColor = System.Drawing.Color.DimGray;
            this.ioSync.contactColor = System.Drawing.Color.DimGray;
            this.ioSync.contactHighlightColor = System.Drawing.Color.Red;
            this.ioSync.highlighted = false;
            this.ioSync.Location = new System.Drawing.Point(0, 23);
            this.ioSync.Name = "ioSync";
            this.ioSync.orientation = AudioProcessor.RTIO.RTOrientation.West;
            this.ioSync.showTitle = true;
            this.ioSync.Size = new System.Drawing.Size(59, 20);
            this.ioSync.TabIndex = 12;
            this.ioSync.Text = "rtio3";
            this.ioSync.title = "Sync";
            this.ioSync.titleColor = System.Drawing.Color.DimGray;
            this.ioSync.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioSync.IOtype = AudioProcessor.RTIO.ProcessingIOType.SignalInput;
            // 
            // ioAmp
            // 
            this.ioAmp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ioAmp.contactBackColor = System.Drawing.Color.DimGray;
            this.ioAmp.contactColor = System.Drawing.Color.DimGray;
            this.ioAmp.contactHighlightColor = System.Drawing.Color.Red;
            this.ioAmp.highlighted = false;
            this.ioAmp.Location = new System.Drawing.Point(312, 49);
            this.ioAmp.Name = "ioAmp";
            this.ioAmp.orientation = AudioProcessor.RTIO.RTOrientation.East;
            this.ioAmp.showTitle = true;
            this.ioAmp.Size = new System.Drawing.Size(53, 20);
            this.ioAmp.TabIndex = 13;
            this.ioAmp.Text = "rtio1";
            this.ioAmp.title = "Amp";
            this.ioAmp.titleColor = System.Drawing.Color.DimGray;
            this.ioAmp.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ioAmp.IOtype = AudioProcessor.RTIO.ProcessingIOType.SignalOutput;
            // 
            // dloct
            // 
            this.dloct.dialColor = System.Drawing.Color.DimGray;
            this.dloct.dialDiameter = 50D;
            this.dloct.dialMarkColor = System.Drawing.Color.Red;
            this.dloct.format = "F0";
            this.dloct.Location = new System.Drawing.Point(147, 23);
            this.dloct.logScale = false;
            this.dloct.maxVal = 4D;
            this.dloct.minVal = -4D;
            this.dloct.Name = "dloct";
            this.dloct.scaleColor = System.Drawing.Color.Gold;
            this.dloct.showScale = true;
            this.dloct.showTitle = true;
            this.dloct.showValue = true;
            this.dloct.Size = new System.Drawing.Size(80, 80);
            this.dloct.TabIndex = 14;
            this.dloct.Text = "control1";
            this.dloct.title = "Octave";
            this.dloct.titleColor = System.Drawing.Color.DimGray;
            this.dloct.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.dloct.unit = "";
            this.dloct.val = 0D;
            this.dloct.valueColor = System.Drawing.Color.DimGray;
            this.dloct.valueFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            // 
            // dlGain
            // 
            this.dlGain.dialColor = System.Drawing.Color.DimGray;
            this.dlGain.dialDiameter = 50D;
            this.dlGain.dialMarkColor = System.Drawing.Color.Red;
            this.dlGain.format = "F0";
            this.dlGain.Location = new System.Drawing.Point(233, 23);
            this.dlGain.logScale = false;
            this.dlGain.maxVal = 20D;
            this.dlGain.minVal = -100D;
            this.dlGain.Name = "dlGain";
            this.dlGain.scaleColor = System.Drawing.Color.Gold;
            this.dlGain.showScale = true;
            this.dlGain.showTitle = true;
            this.dlGain.showValue = true;
            this.dlGain.Size = new System.Drawing.Size(80, 80);
            this.dlGain.TabIndex = 15;
            this.dlGain.Text = "control1";
            this.dlGain.title = "Gain";
            this.dlGain.titleColor = System.Drawing.Color.DimGray;
            this.dlGain.titleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.dlGain.unit = "dB";
            this.dlGain.val = -20D;
            this.dlGain.valueColor = System.Drawing.Color.DimGray;
            this.dlGain.valueFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            // 
            // Sequencer
            // 
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.dlGain);
            this.Controls.Add(this.dloct);
            this.Controls.Add(this.ioAmp);
            this.Controls.Add(this.ioSync);
            this.Controls.Add(this.sfMain);
            this.Controls.Add(this.ioGate);
            this.Controls.Add(this.ioPitch);
            this.Controls.Add(this.dlBPM);
            this.Name = "Sequencer";
            this.shrinkSize = new System.Drawing.Size(120, 107);
            this.shrinkTitle = "Seq.";
            this.Size = new System.Drawing.Size(365, 329);
            this.title = "Sequencer";
            this.ResumeLayout(false);

        }

        double bpm;
        double octave;
        double gain;
        int rows;
        int cols;
        int takt;
        double[,] data;
        double t;

        private void init()
        {
            InitializeComponent();

            dlBPM.val = bpm;
            dloct.val = octave;
            dlGain.val = gain;

            dlBPM.valueChanged += DlBPM_valueChanged;
            dloct.valueChanged += Dloct_valueChanged;
            dlGain.valueChanged += DlGain_valueChanged;

            sfMain.rows = rows;
            sfMain.columns = cols;
            sfMain.takt = takt;
            sfMain.data = data;

            t = 0;

            sfMain.sequencerStateChanged += SfMain_sequencerStateChanged;

            processingType = ProcessingType.Source;
        }

        private void DlGain_valueChanged(object sender, EventArgs e)
        {
            gain = dlGain.val;
        }

        private void Dloct_valueChanged(object sender, EventArgs e)
        {
            octave = dloct.val;
        }

        public Sequencer(int _cols, int _rows, int _takt): base()
        {
            bpm = 120;
            octave = 0;
            gain = -20;
            cols = _cols;
            rows = _rows;
            takt = _takt;
            data = new double[rows, cols];
            init();
        }

        public Sequencer():this(16,12,4)
        {
        }

        public Sequencer(SystemPanel _owner, BinaryReader src) : base(_owner, src)
        {
            bpm = src.ReadDouble();
            cols = src.ReadInt32();
            rows = src.ReadInt32();
            takt = src.ReadInt32();
            octave = src.ReadDouble();
            gain = src.ReadDouble();
            data = new double[rows, cols];
            for (int r = 0; r < rows; r++)
                for (int c = 0; c < cols; c++)
                    data[r, c] = src.ReadDouble();

            init();
        }

        public override void writeToFile(BinaryWriter tgt)
        {
            base.writeToFile(tgt);
            tgt.Write(bpm);
            tgt.Write(cols);
            tgt.Write(rows);
            tgt.Write(takt);
            tgt.Write(octave);
            tgt.Write(gain);
            for (int r = 0; r < rows; r++)
                for (int c = 0; c < cols; c++)
                    tgt.Write(data[r, c]);
        }

        private void SfMain_sequencerStateChanged(object sender, EventArgs e)
        {
            data = sfMain.data;
        }

        private void DlBPM_valueChanged(object sender, EventArgs e)
        {
            bpm = dlBPM.val;
        }


        private int playing = -1;
        private double lastSync = 0;

        public override void tick()
        {
            if (!_active) return;
            SignalBuffer dbsync = getSignalInputBuffer(ioSync);
            SignalBuffer dbpitch = getSignalOutputBuffer(ioPitch);
            SignalBuffer dbamp = getSignalOutputBuffer(ioAmp);
            SignalBuffer dbgate = getSignalOutputBuffer(ioGate);

            if ((dbpitch == null) && (dbgate == null)) return;
            int c = 0;

            double a = Math.Pow(10, gain / 20);
            for (int i=0;i<owner.blockSize;i++)
            {
                if (dbsync != null)
                {
                    if ((dbsync.data[i] > 0) && (lastSync <= 0))
                        t = 0;
                    lastSync = dbsync.data[i];
                }
                else
                    lastSync = 0;
                c = (int)Math.Floor(t * (bpm / 60));
                c = c % cols;
                int found = -1;
                for (int j = 0;j<rows;j++)
                {
                    if ((data[j,c] > 0) && (found < 0))
                        found = j;
                }
                if ((found >= 0) && (playing >= 0) && (found != playing))
                {
                    if (dbgate != null) dbgate.data[i] = 0;
                    if (dbamp != null) dbamp.data[i] = 0;
                    playing = -1;
                } else if (found >= 0)
                {
                    if (dbgate != null) dbgate.data[i] = 1;
                    if (dbamp != null) dbamp.data[i] = data[found,c]*a;
                    if (dbpitch != null) dbpitch.data[i] = (double)found / 12 + octave;
                    playing = found;
                } else if (playing >= 0)
                {
                    playing = -1;
                    if (dbgate != null) dbgate.data[i] = 0;
                    if (dbamp != null) dbamp.data[i] = 0;
                }
                t += 1.0 / owner.sampleRate;
                if (t >= (double)cols / (bpm / 60))
                    t -= (double)cols / (bpm / 60);
            }

            sfMain.hlCol = c;
        }


        class RegisterClass1 : RTObjectReference
        {
            public override List<string> GetAddress() { return new List<string> { "Generator", "Sequencer", "4x 4:4" }; }
            public override RTForm Instantiate() { return new Sequencer(4*4,12,4); }
        }

        public static void Register(List<RTObjectReference> l)
        {
            l.Add(new RegisterClass1());
        }




    }
}
