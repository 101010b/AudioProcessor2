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
    public partial class RTSelector : RTControl
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

        private int _xdim;
        public int xdim
        {
            set { _xdim = value; Invalidate(); }
            get { return _xdim; }
        }

        private Font _textFont;
        public Font textFont
        {
            set { _textFont = value; Invalidate(); }
            get { return _textFont; }
        }

        private Color _textColor;
        public Color textColor
        {
            set { _textColor = value; Invalidate(); }
            get { return _textColor; }
        }

        private Color _frameColor;
        public Color frameColor
        {
            set { _frameColor = value; Invalidate(); }
            get { return _frameColor; }
        }

        private List<string> _entries;
        public List<string> entries
        {
            set { _entries = value; Invalidate(); }
            get {
                if (_entries == null)
                    _entries = new List<string>();
                return _entries;
            }
        }

        private int _selectedItem;
        public int selectedItem
        {
            set
            {
                if ((entries == null) || (entries.Count == 0))
                {
                    _selectedItem = -1;
                } else
                {
                    if ((value < 0) || (value >= entries.Count))
                        _selectedItem = -1;
                    else
                        _selectedItem = value;
                }
                Invalidate();
            } 
            get { return _selectedItem; }
        }

        public event EventHandler selectionStateChanged;

        public RTSelector()
        {
            _title = "Selector";
            _titleColor = Color.DimGray;
            _titleFont = new Font(FontFamily.GenericSansSerif, 8);
            _xdim = 50;
            _textColor = Color.White;
            _frameColor = Color.DimGray;
            _textFont = new Font(FontFamily.GenericSansSerif, 8);
            _entries = new List<string>();
            // _entries.Add("Test");
            // _entries.Add("Test2");
            // _entries.Add("Test löksdfölksdpofj+ß0349ufßq9jfvoüsjefß0");

            // this.DoubleBuffered = true;
        }

        public class ButtonStateChangedEventArgs : EventArgs
        {
            public int val { get; set; }
        }

        public delegate void ButtonStateChangedEventHandler(object sender, ButtonStateChangedEventArgs e);

        void newValue(int selval)
        {
            EventHandler handler = selectionStateChanged;
            ButtonStateChangedEventArgs e = new ButtonStateChangedEventArgs();
            e.val = selval;
            handler?.Invoke(this, e);
        }

        void newValue()
        {
            newValue(_selectedItem);
        }

        Rectangle getSelFrame()
        {
            Rectangle r = ClientRectangle;
            int ofs = Width - (int)Math.Floor(scale * _xdim);
            r.Location = new Point(r.Location.X + ofs, r.Location.Y);
            r.Width -= ofs + 1;
            r.Height -= 1;
            return r;
        }

        void drawTo(Graphics g)
        {
            // Background
            // Brush brushBackground = new SolidBrush(BackColor);
            // g.FillRectangle(brushBackground, this.ClientRectangle);

            Pen framePen = new Pen(_frameColor);
            Rectangle r = getSelFrame();
            g.DrawRectangle(framePen, r);
            if ((_title != null) && (_title.Length > 0))
            {
                Brush tBrush = new SolidBrush(_titleColor);
                GraphicsUtil.drawText(g, Vector.V(r.Left, Height / 2), _titleFont, scale, _title, 0, 2, 1, 0, Vector.V(1, 0), tBrush);
            }
            if ((entries != null) && (entries.Count > 0) && (selectedItem >= 0) && (selectedItem < entries.Count))
            {
                string s = entries[selectedItem];
                Brush textBrush = new SolidBrush(_textColor);
                r.Width -= 2;
                r.Height -= 2;
                r.Location = new Point(r.Location.X + 1, r.Location.Y + 1);
                g.SetClip(r);
                GraphicsUtil.drawText(g, Vector.V(r.Left, Height / 2), _textFont, scale, s, 0, 2, -1, 0, Vector.V(1, 0), textBrush);
            }
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            // base.OnPaint(pe);
            drawTo(pe.Graphics);
        }

        /*public enum DragMode
        {
            Idle = 0,
            Holding
        }*/

        // private DragMode dragMode;

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
            if (Enabled)
            {
                Rectangle r = getSelFrame();
                if (r.Contains(e.Location))
                {
                    if ((entries != null) && (entries.Count > 0))
                    {
                        SelectorInputWin sin = new SelectorInputWin(this, _title, _entries, _selectedItem);
                        sin.StartPosition = FormStartPosition.Manual;
                        sin.Location = PointToScreen(new Point(r.Left, 0));
                        sin.ShowDialog();
                        _selectedItem = sin.selection;
                        newValue();
                        Invalidate();
                    }
                }
                else
                    forwardOnMouseDown(e);
            }
        }

    }
}
