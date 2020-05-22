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
    public partial class RTIO : RTControl
    {
        public ProcessingNet connectedTo;

        public RTForm element
        {
            get {
                if (Parent == null) return null;
                if (Parent is RTForm)
                    return (RTForm)Parent;
                return null;
            }
        }

        private string _title;
        public string title
        {
            set { _title = value; Invalidate(); }
            get { return _title; }
        }

        private Font _titleFont;
        public Font titleFont
        {
            set { _titleFont = value; Invalidate(); }
            get { return _titleFont; }
        }

        private Color _titleColor;
        private Brush titleBrush;
        public Color titleColor
        {
            set { _titleColor = value; titleBrush = new SolidBrush(_titleColor); Invalidate(); }
            get { return _titleColor; }
        }

        private bool _showTitle;
        public bool showTitle
        {
            set { _showTitle = value; Invalidate(); }
            get { return _showTitle; }
        }

        public enum ProcessingIOType
        {
            SignalInput,
            SignalOutput,
            DataInput,
            DataOutput
        }
        private ProcessingIOType _IOtype;
        public ProcessingIOType IOtype
        {
            set { _IOtype = value; Invalidate(); }
            get { return _IOtype; }
        }

        private Color _contactBackColor;
        private Brush contactBackBrush;
        public Color contactBackColor
        {
            set { _contactBackColor = value; contactBackBrush = new SolidBrush(_contactBackColor); Invalidate(); }
            get { return _contactBackColor; }
        }

        private Color _contactColor;
        private Pen contactPen;
        public Color contactColor
        {
            set { _contactColor = value; contactPen = new Pen(_contactColor); Invalidate(); }
            get { return _contactColor; }
        }

        private Color _contactHighlightColor;
        private Pen contactHighlightPen;
        public Color contactHighlightColor
        {
            set { _contactHighlightColor = value; contactHighlightPen = new Pen(_contactHighlightColor); Invalidate(); }
            get { return _contactHighlightColor; }
        }

        private bool _highlighted;
        public bool highlighted
        {
            set { _highlighted = value; Invalidate(); }
            get { return _highlighted; }
        }

        public enum RTOrientation
        {
            East = 0,
            North,
            West,
            South
        }
        private RTOrientation _orientation;
        public RTOrientation orientation
        {
            set { _orientation = value; Invalidate(); }
            get { return _orientation;  }
        }


        public RTIO():base()
        {
            _title = "IO";
            _titleFont = new Font(FontFamily.GenericSansSerif, 8);
            _titleColor = Color.DimGray;
            _showTitle = true;
            _IOtype = ProcessingIOType.SignalInput;
            _contactColor = Color.DimGray;
            _contactBackColor = Color.Black;
            _contactHighlightColor = Color.Red;
            _orientation = RTOrientation.East;
            _highlighted = false;
            // this.DoubleBuffered = true;

            titleBrush = new SolidBrush(_titleColor);
            contactBackBrush = new SolidBrush(_contactBackColor);
            contactPen = new Pen(_contactColor);
            contactHighlightPen = new Pen(_contactHighlightColor);

            connectedTo = null;
        }

        private Vector getAnchor()
        {
            Rectangle r = getRectangle();
            switch (_orientation)
            {
                case RTOrientation.East:
                    return Vector.V(r.Right, (r.Top + r.Bottom) / 2);
                case RTOrientation.North:
                    return Vector.V((r.Right + r.Left) / 2, r.Top);
                case RTOrientation.West:
                    return Vector.V(r.Left, (r.Top + r.Bottom) / 2);
                case RTOrientation.South:
                    return Vector.V((r.Right + r.Left) / 2, r.Bottom);
            }
            return Vector.V(0, 0);
        }

        public Vector getPos()
        {
            RTForm owr = element;
            if (owr == null) return Vector.V(0, 0);
            return owr.owner.fromScreen(Vector.V(owr.Location) + Vector.V(Location) + getAnchor());
        }

        private int rank = -1;
        private void calcRank()
        {
            if (element != null)
                element.calcIORanks();
        }
        public void setRank(int _rank)
        {
            rank = _rank;
        }

        public void getPosAndDir(ref Vector pos, ref Vector dir, ref VectorRect r, ref int _rank)
        {
            RTForm owr = element;
            if (owr == null)
            {
                pos = Vector.Zero;
                dir = Vector.Zero;
                r = VectorRect.Empty;
                rank = 0;
                return;
            }
            pos = owr.owner.fromScreen(Vector.V(owr.Location) + Vector.V(Location) + getAnchor());
            switch(_orientation)
            {
                case RTOrientation.East: dir = Vector.V(1, 0); break;
                case RTOrientation.North: dir = Vector.V(0, -1); break;
                case RTOrientation.West: dir = Vector.V(-1, 0); break;
                case RTOrientation.South: dir = Vector.V(0, 1); break;
            }
            if (rank < 0)
                calcRank();
            _rank = rank; //  owr.GetIOs().IndexOf(this);
            r = new VectorRect(owr.owner.fromScreen(Vector.V(owr.Location)), owr.owner.fromScreen(Vector.V(owr.Location) + Vector.V(owr.Size)));
        }

        public Rectangle getRectangle()
        {
            switch (_orientation)
            {
                case RTOrientation.East:
                    return Rectangle.FromLTRB(Width - Height, 0, Width - 1, Height - 1);
                case RTOrientation.North:
                    return Rectangle.FromLTRB(0, 0, Width - 1, Width);
                case RTOrientation.West:
                    return Rectangle.FromLTRB(0, 0, Height, Height - 1);
                case RTOrientation.South:
                    return Rectangle.FromLTRB(0, Height - 1 - Width, Width - 1, Height - 1);
            }
            return new Rectangle();
        }

        void drawTo(Graphics g)
        {
            // Contact Point
            Vector center = Vector.V(0, 0);
            Vector textdir = Vector.V(1, 0);
            Vector textpos = Vector.V(1, 0);
            Vector dos = Vector.V(1, 0);
            int alx = 0;int aly = 0;
            int cwidth = 1;
            Rectangle r = getRectangle();
            center = Vector.V(r);
            switch (_orientation)
            {
                case RTOrientation.East:
                    cwidth = Height;
                    dos = Vector.V(1, 0);
                    textdir = Vector.V(1, 0);
                    textpos = Vector.V(Width - cwidth, Height / 2);
                    alx = 1;
                    aly = 0;
                    break;
                case RTOrientation.North:
                    cwidth = Width;
                    dos = Vector.V(0, -1);
                    textdir = Vector.V(0, -1);
                    textpos = Vector.V(Width / 2, cwidth);
                    alx = 1;
                    aly = 0;
                    break;
                case RTOrientation.West:
                    cwidth = Height;
                    dos = Vector.V(-1, 0);
                    textdir = Vector.V(1, 0);
                    textpos = Vector.V(cwidth, Height / 2);
                    alx = -1;
                    aly = 0;
                    break;
                case RTOrientation.South:
                    cwidth = Width;
                    dos = Vector.V(0, 1);
                    textdir = Vector.V(0, -1);
                    textpos = Vector.V(Width / 2, Height - 1 - cwidth);
                    alx = -1;
                    aly = 0;
                    break;
            }
            g.DrawRectangle(contactPen, r);
            switch (_IOtype)
            {
                case ProcessingIOType.SignalInput:
                    GraphicsUtil.drawArrow(g, center + dos * cwidth / 2 * 0.8, center - dos * cwidth / 2 * 0.8,
                        (_highlighted) ? contactHighlightPen : contactPen);
                    break;
                case ProcessingIOType.SignalOutput:
                    GraphicsUtil.drawArrow(g, center - dos * cwidth / 2 * 0.8, center + dos * cwidth / 2 * 0.8,
                        (_highlighted) ? contactHighlightPen : contactPen);
                    break;
                case ProcessingIOType.DataInput:
                    GraphicsUtil.drawDoubleArrow(g, center + dos * cwidth / 2 * 0.8, center - dos * cwidth / 2 * 0.8,
                        (_highlighted) ? contactHighlightPen : contactPen);
                    break;
                case ProcessingIOType.DataOutput:
                    GraphicsUtil.drawDoubleArrow(g, center - dos * cwidth / 2 * 0.8, center + dos * cwidth / 2 * 0.8,
                        (_highlighted) ? contactHighlightPen : contactPen);
                    break;

            }

            // Title
            if (_showTitle && (_title != null) && (_title.Length > 0))
            {
                GraphicsUtil.drawText(g, textpos, _titleFont, scale,
                    _title, 0, 2, alx, aly, textdir, titleBrush);
            }

        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            // base.OnPaint(pe);
            drawTo(pe.Graphics);
        }
        
        private enum DragMode
        {
            Idle=0,
            drawLine
        }
        private DragMode dragMode = DragMode.Idle;

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (dragMode == DragMode.drawLine)
            {
                RTForm el = element;
                Vector from = getPos();
                Vector to = el.owner.fromScreen(Vector.V(el.Location) + Vector.V(Location) + Vector.V(e.Location));
                element.owner.showTemporaryConnection(from, to);
            } else 
                forwardOnMouseMove(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            if (dragMode == DragMode.drawLine)
            {
                _highlighted = false;
                Invalidate();

                dragMode = DragMode.Idle;
                RTForm el = element;
                el.owner.hideTemporaryConnection();
                Vector to = el.owner.fromScreen(Vector.V(el.Location) + Vector.V(Location) + Vector.V(e.Location));
                RTIO ioto = el.owner.findIO(to);
                if (ioto != null)
                    el.owner.createConnection(this, ioto);
            } else
                forwardOnMouseUp(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            Rectangle r = getRectangle();
            if (r.Contains(e.Location))
            {
                Parent.BringToFront();

                // Draw a new Connection
                RTForm em = element;
                if ((em != null) && (em.owner != null))
                {
                    _highlighted = true;
                    Invalidate();

                    dragMode = DragMode.drawLine;   
                }
            }
            else
                forwardOnMouseDown(e);
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(e);
            forwardOnMouseWheel(e);
        }

        public bool hits(Vector v)
        {
            Rectangle r = getRectangle();
            v -= Vector.V(Location);
            if (r.Contains(v.Point))
                return true;
            return false;
        }

    }
}

