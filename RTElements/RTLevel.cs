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
    public partial class RTLevel : RTControl
    {

        private String _title;
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

        private GraphicsUtil.TextAlignment _valuePos;
        public GraphicsUtil.TextAlignment valuePos
        {
            set { _valuePos = value; redraw(); }
            get { return _valuePos; }
        }

        private Font _valueFont;
        public Font valueFont
        {
            set { _valueFont = value; redraw(); }
            get { return _valueFont; }
        }

        private Color _valueColor;
        private Brush valueBrush;
        public Color valueColor
        {
            set { _valueColor = value; valueBrush = new SolidBrush(_valueColor); redraw(); }
            get { return _valueColor; }
        }

        private string _format;
        public string format
        {
            set { _format = value; redraw(); }
            get { return _format; }
        }

        private string _unit;
        public string unit
        {
            set { _unit = value; redraw(); }
            get { return _unit; }
        }

        private double _value;
        public double value
        {
            set { _value = value; redraw(); }
            get { return _value; }
        }

        private double _min;
        public double min
        {
            set { _min = value; gridCalculator.min = value; redraw(); }
            get { return _min; }
        }

        private double _max;
        public double max
        {
            set { _max = value; gridCalculator.max = value; redraw(); }
            get { return _max; }
        }

        private bool _logScale;
        public bool logScale
        {
            set { _logScale = value; gridCalculator.logScale = value; redraw(); }
            get { return _logScale; }
        }

        private int _openAngle;
        public int openAngle
        {
            set { _openAngle = value; gridCalculator.reScreen(-openAngle / 2, openAngle / 2); redraw(); }
            get { return _openAngle; }
        }

        private Color _frameColor;
        private Pen framePen;
        public Color frameColor
        {
            set { _frameColor = value; framePen = new Pen(_frameColor); redraw(); }
            get { return _frameColor; }
        }
        private Color _fillColor;
        private Brush fillBrush;
        public Color fillColor
        {
            set { _fillColor = value; fillBrush = new SolidBrush(_fillColor); redraw(); }
            get { return _fillColor; }
        }
        private Color _pointColor;
        private Pen pointPen;
        public Color pointColor
        {
            set { _pointColor = value; pointPen = new Pen(_pointColor); redraw(); }
            get { return _pointColor; }
        }

        public enum RTLevelType
        {
            Off = 0,
            Rotary,
            LinearH,
            LinearV
        }
        private RTLevelType _levelType;
        public RTLevelType levelType
        {
            set { _levelType = value; redraw(); }
            get { return _levelType; }
        }

        private GridCalculator gridCalculator;

        public RTLevel()
        {
            _title = "level";
            _titlePos = GraphicsUtil.TextAlignment.left;
            _titleColor = Color.DimGray;
            titleBrush = new SolidBrush(_titleColor);
            _titleFont = new Font(FontFamily.GenericSansSerif, 8);
            _displaySize = new Size(50, 10);
            _valuePos = GraphicsUtil.TextAlignment.below;
            _valueFont = new Font(FontFamily.GenericSansSerif, 8);
            _valueColor = Color.DimGray;
            valueBrush = new SolidBrush(_valueColor);
            _format = "F2";
            _unit = "";
            _value = 0;
            _min = -1;
            _max = 1;
            _openAngle = 150;
            _frameColor = Color.DimGray;
            framePen = new Pen(_frameColor);
            _fillColor = Color.LimeGreen;
            fillBrush = new SolidBrush(_fillColor);
            _pointColor = Color.Red;
            pointPen = new Pen(_pointColor);
            _levelType = RTLevelType.LinearH;
            _logScale = false;
            gridCalculator = new GridCalculator(_min, _max, _logScale, 2 * Vector.V(displaySize).Len);
            gridCalculator.reScreen(-openAngle / 2, openAngle / 2);
                                 
            this.DoubleBuffered = true;
        }

        void getLevelCoords(ref Vector levelCenter, 
            ref GraphicsUtil.TextPosition titlePosition, 
            ref GraphicsUtil.TextPosition valuePosition, 
            ref Vector dim)
        {
            switch (_levelType)
            {
                case RTLevelType.Off:
                    dim = Vector.Zero;
                    break;
                case RTLevelType.LinearH:
                case RTLevelType.LinearV:
                case RTLevelType.Rotary:
                    dim = Vector.V(displaySize)*scale;
                    break;
            }
            GraphicsUtil.TextAlignment ta = _titlePos;
            if ((_title == null) || (_title.Length < 1))
                ta = GraphicsUtil.TextAlignment.off;
            GraphicsUtil.tripleSplit(ClientSize, _displaySize, scale, ref levelCenter, ref titlePosition, ta, ref valuePosition, _valuePos);
        }

        private string getValueString()
        {
            try {
                string fs = string.Format("{{0:{0}}}", _format);
                if ((_unit != null) && (_unit.Length > 0))
                    fs = string.Format("{0} {1}", fs, _unit);
                return string.Format(fs, _value);
            }
            catch (Exception e)
            {
                return "INVALID";
            }
        }

        void drawTo(Graphics g)
        {
            Vector center = Vector.Zero;
            Vector dim = Vector.Zero;
            GraphicsUtil.TextPosition titlePosition = null;
            GraphicsUtil.TextPosition valuePosition = null;

            getLevelCoords(ref center, ref titlePosition, ref valuePosition, ref dim);
            if (titlePosition != null)
                titlePosition.drawText(g, _titleFont, titleBrush, _title);
            if (valuePosition != null)
            {
                string vs = getValueString();
                valuePosition.drawText(g, _valueFont, valueBrush, vs);
            }

            double v = 0;
            try {
                if (_logScale)
                    v = (Math.Log(_value) - Math.Log(_min)) / (Math.Log(_max) - Math.Log(_min));
                else
                    v = (_value - _min) / (_max - _min);
            } catch (Exception e)
            {
                v = 0;
            }

            switch (_levelType)
            {
                case RTLevelType.LinearH:
                    GraphicsUtil.drawHBar(g,  center, dim, v, framePen, fillBrush);
                    break;
                case RTLevelType.LinearV:
                    GraphicsUtil.drawVBar(g, center, dim, v, framePen, fillBrush);
                    break;
                case RTLevelType.Rotary:
                    GraphicsUtil.drawRotor(g, _openAngle, center, dim, v, gridCalculator, framePen, pointPen);
                    break;
            }

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
