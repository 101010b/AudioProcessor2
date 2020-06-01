using System;
using System.Threading;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using System.Security;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Drawing.Drawing2D;

namespace AudioProcessor
{
    public partial class RTXY : RTControl
    {

        private string _title;
        public string title
        {
            set { _title = value; redraw(); }
            get { return _title; }
        }

        private GraphicsUtil.TextAlignment _titlePos;
        public GraphicsUtil.TextAlignment titlePos
        {
            set { _titlePos = value; redraw(); }
            get { return _titlePos; }
        }

        private Color _titleColor;
        private Brush titleBrush;
        public Color titleColor
        {
            set { _titleColor = value; titleBrush = new SolidBrush(_titleColor); redraw(); }
            get { return _titleColor; }
        }

        private Font _titleFont;
        public Font titleFont
        {
            set { _titleFont = value; redraw(); }
            get { return _titleFont; }
        }

        private Size _displaySize;
        public Size displaySize
        {
            set { _displaySize = value; redraw(); }
            get { return _displaySize; }
        }

        private Color _frameColor;
        private Pen framePen;
        public Color frameColor
        {
            set { _frameColor = value; framePen = new Pen(_frameColor); redraw(); }
            get { return _frameColor; }
        }

        private string _colorSet;
        public string colorSet
        {
            set { _colorSet = value; newColorSet(); Invalidate(); }
            get { return _colorSet; }
        }

        private int _xSteps;
        public int xSteps
        {
            set { _xSteps = value; newDataSet(); Invalidate(); }
            get { return _xSteps; }
        }

        private int _ySteps;
        public int ySteps
        {
            set { _ySteps = value; newDataSet(); Invalidate(); }
            get { return _ySteps; }
        }

        private double _fadeFactor;
        public double fadeFactor
        {
            set { if ((value >= 0) && (value <= 1)) { _fadeFactor = value; newFadeMap(); Invalidate(); } }
            get { return _fadeFactor; }
        }

        public ColorTable colorTable;
        private byte[] data;
        private int[] bmapdata;
        private Bitmap bmap;
        private byte[] fademap;

        public RTXY()
        {
            _title = "XY";
            _titlePos = GraphicsUtil.TextAlignment.above;
            _titleColor = Color.DimGray;
            titleBrush = new SolidBrush(_titleColor);
            _titleFont = new Font(FontFamily.GenericSansSerif, 8);
            _displaySize = new Size(50, 20);
            _frameColor = Color.DimGray;
            framePen = new Pen(_frameColor);
            _colorSet = "KrYW";
            _xSteps = 64;
            _ySteps = 64;
            _fadeFactor = 0.8;
            newFadeMap();
            newColorSet();
            newDataSet();
            updateBitmap();

            this.DoubleBuffered = true;
        }

        private void newFadeMap()
        {
            byte[] newfademap = new byte[256];
            for (int i=0;i<256;i++)
            {
                if (i == 0)
                    newfademap[i] = 0;
                else
                {
                    byte ft = (byte)Math.Floor((double)i * _fadeFactor + 0.5);
                    if (ft >= i)
                        ft = (byte)(i - 1);
                    newfademap[i] = ft;
                }
            }
            fademap = newfademap;
        }

        private void newColorSet()
        {
            if (colorTable == null)
                colorTable = new ColorTable(256,_colorSet);
            else
                colorTable.scheme = _colorSet;
        }

        void newDataSet()
        {
            if ((data == null) || (data.Length != _ySteps * _xSteps))
            {
                data = new byte[_ySteps * _xSteps];
                bmapdata = new int[_ySteps * _xSteps];
            }
        }

        void updateBitmap()
        {
            if ((bmap == null) || (bmap.Width != _xSteps) || (bmap.Height != _ySteps))
                bmap = new Bitmap(_xSteps, _ySteps, PixelFormat.Format32bppRgb);
            BitmapData bmd = bmap.LockBits(new Rectangle(0, 0, bmap.Width, bmap.Height), ImageLockMode.WriteOnly, PixelFormat.Format32bppRgb);
            Marshal.Copy(bmapdata, 0, bmd.Scan0, bmap.Width * bmap.Height);
            bmap.UnlockBits(bmd);
        }

        void getWfCoords(ref Vector wfCenter, ref Vector wfSize, ref GraphicsUtil.TextPosition titlePosition)
        {
            GraphicsUtil.TextAlignment ta = _titlePos;
            if ((_title == null) || (_title.Length < 1))
                ta = GraphicsUtil.TextAlignment.off;
            Size sz = new Size(_displaySize.Width + 4, _displaySize.Height + 4);
            wfSize = Vector.V(_displaySize) * scale;
            GraphicsUtil.dualSplit(ClientSize, sz, scale, ref wfCenter, ref titlePosition, _titlePos);
        }

        void drawTo(Graphics g)
        {
            // Background
            // Brush brushBackground = new SolidBrush(BackColor);
            // g.FillRectangle(brushBackground, this.ClientRectangle);

            Vector center = Vector.Zero;
            Vector size = Vector.Zero;
            GraphicsUtil.TextPosition titlePosition = null;

            getWfCoords(ref center, ref size, ref titlePosition);
            if (titlePosition != null)
            {
                Brush titleBrush = new SolidBrush(_titleColor);
                titlePosition.drawText(g, _titleFont, titleBrush, _title);
            }

            Rectangle fr = VectorRect.FromCenterSize(center, size).rectangle;
            g.DrawRectangle(framePen, fr.Left - 1, fr.Top - 1, fr.Width + 2, fr.Height + 2);
            buildMap();
            updateBitmap(); 
            InterpolationMode imode = g.InterpolationMode;
            PixelOffsetMode pmode = g.PixelOffsetMode;
            g.InterpolationMode = InterpolationMode.NearestNeighbor;
            g.PixelOffsetMode = PixelOffsetMode.Half;
            g.DrawImage(bmap, fr, 0, 0, bmap.Width, bmap.Height, GraphicsUnit.Pixel);
            g.InterpolationMode = imode;
            g.PixelOffsetMode = pmode;
            // needsRedraw = false;
        }

        [DllImport("kernel32.dll", EntryPoint = "CopyMemory", SetLastError = false)]
        public static extern void CopyMemory(IntPtr dest, IntPtr src, uint count);
        [DllImport("kernel32.dll", EntryPoint = "MoveMemory", SetLastError = false)]
        public static extern void MoveMemory(IntPtr dest, IntPtr src, uint count);

        private void setpixel(int ax, int ay)
        {
            if ((ax < 0) || (ay < 0) || (ax >= _xSteps) || (ay >= _ySteps)) return;
            data[ay * _xSteps + ax] = 255;
        }

        public void addData(double[] x, double[] y)
        {
            if ((x == null) || (y == null) || (x.Length != y.Length)) return;


            byte[] pix = new byte[4];

            fadeData();
            int LX=0, LY=0;
            bool lastdef = false;
            for (int i=0;i<x.Length;i++)
            {
                int AX = (int)Math.Floor((x[i]/2.0 + 0.5) * _xSteps + 0.5);
                int AY = (int)Math.Floor((-y[i]/2.0 + 0.5) * _ySteps + 0.5);
                if (lastdef)
                {
                    int dx = AX - LX;
                    int dy = AY - LY;
                    int dxa = (dx < 0) ? -dx : dx;
                    int dya = (dy < 0) ? -dy : dy;

                    if ((dxa <= 1) && (dya <= 1))
                        setpixel(AX, AY);
                    else
                    {
                        if (dxa >= dya)
                        {
                            if (dx > 0)
                                for (int xi = LX + 1; xi <= AX; xi++)
                                    setpixel(xi, LY + (xi - LX) * dy/ dx);
                            else
                                for (int xi = AX; xi != LX; xi++)
                                    setpixel(xi, LY + (xi - LX) * dy / dx);
                        } else
                        {
                            if (dy > 0)
                                for (int yi = LY + 1; yi <= AY; yi++)
                                    setpixel(LX + (yi - LY) * dx / dy, yi);
                            else
                                for (int yi = AY; yi != LY; yi++)
                                    setpixel(LX + (yi - LY) * dx / dy, yi);
                        }
                    }
                } else
                    setpixel(AX, AY);
                LX = AX;
                LY = AY;
                lastdef = true;
            }

            if ((Parent != null) && (Parent.Parent != null) && (Parent.Parent is SystemPanel))
                ((SystemPanel)(Parent.Parent)).scheduleRedraw(this);
        }

        private void fadeData()
        {
            if (_fadeFactor < 0.001)
            {
                Array.Clear(data, 0, data.Length);
            } else
            {
                for (int i = 0; i < data.Length; i++)
                {
                    data[i] = fademap[data[i]];
                }
            }
        }

        private void buildMap()
        {
            for (int i=0;i<data.Length;i++)
                bmapdata[i] = colorTable.icol(data[i]);
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            // base.OnPaint(pe);
            drawTo(pe.Graphics);
        }


        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            forwardOnMouseMove(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            forwardOnMouseUp(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            forwardOnMouseDown(e);
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(e);
            forwardOnMouseWheel(e);
        }


    }
}
