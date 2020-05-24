using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AudioProcessor.SinkSource
{
    public partial class VNAWin : Form
    {
        public bool CanClose;

        public bool running;

        public VNA vna;
        public bool initialized;
        private Timer timer;

        public int channels;

        /*
        public double sweepFMin;
        public double sweepFMax;
        public bool sweepLog;
        public int sweepPoints;
        public double loopDelay;
        public double periods;
        
        public enum PlotMode
        {
            absA, absB, absBA, phiBA, logA, logB, logBA
        }
        public List<String> PlotModeNames = new List<string> { "abs(A)", "abs(B)", "abs(B/A)", "Phi(B/A)", "A[dBFS]", "B[dBFS]", "B/A[dBFS]" };
        */
        PlotTrace absA, logA, phiA;
        PlotTrace[] absB, absBA, phiBA, logB, logBA, phiB;

        public VNAWin()
        {
            InitializeComponent();
            vnaScreen.root = this;
            initialized = false;
            CanClose = true;
            channels = 0;
            FormClosing += VNAWin_FormClosing;

        }

        bool blockRangeSet;

        public void initVNA(VNA _vna)
        {
            vna = _vna;
            timer = new Timer();
            timer.Interval = 100; // ms
            timer.Tick += Timer_Tick;

            channels = vna.channels;
            absB = new PlotTrace[channels];
            absBA = new PlotTrace[channels];
            phiBA = new PlotTrace[channels];
            logB = new PlotTrace[channels];
            logBA = new PlotTrace[channels];
            phiB = new PlotTrace[channels];

            running = false;

            /*
            sweepFMin = 100;
            sweepFMax = 10000;
            sweepLog = true;
            sweepPoints = 61;
            loopDelay = 700;
            periods = 40;
            */

            timer.Enabled = true;
            CanClose = false;
            initialized = true;
            blockRangeSet = true;


            // Setup Screen 
            vnaScreen.x.logScale = vna.config.displayLogF;
            vnaScreen.x.newRange(vna.config.displayFMin, vna.config.displayFMax);
            vnaScreen.changePlot(vna.config.displayDual, vna.config.displayPlotY1, vna.config.displayPlotY2);
            vnaScreen.y1.newRange(vna.config.displayY1Min, vna.config.displayY1Max);
            vnaScreen.y2.newRange(vna.config.displayY2Min, vna.config.displayY2Max);

            // Setup UI Elements
            vnaDualDisplay.Checked = vna.config.displayDual;
            vnaDisplayFMin.Value = Convert.ToDecimal(vna.config.displayFMin);
            vnaDisplayFMax.Value = Convert.ToDecimal(vna.config.displayFMax);
            vnaDisplayFLog.Checked = vna.config.displayLogF;
            foreach (string s in vna.config.PlotModeNames)
            {
                vnaDisplayY1Type.Items.Add(s);
                vnaDisplayY2Type.Items.Add(s);
            }
            vnaDisplayY1Type.SelectedIndex = (int)vna.config.displayPlotY1;
            vnaDisplayY2Type.SelectedIndex = (int)vna.config.displayPlotY2;
            vnaDisplayY1Min.Value = Convert.ToDecimal(vna.config.displayY1Min);
            vnaDisplayY1Max.Value = Convert.ToDecimal(vna.config.displayY1Max);
            vnaDisplayY2Min.Value = Convert.ToDecimal(vna.config.displayY2Min);
            vnaDisplayY2Max.Value = Convert.ToDecimal(vna.config.displayY2Max);

            vnaSweepFMin.Value = Convert.ToDecimal(vna.config.sweepFMin);
            vnaSweepFMax.Value = Convert.ToDecimal(vna.config.sweepFMax);
            vnaSweepLog.Checked = vna.config.sweepLogF;
            vnaSweepPoints.Value = Convert.ToDecimal(vna.config.sweepPoints);
            vnaSweepDelay.Value = Convert.ToDecimal(vna.config.sweepLoopDelay * 1000);
            vnaSweepPeriods.Value = Convert.ToDecimal(vna.config.sweepMPeriods);
            vnaPhaseCorr.Value = Convert.ToDecimal(vna.config.compPhaseBlocks);

            // CallBacks
            vnaSweepRun.Click += VnaSweepRun_Click;        

            vnaDisplayY1Type.SelectedIndexChanged += VnaDisplayY1Type_SelectedIndexChanged;
            vnaDisplayY2Type.SelectedIndexChanged += VnaDisplayY2Type_SelectedIndexChanged;
            vnaDualDisplay.Click += VnaDualDisplay_Click;

            vnaDisplayReset.Click += VnaDisplayReset_Click;

            vnaDisplayFMin.ValueChanged += VnaDisplayFMin_ValueChanged;
            vnaDisplayFMax.ValueChanged += VnaDisplayFMax_ValueChanged;
            vnaDisplayY1Min.ValueChanged += VnaDisplayY1Min_ValueChanged;
            vnaDisplayY1Max.ValueChanged += VnaDisplayY1Max_ValueChanged;
            vnaDisplayY2Min.ValueChanged += VnaDisplayY2Min_ValueChanged;
            vnaDisplayY2Max.ValueChanged += VnaDisplayY2Max_ValueChanged;

            vnaDisplayFLog.Click += VnaDisplayFLog_Click;

            vnaSweepFMin.ValueChanged += VnaSweepFMin_ValueChanged;
            vnaSweepFMax.ValueChanged += VnaSweepFMax_ValueChanged;
            vnaSweepLog.Click += VnaSweepLog_Click;
            vnaSweepPoints.ValueChanged += VnaSweepPoints_ValueChanged;
            vnaSweepDelay.ValueChanged += VnaSweepDelay_ValueChanged;
            vnaSweepPeriods.ValueChanged += VnaSweepPeriods_ValueChanged;
            vnaPhaseCorr.ValueChanged += VnaPhaseCorr_ValueChanged;

            vnaSaveData.Click += VnaSaveData_Click;

            vnaDelete.Click += VnaDelete_Click;
            vnaToMemory.Click += VnaToMemory_Click;

            blockRangeSet = false;
        }

        private void VnaPhaseCorr_ValueChanged(object sender, EventArgs e)
        {
            vna.config.compPhaseBlocks = Convert.ToInt32(vnaPhaseCorr.Value);
        }

        private void VnaToMemory_Click(object sender, EventArgs e)
        {
            vnaScreen.saveTrace();
        }

        private void VnaDelete_Click(object sender, EventArgs e)
        {
            vnaScreen.deleteSelectedTrace();
        }

        private void VnaSaveData_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "XML File|*.xml";
            saveFileDialog1.Title = "Save an XML File";
            saveFileDialog1.ShowDialog();

            // If the file name is not an empty string open it for saving.
            if (saveFileDialog1.FileName != "")
            {
                saveDataToXMLFile(saveFileDialog1.FileName);
            }
        }

        private void saveDataToXMLFile(string fn)
        {
            try
            {
                XMLDataFile xdf = new XMLDataFile(fn);
                xdf.startGroup("VNAMeasurement");
                    xdf.startGroup("Config");
                        xdf.writeNumeric("FMin", vna.config.sweepFMin);
                        xdf.writeNumeric("FMax", vna.config.sweepFMax);
                        xdf.writeNumeric("LogScale", (vna.config.sweepLogF)?1:0);
                        xdf.writeNumeric("Points", vna.config.sweepPoints);
                        xdf.writeNumeric("LoopDelay", vna.config.sweepLoopDelay);
                        xdf.writeNumeric("Periods", vna.config.sweepMPeriods);
                        xdf.writeNumeric("Channels", channels);
                    xdf.closeGroup();
                    xdf.writeNumericArray("f", absA.getXData());
                    xdf.writeNumericArray("absA", absA.getYData());
                    xdf.writeNumericArray("logA", logA.getYData());
                    xdf.writeNumericArray("phiA", phiA.getYData());
                    for (int j=0;j<channels;j++)
                    {
                        xdf.writeNumericArray(string.Format("absB{0}", j + 1), absB[j].getYData());
                        xdf.writeNumericArray(string.Format("absBA{0}", j + 1), absBA[j].getYData());
                        xdf.writeNumericArray(string.Format("phiBA{0}", j + 1), phiBA[j].getYData());
                        xdf.writeNumericArray(string.Format("logB{0}", j + 1), logB[j].getYData());
                        xdf.writeNumericArray(string.Format("logBA{0}", j + 1), logBA[j].getYData());
                        xdf.writeNumericArray(string.Format("phiB{0}", j + 1), phiB[j].getYData());
                }
                xdf.closeGroup();
                xdf.close();
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message, "Error Writing File", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void VnaSweepPeriods_ValueChanged(object sender, EventArgs e)
        {
            vna.config.sweepMPeriods = Convert.ToInt32(vnaSweepPeriods.Value);
        }

        private void VnaSweepDelay_ValueChanged(object sender, EventArgs e)
        {
            vna.config.sweepLoopDelay = Convert.ToDouble(vnaSweepDelay.Value)/1000.0;
        }

        private void VnaSweepPoints_ValueChanged(object sender, EventArgs e)
        {
            vna.config.sweepPoints = Convert.ToInt32(vnaSweepPoints.Value);
        }

        private void VnaSweepLog_Click(object sender, EventArgs e)
        {
            vna.config.sweepLogF = vnaSweepLog.Checked;
        }

        private void VnaSweepFMax_ValueChanged(object sender, EventArgs e)
        {
            vna.config.sweepFMax = Convert.ToDouble(vnaSweepFMax.Value);
        }

        private void VnaSweepFMin_ValueChanged(object sender, EventArgs e)
        {
            vna.config.sweepFMin = Convert.ToDouble(vnaSweepFMin.Value);
        }

        private void VnaDisplayFLog_Click(object sender, EventArgs e)
        {
            vna.config.displayLogF = vnaDisplayFLog.Checked;
            vnaScreen.x.logScale = vnaDisplayFLog.Checked;
            vnaScreen.Invalidate();
        }

        private void VnaDisplayFMin_ValueChanged(object sender, EventArgs e)
        {
            if (blockRangeSet) return;
            vna.config.displayFMin = Convert.ToDouble(vnaDisplayFMin.Value);
            vnaScreen.x.min = Convert.ToDouble(vnaDisplayFMin.Value);
            vnaScreen.Invalidate();
        }

        private void VnaDisplayFMax_ValueChanged(object sender, EventArgs e)
        {
            if (blockRangeSet) return;
            vna.config.displayFMax = Convert.ToDouble(vnaDisplayFMax.Value);
            vnaScreen.x.max = Convert.ToDouble(vnaDisplayFMax.Value);
            vnaScreen.Invalidate();
        }

        private void VnaDisplayY1Min_ValueChanged(object sender, EventArgs e)
        {
            if (blockRangeSet) return;
            vna.config.displayY1Min = Convert.ToDouble(vnaDisplayY1Min.Value);
            vnaScreen.y1.min = Convert.ToDouble(vnaDisplayY1Min.Value);
            vnaScreen.Invalidate();
        }

        private void VnaDisplayY1Max_ValueChanged(object sender, EventArgs e)
        {
            if (blockRangeSet) return;
            vna.config.displayY1Max = Convert.ToDouble(vnaDisplayY1Max.Value);
            vnaScreen.y1.max = Convert.ToDouble(vnaDisplayY1Max.Value);
            vnaScreen.Invalidate();
        }

        private void VnaDisplayY2Min_ValueChanged(object sender, EventArgs e)
        {
            if (blockRangeSet) return;
            vna.config.displayY2Min = Convert.ToDouble(vnaDisplayY2Min.Value);
            vnaScreen.y2.min = Convert.ToDouble(vnaDisplayY2Min.Value);
            vnaScreen.Invalidate();
        }

        private void VnaDisplayY2Max_ValueChanged(object sender, EventArgs e)
        {
            if (blockRangeSet) return;
            vna.config.displayY2Max = Convert.ToDouble(vnaDisplayY2Max.Value);
            vnaScreen.y2.max = Convert.ToDouble(vnaDisplayY2Max.Value);
            vnaScreen.Invalidate();
        }

        public void updateRanges()
        {
            blockRangeSet = true;
            vnaDisplayFMin.Value = Convert.ToDecimal(vnaScreen.x.min);
            vnaDisplayFMax.Value = Convert.ToDecimal(vnaScreen.x.max);
            vnaDisplayY1Min.Value = Convert.ToDecimal(vnaScreen.y1.min);
            vnaDisplayY1Max.Value = Convert.ToDecimal(vnaScreen.y1.max);
            vnaDisplayY2Min.Value = Convert.ToDecimal(vnaScreen.y2.min);
            vnaDisplayY2Max.Value = Convert.ToDecimal(vnaScreen.y2.max);
            vna.config.displayFMin = vnaScreen.x.min;
            vna.config.displayFMax = vnaScreen.x.max;
            vna.config.displayY1Min = vnaScreen.y1.min;
            vna.config.displayY1Max = vnaScreen.y1.max;
            vna.config.displayY2Min = vnaScreen.y2.min;
            vna.config.displayY2Max = vnaScreen.y2.max;
            blockRangeSet = false;
        }

        private void VnaDisplayReset_Click(object sender, EventArgs e)
        {
            vnaScreen.resetScale();
        }

        private void VnaDualDisplay_Click(object sender, EventArgs e)
        {
            vna.config.displayDual = vnaDualDisplay.Checked;
            vnaScreen.changePlot(vna.config.displayDual, vna.config.displayPlotY1, vna.config.displayPlotY2);
        }

        private void VnaDisplayY1Type_SelectedIndexChanged(object sender, EventArgs e)
        {
            vna.config.displayPlotY1 = (VNA.vnaconfig.PlotMode)vnaDisplayY1Type.SelectedIndex;
            vnaScreen.changePlot(vna.config.displayDual, vna.config.displayPlotY1, vna.config.displayPlotY2);
        }

        private void VnaDisplayY2Type_SelectedIndexChanged(object sender, EventArgs e)
        {
            vna.config.displayPlotY2 = (VNA.vnaconfig.PlotMode)vnaDisplayY2Type.SelectedIndex;
            vnaScreen.changePlot(vna.config.displayDual, vna.config.displayPlotY1, vna.config.displayPlotY2);
        }


        private void VnaSweepRun_Click(object sender, EventArgs e)
        {
            if (running)
            {
                vna.stop();
                running = false;
                vnaSweepRun.Text = "Run";
                return;
            }

            absA = new PlotTrace();
            logA = new PlotTrace();
            phiA = new PlotTrace();
            for (int j=0;j<channels;j++)
            {
                absB[j] = new PlotTrace();
                absBA[j] = new PlotTrace();
                phiBA[j] = new PlotTrace();
                logB[j] = new PlotTrace();
                logBA[j] = new PlotTrace();
                phiB[j] = new PlotTrace();
            }

            vnaScreen.addTraces(absA, absB, absBA, phiBA, logA, logB, logBA,phiA, phiB);
            // vna.runSweep(sweepFMin, sweepFMax, sweepLog, sweepPoints, loopDelay / 1000, (int)Math.Floor(periods + 0.5));
            vna.runSweep();
            running = vna.running;
            vnaSweepRun.Text = "Stop";
        }

        private double limit(double I, double low, double high)
        {
            if (I < low) return low;
            if (I > high) return high;
            return I;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (running)
            {
                // Pick data
                while (!vna.dataFifo.empty())
                {
                    SinkSource.VNA.DataPoint dp = vna.dataFifo.get();
                    absA.add(dp.f, limit(dp.A.abs,0,1e10));
                    phiA.add(dp.f, dp.A.phi * 180.0 / Math.PI);
                    for (int j=0;j<channels;j++)
                    {
                        absB[j].add(dp.f, limit(dp.B[j].abs, 0, 1e10));
                        phiB[j].add(dp.f, dp.B[j].phi * 180.0 / Math.PI);
                    }
                    if (dp.A.abs > 0)
                    {
                        for (int j=0;j<channels;j++) {
                            absBA[j].add(dp.f, limit((dp.B[j] / dp.A).abs, 0, 1e10));
                            phiBA[j].add(dp.f, (dp.B[j] / dp.A).phi * 180.0 / Math.PI);
                            logBA[j].add(dp.f, 20 * Math.Log10(limit((dp.B[j] / dp.A).abs, 1e-10, 1e10)));
                        }
                    }
                    else
                    {
                        if (dp.A.abs == 0)
                        {
                            for (int j=0;j<channels;j++)
                            {
                                absBA[j].add(dp.f, 0);
                                phiBA[j].add(dp.f, 0);
                                logBA[j].add(dp.f, -200);
                            }
                        }
                        else
                        {
                            for (int j = 0; j < channels; j++)
                            {
                                absBA[j].add(dp.f, 1e10);
                                phiBA[j].add(dp.f, 0);
                                logBA[j].add(dp.f, 200);
                            }
                        }
                    }
                    logA.add(dp.f, 20 * Math.Log10(limit(dp.A.abs,1e-10,1e10)));
                    for (int j=0;j<channels;j++)
                        logB[j].add(dp.f, 20 * Math.Log10(limit(dp.B[j].abs,1e-10,1e10)));
                    vnaScreen.Invalidate();
                }
                if (!vna.running)
                {
                    // finished
                    running = false;
                    vnaSweepRun.Text = "Run";
                }
            }
        }

        private void VNAWin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!CanClose)
            {
                Hide();
                e.Cancel = true;
            }
        }

    }
}
