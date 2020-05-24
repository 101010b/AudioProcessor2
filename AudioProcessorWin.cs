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

namespace AudioProcessor
{
    public partial class AudioProcessorWin : Form
    {
        public List<RTObjectReference> processingObjects;

        private string saveName;


        public void RegisterProcessingObjects()
        {
            RealtimeSinkSource.WindowsDeviceSink.Register(processingObjects);
            RealtimeSinkSource.WindowsDeviceSource.Register(processingObjects);
            RealtimeSinkSource.WASAPILoopSource.Register(processingObjects);
            RealtimeSinkSource.WASAPISink.Register(processingObjects);
            RealtimeSinkSource.WASAPISource.Register(processingObjects);
            RealtimeSinkSource.ASIODevice.Register(processingObjects);

            SinkSource.FGenerator.Register(processingObjects);
            SinkSource.Oscilloscope.Register(processingObjects);
            SinkSource.SpectrumAnalyzer.Register(processingObjects);
            SinkSource.WaterfallSpectrum.Register(processingObjects);
            SinkSource.LinePlotter.Register(processingObjects);
            SinkSource.WhiteNoise.Register(processingObjects);
            SinkSource.WavFileReader.Register(processingObjects);
            SinkSource.WavFileWriter.Register(processingObjects);
            SinkSource.ShapeGen.Register(processingObjects);
            SinkSource.Sweep.Register(processingObjects);
            SinkSource.VNA.Register(processingObjects);
            SinkSource.RMSVal.Register(processingObjects);
            SinkSource.Sequencer.Register(processingObjects);

            AsyncSinkSource.MIDI_In.Register(processingObjects);
            AsyncSinkSource.AsyncNetListener.Register(processingObjects);

            Processing.Adder.Register(processingObjects);
            Processing.Agc.Register(processingObjects);
            Processing.Averager.Register(processingObjects);
            Processing.BooleanIndicator.Register(processingObjects);
            Processing.BooleanOP.Register(processingObjects);
            Processing.Compare.Register(processingObjects);
            Processing.Constant.Register(processingObjects);
            Processing.FFTFilter.Register(processingObjects);
            Processing.FFTPicker.Register(processingObjects);
            Processing.FixedGain.Register(processingObjects);
            Processing.IIRAFilter.Register(processingObjects);
            Processing.IIRFilter.Register(processingObjects);
            Processing.Mixer.Register(processingObjects);
            Processing.Mult.Register(processingObjects);
            Processing.Mux.Register(processingObjects);
            Processing.Nop.Register(processingObjects);
            Processing.PLL.Register(processingObjects);
            Processing.Sub.Register(processingObjects);
            Processing.Switch.Register(processingObjects);
            Processing.Unary.Register(processingObjects);
            Processing.VCF.Register(processingObjects);
            Processing.VectorDetector.Register(processingObjects);
            Processing.VMux.Register(processingObjects);
            Processing.Echo.Register(processingObjects);
            Processing.Equalizer.Register(processingObjects);

            DataProcessing.Chromagram.Register(processingObjects);
            DataProcessing.MEL.Register(processingObjects);
            DataProcessing.MFCC.Register(processingObjects);
            DataProcessing.DataDeMux.Register(processingObjects);
            DataProcessing.DataFileWriter.Register(processingObjects);
            DataProcessing.DataWaterfallDisplay.Register(processingObjects);
            DataProcessing.DataSubset.Register(processingObjects);
            DataProcessing.DataMerge.Register(processingObjects);
            DataProcessing.DataViewer.Register(processingObjects);
        }

        private int[] sampleRateOptions = new int[] { 11025, 22050, 44100, 48000, 88200, 96000, 176400, 192000 };
        private int[] bufferSizes = new int[] { 10, 20, 50, 100, 200, 500, 1000 };


        public AudioProcessorWin()
        {
            InitializeComponent();
            systemPanel.setAudioProcessorWin(this);

            processingObjects = new List<RTObjectReference>();
            RegisterProcessingObjects();

            saveName = "";
            
            // Build the Menu
            ToolStripMenuItem root = addToolStripMenuItem;
            foreach (RTObjectReference por in processingObjects)
            {
                ToolStripMenuItem pos = root;
                List<string> add = por.GetAddress();
                string name = add.Last();
                add.RemoveAt(add.Count - 1);
                foreach (string lvl in add)
                {
                    int i = 0;
                    while ((i < pos.DropDownItems.Count) &&
                        !pos.DropDownItems[i].Text.Equals(lvl))
                        i++;
                    if (i >= pos.DropDownItems.Count)
                    {
                        ToolStripMenuItem mi = new ToolStripMenuItem();
                        mi.Text = lvl;
                        pos.DropDownItems.Add(mi);
                        pos = mi;
                    }
                    else
                        pos = (ToolStripMenuItem)pos.DropDownItems[i];
                }
                ToolStripMenuItem mu = new ToolStripMenuItem();
                mu.Text = name;
                pos.DropDownItems.Add(mu);
                mu.Click += AddProcessingObjectMenuClick;
                mu.Tag = por;

                pos = null;
                if (add[0].Equals("Source"))
                    pos = audioProcessorTSInput;
                if (add[0].Equals("Sink"))
                    pos = audioProcessorTSOutput;
                if (add[0].Equals("Filter"))
                    pos = audioProcessorTSFilter;
                if (add[0].Equals("Generator"))
                    pos = audioProcessorTSGenerators;
                if (add[0].Equals("Arithmetic"))
                    pos = audioProcessorTSArith;
                if (add[0].Equals("Tools"))
                    pos = audioProcessorTSTools;
                if (add[0].Equals("Control"))
                    pos = audioProcessorTSControl;
                if (add[0].Equals("Data"))
                    pos = audioProcessorTSData;
                if (pos != null)
                {
                    add.RemoveAt(0);
                    foreach (string lvl in add)
                    {
                        int i = 0;
                        while ((i < pos.DropDownItems.Count) &&
                            !pos.DropDownItems[i].Text.Equals(lvl))
                            i++;
                        if (i >= pos.DropDownItems.Count)
                        {
                            ToolStripMenuItem mi = new ToolStripMenuItem();
                            mi.Text = lvl;
                            pos.DropDownItems.Add(mi);
                            pos = mi;
                        }
                        else
                            pos = (ToolStripMenuItem)pos.DropDownItems[i];
                    }
                    mu = new ToolStripMenuItem();
                    mu.Text = name;
                    pos.DropDownItems.Add(mu);
                    mu.Click += AddProcessingObjectMenuClick;
                    mu.Tag = por;
                }
            }

            for (int i=0;i<sampleRateOptions.Length;i++)
            {
                audioProcessingSampleRate.DropDownItems.Add(String.Format("{0} Hz", sampleRateOptions[i]));
                audioProcessingSampleRate.DropDownItems[i].Click += AudioProcessorWin_Click;
                audioProcessingSampleRate.DropDownItems[i].Tag = i;
            }
            audioProcessingSampleRate.Text = String.Format("{0} Hz", systemPanel.sampleRate);

            for (int i=0;i< bufferSizes.Length;i++)
            {
                audioProcessingBufferLength.DropDownItems.Add(String.Format("{0} ms", bufferSizes[i]));
                audioProcessingBufferLength.DropDownItems[i].Click += AudioProcessingBufferLength_Click;
                audioProcessingBufferLength.DropDownItems[i].Tag = i;
            }
            audioProcessingBufferLength.Text = String.Format("{0} ms", 1000 * systemPanel.startInSleepFill / systemPanel.sampleRate);

            // Show Log Window
            systemPanel.logWin = new LogWin();
            systemPanel.logWin.Hide();
            systemPanel.logText("Log WIndow Started");

            audioProcessorWindowLog.Click += AudioProcessorWindowLog_Click;
            audioProcessorFileExit.Click += AudioProcessorFileExit_Click;
            audioProcessorFileOpen.Click += AudioProcessorFileOpen_Click;
            audioProcessorFileSave.Click += AudioProcessorFileSave_Click;
            audioProcessorFileSaveAs.Click += AudioProcessorFileSaveAs_Click;

            aboutToolStripMenuItem.Click += AboutToolStripMenuItem_Click;

            tsOpen.Click += AudioProcessorFileOpen_Click;
            tsSave.Click += AudioProcessorFileSave_Click;
            tsDelete.Click += TsDelete_Click;
            audioProcessorToolBar.Renderer = new RTTSRenderer();
            // audioProcessorToolBar.RenderMode = ToolStripRenderMode.ManagerRenderMode;

        }

        private void AudioProcessingBufferLength_Click(object sender, EventArgs e)
        {
            int idx = (int)((ToolStripItem)sender).Tag;
            int bufsize = bufferSizes[idx];
            systemPanel.startInSleepFill = bufsize * systemPanel.sampleRate / 1000;
            systemPanel.startOutSleepFill = bufsize * systemPanel.sampleRate / 1000;
            audioProcessingBufferLength.Text = String.Format("{0} ms", 1000 * systemPanel.startInSleepFill / systemPanel.sampleRate);
        }

        private void TsDelete_Click(object sender, EventArgs e)
        {
            systemPanel.DeleteClicked();
        }

        public void changeStatusString(string msg)
        {
            audioProcessorStatusLabel.Text = msg;
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutWin aw = new AboutWin();
            aw.ShowDialog();
        }

        private void AudioProcessorWin_Click(object sender, EventArgs e)
        {
            int idx = (int) ((ToolStripItem)sender).Tag;
            int bufsize = 1000 * systemPanel.startInSleepFill / systemPanel.sampleRate;
            systemPanel.changeSampleRate(sampleRateOptions[idx]);
            systemPanel.startInSleepFill = bufsize * systemPanel.sampleRate / 1000;
            systemPanel.startOutSleepFill = bufsize * systemPanel.sampleRate / 1000;
            audioProcessingSampleRate.Text = String.Format("{0} Hz", systemPanel.sampleRate);
        }

        private void saveToFile(string fn)
        {
            try
            {
                BinaryWriter b = new BinaryWriter(new FileStream(fn, FileMode.Create));
                systemPanel.writeFile(b);
                b.Close();
                saveName = fn;
                this.Text = "AudioProcessor [" + saveName + "]";
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error Writing File", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void readFromFile(string fn)
        {
            systemPanel.LockWorker();
            try
            {
                BinaryReader b = new BinaryReader(new FileStream(fn, FileMode.Open));
                systemPanel.readFile(b);
                b.Close();
                saveName = fn;
                this.Text = "AudioProcessor [" + saveName + "]";
                audioProcessingSampleRate.Text = String.Format("{0} Hz", systemPanel.sampleRate);
                audioProcessingBufferLength.Text = String.Format("{0} ms", 1000 * systemPanel.startInSleepFill / systemPanel.sampleRate);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error Reading File", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            systemPanel.UnLockWorker();
            systemPanel.Invalidate();
        }

        private void AudioProcessorFileSaveAs_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "APR File|*.apr";
            sfd.Title = "Save an APR File";
            sfd.ShowDialog();

            // If the file name is not an empty string open it for saving.
            if (sfd.FileName != "")
            {
                saveToFile(sfd.FileName);
            }

        }

        private void AudioProcessorFileSave_Click(object sender, EventArgs e)
        {
            if (saveName.Length > 0)
            {
                saveToFile(saveName);
            } else
            {
                AudioProcessorFileSaveAs_Click(null, null);
            }
        }

        private void AudioProcessorFileOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog sfd = new OpenFileDialog();
            sfd.Filter = "APR File|*.apr";
            sfd.Title = "Open an APR File";
            sfd.ShowDialog();

            // If the file name is not an empty string open it for saving.
            if (sfd.FileName != "")
            {
                readFromFile(sfd.FileName);
            }
        }

        private void AudioProcessorFileExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AudioProcessorWindowLog_Click(object sender, EventArgs e)
        {
            if (systemPanel.logWin == null)
                return;
            systemPanel.logWin.Show();
        }

        private void AddProcessingObjectMenuClick(object sender, EventArgs e)
        {
            RTObjectReference por = (RTObjectReference)((ToolStripMenuItem)sender).Tag;
            systemPanel.LockWorker();
            systemPanel.addElement(por.Instantiate());
            systemPanel.UnLockWorker();
            // systemPanel.Invalidate();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            systemPanel.Shutdown();
            base.OnClosing(e);
        }

        public class RTTSRenderer : ToolStripRenderer 
        {
            protected override void OnRenderArrow(ToolStripArrowRenderEventArgs e)
            {
                e.ArrowColor = Color.DimGray;
                base.OnRenderArrow(e);
            }

            protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
            {
                if (!e.ToolStrip.Text.Equals("ROOT"))
                {
                    Rectangle r = e.AffectedBounds;
                    r.Width -= 1;
                    r.Height -= 1;
                    e.Graphics.DrawRectangle(Pens.DarkGray, r);
                }
                else
                {
                    e.Graphics.DrawLine(Pens.DarkGray, e.AffectedBounds.Left, e.AffectedBounds.Bottom - 1,
                        e.AffectedBounds.Right, e.AffectedBounds.Bottom - 1);
                }
            }

            protected override void OnRenderToolStripBackground(ToolStripRenderEventArgs e)
            {
                e.Graphics.FillRectangle(Brushes.Black, e.AffectedBounds);
            }

            
            protected override void OnRenderDropDownButtonBackground(ToolStripItemRenderEventArgs e)
            {
                e.Graphics.FillRectangle(Brushes.Black, 0, 0, e.Item.Size.Width - 1, e.Item.Size.Height - 1);
            }
            
            protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
            {
                if (e.Item.Selected)
                {
                    e.Graphics.DrawRectangle(Pens.DarkGray, 1, 1, e.Item.Size.Width - 2, e.Item.Size.Height - 2);
                }
                else
                {
                    e.Graphics.FillRectangle(Brushes.Black, 0, 0, e.Item.Size.Width - 1, e.Item.Size.Height - 1);
                }
            }

            protected override void OnRenderButtonBackground(ToolStripItemRenderEventArgs e)
            {
                if (e.Item.Selected)
                {
                    e.Graphics.DrawRectangle(Pens.DarkGray, 0, 0, e.Item.Size.Width - 1, e.Item.Size.Height - 1);
                }
                else
                {
                    e.Graphics.FillRectangle(Brushes.Black, 0, 0, e.Item.Size.Width - 1, e.Item.Size.Height - 1);
                }
            }

            protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
            {
                if (e.Item.Selected)
                    e.TextColor = Color.Yellow;
                else
                    e.TextColor = Color.White;
                //if (e.Item.Selected)
                 //   e.Graphics.FillRectangle(Brushes.DarkBlue, e.Item.Bounds);
                //else
                //    e.Graphics.FillRectangle(Brushes.Black, e.Item.Bounds);
                // e.Graphics.FillRectangle(Brushes.Black, e.TextRectangle);
                base.OnRenderItemText(e);
            }
        }

    }
}
