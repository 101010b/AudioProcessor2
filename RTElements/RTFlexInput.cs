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
    public partial class RTFlexInput : RTControl
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
        public Color titleColor
        {
            set { _titleColor = value; Invalidate(); }
            get { return _titleColor; }
        }

        private GraphicsUtil.TextAlignment _titlePos;
        public GraphicsUtil.TextAlignment titlePos
        {
            set { _titlePos = value; Invalidate(); }
            get { return _titlePos; }
        }

        private Size _valueSize;
        public Size valueSize
        {
            set { _valueSize = value; Invalidate(); }
            get { return _valueSize; }
        }

        public enum RTFlexInputType
        {
            String=0,
            Integer,
            Float
        }
        private RTFlexInputType _inputType;
        public RTFlexInputType inputType
        {
            set { _inputType = value; Invalidate(); }
            get { return _inputType; }
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

        private double _floatVal;
        public double floatVal
        {
            set { _floatVal = value;Invalidate(); }
            get { return _floatVal; }
        }

        private int _intVal;
        public int intVal
        {
            set { _intVal = value; Invalidate(); }
            get { return _intVal; }
        }

        private string _stringVal;
        public string stringVal
        {
            set { _stringVal = value; Invalidate(); }
            get { return _stringVal; }
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

        private bool _drawFrame;
        public bool drawFrame
        {
            set { _drawFrame = value; Invalidate(); }
            get { return _drawFrame; }
        }

        private Color _frameColor;
        public Color frameColor
        {
            set { _frameColor = value; Invalidate(); }
            get { return _frameColor; }
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

        public event EventHandler valueChanged;

        public RTFlexInput()
        {
            _title = "Input";
            _titleFont = new Font(FontFamily.GenericSansSerif, 8);
            _titleColor = Color.DimGray;
            _titlePos = GraphicsUtil.TextAlignment.above;
            _valueSize = new Size(80, 20);
            _minVal = -1;
            _maxVal = 1;
            _floatVal = 0;
            _intVal = 0;
            _stringVal = "";
            _inputType = RTFlexInputType.String;
            _format = "F2";
            _unit = "";
            _drawFrame = true;
            _frameColor = Color.DimGray;
            _valueColor = Color.DimGray;
            _valueFont = new Font(FontFamily.GenericSansSerif, 8);
        }

        string getFormat()
        {
            if ((_format == null) || (_format.Length < 1))
                return "{0}";
            return string.Format("{{0:{0}}}", _format);
        }

        public class ValueChangedEventArgs : EventArgs
        {
            public RTFlexInputType type;
            public double _floatVal;
            public int _intVal;
            public string _stringVal;
            public int intVal
            {
                get { if (type != RTFlexInputType.Integer) throw new Exception("Bad Data Acces"); return _intVal; }
                set { type = RTFlexInputType.Integer; _intVal = value; }
            }
            public double floatVal
            {
                get { if (type != RTFlexInputType.Float) throw new Exception("Bad Data Access"); return _floatVal; }
                set { type = RTFlexInputType.Float; _floatVal = value; }
            }
            public string stringVal
            {
                get { if (type != RTFlexInputType.String) throw new Exception("Bad Data Access"); return _stringVal; }
                set { type = RTFlexInputType.String; _stringVal = value; }
            }
        }

        public delegate void ValueChangedEventHandler(object sender, ValueChangedEventArgs e);

        void newValue()
        {
            EventHandler handler = valueChanged;
            ValueChangedEventArgs e = new ValueChangedEventArgs();
            switch (_inputType)
            {
                case RTFlexInputType.Integer:
                    e.intVal = _intVal;
                    break;
                case RTFlexInputType.Float:
                    e.floatVal = _floatVal;
                    break;
                case RTFlexInputType.String:
                    e.stringVal = _stringVal;
                    break;
            }
            handler?.Invoke(this, e);
        }

        void drawTo(Graphics g)
        {

            // Background
            //Brush brushBackground = new SolidBrush(BackColor);
            //g.FillRectangle(brushBackground, this.ClientRectangle);

            Vector valueCenter = Vector.V(0, 0);
            GraphicsUtil.TextPosition tpos = new GraphicsUtil.TextPosition();
            GraphicsUtil.dualSplit(ClientSize, _valueSize, scale, ref valueCenter, ref tpos, _titlePos);

            if (_titlePos != GraphicsUtil.TextAlignment.off)
            {
                Brush titleBrush = new SolidBrush(_titleColor);
                tpos.drawText(g, _titleFont, titleBrush, _title);
            }

            Rectangle valueR = VectorRect.FromCenterSize(valueCenter, Vector.V(_valueSize)*scale).rectangle;

            // Frame
            if (_drawFrame)
            {
                Pen framePen = new Pen(_frameColor);
                g.DrawRectangle(framePen, valueR);
                valueR.Inflate(-1, -1);
                g.SetClip(valueR);
            }


            // Value
            Brush textBrush = new SolidBrush(_valueColor);
            String s = "";
            switch (_inputType)
            {
                case RTFlexInputType.String:
                    s = _stringVal;
                    break;
                case RTFlexInputType.Float:
                    s = String.Format(getFormat(), _floatVal);
                    if ((unit != null) && (unit.Length > 0))
                        s = s + " " + unit;
                    break;
                case RTFlexInputType.Integer:
                    s = String.Format("{0}", _intVal);
                    if ((unit != null) && (unit.Length > 0))
                        s = s + " " + unit;
                    break;
            }
            GraphicsUtil.drawText(g, valueCenter, _valueFont, scale, s, 0, 2, 0, 0, Vector.X, textBrush);
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
            if (e.Button != MouseButtons.Left) return;

            Vector valueCenter = Vector.V(0, 0);
            GraphicsUtil.TextPosition tpos = new GraphicsUtil.TextPosition();
            GraphicsUtil.dualSplit(ClientSize, _valueSize, scale, ref valueCenter, ref tpos, _titlePos);
            Rectangle valueR = VectorRect.FromCenterSize(valueCenter, Vector.V(_valueSize)).rectangle;
            if (valueR.Contains(e.Location))
            {
                // Hit in Value
                // Show Value Selector Window
                FlexibleInputWin dw;
                switch (_inputType)
                {
                    case RTFlexInputType.String:
                        dw = new FlexibleInputWin(_title, _stringVal);
                        dw.StartPosition = FormStartPosition.Manual;
                        dw.Location = PointToScreen(new Point(0, 0));
                        dw.ShowDialog();
                        _stringVal = dw.stringValue;
                        break;
                    case RTFlexInputType.Integer:
                        if (_minVal < _maxVal)
                            dw = new FlexibleInputWin(_title,((_unit != null) && (_unit.Length > 0))?_unit:null,(int)_minVal,(int)_maxVal,_intVal);
                        else
                            dw = new FlexibleInputWin(_title, ((_unit != null) && (_unit.Length > 0)) ? _unit : null, _intVal);
                        dw.StartPosition = FormStartPosition.Manual;
                        dw.Location = PointToScreen(new Point(0, 0));
                        dw.ShowDialog();
                        _intVal = dw.intValue;
                        break;
                    case RTFlexInputType.Float:
                        if (_minVal < _maxVal)
                            dw = new FlexibleInputWin(_title, ((_unit != null) && (_unit.Length > 0)) ? _unit : null, _minVal, _maxVal, _floatVal,_format);
                        else
                            dw = new FlexibleInputWin(_title, ((_unit != null) && (_unit.Length > 0)) ? _unit : null, _floatVal,_format);
                        dw.StartPosition = FormStartPosition.Manual;
                        dw.Location = PointToScreen(new Point(0, 0));
                        dw.ShowDialog();
                        _floatVal = dw.floatValue;
                        break;
                }
                newValue();
                Invalidate();
            }
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(e);
            forwardOnMouseWheel(e);
        }



    }
}
