using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace AudioProcessor
{
    public class DrawColor
    {
        private Color _color;
        private double _width;

        public Pen pen;
        public SolidBrush brush;

        public Color color
        {
            set
            {
                _color = value;
                pen.Color = value;
                brush.Color = value;
            }
            get
            {
                return _color;
            }
        }

        public double width
        {
            set
            {
                _width = value;
                pen.Width = (float)value;
            }
            get
            {
                return _width;
            }
        }

        public DrawColor(Color __color, double __width)
        {
            _color = __color;
            _width = __width;
            pen = new Pen(__color, (float)__width);
            brush = new SolidBrush(__color);
        }

        public DrawColor(Color __color): this(__color,1.0) { }

        public DrawColor() : this(Color.Red, 1.0) { }

         
    }
}
