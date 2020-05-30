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
    public partial class RTSlider : RTControl
    {


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

        private double _minVal;
        public double minVal
        {
            set { _minVal = value; grid = null; Invalidate(); }
            get { return _minVal; }
        }

        private double _maxVal;
        public double maxVal
        {
            set { _maxVal = value; grid = null; Invalidate(); }
            get { return _maxVal; }
        }

        private bool _logScale;
        public bool logScale
        {
            set { _logScale = value; grid = null; Invalidate(); }
            get { return _logScale; }
        }

        private double _val;
        public double val
        {
            set { _val = value; Invalidate(); }
            get { return _val; }
        }

        private string _format;
        public string format
        {
            set { _format = value; Invalidate(); }
            get { return _format; }
        }

        private string _unit;
        public string unit
        {
            set { _unit = value; Invalidate(); }
            get { return _unit; }
        }

        private Color _valueColor;
        private Brush valueBrush;
        public Color valueColor
        {
            set { _valueColor = value; valueBrush = new SolidBrush(_valueColor); Invalidate(); }
            get { return _valueColor; }
        }

        private Font _valueFont;
        public Font valueFont
        {
            set { _valueFont = value; Invalidate(); }
            get { return _valueFont; }
        }

        private bool _showValue;
        public bool showValue
        {
            set { _showValue = value; Invalidate(); }
            get { return _showValue; }
        }

        private bool _showScale;
        public bool showScale
        {
            set { _showScale = value; Invalidate(); }
            get { return _showScale; }
        }

        private Color _scaleColor;
        private Pen scalePen;
        public Color scaleColor
        {
            set { _scaleColor = value; scalePen = new Pen(_scaleColor); Invalidate(); }
            get { return _scaleColor; }
        }

        private double _slideWidth;
        public double slideWidth
        {
            set { _slideWidth = value; Invalidate(); }
            get { return _slideWidth; }
        }

        private double _slideKnob;
        public double slideKnob
        {
            set { _slideKnob = value; Invalidate(); }
            get { return _slideKnob; }
        }

        private Color _slideColor;
        private Pen penSlide;
        public Color slideColor
        {
            set { _slideColor = value; penSlide = new Pen(_slideColor); Invalidate(); }
            get { return _slideColor; }
        }

        private Color _slideMarkColor;
        private Pen penSlideMark;
        public Color slideMarkColor
        {
            set { _slideMarkColor = value; penSlideMark = new Pen(_slideMarkColor); Invalidate(); }
            get { return _slideMarkColor; }
        }

        private Color _slideMarkFill;
        private Brush brushSlideMark;
        public Color slideMarkFill
        {
            set { _slideMarkFill = value; brushSlideMark = new SolidBrush(_slideMarkFill);Invalidate(); }
            get { return _slideMarkFill; }
        }
               
        public enum SlideDirection
        {
            Vertical, Horizontal
        }
        private SlideDirection _slideDirection;
        public SlideDirection slideDirection
        {
            set { _slideDirection = value; grid = null; Invalidate(); }
            get { return _slideDirection; }
        }

        private double _slideScaleDist;
        public double slideScaleDist
        {
            set { _slideScaleDist = value; Invalidate(); }
            get { return _slideScaleDist; }
        }

        private double _slideScaleWidth;
        public double slideScaleWidth
        {
            set { _slideScaleWidth = value; Invalidate(); }
            get { return _slideScaleWidth; }
        }

        private bool _showScaleValues;
        public bool showScaleValues
        {
            set { _showScaleValues = value; Invalidate(); }
            get { return _showScaleValues; }
        }

        private Font _scaleFont;
        public Font scaleFont
        {
            set { _scaleFont = value; Invalidate(); }
            get { return _scaleFont; }
        }

        private Color _scaleValueColor;
        private Brush scaleFontBrush;
        public Color scaleValueColor
        {
            set { _scaleValueColor = value; scaleFontBrush = new SolidBrush(_scaleValueColor); Invalidate(); }
            get { return _scaleValueColor; }
        }

        private double _lableLength;
        public double lableLength
        {
            set { if (_lableLength != value) { _lableLength = value; grid = null; Invalidate(); } }
            get { return _lableLength; }
        }


        private GridCalculator grid;

        public event EventHandler valueChanged;

        public RTSlider()
        {
            _title = "Slider";
            _titleFont = new Font(FontFamily.GenericSansSerif, 8);
            _titleColor = Color.DimGray;
            _showTitle = true;
            _minVal = -1;
            _maxVal = 1;
            _logScale = false;
            _val = 0;
            _format = "F2";
            _unit = "";
            _valueColor = Color.DimGray;
            _valueFont = new Font(FontFamily.GenericSansSerif, 8);
            _showValue = true;
            _showScale = true;
            _scaleColor = Color.DimGray;
            _slideWidth = 5;
            _slideKnob = 20;
            _slideColor = Color.Silver;
            _slideMarkColor = Color.Red;
            _slideMarkFill = Color.DarkRed;
            _slideDirection = SlideDirection.Vertical;
            _slideScaleDist = 20;
            _slideScaleWidth = 10;
            _showScaleValues = true;
            _scaleFont = new Font(FontFamily.GenericSansSerif, 8);
            _lableLength = 3;
            _scaleValueColor = Color.DimGray;

            brushSlideMark = new SolidBrush(_slideMarkFill);
            penSlideMark = new Pen(_slideMarkColor);
            penSlide = new Pen(_slideColor);
            valueBrush = new SolidBrush(_valueColor);
            titleBrush = new SolidBrush(_titleColor);
            scaleFontBrush = new SolidBrush(_scaleValueColor);
            scalePen = new Pen(_scaleColor);

            this.DoubleBuffered = true;
        }

        private double slidePos()
        {
            if (_val < _minVal) return 0.0;
            if (_val > _maxVal) return 1.0;
            if (_logScale)
            {
                if ((_minVal <= 0) || (_maxVal <= 0))
                    return 0;
                if (_val <= 0) return 0;
                return (Math.Log(_val) - Math.Log(_minVal)) / (Math.Log(_maxVal) - Math.Log(_minVal));
            }
            else
            {
                if (_minVal == _maxVal)
                    return 0.0;
                return (_val - _minVal) / (_maxVal - _minVal);
            }
        }

        string getFormat()
        {
            if ((_format == null) || (_format.Length < 1))
                return "{0}";
            return string.Format("{{0:{0}}}", _format);
        }

        public class ValueChangedEventArgs : EventArgs
        {
            public double value { get; set; }
        }

        public delegate void ValueChangedEventHandler(object sender, ValueChangedEventArgs e);

        void newValue()
        {
            EventHandler handler = valueChanged;
            ValueChangedEventArgs e = new ValueChangedEventArgs();
            e.value = _val;
            handler?.Invoke(this, e);
        }

        void getPositions(ref GraphicsUtil.TextPosition titlePos, 
            ref GraphicsUtil.TextPosition valuePos,
            ref VectorRect bar, ref VectorRect handle,
            ref Vector vlow, ref Vector vhigh)
        {
            double y0 = 0;
            double y1 = Height - 1;

            if (_showTitle)
            {
                titlePos = new GraphicsUtil.TextPosition(Vector.V(Width / 2, 0), 0, 1);
                titlePos.scale = scale;
                y0 += scale * _titleFont.Height*1.5;
            }
            else
                titlePos = null;

            if (_showValue)
            {
                valuePos = new GraphicsUtil.TextPosition(Vector.V(Width / 2, Height - 1), 0, -1);
                valuePos.scale = scale;
                y1 -= scale * _valueFont.Height*1.5;
            }
            else
                valuePos = null;


            // Calculate the required space for the slider, the scale and the scale values
            double w = _slideKnob;
            if (_showScale)
            {
                w += _slideScaleDist;
                w += _slideScaleWidth;
                if (_showScaleValues)
                {
                    if (_slideDirection == SlideDirection.Horizontal)
                        w += _scaleFont.Height;
                    else
                        w += _scaleFont.Height*_lableLength;
                }
            }
            w *= scale;

            double start = 0;
            if (_slideDirection == SlideDirection.Horizontal)
            {
                start = (y1 + y0)/2 - w / 2 + _slideKnob/2*scale;
                double wbar = Width - 3 * _slideWidth * scale;
                bar = VectorRect.FromCenterSize(Vector.V(Width / 2, start),
                    Vector.V(Width - 2, _slideWidth*scale));

                double sp = (Width/2-wbar/2) + slidePos() * wbar;
                handle = VectorRect.FromCenterSize(Vector.V(sp, start),
                    Vector.V(_slideWidth*scale, _slideKnob*scale));

                if (_showScale)
                    start += _slideKnob/2*scale + _slideScaleDist*scale;
                vlow = Vector.V(Width / 2 - wbar / 2, start);
                vhigh = Vector.V(Width / 2 + wbar / 2, start);
            }
            else
            {
                start = Width / 2 - w / 2 + _slideKnob/2*scale;
                double wbar = y1 - y0 - 3*_slideWidth * scale;
                bar = VectorRect.FromCenterSize(Vector.V(start, (y1+y0)/2),
                    Vector.V(_slideWidth*scale, y0-y1-2));
                double sp = (y1+y0)/2 + wbar/2 - slidePos() * wbar;
                handle = VectorRect.FromCenterSize(Vector.V(start, sp),
                    Vector.V(_slideKnob*scale, _slideWidth*scale));
                if (_showScale)
                    start += _slideKnob/2*scale + _slideScaleDist*scale;
                vlow = Vector.V(start, (y1 + y0) / 2 + wbar / 2);
                vhigh = Vector.V(start, (y1 + y0) / 2 - wbar / 2);
            }
        }


        void drawTo(Graphics g)
        {

            GraphicsUtil.TextPosition titlePos = new GraphicsUtil.TextPosition();
            GraphicsUtil.TextPosition valuePos = new GraphicsUtil.TextPosition();
            VectorRect bar = new VectorRect();
            VectorRect handle = new VectorRect();
            Vector vlow = Vector.Zero;
            Vector vhigh = Vector.Zero;

            getPositions(ref titlePos, ref valuePos, ref bar, ref handle, ref vlow, ref vhigh);

            double hlen = 0;
            if (_showScale)
            {
                if (_slideDirection == SlideDirection.Horizontal)
                {
                    hlen = (vhigh.x - vlow.x)/scale;
                    if (grid == null)
                    {
                        grid = new GridCalculator(_minVal, _maxVal, 1e-12, 1e-12, 1.1, _minVal, _maxVal, _logScale, 0, hlen, (double)_scaleFont.Height * _lableLength);
                    }
                    else if (grid.high != hlen)
                        grid.reScreen(0, hlen);
                }
                else
                {
                    hlen = (vlow.y - vhigh.y)/scale;
                    if (grid == null)
                    {
                        grid = new GridCalculator(_minVal, _maxVal, 1e-12, 1e-12, 1.1, _minVal, _maxVal, _logScale, 0, hlen, (double)_scaleFont.Height);
                        grid.showEndLables = true;
                    }
                    else if (grid.high != hlen)
                        grid.reScreen(0, hlen);
                }
            }

            // Title
            if (_showTitle && (_title != null) && (_title.Length > 0))
            {                
                titlePos.drawText(g, _titleFont, titleBrush, _title);
            }

            // Value
            if (_showValue)
            {
                String s = String.Format(getFormat(), _val);
                if ((unit != null) && (unit.Length > 0))
                    s = s + " " + unit;
                valuePos.drawText(g, _valueFont, valueBrush, s);
            }
            g.DrawRectangle(penSlide, bar.rectangle);

            g.FillRectangle(brushSlideMark, handle.rectangle);
            g.DrawRectangle(penSlideMark, handle.rectangle);

            if (_showScale)
            {
                GraphicsUtil.drawLine(g, vlow, vhigh, scalePen);
                Vector vr = 0.5 * _slideScaleWidth * scale * ((vhigh - vlow).norm).vrot90();
                Vector vtext = Vector.Zero;
                if (_slideDirection == SlideDirection.Horizontal)
                    vtext = Vector.V(0, _slideScaleWidth / 2*scale);
                else
                    vtext = Vector.V(_slideScaleWidth / 2*scale, 0);
                
                for (int i=0;i<grid.gridLength;i++)
                {
                    Vector vpos = vlow + (vhigh - vlow) * grid.grid[i].screen / hlen;
                    if (grid.grid[i].isMajor)
                        GraphicsUtil.drawLine(g, vpos - vr, vpos + vr, scalePen);
                    else
                        GraphicsUtil.drawLine(g, vpos - vr/2, vpos + vr/2, scalePen);

                    if (_showScaleValues && grid.grid[i].show && (grid.grid[i].name.Length > 0))
                    {
                        if (_slideDirection == SlideDirection.Horizontal)
                            GraphicsUtil.drawText(g, vpos + vtext, _scaleFont, scale, 
                                grid.grid[i].name, 0, 2, 0, 1, Vector.V(1, 0), scaleFontBrush);
                        else
                            GraphicsUtil.drawText(g, vpos + vtext, _scaleFont, scale,
                                grid.grid[i].name, 0, 2, -1, 0, Vector.V(1, 0), scaleFontBrush);
                    }
                }
            }            
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            drawTo(pe.Graphics);
        }

        public enum DragMode
        {
            Idle = 0,
            Dial
        }
        private DragMode dragMode;
        private Point dragStart;

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (dragMode == DragMode.Dial)
            {

                GraphicsUtil.TextPosition titlePos = new GraphicsUtil.TextPosition();
                GraphicsUtil.TextPosition valuePos = new GraphicsUtil.TextPosition();
                VectorRect bar = new VectorRect();
                VectorRect handle = new VectorRect();
                Vector vlow = Vector.Zero;
                Vector vhigh = Vector.Zero;

                getPositions(ref titlePos, ref valuePos, ref bar, ref handle, ref vlow, ref vhigh);


                // Hit in Dial Region
                double n = 0;
                if (_slideDirection == SlideDirection.Horizontal)
                    n = (e.X - vlow.x) / (vhigh.x - vlow.x);
                else
                    n = (e.Y - vlow.y) / (vhigh.y - vlow.y);
                if (n < 0) n = 0;
                if (n > 1.0) n = 1;

                if (logScale)
                {
                    if ((_minVal <= 0) || (_maxVal <= 0) || (_minVal == _maxVal))
                        _val = _minVal;
                    else
                        _val = Math.Exp(n * (Math.Log(_maxVal) - Math.Log(_minVal)) + Math.Log(_minVal));
                }
                else
                {
                    _val = n * (_maxVal - _minVal) + _minVal;
                }
                newValue();
                Invalidate();
            }
            else forwardOnMouseMove(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            if (dragMode == DragMode.Dial)
            {
                GraphicsUtil.TextPosition titlePos = new GraphicsUtil.TextPosition();
                GraphicsUtil.TextPosition valuePos = new GraphicsUtil.TextPosition();
                VectorRect bar = new VectorRect();
                VectorRect handle = new VectorRect();
                Vector vlow = Vector.Zero;
                Vector vhigh = Vector.Zero;

                getPositions(ref titlePos, ref valuePos, ref bar, ref handle, ref vlow, ref vhigh);


                // Hit in Dial Region
                double n = 0;
                if (_slideDirection == SlideDirection.Horizontal)
                    n = (e.X - vlow.x) / (vhigh.x - vlow.x);
                else
                    n = (e.Y - vlow.y) / (vhigh.y - vlow.y);
                if (n < 0) n = 0;
                if (n > 1.0) n = 1;

                if (logScale)
                {
                    if ((_minVal <= 0) || (_maxVal <= 0) || (_minVal == _maxVal))
                        _val = _minVal;
                    else
                        _val = Math.Exp(n * (Math.Log(_maxVal) - Math.Log(_minVal)) + Math.Log(_minVal));
                }
                else
                {
                    _val = n * (_maxVal - _minVal) + _minVal;
                }
                newValue();
                Invalidate();
                dragMode = DragMode.Idle;
            }
            else forwardOnMouseUp(e);
        }

        // private static double sqr(double s) { return s * s; }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button != MouseButtons.Left) return;
            double scl = scale;

            if ((e.X < 0) || (e.X >= Width) || (e.Y < 0) || (e.Y >= Height)) return;

            if (_showValue && e.Y >= Height-1-valueFont.Height*scale)
            {
                // Hit in Value
                // Show Value Selector Window
                NumericInputWin dw = new NumericInputWin(this,
                    ((_title != null) && (_title.Length > 0)) ? _title : null,
                    ((_unit != null) && (_unit.Length > 0)) ? _unit : null,
                    getFormat(), true, _minVal, _val, _maxVal, _logScale);
                dw.StartPosition = FormStartPosition.Manual;
                dw.Location = PointToScreen(e.Location);
                dw.ShowDialog();
                _val = dw.value;
                newValue();
                Invalidate();
                return;
            }

            GraphicsUtil.TextPosition titlePos = new GraphicsUtil.TextPosition();
            GraphicsUtil.TextPosition valuePos = new GraphicsUtil.TextPosition();
            VectorRect bar = new VectorRect();
            VectorRect handle = new VectorRect();
            Vector vlow = Vector.Zero;
            Vector vhigh = Vector.Zero;

            getPositions(ref titlePos, ref valuePos, ref bar, ref handle, ref vlow, ref vhigh);


            VectorRect vr = VectorRect.containingRects(bar, handle);

            if (vr.inside(e.X, e.Y))
            {
                // Hit in Dial Region
                double n = 0;
                if (_slideDirection == SlideDirection.Horizontal)
                    n = (e.X - vlow.x) / (vhigh.x - vlow.x);
                else
                    n = (e.Y - vlow.y) / (vhigh.y - vlow.y);
                if (n < 0) n = 0;
                if (n > 1.0) n = 1;

                if (logScale)
                {
                    if ((_minVal <= 0) || (_maxVal <= 0) || (_minVal == _maxVal))
                        _val = _minVal;
                    else
                        _val = Math.Exp(n * (Math.Log(_maxVal) - Math.Log(_minVal)) + Math.Log(_minVal));
                }
                else
                {
                    _val = n * (_maxVal - _minVal) + _minVal;
                }
                newValue();
                Invalidate();
                dragMode = DragMode.Dial;
                dragStart = e.Location;
            }
            else
                forwardOnMouseDown(e);
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(e);

            GraphicsUtil.TextPosition titlePos = new GraphicsUtil.TextPosition();
            GraphicsUtil.TextPosition valuePos = new GraphicsUtil.TextPosition();
            VectorRect bar = new VectorRect();
            VectorRect handle = new VectorRect();
            Vector vlow = Vector.Zero;
            Vector vhigh = Vector.Zero;

            getPositions(ref titlePos, ref valuePos, ref bar, ref handle, ref vlow, ref vhigh);

            VectorRect vr = VectorRect.containingRects(bar, handle);

            if (vr.inside(e.X, e.Y))
            {
                ((HandledMouseEventArgs)e).Handled = true;
                if (_logScale)
                {
                    if ((_minVal <= 0) || (_maxVal <= 0) || (_maxVal == _minVal)) return;
                    if (_val <= 0) return;
                    double v = Math.Log(_val) + (double)e.Delta / 2000 * (Math.Log(_maxVal) - Math.Log(_minVal));
                    if (v < Math.Log(_minVal))
                        v = Math.Log(_minVal);
                    if (v > Math.Log(_maxVal))
                        v = Math.Log(_maxVal);
                    _val = Math.Exp(v);
                    Invalidate();
                    newValue();
                } 
                else
                {
                    if (_minVal >= _maxVal) return;
                    double v = _val + (double)e.Delta / 2000 * (_maxVal - _minVal);
                    if (v < _minVal) v = _minVal;
                    if (v > _maxVal) v = _maxVal;
                    _val = v;
                    Invalidate();
                    newValue();
                }
            } 
            else
                forwardOnMouseWheel(e);
        }



    }
}
