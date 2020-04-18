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
    public partial class RTButton : RTControl
    {

        public enum RTButtonType
        {
            ClickButton = 0,
            ToggleButton,
            HoldButton
        }

        private RTButtonType _buttonType;
        public RTButtonType buttonType
        {
            set { _buttonType = value; Invalidate(); }
            get { return _buttonType; }
        }

        private String _title;
        public string title
        {
            set { _title = value; Invalidate(); }
            get { return _title; }
        }

        public enum RTTitlePos
        {
            Off = 0,
            Left,
            Right,
            Above,
            Below
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

        private Size _buttonDim;
        public Size buttonDim
        {
            set { _buttonDim = value; Invalidate(); }
            get { return _buttonDim; }
        }

        private string _onText;
        public string onText
        {
            set { _onText = value; Invalidate(); }
            get { return _onText; }
        }

        private string _offText;
        public string offText
        {
            set { _offText = value; Invalidate(); }
            get { return _offText; }
        }

        private bool _buttonState;
        public bool buttonState
        {
            set { _buttonState = value; Invalidate(); }
            get { return _buttonState; }
        }

        private Font _textFont;
        public Font textFont
        {
            set { _textFont = value; Invalidate(); }
            get { return _textFont; }
        }

        private Color _textOnColor;
        public Color textOnColor
        {
            set { _textOnColor = value; Invalidate(); }
            get { return _textOnColor; }
        }

        private Color _textOffColor;
        public Color textOffColor
        {
            set { _textOffColor = value; Invalidate(); }
            get { return _textOffColor; }
        }

        private Color _frameOnColor;
        public Color frameOnColor
        {
            set { _frameOnColor = value; Invalidate(); }
            get { return _frameOnColor; }
        }

        private Color _frameHoldColor;
        public Color frameHoldColor
        {
            set { _frameHoldColor = value; Invalidate(); }
            get { return _frameHoldColor; }
        }


        private Color _frameOffColor;
        public Color frameOffColor
        {
            set { _frameOffColor = value; Invalidate(); }
            get { return _frameOffColor; }
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
                     
        public event EventHandler buttonStateChanged;
        private bool holdState;

        public RTButton()
        {
            _buttonType = RTButtonType.ClickButton;
            _title = "Button";
            _titlePos = RTTitlePos.Left;
            _titleColor = Color.DimGray;
            _titleFont = new Font(FontFamily.GenericSansSerif, 8);
            _buttonDim = new Size(30, 15);
            _onText = "On";
            _offText = "Off";
            _buttonState = false;
            _textFont = new Font(FontFamily.GenericSansSerif, 8);
            _textOnColor = Color.Red;
            _textOffColor = Color.DimGray;
            _frameOnColor = Color.Red;
            _frameHoldColor = Color.Yellow;
            _frameOffColor = Color.DimGray;
            _fillOnColor = Color.DarkRed;
            _fillOffColor = Color.Black;
            holdState = false;

            // this.DoubleBuffered = true;
        }

        public class ButtonStateChangedEventArgs : EventArgs
        {
            public bool on { get; set; }
        }

        public delegate void ButtonStateChangedEventHandler(object sender, ButtonStateChangedEventArgs e);

        void newValue(bool state)
        {
            EventHandler handler = buttonStateChanged;
            ButtonStateChangedEventArgs e = new ButtonStateChangedEventArgs();
            e.on = state;
            handler?.Invoke(this, e);
        }

        void newValue()
        {
            newValue(_buttonState);
        }

        void getButtonCoords(ref Vector center, ref Vector textpos, ref int ax, ref int ay)
        {
            center = Vector.V(Width / 2, Height / 2);
            textpos = center;
            ax = ay = 0;
            if ((_titlePos != RTTitlePos.Off) && (_title != null) && (_title.Length > 0))
            {
                switch (_titlePos)
                {
                    case RTTitlePos.Left:
                        center = Vector.V(Width - (int)Math.Floor(scale * _buttonDim.Width + 0.5) - 1, Height / 2);
                        textpos = center - Vector.V(scale * _buttonDim.Width, 0);
                        ax = 1; ay = 0;
                        break;
                    case RTTitlePos.Right:
                        center = Vector.V((int)Math.Floor(scale * _buttonDim.Width + 0.5) + 1, Height / 2);
                        textpos = center + Vector.V(scale * _buttonDim.Width, 0);
                        ax = -1; ay = 0;
                        break;
                    case RTTitlePos.Above:
                        center = Vector.V(Width / 2, Height - (int)Math.Floor(scale * _buttonDim.Height + 0.5) - 1);
                        textpos = center - Vector.V(0, scale * _buttonDim.Height);
                        ax = 0; ay = -1;
                        break;
                    case RTTitlePos.Below:
                        center = Vector.V(Width / 2, (int)Math.Floor(scale * _buttonDim.Height + 0.5) + 1);
                        textpos = center + Vector.V(0, scale * _buttonDim.Height);
                        ax = 0; ay = 1;
                        break;
                }
            }
        }

        Rectangle getButton()
        {
            Vector center, textpos;
            int ax, ay;
            center = Vector.V();
            textpos = Vector.V();
            ax = ay = 0;
            getButtonCoords(ref center, ref textpos, ref ax, ref ay);
            return VectorRect.FromCenterSize(center, Vector.V(_buttonDim)*scale).rectangle;
        }

        void drawTo(Graphics g)
        {
            // Background
            Brush brushBackground = new SolidBrush(BackColor);
            g.FillRectangle(brushBackground, this.ClientRectangle);

            Vector center = Vector.V();
            Vector textpos = Vector.V();
            int ax=0, ay=0;
            getButtonCoords(ref center, ref textpos, ref ax, ref ay);
            if ((_titlePos != RTTitlePos.Off) && (_title != null) && (_title.Length > 0))
            {
                Brush titleBrush = new SolidBrush(_titleColor);
                GraphicsUtil.drawText(g, textpos, _titleFont, scale, _title, 0, 2, ax, ay, Vector.V(1, 0), titleBrush);
            }

            Rectangle btnr = VectorRect.FromCenterSize(center, Vector.V(_buttonDim)*scale).rectangle;
            Brush fillBrush = new SolidBrush((_buttonState) ? _fillOnColor : _fillOffColor);
            Pen framePen = new Pen((holdState) ? _frameHoldColor : ((_buttonState) ? _frameOnColor : _frameOffColor));
            g.FillRectangle(fillBrush, btnr);
            g.DrawRectangle(framePen, btnr);

            if (_buttonState && (_onText != null) && (_onText.Length > 0))
            {
                Brush textBrush = new SolidBrush(_textOnColor);
                GraphicsUtil.drawText(g, center, _textFont, scale, _onText, 0, 2, 0, 0, Vector.V(1, 0), textBrush);
            } else if (!_buttonState && (_offText != null) && (_offText.Length > 0))
            {
                Brush textBrush = new SolidBrush(_textOffColor);
                GraphicsUtil.drawText(g, center, _textFont, scale, _offText, 0, 2, 0, 0, Vector.V(1, 0), textBrush);
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

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (dragMode == DragMode.Holding)
            {
                Rectangle rbtn = getButton();
                if (rbtn.Contains(e.Location))
                {
                    if (!holdState)
                    {
                        holdState = true;
                        if (_buttonType == RTButtonType.HoldButton)
                        {
                            _buttonState = true;
                            newValue(true);
                        }
                        Invalidate();
                    }
                }
                else
                {
                    if (holdState)
                    {
                        holdState = false;
                        if (_buttonType == RTButtonType.HoldButton)
                        {
                            _buttonState = false;
                            newValue(false);
                        }
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
                Rectangle rbtn = getButton();
                switch (_buttonType)
                {
                    case RTButtonType.ClickButton:
                        if (rbtn.Contains(e.Location))
                        {
                            newValue(true);
                        }
                        _buttonState = false;
                        break;
                    case RTButtonType.ToggleButton:
                        if (rbtn.Contains(e.Location))
                        {
                            _buttonState = !_buttonState;
                            newValue(_buttonState);
                        }
                        break;
                    case RTButtonType.HoldButton:
                        _buttonState = false;
                        if (holdState)
                            newValue(false);
                        break;
                }
                holdState = false;
                Invalidate();
            }
            else
                forwardOnMouseUp(e);
        }


        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            Rectangle rbtn = getButton();
            if (rbtn.Contains(e.Location))
            {
                dragMode = DragMode.Holding;
                holdState = true;
                if (_buttonType == RTButtonType.HoldButton)
                {
                    _buttonState = true;
                    newValue(true);
                }
                Invalidate();
            } else
                forwardOnMouseDown(e);
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(e);
            forwardOnMouseWheel(e);
        }



    }
}
