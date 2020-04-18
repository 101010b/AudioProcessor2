using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AudioProcessor
{
    public class RTControl:Control
    {

        protected Vector orgPos;
        protected Vector orgDim;
        protected double scale;
        public bool needsRedraw;

        private bool intentionallyHidden=false;
        public new void Hide()
        {
            intentionallyHidden = true;
            base.Hide();
        }

        public void Shrink(bool doShrink)
        {
            if (doShrink)
            { // Hide
                if (!Visible) return;
                intentionallyHidden = false;
                base.Hide();
            } else
            {
                if (!Visible)
                {
                    if (!intentionallyHidden)
                        Visible = true;
                }
            }
        }

        public RTControl(Control parent, string text, int left, int top, int width, int height):base(parent,text,left,top,width,height)
        {
            orgPos = Vector.V(0, 0);
            orgDim = Vector.V(width, height);
            scale = 1;
            needsRedraw = false;
        }

        public RTControl():this(null,"",0,0,100,100)
        {
        }

        public RTControl(string text):this(null,text,0,0,100,100)
        {
        }

        public RTControl(Control parent, string text):this(parent,text,0,0,100,100)
        {
        }

        public RTControl(string text, int left, int top, int width, int height):this(null,text, left, top, width, height)
        {
        }

        private int anchorX = 0;
        private int anchorY = 0;

        public void setOrg()
        {
            bool anchorleft = ((Anchor & AnchorStyles.Left) != 0);
            bool anchorright = ((Anchor & AnchorStyles.Right) != 0);
            bool anchortop = ((Anchor & AnchorStyles.Top) != 0);
            bool anchorbottom = ((Anchor & AnchorStyles.Bottom) != 0);
            int OWidth = Parent.Width;
            int OHeight = Parent.Height;

            anchorX = -1;
            if (!anchorleft && !anchorright) anchorX = 0;
            else if (anchorleft && !anchorright) anchorX = -1;
            else if (!anchorleft && anchorright) anchorX = 1;
            else anchorX = 0;

            anchorY = -1;
            if (!anchortop && !anchorbottom) anchorY = 0;
            else if (anchortop && !anchorbottom) anchorY = -1;
            else if (!anchortop && anchorbottom) anchorY = 1;
            else anchorY = 0;

            switch (anchorX)
            {
                case -1: orgPos.x = Location.X; break;
                case 0: orgPos.x = Location.X - OWidth / 2; break;
                case 1: orgPos.x = OWidth - Location.X; break;
            }
            switch (anchorY)
            {
                case -1: orgPos.y = Location.Y; break;
                case 0: orgPos.y = Location.Y - OHeight / 2; break;
                case 1: orgPos.y = OHeight - Location.Y; break;
            }
            // orgPos = Vector.V(Location);
            orgDim = Vector.V(Width, Height);
        }

        public void redraw()
        {
            if ((Parent != null) && (Parent is SystemPanel))
            {
                needsRedraw = true;
            } else
            {
                Invalidate();
            }
        }

        public void rescaleFromRoot(double rootscale)
        {
            int OWidth = Parent.Width;
            int OHeight = Parent.Height;
            Width = (int)Math.Floor(orgDim.x * rootscale + 0.5);
            Height = (int)Math.Floor(orgDim.y * rootscale + 0.5);
            Vector abspos = Vector.Zero;
            switch (anchorX)
            {
                case -1: abspos.x = orgPos.x * rootscale; break;
                case 0: abspos.x = OWidth / 2 + orgPos.x*rootscale; break;
                case 1: abspos.x = OWidth - orgPos.x * rootscale; break;
            }
            switch (anchorY)
            {
                case -1: abspos.y = orgPos.y * rootscale; break;
                case 0: abspos.y = OHeight / 2 + orgPos.y * rootscale; break;
                case 1: abspos.y = OHeight - orgPos.y * rootscale; break;
            }
            // Vector abspos = orgPos * rootscale;
            Location = abspos.Point;
            scale = rootscale;
            Invalidate();
        }

        public void forwardOnMouseMove(MouseEventArgs e)
        {
            if ((Parent != null) && (Parent is RTForm p))
            {
                System.Drawing.Point pt = p.PointToClient(PointToScreen(e.Location));
                MouseEventArgs e2 = new MouseEventArgs(e.Button, e.Clicks, pt.X, pt.Y, e.Delta);
                p.ForwardOnMouseMove(e2);
            }
        }

        public void forwardOnMouseUp(MouseEventArgs e)
        {
            if ((Parent != null) && (Parent is RTForm p))
            {
                System.Drawing.Point pt = p.PointToClient(PointToScreen(e.Location));
                MouseEventArgs e2 = new MouseEventArgs(e.Button, e.Clicks, pt.X, pt.Y, e.Delta);
                p.ForwardOnMouseUp(e2);
            }
        }

        public void forwardOnMouseDown(MouseEventArgs e)
        {
            if ((Parent != null) && (Parent is RTForm p))
            {
                System.Drawing.Point pt = p.PointToClient(PointToScreen(e.Location));
                MouseEventArgs e2 = new MouseEventArgs(e.Button, e.Clicks, pt.X, pt.Y, e.Delta);
                p.ForwardOnMouseDown(e2);
            }
        }

        public void forwardOnMouseWheel(MouseEventArgs e)
        {
            if ((Parent != null) && (Parent is RTForm p))
            {
                System.Drawing.Point pt = p.PointToClient(PointToScreen(e.Location));
                MouseEventArgs e2 = new MouseEventArgs(e.Button, e.Clicks, pt.X, pt.Y, e.Delta);
                p.ForwardOnMouseWheel(e2);
            }
        }

    }
}
