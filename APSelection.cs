using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioProcessor
{
    public class APSelection
    {
        private List<RTForm> forms;
        private List<ProcessingNet> nets;

        public int items
        {
            get { return ((forms != null) ? forms.Count : 0) + ((nets != null) ? nets.Count : 0); }
        }

        public APSelection()
        {
            forms = new List<RTForm>();
            nets = new List<ProcessingNet>();
        }

        public void select(RTForm f)
        {
            if (f == null) return;
            if (forms.Contains(f)) return;
            forms.Add(f);
            f.selected = true;
        }

        public void select(ProcessingNet n)
        {
            if (n == null) return;
            if (nets.Contains(n)) return;
            nets.Add(n);
            n.doSelect();
        }

        public void select(ProcessingNet n, int connection)
        {
            if (n == null) return;
            if (!nets.Contains(n)) 
                nets.Add(n);
            n.doSelect(connection);
        }

        public void unselect(RTForm f)
        {
            if (f == null) return;
            if (!forms.Contains(f)) return;
            forms.Remove(f);
            f.selected = false;
        }

        public void unselect(ProcessingNet n)
        {
            if (n == null) return;
            if (!nets.Contains(n)) return;
            nets.Remove(n);
            n.unSelect();
            // n.selected = false;
        }

        public void unselect(ProcessingNet n, int connection)
        {
            if (n == null) return;
            if (!nets.Contains(n)) return;
            n.unSelect(connection);
            if (!n.anySelected())
                nets.Remove(n);
        }

        public void unselect()
        {
            foreach (RTForm r in forms)
                r.selected = false;
            foreach (ProcessingNet n in nets)
                n.unSelect(); //  n.selected = false;
            forms.Clear();
            nets.Clear();
        }

        public bool selected(RTForm r)
        {
            if (r == null) return false;
            return forms.Contains(r);
        }

        public bool selected(ProcessingNet n)
        {
            if (n == null) return false;
            return nets.Contains(n);
        }

        public void removeConnections()
        {
            foreach (ProcessingNet n in nets)
                n.removeSelectedConnections();
            nets.Clear();
        }

        public void removeElements()
        {
            foreach (RTForm f in forms)
                f.owner.DeleteElement(f);
            forms.Clear();
        }

        public void initateMove(RTForm rootmover)
        {
            foreach (RTForm r in forms)
            {
                if (r != rootmover)
                    r.initiateMove();
            }
        }

        public void temporaryMove(RTForm rootmover, Vector delta)
        {
            foreach (RTForm r in forms)
            {
                if (r != rootmover)
                    r.temporaryMove(delta);
            }
        }

        public void finalizeMove(RTForm rootmover, Vector delta)
        {
            foreach (RTForm r in forms)
            {
                if (r != rootmover)
                    r.finalizeMove(delta);
            }
        }

        public ProcessingNet getNet(int i)
        {
            if ((i < 0) || (nets == null) || (i >= nets.Count)) return null;
            return nets[i];
        }

        public RTForm getElement(int i)
        {
            if ((i < 0) || (forms == null) || (i >= forms.Count)) return null;
            return forms[i];
        }

    }
}
