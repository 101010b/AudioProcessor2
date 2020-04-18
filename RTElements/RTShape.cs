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
    public partial class RTShape : RTControl
    {

        private String _title;
        public string title
        {
            set { _title = value; Invalidate(); }
            get { return _title; }
        }

        public enum RTTitlePos
        {
            Off = 0,
            TopLeft,
            TopCenter,
            TopRight,
            BottomLeft,
            BottomCenter,
            BottomRight
        }
        private RTTitlePos _titlePos;
        public RTTitlePos titlePos
        {
            set { _titlePos = value; Invalidate(); }
            get { return _titlePos; }
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

        private Size _shapeDim;
        public Size shapeDim
        {
            set { _shapeDim = value; reGrid(); Invalidate(); }
            get { return _shapeDim; }
        }

        private Color _frameColor;
        public Color frameColor
        {
            set { _frameColor = value; Invalidate(); }
            get { return _frameColor; }
        }

        private Color _shapeColor;
        public Color shapeColor
        {
            set { _shapeColor = value; Invalidate(); }
            get { return _shapeColor; }
        }

        private Color _anchorColor;
        public Color anchorColor
        {
            set { _anchorColor = value; Invalidate(); }
            get { return _anchorColor; }
        }

        private int _anchorSize;
        public int anchorSize
        {
            set { _anchorSize = value; Invalidate(); }
            get { return _anchorSize; }
        }

        private double _attack;
        public double attack
        {
            set { _attack = value; reGrid(); Invalidate(); }
            get { return _attack; }
        }

        private double _attackMin;
        public double attackMin
        {
            set { _attackMin = value; reGrid(); Invalidate(); }
            get { return _attackMin; }
        }

        private double _attackMax;
        public double attackMax
        {
            set { _attackMax = value; Invalidate(); }
            get { return _attackMax; }
        }

        private double _attackLevel;
        public double attackLevel
        {
            set { _attackLevel = value; reGrid(); Invalidate(); }
            get { return _attackLevel; }
        }

        private double _attackLevelMin;
        public double attackLevelMin
        {
            set { _attackLevelMin = value; Invalidate(); }
            get { return _attackLevelMin; }
        }

        private double _attackLevelMax;
        public double attackLevelMax
        {
            set { _attackLevelMax = value; Invalidate(); }
            get { return _attackLevelMax; }
        }

        private double _decay;
        public double decay
        {
            set { _decay = value; reGrid(); Invalidate(); }
            get { return _decay; }
        }

        private double _decayMin;
        public double decayMin
        {
            set { _decayMin = value; Invalidate(); }
            get { return _decayMin; }
        }

        private double _decayMax;
        public double decayMax
        {
            set { _decayMax = value; Invalidate(); }
            get { return _decayMax; }
        }

        private double _hold;
        public double hold
        {
            set { _hold = value; reGrid(); Invalidate(); }
            get { return _hold; }
        }

        private double _holdMin;
        public double holdMin
        {
            set { _holdMin = value; reGrid(); Invalidate(); }
            get { return _holdMin; }
        }

        private double _holdMax;
        public double holdMax
        {
            set { _holdMax = value; reGrid(); Invalidate(); }
            get { return _holdMax; }
        }

        private double _holdLevel;
        public double holdLevel
        {
            set { _holdLevel = value; reGrid(); Invalidate(); }
            get { return _holdLevel; }
        }

        private double _holdLevelMin;
        public double holdLevelMin
        {
            set { _holdLevelMin = value; Invalidate(); }
            get { return _holdLevelMin; }
        }

        private double _holdLevelMax;
        public double holdLevelMax
        {
            set { _holdLevelMax = value; Invalidate(); }
            get { return _holdLevelMax; }
        }

        private bool _holdFix;
        public bool holdFix
        {
            set { _holdFix = value; reGrid(); Invalidate(); }
            get { return _holdFix; }
        }

        private double _fade;
        public double fade
        {
            set { _fade = value; reGrid(); Invalidate(); }
            get { return _fade; }
        }

        private double _fadeMin;
        public double fadeMin
        {
            set { _fadeMin = value; Invalidate(); }
            get { return _fadeMin; }
        }

        private double _fadeMax;
        public double fadeMax
        {
            set { _fadeMax = value; Invalidate(); }
            get { return _fadeMax; }
        }

        private bool _showYScale;
        public bool showYScale
        {
            set { _showYScale = value; Invalidate(); }
            get { return _showYScale; }
        }

        private bool _showXScale;
        public bool showXScale
        {
            set { _showXScale = value; Invalidate(); }
            get { return _showXScale; }
        }
        private Color _majorGridColor;
        public Color majorGridColor
        {
            set { _majorGridColor = value;Invalidate(); }
            get { return _majorGridColor; }
        }

        private Color _minorGridColor;
        public Color minorGridColor
        {
            set { _minorGridColor = value;Invalidate(); }
            get { return _minorGridColor; }
        }

        private bool _showMajorYGrid;
        public bool showMajorYGrid
        {
            set { _showMajorYGrid = value; Invalidate(); }
            get { return _showMajorYGrid; }
        }
        private bool _showMinorYGrid;
        public bool showMinorYGrid
        {
            set { _showMajorYGrid = value; Invalidate(); }
            get { return _showMinorYGrid; }
        }
        private bool _showMajorXGrid;
        public bool showMajorXGrid
        {
            set { _showMajorXGrid = value; Invalidate(); }
            get { return _showMajorXGrid; }
        }
        private bool _showMinorXGrid;
        public bool showMinorXGrid
        {
            set { _showMinorXGrid = value; Invalidate(); }
            get { return _showMinorXGrid; }
        }

        private Color _scaleColor;
        public Color scaleColor
        {
            set { _scaleColor = value; Invalidate(); }
            get { return _scaleColor; }
        }

        private Font _scaleFont;
        public Font scaleFont
        {
            set { _scaleFont = value; reGrid(); Invalidate(); }
            get { return _scaleFont; }
        }



        public event EventHandler shapeStateChanged;

        public RTShape()
        {
            _title = "Shape";
            _titlePos = RTTitlePos.TopLeft;
            _titleColor = Color.DimGray;
            _titleFont = new Font(FontFamily.GenericSansSerif, 8);
            _shapeDim = new Size(30, 15);
            _frameColor = Color.DimGray;
            _shapeColor = Color.White;
            _anchorColor = Color.RoyalBlue;
            _anchorSize = 6;

            _attack = 1;
            _attackMin = 0.01;
            _attackMax = 100;

            _attackLevel = 1;
            _attackLevelMin = 0;
            _attackLevelMax = 10;

            _decay = 10;
            _decayMin = 0.01;
            _decayMax = 1000;

            _hold = 100;
            _holdMin = 1;
            _holdMax = 1000;
            _holdFix = false;

            _holdLevel = 0.5;
            _holdLevelMin = 0;
            _holdLevelMax = 10;

            _fade = 100;
            _fadeMin = 1;
            _fadeMax = 1000;

            _showYScale = false;
            _showXScale = false;
            _scaleColor = Color.DimGray;
            _scaleFont = new Font(FontFamily.GenericSansSerif, 8);

            _majorGridColor = Color.FromArgb(64, 64, 64);
            _minorGridColor = Color.FromArgb(32, 32, 32);
            _showMajorYGrid = true;
            _showMinorYGrid = true;
            _showMajorXGrid = true;
            _showMinorXGrid = true;

            reGrid();

            this.DoubleBuffered = true;
        }

        private GridCalculator gridX, gridY;

        private void reGrid()
        {
            double xmin = _attackMin;
            double xmax = _attackMin + _attack + _decay + ((_holdFix) ? Math.Sqrt(_holdMin * _holdMax) : _hold) + _fade;
            double ymin = min(0, _attackLevel, _holdLevel);
            double ymax = max(0, _attackLevel, _holdLevel);
            if (ymax == ymin)
            {
                ymin = -0.1;
                ymax = 0.1;
            }
            double yext = max(_attackLevelMax, _holdLevelMax) - min(_attackLevelMin, _holdLevelMin);
            double dy = ymax - ymin;
            ymin -= dy * 0.1;
            ymax += dy * 0.1;
            ymin = Math.Floor(ymin * 10) / 10;
            ymax = Math.Ceiling(ymax * 10) / 10;
            double fontheight = _scaleFont.GetHeight();
            if (gridX == null)
                gridX = new GridCalculator(0, 1, 1, _attackMin, 0.1, xmin, xmax, true, 0, _shapeDim.Width, fontheight);
            else
                gridX.reStructure(xmin, xmax, 0, _shapeDim.Width);
            if (gridY == null)
                gridY = new GridCalculator(_attackLevelMin, _attackLevelMax, yext / 20, 1, 10, ymin, ymax, false, 0, _shapeDim.Height, fontheight);
            else
                gridY.reStructure(ymin, ymax, 0, _shapeDim.Height);
        }

        public class ShapeStateChangedEventArgs : EventArgs
        {
            public double attack { get; set; }
            public double attackLevel { get; set; }
            public double decay { get; set; }
            public double hold { get; set; }
            public double holdLevel { get; set; }
            public bool holdFix { get; set; }
            public double fade { get; set; }
        }

        public delegate void ShapeStateChangedEventHandler(object sender, ShapeStateChangedEventArgs e);

        void newValue()
        {
            EventHandler handler = shapeStateChanged;
            ShapeStateChangedEventArgs e = new ShapeStateChangedEventArgs();
            e.attack = _attack;
            e.attackLevel = _attackLevel;
            e.decay = _decay;
            e.hold = _hold;
            e.holdLevel = _holdLevel;
            e.holdFix = _holdFix;
            e.fade = _fade;

            handler?.Invoke(this, e);
        }

        Rectangle getShapeRect()
        {
            double atop, abottom, aleft, aright;
            atop = Height/2 - _shapeDim.Height * scale / 2;
            abottom = atop + _shapeDim.Height * scale - 1;
            double textheight = _titleFont.GetHeight() * scale * 1.1;
            double scaleHeight = _scaleFont.GetHeight() * scale * 1.1;
            switch (_titlePos)
            {
                case RTTitlePos.Off:
                    if (_showXScale)
                    {
                        if (_showYScale)
                            atop = scaleHeight / 2;
                        else
                            atop = 0;
                        abottom = atop + _shapeDim.Height*scale - 1;
                    } else
                    {
                        atop = Height / 2 - _shapeDim.Height * scale / 2;
                        abottom = atop + _shapeDim.Height * scale - 1;
                    }
                    break;
                case RTTitlePos.TopLeft:
                case RTTitlePos.TopCenter:
                case RTTitlePos.TopRight:
                    atop = textheight;
                    abottom = atop + _shapeDim.Height * scale - 1;
                    break;
                case RTTitlePos.BottomLeft:
                case RTTitlePos.BottomCenter:
                case RTTitlePos.BottomRight:
                    if (_showYScale)
                        atop = scaleHeight / 2;
                    else
                        atop = 0;
                    abottom = atop + _shapeDim.Height * scale - 1;
                    break;
            }
            if (_showYScale)
            {
                if (_showXScale)
                    aright = Width - 1 - scaleHeight / 2;
                else
                    aright = Width - 1;
                aleft = aright - (_shapeDim.Width * scale + 1);
            } else
            {
                aleft = Width / 2 - _shapeDim.Width * scale / 2;
                aright = aleft + _shapeDim.Width * scale - 1;
            }
            //aleft = Width / 2 - _shapeDim.Width * scale / 2;
            //aright = aleft + _shapeDim.Width * scale - 1;
            return VectorRect.FromTwoPoints(aleft,atop,aright,abottom).rectangle;
        }

        void getShapeCoords(ref Rectangle r, ref GraphicsUtil.TextPosition textpos)
        {
            r = getShapeRect();
            Vector tl = Vector.V(r.Location);
            Vector tr = Vector.V(r.Location.X + r.Width - 1, r.Location.Y + r.Height - 1);
            switch (_titlePos)
            {
                case RTTitlePos.TopLeft:
                    textpos = new GraphicsUtil.TextPosition(tl, scale, -1, -1);
                    break;
                case RTTitlePos.TopCenter:
                    textpos = new GraphicsUtil.TextPosition(Vector.V((tl.x+tr.x)/2, tl.y), scale, 0, -1);
                    break;
                case RTTitlePos.TopRight:
                    textpos = new GraphicsUtil.TextPosition(Vector.V(tr.x, tl.y), scale, 1, -1);
                    break;
                case RTTitlePos.BottomLeft:
                    if (_showXScale)
                        textpos = new GraphicsUtil.TextPosition(Vector.V(tl.x, Height-1), scale, -1, -1);
                    else
                        textpos = new GraphicsUtil.TextPosition(Vector.V(tl.x, tr.y), scale, -1, 1);
                    break;
                case RTTitlePos.BottomCenter:
                    if (_showXScale)
                        textpos = new GraphicsUtil.TextPosition(Vector.V((tl.x + tr.x) / 2, Height-1), scale, 0, -1);
                    else
                        textpos = new GraphicsUtil.TextPosition(Vector.V((tl.x + tr.x) / 2, tr.y), scale, 0, 1);
                    break;
                case RTTitlePos.BottomRight:
                    if (_showXScale)
                        textpos = new GraphicsUtil.TextPosition(Vector.V(tr.x,Height-1), scale, 1, -1);
                    else
                        textpos = new GraphicsUtil.TextPosition(tr, scale, 1, -1);
                    break;
            }
        }

        private double min(double a, double b) { return (a < b) ? a : b; }
        private double max(double a, double b) { return (a > b) ? a : b; }
        private double min(double a, double b, double c) { double abmin = min(a, b); return (abmin < c) ? abmin : c; }
        private double max(double a, double b, double c) { double abmax = max(a, b); return (abmax > c) ? abmax : c; }
        private double min(double a, double b, double c, double d) { return min(min(a, b), min(c, d)); }
        private double max(double a, double b, double c, double d) { return max(max(a, b), max(c, d)); }

        Vector[] getShape(Rectangle shape, ref double ymin, ref double ymax)
        {
            int w = shape.Width;
            int h = shape.Height;
            double t;
            double __hold = _hold;
            if (_holdFix)
                __hold = Math.Sqrt(_holdMax * _holdMin);
            if (gridY == null) reGrid();
            ymin = gridY.min;
            ymax = gridY.max;


            Vector[] l = new Vector[5];
            double x = 0;
            l[0] = Vector.V(x, 0);
            x += _attack;
            l[1] = Vector.V(x, _attackLevel);
            x += _decay;
            l[2] = Vector.V(x, _holdLevel);
            x += __hold;
            l[3] = Vector.V(x, _holdLevel);
            x += _fade;
            l[4] = Vector.V(x, 0);
            for (int i = 0; i < 5; i++)
            {
                l[i].y = (h - 1) - (h - 1.0) * (l[i].y - ymin) / (ymax - ymin) + shape.Y;
                l[i].x = (w-1)*
                    (Math.Log10(l[i].x + _attackMin) - Math.Log10(_attackMin))/
                    (Math.Log10(x      + _attackMin) - Math.Log10(_attackMin)) + shape.X;
            }
            return l;
        }

        Vector[] getShape(Rectangle shape)
        {
            double ymin = 0, ymax = 0;
            return getShape(shape, ref ymin, ref ymax);
        }

        void drawTo(Graphics g)
        {
            // Background
            //Brush brushBackground = new SolidBrush(BackColor);
            //g.FillRectangle(brushBackground, this.ClientRectangle);

            Rectangle shape = new Rectangle();
            GraphicsUtil.TextPosition tp = new GraphicsUtil.TextPosition();
            getShapeCoords(ref shape, ref tp);

            if ((_titlePos != RTTitlePos.Off) && (_title != null) && (_title.Length > 0))
            {
                Brush titleBrush = new SolidBrush(_titleColor);
                tp.drawText(g, _titleFont, titleBrush, _title);
            }

            Pen framePen = new Pen(_frameColor);
            Rectangle oshape = shape;
            shape.Inflate(-1, -1);

            double ymin = 0, ymax = 0;
            Vector[] l = getShape(shape, ref ymin, ref ymax);

            Brush scaleBrush = new SolidBrush(_scaleColor);
            Pen majorGridPen = new Pen(_majorGridColor);
            Pen minorGridPen = new Pen(_minorGridColor);
            for (int i = 0;i<gridY.gridLength;i++)
            {
                double y = shape.Bottom - gridY.grid[i].screen;
                string s = gridY.grid[i].name;
                if (gridY.grid[i].isMajor && _showYScale)
                    GraphicsUtil.drawText(g, Vector.V(shape.Left, y), _scaleFont, scale, s, 0, 2, 1, 0, Vector.X, scaleBrush);
                if (gridY.grid[i].isMajor && _showMajorYGrid)
                    GraphicsUtil.drawLine(g, Vector.V(shape.Left, y), Vector.V(shape.Right, y), majorGridPen);
                if (!gridY.grid[i].isMajor && _showMinorYGrid)
                    GraphicsUtil.drawLine(g, Vector.V(shape.Left, y), Vector.V(shape.Right, y), minorGridPen);
            }
            for (int i = 0; i < gridX.gridLength; i++)
            {
                double x = shape.Left + gridX.grid[i].screen;
                string s = gridX.grid[i].name;
                if (gridX.grid[i].isMajor && showXScale)
                    GraphicsUtil.drawText(g, Vector.V(x, shape.Bottom), _scaleFont, scale, s, 0, 2, -1, 0, Vector.Y, scaleBrush);
                if (gridX.grid[i].isMajor && _showMajorXGrid)
                    GraphicsUtil.drawLine(g, Vector.V(x, shape.Bottom), Vector.V(x, shape.Top), majorGridPen);
                if (!gridX.grid[i].isMajor && _showMinorXGrid)
                    GraphicsUtil.drawLine(g, Vector.V(x, shape.Bottom), Vector.V(x, shape.Top), minorGridPen);
            }

            g.DrawRectangle(framePen, oshape);

            Pen anchorPen = new Pen(_anchorColor);
            Brush selBrush = null;
            if (dragMode == DragMode.Holding)
                selBrush = new SolidBrush(Color.Red);
            Point[] p = new Point[l.Length];
            g.SetClip(shape);
            for (int i=0;i<l.Length;i++)
            {
                p[i] = l[i].Point;
                if (i > 0)
                {
                    Rectangle A = new Rectangle(p[i].X - _anchorSize / 2, p[i].Y - _anchorSize / 2, _anchorSize, _anchorSize);
                    if ((dragMode == DragMode.Holding) && (dragSelect == i))
                        g.FillRectangle(selBrush, A);
                    else
                        g.DrawRectangle(anchorPen, A);
                }
            }
            Pen shapePen = new Pen(_shapeColor);
            g.DrawLines(shapePen, p);            

        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            // base.OnPaint(pe);
            drawTo(pe.Graphics);
        }

        public enum DragMode
        {
            Idle = 0,
            Holding
        }

        private DragMode dragMode;
        private int dragSelect;
        private Vector dragStart;
        private double attackStore;
        private double attackLevelStore;
        private double decayStore;
        private double holdStore;
        private double holdLevelStore;
        private double fadeStore;

        private void processMouseDragPos(Vector mouseloc)
        {
            Vector delta = mouseloc - dragStart;
            delta.y = -delta.y;
            switch (dragSelect)
            {
                case 1: // Attack
                    double ax = Math.Pow(10, Math.Log10(attackStore) + delta.x / 100);
                    if (ax < _attackMin) ax = _attackMin;
                    if (ax > _attackMax) ax = _attackMax;
                    double al = attackLevelStore + delta.y * (_attackLevelMax - _attackLevelMin) / 1000;
                    if (al < _attackLevelMin) al = _attackLevelMin;
                    if (al > _attackLevelMax) al = _attackLevelMax;
                    _attack = ax;
                    _attackLevel = al;
                    reGrid();
                    Invalidate();
                    newValue();
                    break;
                case 2: // Decay
                    double dx = Math.Pow(10, Math.Log10(decayStore) + delta.x / 100);
                    if (dx < _decayMin) dx = _decayMin;
                    if (dx > _decayMax) dx = _decayMax;
                    double dl = holdLevelStore + delta.y * (_holdLevelMax - _holdLevelMin) / 1000;
                    if (dl < _holdLevelMin) dl = _holdLevelMin;
                    if (dl > _holdLevelMax) dl = _holdLevelMax;
                    _decay = dx;
                    _holdLevel = dl;
                    reGrid();
                    Invalidate();
                    newValue();
                    break;
                case 3: // Hold/Sustain
                    if (!holdFix)
                    {
                        double hx = Math.Pow(10, Math.Log10(holdStore) + delta.x / 100);
                        if (hx < _holdMin) hx = _holdMin;
                        if (hx > _holdMax) hx = _holdMax;
                        _hold = hx;
                    }
                    double hl = holdLevelStore + delta.y * (_holdLevelMax - _holdLevelMin) / 1000;
                    if (hl < _holdLevelMin) hl = _holdLevelMin;
                    if (hl > _holdLevelMax) hl = _holdLevelMax;
                    _holdLevel = hl;
                    reGrid();
                    Invalidate();
                    newValue();
                    break;
                case 4: // fade
                    double fx = Math.Pow(10, Math.Log10(fadeStore) + delta.x / 100);
                    if (fx < _fadeMin) fx = _fadeMin;
                    if (fx > _fadeMax) fx = _fadeMax;
                    _fade = fx;
                    reGrid();
                    Invalidate();
                    newValue();
                    break;
            }

        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (dragMode == DragMode.Holding)
            {
                processMouseDragPos(Vector.V(e.Location));
            }
            else
                forwardOnMouseMove(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            if (dragMode == DragMode.Holding)
            {
                processMouseDragPos(Vector.V(e.Location));
                dragMode = DragMode.Idle;
                Invalidate();
            }
            else
                forwardOnMouseUp(e);
        }
        

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            Rectangle r = getShapeRect();
            if (r.Contains(e.Location))
            {
                Vector m = Vector.V(e.Location);
                Vector[] l = getShape(r);
                int found = -1;
                for (int i=1;i<l.Length;i++)
                {
                    if ((m - l[i]).Len < 5)
                        found = i;
                }
                if (found >= 0)
                {
                    dragMode = DragMode.Holding;
                    dragSelect = found;
                    dragStart = m;
                    attackStore = _attack;
                    attackLevelStore = _attackLevel;
                    decayStore = _decay;
                    holdStore = _hold;
                    holdLevelStore = _holdLevel;
                    fadeStore = _fade;
                    Invalidate();
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



    }
}
