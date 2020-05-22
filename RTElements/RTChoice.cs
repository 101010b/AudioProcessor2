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

    public partial class RTChoice : RTControl
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

        private Font _valueFont;
        public Font valueFont
        {
            set { _valueFont = value; Invalidate(); }
            get { return _valueFont; }
        }

        private int _xdim;
        public int xdim
        {
            set { _xdim = value; Invalidate(); }
            get { return _xdim; }
        }

        private Color _frontColor;
        private Pen frontPen;
        private Brush frontBrush;
        public Color frontColor
        {
            set { _frontColor = value;
                frontPen = new Pen(_frontColor);
                frontBrush = new SolidBrush(_frontColor);
                Invalidate(); }
            get { return _frontColor; }
        }

        private Color _backColor;
        private Brush backBrush;
        public Color backColor
        {
            set { _backColor = value; backBrush = new SolidBrush(_backColor); Invalidate(); }
            get { return _backColor; }
        }

        public enum ChoiceType
        {
            ListDefined,
            Numeric,
            NumericOff
        };
        private ChoiceType _choiceType;
        public ChoiceType choiceType
        {
            set { _choiceType = value; Invalidate(); }
            get { return _choiceType; }
        }
        private string _offString;
        public string offString
        {
            set { _offString = value; Invalidate(); }
            get { return _offString; }
        }

        private int _numericMin;
        public int numericMin
        {
            set { _numericMin = value; Invalidate(); }
            get { return _numericMin; }
        }

        private int _numericMax;
        public int numericMax
        {
            set { _numericMax = value; Invalidate(); }
            get { return _numericMax; }
        }

        private List<RTDrawable> _entries;
        public void setEntries(List<RTDrawable> entries)
        {
            _entries = entries;
            if (_selectedItem >= entries.Count())
                _selectedItem = -1;
            Invalidate();
        }

        private int _selectedItem;
        public int selectedItem
        {
            set
            {
                switch (_choiceType)
                {
                    case ChoiceType.ListDefined:
                        if ((_entries == null) || (_entries.Count == 0))
                        {
                            _selectedItem = -1;
                        }
                        else
                        {
                            if ((value < 0) || (value >= _entries.Count))
                                _selectedItem = -1;
                            else
                                _selectedItem = value;
                        }
                        break;
                    case ChoiceType.Numeric:
                        if (_numericMax < _numericMin)
                            _selectedItem = -1;
                        else
                        {
                            if (value < 0)
                                _selectedItem = _numericMin;
                            else if (value > (_numericMax - _numericMin))
                                _selectedItem = _numericMax;
                            else
                                _selectedItem = value;
                        }
                        break;
                    case ChoiceType.NumericOff:
                        if (_numericMax < _numericMin)
                            _selectedItem = -1;
                        else
                        {
                            if (value < -1)
                                _selectedItem = -1;
                            else if (value > (_numericMax - _numericMin))
                                _selectedItem = _numericMax;
                            else
                                _selectedItem = value;
                        }
                        break;
                }
                Invalidate();
            }
            get { return _selectedItem; }
        }

        public RTChoice()
        {
            _title = "Choice";
            _titleColor = Color.DimGray;
            _titleFont = new Font(FontFamily.GenericSansSerif, 8);
            _valueFont = new Font(FontFamily.GenericSansSerif, 8);
            _xdim = 50;
            _selectedItem = -1;
            _frontColor = Color.DimGray;
            frontPen = new Pen(_frontColor);
            frontBrush = new SolidBrush(_frontColor);
            _backColor = Color.Black;
            backBrush = new SolidBrush(_backColor);
            _entries = new List<RTDrawable>();
            _offString = "off";
            _numericMin = 0;
            _numericMax = 100;
            _choiceType = ChoiceType.ListDefined;

            //_entries.Add(new RTDrawableText("bla"));
            //_entries.Add(new RTDrawableWaveform(RTDrawableWaveform.WaveForm.Sine, -0.5));
            //_entries.Add(new RTDrawableWaveform(RTDrawableWaveform.WaveForm.Triangle, -0.5));
            //_entries.Add(new RTDrawableWaveform(RTDrawableWaveform.WaveForm.Saw, -0.5));
            //_entries.Add(new RTDrawableWaveform(RTDrawableWaveform.WaveForm.Rectangle, -0.5));
            //_entries.Add(new RTDrawableWaveform(RTDrawableWaveform.WaveForm.Noise, 0));
            // _selectedItem = 0;

            // this.DoubleBuffered = true;
        }

        public event EventHandler choiceStateChanged;

        public class ChoiceStateChangedEventArgs : EventArgs
        {
            public int val { get; set; }
        }

        public delegate void ChoiceStateChangedEventHandler(object sender, ChoiceStateChangedEventArgs e);

        void newValue(int selval)
        {
            EventHandler handler = choiceStateChanged;
            ChoiceStateChangedEventArgs e = new ChoiceStateChangedEventArgs();
            switch (_choiceType)
            {
                case ChoiceType.ListDefined:
                    e.val = selval;
                    break;
                case ChoiceType.Numeric:
                    e.val = _numericMin + selval;
                    break;
                case ChoiceType.NumericOff:
                    e.val = _numericMin + selval;
                    break;
            }
            handler?.Invoke(this, e);
        }

        void newValue()
        {
            newValue(_selectedItem);
        }

        void getFrames(ref Rectangle sel, ref Rectangle up, ref Rectangle down)
        {
            int selwidth = (int)Math.Floor(scale * _xdim + 0.5);
            int btnwidth = Height / 2;
            sel = Rectangle.FromLTRB(Width - 1 - selwidth - btnwidth, 0, Width - 1 - Height / 2, Height - 1);
            up = Rectangle.FromLTRB(Width - 1 - btnwidth, 0, Width - 1, btnwidth - 1);
            down = Rectangle.FromLTRB(Width - 1 - btnwidth, btnwidth, Width - 1, Height - 1);
            /*Rectangle r = ClientRectangle;
            int ofs = Width - (int)Math.Floor(scale * _xdim+0.5);
            r.Location = new Point(r.Location.X + ofs, r.Location.Y);
            r.Width -= ofs + 1;
            r.Height -= 1;*/
        }

        void drawTo(Graphics g)
        {
            // Background
            // Brush brushBackground = new SolidBrush(BackColor);
            // g.FillRectangle(brushBackground, this.ClientRectangle);

            Rectangle sel, up, down;
            sel = new Rectangle();
            up = new Rectangle();
            down = new Rectangle();
            getFrames(ref sel, ref up, ref down);

            if ((_title != null) && (_title.Length > 0))
            {
                Brush tBrush = new SolidBrush(_titleColor);
                GraphicsUtil.drawText(g, Vector.V(sel.Left, Height / 2), _titleFont, scale, _title, 0, 2, 1, 0, Vector.V(1, 0), tBrush);
            }
            Pen framePen = new Pen(frontColor);
            g.DrawRectangle(framePen, sel);
            sel.Inflate(-1, -1);
            switch (_choiceType)
            {
                case ChoiceType.ListDefined:
                    if ((_entries != null) && (_entries.Count > 0) && (selectedItem >= 0) && (selectedItem < _entries.Count))
                    {
                        _entries[_selectedItem].draw(g, backColor, frontColor, sel);
                    }
                    if ((_entries != null) && (_entries.Count > 0))
                    {
                        if (_selectedItem < _entries.Count - 1)
                            GraphicsUtil.drawTriangle(g, Vector.V(up), (double)up.Height, Vector.V(0, -1), framePen);
                        if (_selectedItem > 0)
                            GraphicsUtil.drawTriangle(g, Vector.V(down), (double)up.Height, Vector.V(0, 1), framePen);
                    }
                    break;
                case ChoiceType.Numeric:
                    g.FillRectangle(backBrush, sel);
                    g.DrawRectangle(framePen, sel);
                    GraphicsUtil.drawText(g, Vector.V(sel), _valueFont, scale,
                        String.Format("{0}", _numericMin + _selectedItem), 0, 2, 0, 0, Vector.X, frontBrush);
                    if (_selectedItem < (_numericMax-_numericMin))
                        GraphicsUtil.drawTriangle(g, Vector.V(up), (double)up.Height, Vector.V(0, -1), framePen);
                    if (_selectedItem > 0)
                        GraphicsUtil.drawTriangle(g, Vector.V(down), (double)up.Height, Vector.V(0, 1), framePen);
                    break;
                case ChoiceType.NumericOff:
                    g.FillRectangle(backBrush, sel);
                    g.DrawRectangle(framePen, sel);
                    if (_selectedItem == -1)
                        GraphicsUtil.drawText(g, Vector.V(sel), _valueFont, scale,
                            _offString, 0, 2, 0, 0, Vector.X, frontBrush);
                    else
                        GraphicsUtil.drawText(g, Vector.V(sel), _valueFont, scale,
                            String.Format("{0}", _numericMin + _selectedItem), 0, 2, 0, 0, Vector.X, frontBrush);
                    if (_selectedItem < (_numericMax - _numericMin))
                        GraphicsUtil.drawTriangle(g, Vector.V(up), (double)up.Height, Vector.V(0, -1), framePen);
                    if (_selectedItem >= 0)
                        GraphicsUtil.drawTriangle(g, Vector.V(down), (double)up.Height, Vector.V(0, 1), framePen);
                    break;
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
            Dragging
        }

        private DragMode dragMode;
        private int dragStart;
        private int dragSel;

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (dragMode == DragMode.Dragging)
            {
                int dy = (int)Math.Floor((e.Y - dragStart)*scale / Height+0.5);
                int newsel = dragSel + dy;
                switch (_choiceType)
                {
                    case ChoiceType.ListDefined:
                        if (newsel < 0) newsel = 0;
                        if (newsel >= _entries.Count) newsel = _entries.Count - 1;
                        if (newsel != _selectedItem)
                        {
                            _selectedItem = newsel;
                            newValue();
                            Invalidate();
                        }
                        break;
                    case ChoiceType.Numeric:
                        if (newsel < 0) newsel = 0;
                        if (newsel >= (_numericMax-_numericMin+1)) newsel = (_numericMax - _numericMin + 1) - 1;
                        if (newsel != _selectedItem)
                        {
                            _selectedItem = newsel;
                            newValue();
                            Invalidate();
                        }
                        break;
                    case ChoiceType.NumericOff:
                        if (newsel < -1) newsel = -1;
                        if (newsel >= (_numericMax - _numericMin + 1)) newsel = (_numericMax - _numericMin + 1) - 1;
                        if (newsel != _selectedItem)
                        {
                            _selectedItem = newsel;
                            newValue();
                            Invalidate();
                        }
                        break;
                }
            } else 
                forwardOnMouseMove(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            if (dragMode == DragMode.Dragging)
            {
                int dy = (int)Math.Floor((e.Y - dragStart) * scale / Height + 0.5);
                int newsel = dragSel + dy;
                switch (_choiceType)
                {
                    case ChoiceType.ListDefined:
                        if (newsel < 0) newsel = 0;
                        if (newsel >= _entries.Count) newsel = _entries.Count - 1;
                        if (newsel != _selectedItem)
                        {
                            _selectedItem = newsel;
                            newValue();
                            Invalidate();
                        }
                        break;
                    case ChoiceType.Numeric:
                        if (newsel < 0) newsel = 0;
                        if (newsel >= (_numericMax - _numericMin + 1)) newsel = (_numericMax - _numericMin + 1) - 1;
                        if (newsel != _selectedItem)
                        {
                            _selectedItem = newsel;
                            newValue();
                            Invalidate();
                        }
                        break;
                    case ChoiceType.NumericOff:
                        if (newsel < -1) newsel = -1;
                        if (newsel >= (_numericMax - _numericMin + 1)) newsel = (_numericMax - _numericMin + 1) - 1;
                        if (newsel != _selectedItem)
                        {
                            _selectedItem = newsel;
                            newValue();
                            Invalidate();
                        }
                        break;
                }
                dragMode = DragMode.Idle;
            }
            else
                forwardOnMouseUp(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (Enabled)
            {
                Rectangle sel, up, down;
                sel = new Rectangle();
                up = new Rectangle();
                down = new Rectangle();
                getFrames(ref sel, ref up, ref down);
                if (sel.Contains(e.Location))
                {
                    switch (_choiceType)
                    {
                        case ChoiceType.ListDefined:
                            if ((_entries != null) && (_entries.Count > 0))
                            {
                                dragStart = e.Y;
                                dragSel = _selectedItem;
                                dragMode = DragMode.Dragging;
                            }
                            break;
                        case ChoiceType.Numeric:
                            if (_numericMin < _numericMax)
                            {
                                dragStart = e.Y;
                                dragSel = _selectedItem;
                                dragMode = DragMode.Dragging;
                            }
                            break;
                        case ChoiceType.NumericOff:
                            if (_numericMin <= _numericMax)
                            {
                                dragStart = e.Y;
                                dragSel = _selectedItem;
                                dragMode = DragMode.Dragging;
                            }
                            break;
                    }
                }
                else if (up.Contains(e.Location))
                {
                    switch (_choiceType)
                    {
                        case ChoiceType.ListDefined:
                            if ((_entries != null) && (_entries.Count > 0) && (_selectedItem < _entries.Count - 1))
                            {
                                _selectedItem++;
                                newValue();
                                Invalidate();
                            }
                            break;
                        case ChoiceType.Numeric:
                            if ((_numericMin < _numericMax) && (_selectedItem < (_numericMax-_numericMin)))
                            {
                                _selectedItem++;
                                newValue();
                                Invalidate();
                            }
                            break;
                        case ChoiceType.NumericOff:
                            if ((_numericMin <= _numericMax) && (_selectedItem < (_numericMax - _numericMin)))
                            {
                                _selectedItem++;
                                newValue();
                                Invalidate();
                            }
                            break;
                    }
                }
                else if (down.Contains(e.Location))
                {
                    switch(_choiceType)
                    {
                        case ChoiceType.ListDefined:
                            if ((_entries != null) && (_entries.Count > 0) && (_selectedItem > 0))
                            {
                                _selectedItem--;
                                newValue();
                                Invalidate();
                            }
                            break;
                        case ChoiceType.Numeric:
                            if ((_numericMin < _numericMax) && (_selectedItem > 0))
                            {
                                _selectedItem--;
                                newValue();
                                Invalidate();
                            }
                            break;
                        case ChoiceType.NumericOff:
                            if ((_numericMin <= _numericMax) && (_selectedItem >= 0))
                            {
                                _selectedItem--;
                                newValue();
                                Invalidate();
                            }
                            break;
                    }
                }
                else
                    forwardOnMouseDown(e);
            }
        }


        public class RTDrawable
        {
            public RTDrawable()
            {
            }

            public virtual void draw(Graphics g, Color colorBack, Color colorFront, Rectangle frame)
            {
                Brush brush = new SolidBrush(colorBack);
                Pen pen = new Pen(colorFront);
                g.FillRectangle(brush, frame);
                g.DrawRectangle(pen, frame);
                g.DrawLine(pen, frame.Left, frame.Top, frame.Right, frame.Bottom);
                g.DrawLine(pen, frame.Left, frame.Bottom, frame.Right, frame.Top);
            }

        }

        public class RTDrawableText : RTDrawable
        {
            string text;
            Font font;

            public RTDrawableText(String _text)
            {
                if ((_text == null) || (_text.Length < 1))
                    text = "?";
                else
                    text = _text;
                font = new Font(FontFamily.GenericSansSerif, 8);
            }

            public RTDrawableText() : this("?")
            {
            }

            public override void draw(Graphics g, Color colorBack, Color colorFront, Rectangle frame)
            {
                Vector center = Vector.V(frame);
                Brush brush = new SolidBrush(colorBack);
                g.FillRectangle(brush, frame);
                double scale = (double)frame.Height / 16;
                brush = new SolidBrush(colorFront);
                GraphicsUtil.drawText(g, center, font, scale, text, 0, 2, 0, 0, Vector.X, brush);
            }
        }

        public class RTDrawableWaveform : RTDrawable
        {
            public enum WaveForm
            {
                Sine,
                Triangle,
                Saw,
                Rectangle,
                Noise
            }

            WaveForm waveform;
            double modulation;
            Random rand;

            public RTDrawableWaveform(WaveForm _waveform, double _modulation)
            {
                waveform = _waveform;
                modulation = _modulation;
                rand = new Random();
            }

            public RTDrawableWaveform(WaveForm _waveform) : this(_waveform, 0)
            {
            }

            public RTDrawableWaveform() : this(WaveForm.Sine, 0)
            {
            }

            private static double tri(double x, double modulation)
            {
                double y = 0;
                double mod = (modulation + 1) / 2;
                if (mod < 0) mod = 0;
                if (mod > 1) mod = 1;
                if (x <= mod)
                    return (x / mod) * 2 - 1;
                return (1 - (x - mod) / (1 - mod)) * 2 - 1;
            }

            private static double saw(double x, double modulation)
            {
                double y = 2 * x * Math.Exp(modulation) - 1;
                if (y < -1) y = -1;
                if (y > 1) y = 1;
                return y;
            }

            private static double rect(double x, double modulation)
            {
                if (x < (modulation + 1) / 2)
                    return -1;
                else return 1;
            }

            private double func(double x)
            {
                x = x - Math.Floor(x);
                switch (waveform)
                {
                    case WaveForm.Sine: return Math.Sin(2 * Math.PI * Math.Exp(modulation) * x);
                    case WaveForm.Triangle: return tri(x, modulation);
                    case WaveForm.Saw: return saw(x, modulation);
                    case WaveForm.Rectangle: return rect(x, modulation);
                    case WaveForm.Noise: return rand.NextDouble() * 2.0 - 1;
                }
                return 0;
            }

            public override void draw(Graphics g, Color colorBack, Color colorFront, Rectangle frame)
            {
                Vector center = Vector.V(frame);
                Vector dim = Vector.V(frame.Size) / 2;
                Brush brush = new SolidBrush(colorBack);
                g.FillRectangle(brush, frame);
                Pen pen = new Pen(colorFront);
                int N = 50;
                Point[] plist = new Point[N];
                for (int i = 0; i < N; i++)
                {
                    double x = (double)i * 2 / (N - 1) - 1.0; // -1..1
                    double y = -func(x);
                    plist[i] = (Vector.V(x * dim.x, y * dim.y * 0.9) + center).Point;
                }
                g.DrawLines(pen, plist);
            }
        }


    }
}
