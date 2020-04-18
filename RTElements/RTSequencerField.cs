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
    public partial class RTSequencerField : RTControl
    {

        private Color _frameColor;
        public Color frameColor
        {
            set { _frameColor = value; Invalidate(); }
            get { return _frameColor; }
        }

        private Color _fillOnColor;
        public Color fillOnColor
        {
            set { _fillOnColor = value; Invalidate(); }
            get { return _fillOnColor; }
        }

        private Color _fillOffColor;
        public Color fillOffColor
        {
            set { _fillOffColor = value; Invalidate(); }
            get { return _fillOffColor; }
        }

        private int _columns;
        public int columns
        {
            set { rescaleArray(_rows,value); Invalidate(); }
            get { return _columns; }
        }

        private int _rows;
        public int rows
        {
            set { rescaleArray(value, _columns); Invalidate(); }
            get { return _rows; }
        }

        private int _takt;
        public int takt
        {
            set { _takt = value; Invalidate(); }
            get { return _takt; }
        }

        private Font _colHeadFont;
        public Font colHeadFont
        {
            set { _colHeadFont = value; Invalidate(); }
            get { return _colHeadFont; }
        }

        private Color _colHeadColor;
        public Color colHeadColor
        {
            set { _colHeadColor = value; Invalidate(); }
            get { return _colHeadColor; }
        }

        private int _colHeadHeight;
        public int colHeadHeight
        {
            set { _colHeadHeight = value; Invalidate(); }
            get { return _colHeadHeight; }
        }

        private Font _rowHeadFont;
        public Font rowHeadFont
        {
            set { _rowHeadFont = value; Invalidate(); }
            get { return _rowHeadFont; }
        }

        private Color _rowHeadColor;
        public Color rowHeadColor
        {
            set { _rowHeadColor = value; Invalidate(); }
            get { return _rowHeadColor; }
        }

        private int _rowHeadWidth;
        public int rowHeadWidth
        {
            set { _rowHeadWidth = value; Invalidate(); }
            get { return _rowHeadWidth; }
        }

        private bool _showColHeads;
        public bool showColHeads
        {
            set { _showColHeads = value; Invalidate(); }
            get { return _showColHeads; }
        }

        private bool _showRowHeads;
        public bool showRowHeads
        {
            set { _showRowHeads = value; Invalidate(); }
            get { return _showRowHeads; }
        }

        private Color _highLightColor;
        public Color highLightColor
        {
            set { _highLightColor = value; Invalidate(); }
            get { return _highLightColor; }
        }

        private int _hlCol;
        public int hlCol
        {
            set { if (_hlCol != value) { _hlCol = value; Invalidate(); } }
            get { return _hlCol; }
        }

        private Color _selectColor;
        public Color selectColor
        {
            set { _selectColor = value; Invalidate(); }
            get { return _selectColor; }
        }

        private double[,] _data;

        public event EventHandler sequencerStateChanged;

        public RTSequencerField()
        {
            _frameColor = Color.DarkBlue;
            _fillOnColor = Color.Green;
            _fillOffColor = Color.Black;
            _columns = 16;
            _rows = 12;
            _takt = 4;
            _colHeadFont = new Font(FontFamily.GenericSansSerif, 8);
            _colHeadColor = Color.DarkGray;
            _colHeadHeight = 16;
            _rowHeadFont = new Font(FontFamily.GenericSansSerif, 8);
            _rowHeadColor = Color.DarkGray;
            _rowHeadWidth = 30;
            _showColHeads = true;
            _showRowHeads = false;
            _hlCol = -1;
            _highLightColor = Color.DarkRed;
            _selectColor = Color.Aqua;

            _data = new double[_rows, columns];

            this.DoubleBuffered = true;
        }

        private void rescaleArray(int __rows, int __columns)
        {
            if ((__rows == _rows) && (__columns == _columns)) return;
            if (__rows < 1) return;
            if (__columns < 1) return;
            double[,] old = _data;
            int oldrows = _rows;
            int oldcols = _columns;
            _rows = __rows;
            _columns = __columns;
            _data = new double[_rows, _columns];
            for (int r = 0; (r < _rows) && (r < oldrows); r++)
                for (int c = 0; (c < _columns) && (c < oldcols); c++)
                    _data[r, c] = old[r, c];
        }

        private void setData(double[,] din)
        {
            int irows = din.GetLength(0);
            int icols = din.GetLength(1);
            for (int r = 0; (r < _rows) && (r < irows); r++)
                for (int c = 0; (c < _columns) && (c < icols); c++)
                    _data[r, c] = din[r, c];
        }

        private double[,] getData()
        {
            return (double[,]) _data.Clone();
        }

        public double[,] data
        {
            set { setData(value);Invalidate(); }
            get { return getData(); }
        }

        public class SequencerStateChangedEventArgs : EventArgs
        {
        }

        public delegate void SequencerStateChangedEventHandler(object sender, SequencerStateChangedEventArgs e);
        
        void newState()
        {
            EventHandler handler = sequencerStateChanged;
            SequencerStateChangedEventArgs e = new SequencerStateChangedEventArgs();
            handler?.Invoke(this, e);
        }

        private void getSequencerGeometry(ref Rectangle seq)
        {
            seq = ClientRectangle;
            if (showColHeads)
            {
                seq.Height -= colHeadHeight;
                seq.Y += colHeadHeight;
            }
            if (showRowHeads)
            {
                seq.Width -= rowHeadWidth;
                seq.X += rowHeadWidth;
            }
            seq.Width -= 1;
            seq.Height -= 1;
        }

        string notename(int n)
        {
            n = (n-69+144) % 12;
            switch (n)
            {
                case 0: return "a";
                case 1: return "a#";
                case 2: return "h";
                case 3: return "c";
                case 4: return "c#";
                case 5: return "d";
                case 6: return "d#";
                case 7: return "e";
                case 8: return "f";
                case 9: return "f#";
                case 10: return "g";
                case 11: return "g#";
            }
            return "";
        }

        void drawTo(Graphics g)
        {
            // Background
            // Brush brushBackground = new SolidBrush(BackColor);
            // g.FillRectangle(brushBackground, this.ClientRectangle);
            Rectangle seq = this.ClientRectangle;
            Pen framePen = new Pen(frameColor);
            getSequencerGeometry(ref seq);
            g.DrawRectangle(framePen, seq);
            if (_hlCol >= 0)
            {
                int x1 = seq.X + _hlCol * seq.Width / _columns;
                int x2 = seq.X + (_hlCol+1) * seq.Width / _columns;
                Rectangle hl = new Rectangle(x1, seq.Y, x2-x1-1, seq.Height);
                Brush hb = new SolidBrush(_highLightColor);
                g.FillRectangle(hb, hl);
            }
            if ((dragMode == DragMode.Holding) && (dragcol >= 0) && (dragcol >= 0))
            {
                int x1 = seq.X + dragcol * seq.Width / _columns;
                int x2 = seq.X + (dragcol + 1) * seq.Width / _columns;
                int y1 = seq.Y + (_rows - 1 - (dragrow + 1)) * seq.Height / _rows;
                int y2 = seq.Y + (_rows - 1 - dragrow) * seq.Height / _rows;
                Brush hs = new SolidBrush(_selectColor);
                g.FillRectangle(hs, new Rectangle(x1, 0, x2-x1+1, seq.Y-1));
                g.FillRectangle(hs, new Rectangle(0, y2, seq.X-1, y2-y1+1));
            }

            if (_showColHeads)
            {
                Brush colheadbrush = new SolidBrush(_colHeadColor);
                for (int c = 0; c < _columns; c++)
                {
                    Vector tp = new Vector(seq.X + (double)seq.Width / _columns * (c + 0.5), seq.Y);
                    GraphicsUtil.drawText(g, tp, _colHeadFont, scale, string.Format("{0}", (c % _takt) + 1), 0, 2, 0, -1, Vector.X, colheadbrush);
                }
            }
            if (_showRowHeads)
            {
                Brush rowheadbrush = new SolidBrush(_rowHeadColor);
                for (int r = 0; r < _rows; r++)
                {
                    Vector tp = new Vector(seq.X,seq.Y + (double)seq.Height / _rows * (r + 0.5));
                    GraphicsUtil.drawText(g, tp, _rowHeadFont, scale, notename(_rows - r), 0, 2, 1, 0, Vector.X, rowheadbrush);
                }
            }
            for (int c = 1;c<_columns;c++)
            {
                int cx = seq.X + seq.Width * c / _columns;
                g.DrawLine(framePen, cx, seq.Y, cx, seq.Y + seq.Height - 1);
            }
            for (int r = 1; r < _rows; r++)
            {
                int cy = seq.Y + seq.Height * r / _rows;
                g.DrawLine(framePen, seq.X, cy, seq.X+seq.Width-1, cy);
            }
            Brush fb = new SolidBrush(fillOnColor);
            for (int r = 0;r < _rows;r++)
                for (int c=0;c < _columns;c++)
                {
                    if (_data[r,c] > 0)
                    {
                        Vector ctr = Vector.V(seq.X + (c + 0.5) * seq.Width / _columns, seq.Y + (_rows - 1 - r + 0.5) * seq.Height / _rows);
                        // ((SolidBrush)fb).Color = fillOnColor;
                        GraphicsUtil.fillCircle(g,ctr, (double)seq.Width/_columns/3, fb);
                    }
                }
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
        int dragrow, dragcol;

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (dragMode == DragMode.Holding)
            {
                Rectangle seq = new Rectangle();
                getSequencerGeometry(ref seq);
                if (seq.Contains(e.Location))
                {
                    int _dragcol = (e.Location.X - seq.X) * _columns / seq.Width;
                    if (_dragcol < 0) _dragcol = 0;
                    if (_dragcol >= _columns) _dragcol = _columns - 1;
                    int _dragrow = (e.Location.Y - seq.Y) * _rows / seq.Height;
                    if (_dragrow < 0) _dragrow = 0;
                    if (_dragrow >= _rows) _dragrow = _rows - 1;
                    _dragrow = _rows - 1 - _dragrow;
                    if ((_dragcol != dragcol) || (_dragrow != dragrow))
                    {
                        dragcol = _dragcol;
                        dragrow = _dragrow;
                        Invalidate();
                    }
                } else
                {
                    if ((dragrow >= 0) && (dragcol >= 0))
                    {
                        dragrow = dragcol = -1;
                        Invalidate();
                    }
                }
            }
            else
                forwardOnMouseMove(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            if (dragMode == DragMode.Holding)
            {
                dragMode = DragMode.Idle;
                Rectangle seq = new Rectangle();
                getSequencerGeometry(ref seq);
                if (seq.Contains(e.Location))
                {
                    dragcol = (e.Location.X - seq.X) * _columns / seq.Width;
                    if (dragcol < 0) dragcol = 0;
                    if (dragcol >= _columns) dragcol = _columns - 1;
                    dragrow = (e.Location.Y - seq.Y) * _rows / seq.Height;
                    if (dragrow < 0) dragrow = 0;
                    if (dragrow >= _rows) dragrow = _rows - 1;
                    dragrow = _rows - 1 - dragrow;
                    if (_data[dragrow, dragcol] > 0)
                        _data[dragrow, dragcol] = 0;
                    else
                        _data[dragrow, dragcol] = 1;
                    Invalidate();
                    newState();
                }
            }
            else
                forwardOnMouseUp(e);
        }
        
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            Rectangle seq = new Rectangle();
            getSequencerGeometry(ref seq);
            if (seq.Contains(e.Location))
            {
                dragMode = DragMode.Holding;
                dragcol = (e.Location.X-seq.X) * _columns / seq.Width;
                if (dragcol < 0) dragcol = 0;
                if (dragcol >= _columns) dragcol = _columns-1;
                dragrow = (e.Location.Y-seq.Y) * _rows / seq.Height;
                if (dragrow < 0) dragrow = 0;
                if (dragrow >= _rows) dragrow = _rows - 1;
                dragrow = _rows-1-dragrow;
                Invalidate();
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
