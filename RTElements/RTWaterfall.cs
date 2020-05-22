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
    public partial class RTWaterfall : RTControl
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

        private int _timeSteps;
        public int timeSteps
        {
            set { _timeSteps = value; newDataSet(); Invalidate(); }
            get { return _timeSteps; }
        }

        private int _ySteps;
        public int ySteps
        {
            set { _ySteps = value; newDataSet(); Invalidate(); }
            get { return _ySteps; }
        }

        private bool _bipolar;
        public bool bipolar
        {
            set { _bipolar = value; Invalidate(); }
            get { return _bipolar; }
        }

        public ColorTable colorTable;
        private byte[] data;
        private Bitmap bmap;

        public RTWaterfall()
        {
            _title = "Waterfall";
            _titlePos = GraphicsUtil.TextAlignment.above;
            _titleColor = Color.DimGray;
            titleBrush = new SolidBrush(_titleColor);
            _titleFont = new Font(FontFamily.GenericSansSerif, 8);
            _displaySize = new Size(50, 20);
            _frameColor = Color.DimGray;
            framePen = new Pen(_frameColor);
            _colorSet = "KrYW";
            _timeSteps = 64;
            _ySteps = 16;
            _bipolar = false;
            newColorSet();
            newDataSet();

            this.DoubleBuffered = true;
        }

        void newColorSet()
        {
            if (colorTable == null)
                colorTable = new ColorTable(_colorSet);
            else
                colorTable.scheme = _colorSet;
        }

        void newDataSet()
        {
            if ((data == null) || (data.Length != _ySteps * _timeSteps * 4))
                data = new byte[_ySteps * _timeSteps * 4];
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
            if ((bmap == null) || (data.Length != bmap.Height*bmap.Width*4))
            {
                bmap = new Bitmap(_timeSteps, _ySteps, PixelFormat.Format32bppRgb);
            }
            BitmapData bmd = bmap.LockBits(new Rectangle(0, 0, bmap.Width, bmap.Height), ImageLockMode.WriteOnly,PixelFormat.Format32bppRgb);
            Marshal.Copy(data, 0, bmd.Scan0, bmap.Width * bmap.Height * 4);
            bmap.UnlockBits(bmd);
            InterpolationMode imode = g.InterpolationMode;
            PixelOffsetMode pmode = g.PixelOffsetMode;
            g.InterpolationMode = InterpolationMode.NearestNeighbor;
            g.PixelOffsetMode = PixelOffsetMode.Half;
            g.DrawImage(bmap, fr,0,0,bmap.Width, bmap.Height,GraphicsUnit.Pixel);
            g.InterpolationMode = imode;
            g.PixelOffsetMode = pmode;

            // needsRedraw = false;
        }

        [DllImport("kernel32.dll", EntryPoint = "CopyMemory", SetLastError = false)]
        public static extern void CopyMemory(IntPtr dest, IntPtr src, uint count);
        [DllImport("kernel32.dll", EntryPoint = "MoveMemory", SetLastError = false)]
        public static extern void MoveMemory(IntPtr dest, IntPtr src, uint count);

        public void addColumn(double[] dt)
        {
            if (dt == null) return;
            if (dt.Length != _ySteps) return;
            Array.Copy(data, 0, data, 4, data.Length - 4);
            byte[] pix = new byte[4];
            for (int y = 0; y < _ySteps; y++)
            {
                if (_bipolar)
                    colorTable.col((dt[_ySteps - 1 - y] + 1.0) / 2.0, ref pix[2], ref pix[1], ref pix[0]);
                else 
                    colorTable.col(dt[_ySteps-1-y], ref pix[2], ref pix[1], ref pix[0]);
                Array.Copy(pix, 0, data, y * _timeSteps * 4, 4);
            }
            if ((Parent != null) && (Parent.Parent != null) && (Parent.Parent is SystemPanel))
                ((SystemPanel)(Parent.Parent)).scheduleRedraw(this);
        }

        public void addColumn(double[] dt, int start, int len)
        {
            if (dt == null) return;
            if (start < 0) return;
            if (start + len - 1 >= dt.Length) return;
            if (len != _ySteps) return;
            Array.Copy(data, 0, data, 4, data.Length - 4);
            byte[] pix = new byte[4];
            for (int y = 0; y < _ySteps; y++)
            {
                if (_bipolar)
                    colorTable.col((dt[_ySteps - 1 - y] + 1.0) / 2.0, ref pix[2], ref pix[1], ref pix[0]);
                else
                    colorTable.col(dt[start + _ySteps - 1 - y], ref pix[2], ref pix[1], ref pix[0]);
                Array.Copy(pix, 0, data, y * _timeSteps * 4, 4);
            }
            if ((Parent != null) && (Parent.Parent != null) && (Parent.Parent is SystemPanel))
                ((SystemPanel)(Parent.Parent)).scheduleRedraw(this);
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
