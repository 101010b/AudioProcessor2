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
    public partial class RTDial : RTControl
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
            get { return _titleFont;  }
        }

        private Color _titleColor;
        public Color titleColor
        {
            set { _titleColor = value; Invalidate(); }
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
            set { _minVal = value; Invalidate(); }
            get { return _minVal; }
        }

        private double _maxVal;
        public double maxVal
        {
            set { _maxVal = value; Invalidate(); }
            get { return _maxVal; }
        }

        private bool _logScale;
        public bool logScale
        {
            set { _logScale = value; Invalidate(); }
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
        public Color valueColor
        {
            set { _valueColor = value; Invalidate(); }
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
        public Color scaleColor
        {
            set { _scaleColor = value; Invalidate(); }
            get { return _scaleColor; }
        }

        private double _dialDiameter;
        public double dialDiameter
        {
            set { _dialDiameter = value; Invalidate(); }
            get { return _dialDiameter; }
        }

        private Color _dialColor;
        public Color dialColor
        {
            set { _dialColor = value; Invalidate(); }
            get { return _dialColor; }
        }

        private Color _dialMarkColor;
        public Color dialMarkColor
        {
            set { _dialMarkColor = value; Invalidate(); }
            get { return _dialMarkColor; }
        }

        private GridCalculator grid;

        public event EventHandler valueChanged;

        public RTDial()
        {
            _title = "Dial";
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
            _scaleColor = Color.Gold;
            _dialDiameter = 30;
            _dialColor = Color.Silver;
            _dialMarkColor = Color.Red;
            grid = new GridCalculator(_minVal, _maxVal, _logScale, 270);


            this.DoubleBuffered = true;
        }

        private double dialPos()
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

        public class ValueChangedEventArgs: EventArgs
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

        void drawTo(Graphics g)
        {

            double scl = scale;

            // Background
            //Brush brushBackground = new SolidBrush(BackColor);
            //g.FillRectangle(brushBackground, this.ClientRectangle);

            Vector center = Vector.V(Width / 2, Height / 2);

            // Title
            if (_showTitle && (_title != null) && (_title.Length > 0))
            {
                Brush textBrush = new SolidBrush(_titleColor);
                // g.DrawString(_title, _titleFont, textBrush, Width / 2, Height / 2);
                GraphicsUtil.drawText(g, center-Vector.V(0,_dialDiameter/2*scl), _titleFont, scl, 
                    _title, 0, 2, 0, -1, Vector.X, textBrush);
            }


            // Dial
            double rad = _dialDiameter * scl / 2;
            RectangleF rf = Vector.RFC(center, Vector.diag(rad * 2 * 0.8));
            Pen knobPen = new Pen(_dialColor);
            g.DrawEllipse(knobPen, rf);

            /*Brush brushRotKnob = new SolidBrush(_dialColor);
            g.FillEllipse(brushRotKnob, rf);
            Pen penRotKnob = new Pen(Color.AliceBlue);
            rf = Vector.RFC(center, Vector.diag(rad * 2 * 0.8 * 0.9));
            g.DrawEllipse(penRotKnob, rf);*/


            double slp = dialPos();
            double phi = Math.PI * 1 / 4 - (1 - slp) * Math.PI * 3 / 2;
            Pen penRotMark = new Pen(_dialMarkColor);
            Vector pointpos = center + Vector.V(rad * 0.6, 0).rot(phi);
            g.DrawEllipse(penRotMark, VectorRect.FromCenterSize(pointpos, Vector.V(rad / 5, rad / 5)).rectangleF);
            // g.DrawLine(penRotMark, (center + Vector.V(rad * 0.7, 0).rot(phi)).PointF, (center + Vector.V(rad * 0.3, 0).rot(phi)).PointF);


            if (_showScale)
            {
                // Grid
                grid.logScale = _logScale;
                grid.newRange(_minVal, _maxVal);
                Pen penRotScale = new Pen(_scaleColor);
                for (int i = 0; i < grid.gridLength; i++)
                {
                    double alpha = Math.PI / 4 - (1 - grid.grid[i].screen / grid.high) * 1.5 * Math.PI;
                    Vector vin = Vector.V(rad * 0.85, 0).rot(alpha);
                    Vector vout = Vector.V(rad * ((grid.grid[i].isMajor) ? (0.98) : (0.9)), 0).rot(alpha);
                    g.DrawLine(penRotScale, (center + vin).PointF, (center + vout).PointF);
                }
            }

            // Value
            if (_showValue)
            {
                String s = String.Format(getFormat(), _val);
                Brush textBrush = new SolidBrush(_valueColor);
                if ((unit != null) && (unit.Length > 0))
                    s = s + " " + unit;
                GraphicsUtil.drawText(g, center + Vector.V(0,_dialDiameter/2*scl), _valueFont, scl,
                    s, 0, 2, 0, 1, Vector.X, textBrush);

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
            Dial
        }
        private DragMode dragMode;
        private Point dragStart;

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (dragMode == DragMode.Dial)
            {
                Vector dist = Vector.V(e.Location) - Vector.V(Width / 2, Height / 2);
                double phit = (-dist).Phi;
                if (phit < -Math.PI / 2) phit += 2.0 * Math.PI;
                double n = (phit + Math.PI / 4) / (1.5 * Math.PI);
                if (n < 0) n = 0;
                if (n > 1) n = 1;
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
                Vector dist = Vector.V(e.Location) - Vector.V(Width / 2, Height / 2);
                double phit = (-dist).Phi;
                if (phit < -Math.PI / 2) phit += 2.0 * Math.PI;
                double n = (phit + Math.PI / 4) / (1.5 * Math.PI);
                if (n < 0) n = 0;
                if (n > 1) n = 1;
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

        private static double sqr(double s) { return s * s; }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button != MouseButtons.Left) return;
            double scl = scale;
            if ((e.X < 0) || (e.X >= Width) || (e.Y < 0) || (e.Y >= Height)) return;
            Vector center = Vector.V(Width / 2, Height / 2);
            if (_showValue && e.Y >= center.y + _dialDiameter * scl / 2)
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
            }
            else if (Math.Sqrt(sqr(e.X - center.x) + sqr(e.Y - center.y)) < _dialDiameter * scl / 2)
            {
                // Hit in Dial Region
                Vector dist = Vector.V(e.Location) - Vector.V(Width / 2, Height / 2);
                double phit = (-dist).Phi;
                if (phit < -Math.PI / 2) phit += 2.0 * Math.PI;
                double n = (phit + Math.PI / 4) / (1.5 * Math.PI);
                if (n < 0) n = 0;
                if (n > 1) n = 1;
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
            ((HandledMouseEventArgs)e).Handled = true;
            Vector center = Vector.V(Width / 2, Height / 2);
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
            else if(Math.Sqrt(sqr(e.X - center.x) + sqr(e.Y - center.y)) < _dialDiameter * scale / 2)
            {
                if (_minVal >= _maxVal) return;
                double v = _val + (double)e.Delta / 2000 * (_maxVal - _minVal);
                if (v < _minVal) v = _minVal;
                if (v > _maxVal) v = _maxVal;
                _val = v;
                Invalidate();
                newValue();
            }
            else 
                forwardOnMouseWheel(e);
        }



    }
}
