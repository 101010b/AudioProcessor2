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
    public partial class RTLED : RTControl
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
            Left,
            Right,
            Above,
            Below
        }
        private RTTitlePos _titlePos;
        public RTTitlePos titlePos
        {
            set { _titlePos = value; redraw(); }
            get { return _titlePos; }
        }

        private Color _titleColor;
        public Color titleColor
        {
            set { _titleColor = value; redraw(); }
            get { return _titleColor; }
        }

        private Font _titleFont;
        public Font titleFont
        {
            set { _titleFont = value; redraw(); }
            get { return _titleFont; }
        }

        private Size _LEDDim;
        public Size LEDDim
        {
            set { _LEDDim = value; redraw(); }
            get { return _LEDDim; }
        }

        private string _onText;
        public string onText
        {
            set { _onText = value; redraw(); }
            get { return _onText; }
        }

        private string _offText;
        public string offText
        {
            set { _offText = value; redraw(); }
            get { return _offText; }
        }

        private bool _LEDState;
        public bool LEDState
        {
            set { _LEDState = value; redraw(); }
            get { return _LEDState; }
        }

        private Font _textFont;
        public Font textFont
        {
            set { _textFont = value; redraw(); }
            get { return _textFont; }
        }

        private Color _textOnColor;
        public Color textOnColor
        {
            set { _textOnColor = value; redraw(); }
            get { return _textOnColor; }
        }

        private Color _textOffColor;
        public Color textOffColor
        {
            set { _textOffColor = value; redraw(); }
            get { return _textOffColor; }
        }

        private Color _frameOnColor;
        public Color frameOnColor
        {
            set { _frameOnColor = value; redraw(); }
            get { return _frameOnColor; }
        }

        private Color _frameOffColor;
        public Color frameOffColor
        {
            set { _frameOffColor = value; redraw(); }
            get { return _frameOffColor; }
        }

        private Color _fillOnColor;
        public Color fillOnColor
        {
            set { _fillOnColor = value; redraw(); }
            get { return _fillOnColor; }
        }

        private Color _fillOffColor;
        public Color fillOffColor
        {
            set { _fillOffColor = value; redraw(); }
            get { return _fillOffColor; }
        }


        public RTLED()
        {
            _title = "LED";
            _titlePos = RTTitlePos.Left;
            _titleColor = Color.DimGray;
            _titleFont = new Font(FontFamily.GenericSansSerif, 8);
            _LEDDim = new Size(15, 15);
            _onText = "";
            _offText = "";
            _LEDState = false;
            _textFont = new Font(FontFamily.GenericSansSerif, 8);
            _textOnColor = Color.Red;
            _textOffColor = Color.DimGray;
            _frameOnColor = Color.Red;
            _frameOffColor = Color.DimGray;
            _fillOnColor = Color.DarkRed;
            _fillOffColor = Color.Black;

            // this.DoubleBuffered = true;
        }

        void getLEDCoords(ref Vector center, ref Vector textpos, ref int ax, ref int ay)
        {
            center = Vector.V(Width / 2, Height / 2);
            textpos = center;
            ax = ay = 0;
            if ((_titlePos != RTTitlePos.Off) && (_title != null) && (_title.Length > 0))
            {
                switch (_titlePos)
                {
                    case RTTitlePos.Left:
                        center = Vector.V(Width - (int)Math.Floor(scale * _LEDDim.Width + 0.5) - 1, Height / 2);
                        textpos = center - Vector.V(scale * _LEDDim.Width, 0);
                        ax = 1; ay = 0;
                        break;
                    case RTTitlePos.Right:
                        center = Vector.V((int)Math.Floor(scale * _LEDDim.Width + 0.5) + 1, Height / 2);
                        textpos = center + Vector.V(scale * _LEDDim.Width, 0);
                        ax = -1; ay = 0;
                        break;
                    case RTTitlePos.Above:
                        center = Vector.V(Width / 2, Height - (int)Math.Floor(scale * _LEDDim.Height + 0.5) - 1);
                        textpos = center - Vector.V(0, scale * _LEDDim.Height);
                        ax = 0; ay = -1;
                        break;
                    case RTTitlePos.Below:
                        center = Vector.V(Width / 2, (int)Math.Floor(scale * _LEDDim.Height + 0.5) + 1);
                        textpos = center + Vector.V(0, scale * _LEDDim.Height);
                        ax = 0; ay = 1;
                        break;
                }
            }
        }

        Rectangle getLED()
        {
            Vector center, textpos;
            int ax, ay;
            center = Vector.V();
            textpos = Vector.V();
            ax = ay = 0;
            getLEDCoords(ref center, ref textpos, ref ax, ref ay);
            return VectorRect.FromCenterSize(center, Vector.V(_LEDDim) * scale).rectangle;
        }

        void drawTo(Graphics g)
        {
            // Background
            //Brush brushBackground = new SolidBrush(BackColor);
            // g.FillRectangle(brushBackground, this.ClientRectangle);

            Vector center = Vector.V();
            Vector textpos = Vector.V();
            int ax = 0, ay = 0;
            getLEDCoords(ref center, ref textpos, ref ax, ref ay);
            if ((_titlePos != RTTitlePos.Off) && (_title != null) && (_title.Length > 0))
            {
                Brush titleBrush = new SolidBrush(_titleColor);
                GraphicsUtil.drawText(g, textpos, _titleFont, scale, _title, 0, 2, ax, ay, Vector.V(1, 0), titleBrush);
            }

            Rectangle btnr = VectorRect.FromCenterSize(center, Vector.V(_LEDDim) * scale).rectangle;
            Brush fillBrush = new SolidBrush((_LEDState) ? _fillOnColor : _fillOffColor);
            Pen framePen = new Pen((_LEDState) ? _frameOnColor : _frameOffColor);
            g.FillRectangle(fillBrush, btnr);
            g.DrawRectangle(framePen, btnr);

            if (_LEDState && (_onText != null) && (_onText.Length > 0))
            {
                Brush textBrush = new SolidBrush(_textOnColor);
                GraphicsUtil.drawText(g, center, _textFont, scale, _onText, 0, 2, 0, 0, Vector.V(1, 0), textBrush);
            }
            else if (!_LEDState && (_offText != null) && (_offText.Length > 0))
            {
                Brush textBrush = new SolidBrush(_textOffColor);
                GraphicsUtil.drawText(g, center, _textFont, scale, _offText, 0, 2, 0, 0, Vector.V(1, 0), textBrush);
            }

            // needsRedraw = false;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            // base.OnPaint(pe);
            drawTo(pe.Graphics);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            ((RTForm)Parent).ForwardOnMouseMove(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            ((RTForm)Parent).ForwardOnMouseUp(e);
        }


        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            ((RTForm)Parent).ForwardOnMouseDown(e);
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(e);
            ((RTForm)Parent).ForwardOnMouseWheel(e);
        }

    }
}
