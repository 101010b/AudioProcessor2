using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace AudioProcessor
{
    public class GraphicsUtil
    {

        public class TextPosition
        {
            public Vector anchor;
            public int ax, ay;
            public int bx;
            public double spacing;
            public Vector dir;
            public double scale;

            public TextPosition(Vector _anchor, double _scale, int _bx, double _spacing, int _ax, int _ay, Vector _dir)
            {
                anchor = _anchor;
                bx = _bx;
                spacing = _spacing;
                ax = _ax;
                ay = _ay;
                dir = _dir;
                scale = _scale;
            }

            public TextPosition(Vector _anchor, double _scale, int _ax, int _ay) : this(_anchor, _scale, 0, 2, _ax, _ay, Vector.X)
            {
            }

            public TextPosition(Vector _anchor, int _ax, int _ay) : this(_anchor, 1, 0, 2, _ax, _ay, Vector.X)
            {
            }

            public TextPosition(Vector _anchor, double _scale) : this(_anchor, _scale, 0, 2, 0, 0, Vector.X)
            {
            }

            public TextPosition(Vector _anchor) : this(_anchor, 1, 0, 2, 0, 0, Vector.X)
            {
            }

            public TextPosition() : this(Vector.Zero, 1, 0,2,0,0,Vector.X)
            {
            }

            public void drawText(Graphics g, Font f, Brush b, string s)
            {
                GraphicsUtil.drawText(g, anchor, f, scale, s, bx, spacing, ax, ay, dir, b);
            }

        }

        public enum TextAlignment
        {
            off,above, below, left, right
        }

        public static void dualSplit(Size frame, Size fixedElement, double scale, ref Vector fixedCenter, ref TextPosition tpos, TextAlignment texto)
        {
            Vector dim = Vector.V(fixedElement)*scale;
            Vector frm = Vector.V(frame);
            switch (texto)
            {
                case TextAlignment.off:
                    fixedCenter = frm / 2;
                    tpos = null;
                    break;
                case TextAlignment.above:
                    fixedCenter = Vector.V(frm.x/2, frm.y - 1-dim.y/2);
                    tpos = new TextPosition(fixedCenter - Vector.V(0, dim.y / 2), scale, 0, -1);
                    break;
                case TextAlignment.below:
                    fixedCenter = Vector.V(frm.x / 2, dim.y / 2);
                    tpos = new TextPosition(fixedCenter + Vector.V(0, dim.y / 2), scale, 0, 1);
                    break;
                case TextAlignment.left:
                    fixedCenter = Vector.V(frm.x - 1 - dim.x / 2, frm.y / 2);
                    tpos = new TextPosition(fixedCenter - Vector.V(dim.x / 2, 0), scale, 1, 0);
                    break;
                case TextAlignment.right:
                    fixedCenter = Vector.V(dim.x / 2, frm.y / 2);
                    tpos = new TextPosition(fixedCenter + Vector.V(dim.x / 2, 0), scale, -1, 0);
                    break;
            }
        }

        public enum DualTextAlignment
        {
            AboveRight, RightBelow, BelowLeft, LeftAbove,
            AboveBelow, LeftRight
        }

        private static void tripleSplitRel(Size frame, Size fixedElement, double scale, ref Vector fixedCenter, ref TextPosition T1, ref TextPosition T2, DualTextAlignment DA)
        {
            Vector dim = Vector.V(fixedElement)*scale;
            Vector frm = Vector.V(frame);
            switch (DA)
            {
                case DualTextAlignment.AboveRight:
                    fixedCenter = Vector.V(0, frm.y - 1) + Vector.V(dim.x / 2, -dim.y/2);
                    T1 = new TextPosition(fixedCenter - Vector.V(0, dim.y / 2), scale, 0, -1);
                    T2 = new TextPosition(fixedCenter + Vector.V(dim.x/2, 0), scale, -1, 0);
                    break;
                case DualTextAlignment.RightBelow:
                    fixedCenter = Vector.V(0, 0) + dim / 2;
                    T1 = new TextPosition(fixedCenter + Vector.V(dim.x / 2, 0), scale, -1, 0);
                    T2 = new TextPosition(fixedCenter + Vector.V(0, dim.y / 2), scale, 0, 1);
                    break;
                case DualTextAlignment.BelowLeft:
                    fixedCenter = Vector.V(frm.x - 1, 0) + Vector.V(-dim.x / 2,dim.y/2);
                    T1 = new TextPosition(fixedCenter + Vector.V(0, dim.y / 2), scale, 0, 1);
                    T2 = new TextPosition(fixedCenter + Vector.V(-dim.x / 2, 0), scale, 1, 0);
                    break;
                case DualTextAlignment.LeftAbove:
                    fixedCenter = Vector.V(frm.x - 1, frm.y - 1) - dim / 2;
                    T1 = new TextPosition(fixedCenter - Vector.V(dim.x / 2, 0), scale, 1, 0);
                    T2 = new TextPosition(fixedCenter - Vector.V(0, dim.y / 2), scale, 0, -1);
                    break;
                case DualTextAlignment.AboveBelow:
                    fixedCenter = Vector.V(frm.x / 2, frm.y / 2);
                    T1 = new TextPosition(fixedCenter - Vector.V(0, dim.y / 2), scale, 0, -1);
                    T2 = new TextPosition(fixedCenter + Vector.V(0, dim.y / 2), scale, 0, 1);
                    break;
                case DualTextAlignment.LeftRight:
                    fixedCenter = Vector.V(frm.x / 2, frm.y / 2);
                    T1 = new TextPosition(fixedCenter - Vector.V(dim.x / 2, 0), scale, 1, 0);
                    T2 = new TextPosition(fixedCenter + Vector.V(dim.x / 2, 0), scale, -1, 0);
                    break;
            }
        }

        public static void tripleSplit(Size frame, Size fixedElement, double scale, ref Vector fixedCenter, ref TextPosition tpos1, TextAlignment texto1, ref TextPosition tpos2, TextAlignment texto2)
        {
            if ((texto1 == TextAlignment.off) && (texto2 == TextAlignment.off)) {
                fixedCenter = Vector.V(frame) / 2;
                tpos1 = tpos2 = null;
                return;
            }
            if (texto1 == TextAlignment.off)
            {
                // Only the second text
                tpos1 = null;
                dualSplit(frame, fixedElement, scale, ref fixedCenter, ref tpos2, texto2);
                return;
            }
            if (texto2 == TextAlignment.off)
            {
                // Only the first text
                tpos2 = null;
                dualSplit(frame, fixedElement, scale, ref fixedCenter, ref tpos1, texto1);
                return;
            }
            if (texto1 == texto2)
            {
                // Illegal setting
                // Show only the first text
                tpos2 = null;
                dualSplit(frame, fixedElement, scale, ref fixedCenter, ref tpos1, texto1);
                return;
            }

            switch (texto1)
            {
                case TextAlignment.above:
                    switch (texto2)
                    {
                        case TextAlignment.below:
                            tripleSplitRel(frame, fixedElement, scale, ref fixedCenter, ref tpos1, ref tpos2, DualTextAlignment.AboveBelow);
                            break;
                        case TextAlignment.left:
                            tripleSplitRel(frame, fixedElement, scale, ref fixedCenter, ref tpos2, ref tpos1, DualTextAlignment.LeftAbove);
                            break;
                        case TextAlignment.right:
                            tripleSplitRel(frame, fixedElement, scale, ref fixedCenter, ref tpos1, ref tpos2, DualTextAlignment.AboveRight);
                            break;
                    }
                    break;
                case TextAlignment.below:
                    switch (texto2)
                    {
                        case TextAlignment.above:
                            tripleSplitRel(frame, fixedElement, scale, ref fixedCenter, ref tpos2, ref tpos1, DualTextAlignment.AboveBelow);
                            break;
                        case TextAlignment.left:
                            tripleSplitRel(frame, fixedElement, scale, ref fixedCenter, ref tpos1, ref tpos2, DualTextAlignment.BelowLeft);
                            break;
                        case TextAlignment.right:
                            tripleSplitRel(frame, fixedElement, scale, ref fixedCenter, ref tpos2, ref tpos1, DualTextAlignment.RightBelow);
                            break;
                    }
                    break;
                case TextAlignment.left:
                    switch (texto2)
                    {
                        case TextAlignment.above:
                            tripleSplitRel(frame, fixedElement, scale, ref fixedCenter, ref tpos1, ref tpos2, DualTextAlignment.LeftAbove);
                            break;
                        case TextAlignment.below:
                            tripleSplitRel(frame, fixedElement, scale, ref fixedCenter, ref tpos2, ref tpos1, DualTextAlignment.BelowLeft);
                            break;
                        case TextAlignment.right:
                            tripleSplitRel(frame, fixedElement, scale, ref fixedCenter, ref tpos1, ref tpos2, DualTextAlignment.LeftRight);
                            break;
                    }
                    break;
                case TextAlignment.right:
                    switch (texto2)
                    {
                        case TextAlignment.above:
                            tripleSplitRel(frame, fixedElement, scale, ref fixedCenter, ref tpos2, ref tpos1, DualTextAlignment.AboveRight);
                            break;
                        case TextAlignment.below:
                            tripleSplitRel(frame, fixedElement, scale, ref fixedCenter, ref tpos1, ref tpos2, DualTextAlignment.RightBelow);
                            break;
                        case TextAlignment.left:
                            tripleSplitRel(frame, fixedElement, scale, ref fixedCenter, ref tpos2, ref tpos1, DualTextAlignment.LeftRight);
                            break;
                    }
                    break;
            }


        }



        /* drawText - Draws Text to a Graphics Display
         * Not Self-Explaining Parameters
         * bx = Text Block Align - if multiple Lines, text can be aligned to left (-1), center (0) and right (1)
         * ax = Horizontal Text Align: left (-1), center (0), right (1)
         * ay = Vertical Text Align: bottom (-1), center (0), top (1)
         *      +-------------+-------------+   ay =  1
         *      + T E X T I N S I D E B O X +   ay =  0
         *      +-------------+-------------+   ay = -1 
         *    ax = -1      ax = 0        ax = 1
         * space = Additional space around Text in Pixels
         * dir = x-Vector for rotation (provide "new Vector(1,0)" for horizontal Text
         */

        private static GraphicsPath gp;

        public static VectorBox drawText(Graphics g, Vector pos, Font f, double scale, string txt, int bx, double space, int ax, int ay, Vector dir, Brush brush)
        {
            if (txt == null) return new VectorBox(pos, new Vector(0,0), new Vector(0,0));
            if (dir.Len == 0) dir = new Vector(1, 0);
            txt = txt.Replace('|', '\n');

            if (gp == null)
                gp = new GraphicsPath();
            else
                gp.Reset();
            //GraphicsPath gp = new GraphicsPath();

            // String Internal Alignment
            StringFormat sf = new StringFormat();
            if (bx < 0)
                sf.Alignment = StringAlignment.Near;
            else if (bx > 0)
                sf.Alignment = StringAlignment.Far;
            else
                sf.Alignment = StringAlignment.Center;

            gp.AddString(txt, f.FontFamily, (int) f.Style, f.Height, new PointF(0, 0), sf);

            RectangleF bb = gp.GetBounds();
            bb.Inflate(new SizeF((float)space, (float)space));
            // gp.Reset();

            double w = bb.Width;
            double h = bb.Height;
            double cx = bb.Left + w / 2;
            double cy = bb.Top + h / 2;

            Matrix mtx = new Matrix();
            mtx.Translate((float)-cx, (float)-cy); // Center

            VectorBox vb = new VectorBox();
            vb.X = new Vector(bb.Width, 0);
            vb.Y = new Vector(0, bb.Height);
            vb.pos = -vb.X/2-vb.Y/2;

            if (ax < 0)
            {
                mtx.Translate((float)w / 2, 0, MatrixOrder.Append);
                vb.translate(new Vector(w / 2, 0));
            }
            else if (ax > 0)
            {
                mtx.Translate((float)-w / 2, 0, MatrixOrder.Append);
                vb.translate(new Vector(-w / 2, 0));
            }

            if (ay < 0)
            {
                mtx.Translate(0, (float)-h / 2, MatrixOrder.Append);
                vb.translate(new Vector(0, -h / 2));
            }
            else if (ay > 0)
            {
                mtx.Translate(0, (float)h / 2, MatrixOrder.Append);
                vb.translate(new Vector(0, h / 2));
            }

            // Rotate 
            mtx.Rotate((float)(dir.Phi * 180 / Math.PI), MatrixOrder.Append);
            // mtx.Rotate((float)dir.Phi, MatrixOrder.Append);
            vb.rot(dir.Phi);

            mtx.Scale((float)scale, (float)scale, MatrixOrder.Append);
            vb.scale(scale);

            // Translate to final position
            mtx.Translate((float)pos.x, (float)pos.y, MatrixOrder.Append);
            vb.translate(pos);

            // Do the Translate
            gp.Transform(mtx);

            SmoothingMode md = g.SmoothingMode;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.FillPath(brush, gp);
            g.SmoothingMode = md;

            // gp.Dispose();

            return vb;

        }

        // Just simulate Rendering an return the size Box
        public static VectorBox sizeText(Vector pos, Font f, double scale, string txt, int bx, double space, int ax, int ay, Vector dir)
        {
            if (txt == null) return new VectorBox(pos, new Vector(0, 0), new Vector(0, 0));
            if (dir.Len == 0) dir = new Vector(1, 0);
            txt = txt.Replace('|', '\n');

            if (gp == null)
                gp = new GraphicsPath();
            else
                gp.Reset();
            // GraphicsPath gp = new GraphicsPath();

            // String Internal Alignment
            StringFormat sf = new StringFormat();
            if (bx < 0)
                sf.Alignment = StringAlignment.Near;
            else if (bx > 0)
                sf.Alignment = StringAlignment.Far;
            else
                sf.Alignment = StringAlignment.Center;

            gp.AddString(txt, f.FontFamily, (int)f.Style, f.Height, new PointF(0, 0), sf);

            RectangleF bb = gp.GetBounds();
            bb.Inflate(new SizeF((float)space, (float)space));

            double w = bb.Width;
            double h = bb.Height;
            double cx = bb.Left + w / 2;
            double cy = bb.Top + h / 2;

            Matrix mtx = new Matrix();
            mtx.Translate((float)-cx, (float)-cy); // Center

            VectorBox vb = new VectorBox();
            vb.X = new Vector(bb.Width, 0);
            vb.Y = new Vector(0, bb.Height);
            vb.pos = -vb.X / 2 - vb.Y / 2;

            if (ax < 0)
            {
                mtx.Translate((float)w / 2, 0, MatrixOrder.Append);
                vb.translate(new Vector(w / 2, 0));
            }
            else if (ax > 0)
            {
                mtx.Translate((float)-w / 2, 0, MatrixOrder.Append);
                vb.translate(new Vector(-w / 2, 0));
            }

            if (ay < 0)
            {
                mtx.Translate(0, (float)-h / 2, MatrixOrder.Append);
                vb.translate(new Vector(0, -h / 2));
            }
            else if (ay > 0)
            {
                mtx.Translate(0, (float)h / 2, MatrixOrder.Append);
                vb.translate(new Vector(0, h / 2));
            }

            // Rotate 
            mtx.Rotate((float)(dir.Phi*180/Math.PI), MatrixOrder.Append);
            vb.rot(dir.Phi);

            mtx.Scale((float)scale, (float)scale, MatrixOrder.Append);
            vb.scale(scale);

            // Translate to final position
            mtx.Translate((float)pos.x, (float)pos.y, MatrixOrder.Append);
            vb.translate(pos);

            // gp.Dispose();


            return vb;

        }

        public static VectorBox sizeText(Font f, double scale, string txt, int bx, double space, int ax, int ay, Vector dir)
        {
            return sizeText(Vector.Zero, f, scale, txt, bx, space, ax, ay, dir);
        }

        public static VectorBox sizeText(Font f, double scale, string txt, double space, int ax, int ay, Vector dir)
        {
            return sizeText(Vector.Zero, f, scale, txt, ax, space, ax, ay, dir);
        }

        public static VectorBox sizeText(Font f, string txt, int bx, double space, int ax, int ay, Vector dir)
        {
            return sizeText(Vector.Zero, f, 1, txt, bx, space, ax, ay, dir);
        }

        public static VectorBox sizeText(Font f, string txt, double space, int ax, int ay, Vector dir)
        {
            return sizeText(Vector.Zero, f, 1, txt, ax, space, ax, ay, dir);
        }

        public static VectorBox sizeText(Font f, string txt, int bx, double space, int ax, int ay)
        {
            return sizeText(Vector.Zero, f, 1, txt, bx, space, ax, ay, Vector.X);
        }

        public static VectorBox sizeText(Font f, string txt, double space, int ax, int ay)
        {
            return sizeText(Vector.Zero, f, 1, txt, ax, space, ax, ay, Vector.X);
        }

        public static void drawRoundedRect(Graphics g, RectangleF rf, float rad, Pen penOutline, Brush brushFill)
        {
            if (gp == null)
                gp = new GraphicsPath();
            else
                gp.Reset();
            // GraphicsPath gp = new GraphicsPath();
            gp.AddArc(rf.Left, rf.Top,                                  2.0F * rad, 2.0F * rad, 180, 90);
            gp.AddArc(rf.Right - 2.0F * rad, rf.Top,                    2.0F * rad, 2.0F * rad, 270, 90);
            gp.AddArc(rf.Right - 2.0F * rad, rf.Bottom - 2.0F * rad,    2.0F * rad, 2.0F * rad, 0, 90);
            gp.AddArc(rf.Left,               rf.Bottom - 2.0F * rad,    2.0F * rad, 2.0F * rad, 90, 90);
            gp.CloseFigure();
            if (brushFill != null)
                g.FillPath(brushFill, gp);
            if (penOutline != null)
                g.DrawPath(penOutline, gp);
            // gp.Dispose();
        }

        public static void drawArrow(Graphics g, Vector from, Vector to, Pen p)
        {
            Vector v = to - from;
            Vector right = v.vrot90();
            g.DrawLine(p, from.Point, to.Point);
            g.DrawLine(p, to.Point, (to - v * 0.4 + right * 0.2).Point);
            g.DrawLine(p, to.Point, (to - v * 0.4 - right * 0.2).Point);
        }

        public static void drawDoubleArrow(Graphics g, Vector from, Vector to, Pen p)
        {
            Vector v = to - from;
            Vector right = v.vrot90();
            g.DrawLine(p, (from+0.05*right).Point, (to+0.05*right).Point);
            g.DrawLine(p, (from-0.05*right).Point, (to-0.05*right).Point);
            g.DrawLine(p, (to+0.05*right).Point, (to - v * 0.4 + right * 0.2).Point);
            g.DrawLine(p, (to-0.05*right).Point, (to - v * 0.4 - right * 0.2).Point);
        }

        public static void drawTriangle(Graphics g, Vector center, double size, Vector direction, Pen p)
        {
            Vector A = center + direction * size / 2;
            Vector B = center + direction.vrot(Math.PI * 2 / 3) * size / 2;
            Vector C = center + direction.vrot(-Math.PI * 2 / 3) * size / 2;
            Point[] plist = new Point[4];
            plist[0] = A.Point;
            plist[1] = B.Point;
            plist[2] = C.Point;
            plist[3] = plist[0];
            g.DrawLines(p, plist);
        }

        public static void drawHBar(Graphics g, Vector center, Vector dim, double grade, Pen framePen, Brush fillBrush)
        {
            if (double.IsNaN(grade) || double.IsInfinity(grade))
                grade = 0;
            if (grade < 0) grade = 0;
            if (grade > 1.0) grade = 1.0;
            Rectangle r = VectorRect.FromPointSize(center-dim/2, dim).rectangle;
            Rectangle rf = VectorRect.FromPointSize(center - dim / 2,Vector.V(grade * dim.x, dim.y)).rectangle;
            g.FillRectangle(fillBrush, rf);
            g.DrawRectangle(framePen, r);
        }

        public static void drawVBar(Graphics g, Vector center, Vector dim, double grade, Pen framePen, Brush fillBrush)
        {
            if (double.IsNaN(grade) || double.IsInfinity(grade))
                grade = 0;
            if (grade < 0) grade = 0;
            if (grade > 1.0) grade = 1.0;
            Rectangle r = VectorRect.FromPointSize(center-dim/2, dim).rectangle;
            Rectangle rf = VectorRect.FromPointSize(center + Vector.V(-dim.x / 2, -dim.y/2+(1-grade)*dim.y), Vector.V(dim.x, grade *dim.y)).rectangle;
            g.FillRectangle(fillBrush, rf);
            g.DrawRectangle(framePen, r);
        }

        public static void drawArc(Graphics g, Vector center, double phi1, double phi2, double r, Pen p)
        {
            RectangleF rf = VectorRect.FromCenterSize(center, Vector.V(2 * r, 2 * r)).rectangleF;
            phi1 = -phi1;
            phi2 = -phi2;
            if (phi1 > phi2)
            {
                double temp = phi1;
                phi1 = phi2;
                phi2 = temp;
            }
            g.DrawArc(p, rf, (float)(phi1*180/Math.PI), (float)((phi2 - phi1)*180/Math.PI));
        }

        public static void drawLine(Graphics g, Vector start, Vector stop, Pen p)
        {
            g.DrawLine(p, start.PointF, stop.PointF);
        }

        public static void drawCircle(Graphics g, Vector ctr, double r, Pen p)
        {
            g.DrawEllipse(p, (float)(ctr.x - r), (float)(ctr.y - r), (float)(2 * r), (float)(2 * r));
        }

        public static void fillCircle(Graphics g, Vector ctr, double r, Brush b)
        {
            g.FillEllipse(b, (float)(ctr.x - r), (float)(ctr.y - r), (float)(2 * r), (float)(2 * r));
        }

        public static void drawRotor(Graphics g, double openAngle, 
            Vector center, Vector dim, double grade, GridCalculator grid, Pen framePen, Pen linePen)
        {
            g.SetClip(VectorRect.FromCenterSize(center, dim).rectangle);
            if (double.IsNaN(grade) || double.IsInfinity(grade))
                grade = 0;
            if (grade < 0) grade = 0;
            if (grade > 1.0) grade = 1.0;
            double phi0 = (90 + openAngle / 2) * Math.PI / 180;
            double phi1 = (90 - openAngle / 2) * Math.PI / 180;
            double a = 0.3;
            double rad = (dim.y-1) / (1.0 - a * Math.Sin(phi1));
            Vector rotc = center + Vector.V(0, rad-(dim.y-1) / 2);
            drawArc(g, rotc, phi0, phi1, rad, framePen);
            drawArc(g, rotc, phi0, phi1, rad*a, framePen);
            double phid = phi1 + grade * (phi0 - phi1);
            if (grid != null)
            {
                for (int i = 0; i < grid.gridLength; i++)
                {
                    double alpha = -Math.PI/2 + grid.grid[i].screen*Math.PI/180;
                    Vector vout = Vector.V(rad, 0).rot(alpha);
                    Vector vin = Vector.V(rad * ((grid.grid[i].isMajor) ? (0.8) : (0.9)), 0).rot(alpha);
                    drawLine(g,rotc + vin, rotc + vout, framePen);
                }
            }
            drawLine(g, rotc - Vector.V(rad * a, 0).rot(phid), rotc - Vector.V(rad*0.95, 0).rot(phid), linePen);
            drawLine(g, rotc - Vector.V(rad * a, 0).rot(phi0), rotc - Vector.V(rad, 0).rot(phi0), framePen);
            drawLine(g, rotc - Vector.V(rad * a, 0).rot(phi1), rotc - Vector.V(rad, 0).rot(phi1), framePen);
            g.ResetClip();
        }

        public enum ButtonType
        {
            Empty = 0,
            Delete,
            Shrink,
            Expand,
            Active,
            InActive
        }

        public static void drawButton(Graphics g, Rectangle r, ButtonType btype, Pen framePen, Pen symbolPen)
        {
            g.DrawRectangle(framePen, r);
            Vector center = Vector.V(r);
            Vector X = Vector.X * r.Width / 2;
            Vector Y = -Vector.Y * r.Height / 2;
            switch (btype)
            {
                case ButtonType.Empty: break;
                case ButtonType.Delete:
                    drawLine(g, center  + (X + Y) * 0.8, center + (X + Y) * (-0.8), symbolPen);
                    drawLine(g, center + (X - Y) * 0.8, center + (Y - X) * 0.8, symbolPen);
                    break;
                case ButtonType.Shrink:
                    drawArrow(g, center + (X + Y) * 0.9, center + (X + Y) * 0.1, symbolPen);
                    drawArrow(g, center + (X + Y) * (-0.9), center + (X + Y) * (-0.1), symbolPen);
                    break;
                case ButtonType.Expand:
                    drawArrow(g, center + (X + Y) * 0.1, center + (X + Y) * 0.9, symbolPen);
                    drawArrow(g, center + (X + Y) * (-0.1), center + (X + Y) * (-0.9), symbolPen);
                    break;
                case ButtonType.Active:
                    drawLine(g, center + X * (-0.9), center + X * (-0.3), symbolPen);
                    drawLine(g, center + X * (-0.3), center + X * (-0.3) + (X*0.7).rot(-10*Math.PI/180), symbolPen);
                    drawLine(g, center + X * (0.3) + Vector.X * r.Height/10, center + X * (0.9), symbolPen);
                    drawCircle(g, center + X * (0.3), r.Height / 10, symbolPen);
                    break;
                case ButtonType.InActive:
                    drawLine(g, center + X * (-0.9), center + X * (-0.3), symbolPen);
                    drawLine(g, center + X * (-0.3), center + X * (-0.3) + (X * 0.7).rot(-35 * Math.PI / 180), symbolPen);
                    drawLine(g, center + X * (0.3) + Vector.X * r.Height / 10, center + X * (0.9), symbolPen);
                    drawCircle(g, center + X * (0.3), r.Height / 10, symbolPen);
                    break;
            }
        }

        public class BlockConnection
        {

            private Vector _A;
            public Vector A
            {
                set { if (_A != value) valid = false; _A = value;}
                get { return _A; }
            }

            private Vector _Adir;
            public Vector Adir
            {
                set { if (_Adir != value) valid = false; _Adir = value; }
                get { return _Adir; }
            }

            private Vector _B;
            public Vector B
            {
                set { if (_B != value) valid = false; _B = value; }
                get { return _B; }
            }

            private Vector _Bdir;
            public Vector BDir
            {
                set { if (_Bdir != value) valid = false; _Bdir = value; }
                get { return _Bdir; }
            }

            private VectorRect _VA;
            public VectorRect VA
            {
                set { if (_VA != value) valid = false; _VA = value; }
                get { return _VA; }
            }
            private VectorRect _VB;
            public VectorRect VB
            {
                set { if (_VB != value) valid = false; _VB = value; }
                get { return _VB; }
            }
            private double _stdgapA;
            public double stdgapA
            {
                set { if (_stdgapA != value) valid = false; _stdgapA = value; }
                get { return _stdgapA; }
            }
            private double _stdgapB;
            public double stdgapB
            {
                set { if (_stdgapB != value) valid = false; _stdgapB = value; }
                get { return _stdgapB; }
            }

            private bool valid;
            private VectorPath pointlist;

            public BlockConnection()
            {
                _A = Vector.V(1, 0);
                _B = Vector.V(-1, 0);
                _Adir = Vector.V(1, 0);
                _Bdir = Vector.V(-1, 0);
                _VA = VectorRect.Empty;
                _VB = VectorRect.Empty;
                _stdgapA = 20;
                _stdgapB = 20;
                valid = false;
            }

            public BlockConnection(
                Vector __A, Vector __Adir, VectorRect __VA, double __stdgapA,
                Vector __B, Vector __Bdir, VectorRect __VB, double __stdgapB)
            {
                _A = __A;
                _B = __B;
                _Adir = __Adir;
                _Bdir = __Bdir;
                _VA = __VA;
                _VB = __VB;
                _stdgapA = __stdgapA;
                _stdgapB = __stdgapB;
                valid = false;
            }

            public BlockConnection(Vector __A, Vector __B) :
                this(__A, Vector.Zero, VectorRect.Empty, 20, __B, Vector.Zero, VectorRect.Empty, 20)
            {
            }

            public BlockConnection(Vector __A, double __stdgapA, Vector __B, double __stdgapB) :
                this(__A, Vector.Zero, VectorRect.Empty, __stdgapA, __B, Vector.Zero, VectorRect.Empty, __stdgapB)
            {
            }

            public BlockConnection(Vector __A, Vector __Adir, Vector __B, Vector __Bdir) :
                this(__A, __Adir, VectorRect.Empty, 20, __B, __Bdir, VectorRect.Empty, 20)
            {
            }

            public BlockConnection(Vector __A, Vector __Adir, double __stdgapA, Vector __B, Vector __Bdir, double __stdgapB) :
                this(__A, __Adir, VectorRect.Empty, __stdgapA, __B, __Bdir, VectorRect.Empty, __stdgapB)
            {
            }

            public BlockConnection(Vector __A, Vector __Adir, VectorRect __VA, Vector __B, Vector __Bdir, VectorRect __VB) :
                this(__A, __Adir, __VA, 20, __B, __Bdir, __VB, 20)

            {
            }

            public void draw(Graphics g, Pen pback, Pen pfront)
            {
                if (!valid || pointlist == null)
                {
                    Pen q = new Pen(Color.Gray);
                    calcConnection(g, q);
                }
                if (!valid || pointlist == null)
                    return;

                Point[] pl = new Point[pointlist.Count];
                for (int i = 0; i < pl.Count(); i++)
                    pl[i] = pointlist.list[i].Point;
                g.DrawLines(pback, pl);
                g.DrawLines(pfront, pl);
            }




            private void fallback()
            {
                if (_A == _B) return; // This is no line
                pointlist = new VectorPath();
                pointlist.addPoint(_A);
                if (_Adir.nonZero)
                    pointlist.addPoint(_A + _Adir * _stdgapA);
                if (_Bdir.nonZero)
                    pointlist.addPoint(_B + _Bdir * _stdgapB);
                pointlist.addPoint(_B);
                valid = true;
            }

            private void tracePath(int from, int to, List<VectorLine> lines, List<VectorPath> vp, VectorPath start, List<int> startl)
            {
                if (from == to)
                {
                    // On the final line
                    VectorPath ep = new VectorPath(start);
                    ep.addPoint(lines[to].B);
                    vp.Add(ep);
                    return;
                }

                // Check for intersections
                for (int i = 0; i < lines.Count; i++)
                    if ((i != from) && (startl.IndexOf(i) < 0))
                    {
                        Vector ip = Vector.Zero;
                        if (VectorLine.intersect(lines[from], lines[i], ref ip)) {
                            // Lines intersect!
                            bool isavalidline = true;
                            if (isavalidline && (startl.Count > 1) && _VA.nonZero && _VA.inside(ip)) isavalidline = false;
                            if (isavalidline && _VB.nonZero && _VB.inside(ip)) isavalidline = false;
                            VectorLine nl = new VectorLine(start.list.Last(), ip, VectorLine.LineType.AB);
                            if (isavalidline && (startl.Count > 1) && _VA.nonZero && _VA.Intersects(nl)) isavalidline = false;
                            if (isavalidline && _VB.nonZero && _VB.Intersects(nl)) isavalidline = false;
                            if (isavalidline)
                            {
                                VectorPath ep = new VectorPath(start);
                                List<int> startlx = new List<int>(startl);
                                startlx.Add(i);
                                ep.addPoint(ip);
                                tracePath(i, to, lines, vp, ep, startlx);
                            }
                        }
                    }
            }

            private void findPath(int from, int to, List<VectorLine> lines, List<VectorPath> vp)
            {
                VectorPath tp = new VectorPath();
                List<int> startl = new List<int>();
                tp.addPoint(lines[from].A);
                startl.Add(from);
                tracePath(from, to, lines, vp, tp,startl);
            }
            
            private VectorPath findPath(int[] from, int [] to, List<VectorLine> lines)
            {
                List<VectorPath> vp = new List<VectorPath>();
                for (int i = 0; i < from.Length; i++)
                    for (int j = 0; j < to.Length; j++)
                        findPath(from[i], to[j], lines, vp);
                if (vp.Count < 1)
                    return null;
                int shortest = 0;
                int shortl = vp[0].Count;
                double shortd = vp[0].length;
                for (int i=1;i<vp.Count;i++)
                {
                    int l = vp[i].Count;
                    double ld = vp[i].length;
                    if ((l < shortl) || ((l == shortl) && (ld < shortd)))
                    {
                        shortl = l;
                        shortd = ld;
                        shortest = i;
                    }  
                }
                return vp[shortest];
            }

            private void calcConnection(Graphics g, Pen q)
            {
                try
                {
                    if (_A == _B) return; // No Line
                    /*
                    VectorLine LA = new VectorLine(new Vector(0, 20), new Vector(10, 20), VectorLine.LineType.Infinite);
                    VectorLine LB = new VectorLine(new Vector(10, 0), new Vector(10, 50), VectorLine.LineType.Infinite);
                    Vector ip = Vector.Zero;
                    VectorLine.intersect(LA, LB, ref ip);
                    */

                    List<VectorLine> vl = new List<VectorLine>();
                    int[] sp;
                    int[] ep;
                    if (_Adir.isZero)
                    {
                        sp = new int[4] { vl.Count, vl.Count+1, vl.Count+2, vl.Count+3 };
                        vl.Add(new VectorLine(_A, _A + Vector.X, VectorLine.LineType.AInf));
                        vl.Add(new VectorLine(_A, _A - Vector.X, VectorLine.LineType.AInf));
                        vl.Add(new VectorLine(_A, _A + Vector.Y, VectorLine.LineType.AInf));
                        vl.Add(new VectorLine(_A, _A - Vector.Y, VectorLine.LineType.AInf));
                    }
                    else
                    {
                        Vector p = _A + _Adir * _stdgapA;
                        sp = new int[1] { vl.Count };
                        vl.Add(new VectorLine(_A, p, VectorLine.LineType.AInf));
                        //vl.Add(new VectorLine(p, p + _Adir, VectorLine.LineType.AInf));
                        //vl.Add(new VectorLine(p, p + _Adir.vrot90(), VectorLine.LineType.AInf));
                        //vl.Add(new VectorLine(p, p + _Adir.vrot270(), VectorLine.LineType.AInf));
                    }
                    if (_Bdir.isZero)
                    {
                        ep = new int[4] { vl.Count, vl.Count + 1, vl.Count + 2, vl.Count +3 };
                        vl.Add(new VectorLine(_B - Vector.X, _B, VectorLine.LineType.InfB));
                        vl.Add(new VectorLine(_B - Vector.X, _B, VectorLine.LineType.InfB));
                        vl.Add(new VectorLine(_B - Vector.Y, _B, VectorLine.LineType.InfB));
                        vl.Add(new VectorLine(_B - Vector.Y, _B, VectorLine.LineType.InfB));
                    }
                    else
                    {
                        Vector p = _B + _Bdir * _stdgapB;
                        ep = new int[1] { vl.Count };
                        vl.Add(new VectorLine(p, _B, VectorLine.LineType.InfB));
                        //vl.Add(new VectorLine(p, p + _Bdir, VectorLine.LineType.AInf));
                        //vl.Add(new VectorLine(p, p + _Bdir.vrot90(), VectorLine.LineType.AInf));
                        //vl.Add(new VectorLine(p, p + _Bdir.vrot270(), VectorLine.LineType.AInf));
                    }
                    if (_VA.nonZero)
                    {
                        // Add four Lines surrounding the rectangle
                        vl.Add(_VA.LineAbove(_stdgapA));
                        vl.Add(_VA.LineBelow(_stdgapA));
                        vl.Add(_VA.LineLeft(_stdgapA));
                        vl.Add(_VA.LineRight(_stdgapA));
                    }
                    if (_VB.nonZero && (_VB == _VA))
                        _VB = new VectorRect();
                    if (_VB.nonZero)
                    {
                        // Add four Lines surrounding the rectangle
                        vl.Add(_VB.LineAbove(_stdgapB));
                        vl.Add(_VB.LineBelow(_stdgapB));
                        vl.Add(_VB.LineLeft(_stdgapB));
                        vl.Add(_VB.LineRight(_stdgapB));
                    }
                    
                    /*
                    for (int i=0;i<vl.Count;i++)
                    {
                        vl[i].draw(g, q);
                    }                    
                    for (int i=0;i<vl.Count-1;i++)
                        for (int j=i+1;j<vl.Count;j++)
                        {
                            Vector vi = Vector.Zero;
                            if (VectorLine.intersect(vl[i],vl[j],ref vi))
                            {
                                g.DrawEllipse(q, VectorRect.FromCenterSize(vi, Vector.V(6, 6)).rectangle);
                            }
                        }
                    */    

                    VectorPath vp = findPath(sp, ep, vl);
                    if (vp != null)
                    {
                        pointlist = vp;
                        valid = true;
                    }
                    else 
                        fallback();
                }
                catch (Exception e)
                {
                    fallback();
                }
            }

            public double linedist(Vector v)
            {
                if (!valid || pointlist == null)
                {
                    Pen q = new Pen(Color.Gray);
                    calcConnection(null,null);
                }
                if (!valid || pointlist == null)
                    return 1e9;
                return pointlist.linedist(v);
            }

            public bool inside(VectorRect vr)
            {
                return pointlist.inside(vr);
            }



        }

    }
}
