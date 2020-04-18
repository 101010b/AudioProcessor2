using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioProcessor
{
    public class VectorPath
    {
        public List<Vector> list;

        public VectorPath()
        {
            list = null;
        }

        public VectorPath(VectorPath vp)
        {
            list = new List<Vector>(vp.list.Count);
            for (int i = 0; i < vp.list.Count; i++)
                list.Add(vp.list[i]);
        }

        public int Count
        {
            get { return (list == null) ? 0 : list.Count; }
        }

        public bool isEmpty
        {
            get { return (list == null) || (list.Count < 2); }
        }

        public double length
        {
            get { return getLength(); }
        }

        public double getLength()
        {
            if ((list == null) || (list.Count < 2)) return 0;
            double l = 0;
            for (int i = 0; i < list.Count - 1; i++)
                l += (list[i + 1] - list[i]).Len;
            return l;
        }

        public void addPoint(Vector v)
        {
            if (list == null)
                list = new List<Vector>();
            if (list.Count == 0)
            {
                list.Add(v);
                return;
            }
            if (list.Last() != v)
                list.Add(v);
        }

        public double linedist(Vector v)
        {
            if ((list == null) || (list.Count < 1)) return 1e99;
            double mindist = (v - list[0]).Len;
            for (int i=1;i<list.Count;i++)
            {
                double pd = (v - list[i]).Len;
                if (pd < mindist) mindist = pd;
                pd = Vector.lineDist(list[i - 1], list[i], v);
                if (pd < mindist) mindist = pd;
            }
            return mindist;
        }

        public bool inside(VectorRect vr)
        {
            if ((list == null) || (list.Count < 1)) return false;
            foreach (Vector v in list)
                if (!vr.inside(v)) return false;
            return true;
        }

    }
}
