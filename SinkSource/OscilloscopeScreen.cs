using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AudioProcessor.SinkSource
{
    public partial class OscilloscopeScreen : Control
    {

        OscilloscopeWin root;
        public int channels;
        public OscilloscopeWin.OscilloscopeLine[] lines;

        public int decay;

        private Bitmap screen;
        // private byte[] screenBytes;
        private int screenStride;
        private Graphics screenGraphics;

        private Brush brushBack;
        private Pen penGrid;
        private Pen penFrame;

        private Color _colorGrid = Color.White;
        public Color colorGrid
        {
            set
            {
                _colorGrid = value;
                penGrid = new Pen(_colorGrid);
            }
            get { return _colorGrid; }
        }

        private Color _colorFrame = Color.White;
        public Color colorFrame
        {
            set { _colorFrame = value; penFrame = new Pen(_colorFrame); }
            get { return _colorFrame; }
        }
        
        public OscilloscopeScreen()
        {
            InitializeComponent();

            brushBack = new SolidBrush(BackColor);
            penGrid = new Pen(_colorGrid);
            penFrame = new Pen(_colorFrame);
            DoubleBuffered = true;
            channels = 0;
            BackColorChanged += OscilloscopeScreen_BackColorChanged;
        }

        private void OscilloscopeScreen_BackColorChanged(object sender, EventArgs e)
        {
            brushBack = new SolidBrush(BackColor);
        }

        public void initOscilloscopeScreen(OscilloscopeWin _root, int _channels, OscilloscopeWin.OscilloscopeLine[] _lines)
        {
            root = _root;
            lines = _lines;
            channels = _channels;
        }

        private unsafe void fadeScreen()
        {

            if (decay == 0)
            {
                screenGraphics.FillRectangle(brushBack, new Rectangle(0, 0, screen.Width, screen.Height));
            } else
            {
                BitmapData bmd = screen.LockBits(new Rectangle(0, 0, screen.Width, screen.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppRgb);
                byte* scan0 = (byte*)bmd.Scan0.ToPointer();
                for (int y = 0; y < screen.Height; y++)
                {
                    int ofs = y * bmd.Stride;
                    for (int x = 0; x < screen.Width; x++)
                    {
                        ofs++;
                        if (scan0[ofs] < decay)
                            scan0[ofs] = 0;
                        else
                            scan0[ofs] -= (byte)decay;
                        ofs++;
                        if (scan0[ofs] < decay)
                            scan0[ofs] = 0;
                        else
                            scan0[ofs] -= (byte)decay;
                        ofs++;
                        if (scan0[ofs] < decay)
                            scan0[ofs] = 0;
                        else
                            scan0[ofs] -= (byte)decay;
                        ofs++;
                    }
                }
                screen.UnlockBits(bmd);
            }
        }

        private int[] xlines = null;
        private int[] ylines = null;

        protected override void OnPaint(PaintEventArgs pe)
        {
            int bmw = Width - 20;
            int bmh = Height - 20;
            int bmx = 10;
            int bmy = 10;

            if ((screen == null) || (screen.Width != bmw) || (screen.Height != bmh))
            {
                if (screenGraphics != null) screenGraphics.Dispose();
                screenGraphics = null;

                screen = new Bitmap(bmw, bmh, PixelFormat.Format32bppRgb);
                screenGraphics = Graphics.FromImage(screen);
                BitmapData bmd = screen.LockBits(new Rectangle(0, 0, bmw, bmh), ImageLockMode.ReadWrite, PixelFormat.Format32bppRgb);
                screenStride = bmd.Stride;
                screen.UnlockBits(bmd);

                xlines = new int[11];
                ylines = new int[11];
                for (int x=-5;x<=5; x++)
                {
                    xlines[x + 5] = (int)Math.Floor((x + 5.0) * (bmw - 1) / 10.0 + 0.5);
                    ylines[x + 5] = (int)Math.Floor((x + 5.0) * (bmh - 1) / 10.0 + 0.5);
                }
            }

            // Fade screen
            fadeScreen();

            // draw grid lines
            if (root == null || root.drawGrid)
            {
                for (int i=0;i<xlines.Length;i++)
                {
                    screenGraphics.DrawLine(penGrid, xlines[i], 0, xlines[i], bmh - 1);
                    screenGraphics.DrawLine(penGrid, 0, ylines[i], bmw - 1, ylines[i]);
                }
            }

            // Draw new lines
            if ((root != null) && root.xydisplay)
            {
                lines[0].DrawXY(screenGraphics, bmw, bmh, lines[1]);
                lines[2].DrawXY(screenGraphics, bmw, bmh, lines[3]);
            } else 
            {
                if (channels > 0) {
                    for (int i = 0; i < channels; i++)
                        lines[i].Draw(screenGraphics,bmw,bmh);
                }
            }
            // Draw the Bitmap
            pe.Graphics.DrawImageUnscaled(screen, bmx, bmy);
            pe.Graphics.DrawRectangle(penFrame, bmx - 2, bmy - 2, bmw+3, bmh+3);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            Invalidate();
        }
    }
}
