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

namespace AudioProcessor
{
    public partial class RTLabel : RTControl
    {

        private String _title;
        public string title
        {
            set { _title = value; Invalidate(); }
            get { return _title; }
        }

        private Color _titleColor;
        public Color titleColor
        {
            set { _titleColor = value; Invalidate(); }
            get { return _titleColor; }
        }

        private Font _titleFont;
        public Font titleFont
        {
            set { _titleFont = value; Invalidate(); }
            get { return _titleFont; }
        }

        public enum LableAnchor
        {
            TopLeft, Top, TopRight,
            Left, Center, Right,
            BottomLeft,Bottom,BottomRight
        }
        private LableAnchor _anchor;
        public LableAnchor anchor
        {
            set { _anchor = value; Invalidate(); }
            get { return _anchor; }
        }

        private int _angle;
        public int angle
        {
            set { _angle = value; Invalidate(); }
            get { return _angle; }
        }

        public RTLabel()
        {
            _title = "Label";
            _titleColor = Color.DimGray;
            _titleFont = new Font(FontFamily.GenericSansSerif, 8);
            _anchor = LableAnchor.Center;
            _angle = 0;
        }

        void drawTo(Graphics g)
        {
            // Background
            // Brush brushBackground = new SolidBrush(BackColor);
            // g.FillRectangle(brushBackground, this.ClientRectangle);

            if ((_title != null) && (_title.Length > 0))
            {
                Brush tBrush = new SolidBrush(_titleColor);
                Vector dir = Vector.V(1, 0).rot((double)-_angle * Math.PI / 180);
                Vector anchor = Vector.V(Width / 2, Height / 2);
                int ax = 0, ay = 0;
                switch (_anchor)
                {
                    case LableAnchor.TopLeft: anchor = Vector.V(0, 0); ax = -1; ay = 1; break;
                    case LableAnchor.Top: anchor = Vector.V(Width/2, 0); ax = 0; ay = 1; break;
                    case LableAnchor.TopRight: anchor = Vector.V(Width-1, 0); ax = 1; ay = 1; break;
                    case LableAnchor.Left: anchor = Vector.V(0, Height/2); ax = -1; ay = 0; break;
                    case LableAnchor.Center: anchor = Vector.V(Width/2, Height/2); ax = 0; ay = 0; break;
                    case LableAnchor.Right: anchor = Vector.V(Width-1, Height/2); ax = 1; ay = 0; break;
                    case LableAnchor.BottomLeft: anchor = Vector.V(0, Height-1); ax = -1; ay = -1; break;
                    case LableAnchor.Bottom: anchor = Vector.V(Width/2, Height - 1); ax = 0; ay = -1; break;
                    case LableAnchor.BottomRight: anchor = Vector.V(Width-1, Height - 1); ax = 1; ay = -1; break;

                }
                GraphicsUtil.drawText(g, anchor, _titleFont, scale, _title, 0, 2, ax, ay, dir, tBrush);
            }
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            // base.OnPaint(pe);
            drawTo(pe.Graphics);
        }
        /*
        protected override void WndProc(ref Message m)
        {
            const int WM_NCHITTEST = 0x0084;
            const int HTTRANSPARENT = (-1);

            if (m.Msg == WM_NCHITTEST)
            {
                m.Result = (IntPtr)HTTRANSPARENT;
            }
            else
            {
                base.WndProc(ref m);
            }
        }
        */
        
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

    }
}
