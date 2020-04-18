using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace AudioProcessor
{

    public class ProcessingNet
    {

        
        

        class ProcessingConnection
        {
            public int i1;
            public int i2;
            public bool selected;

            public GraphicsUtil.BlockConnection bc;

            public ProcessingConnection(int _i1, int _i2)
            {
                i1 = _i1;
                i2 = _i2;
                bc = null;
                selected = false;
            }

            public Boolean Connects(int a1, int a2)
            {
                if (((i1 == a1) && (i2 == a2)) ||
                     ((i1 == a2) && (i2 == a1))) return true;
                return false;
            }

            public Boolean Contains(int a)
            {
                return (i1 == a) || (i2 == a);
            }

            public void IntelliRemove(int i)
            {
                if (i1 == i) throw new Exception("This should never happen...");
                if (i2 == i) throw new Exception("This should never happen...");
                if (i1 > i) i1--;
                if (i2 > i) i2--;
            }

            public int LowNode() { return (i1 < i2) ? i1 : i2; }
            public int HighNode() { return (i1 > i2) ? i1 : i2; }

        }

        // Used in Functions only
        class ProcessingConnectionRef
        {
            public RTIO i1;
            public RTIO i2;
            public int group;
            public ProcessingConnectionRef(RTIO _i1, RTIO _i2)
            {
                i1 = _i1;
                i2 = _i2;
                group = -1;
            }
            public Boolean ConnectedTo(ProcessingConnectionRef q)
            {
                return ((i1 == q.i1) || (i1 == q.i2) || (i2 == q.i1) || (i2 == q.i2));
            }
        }

        SystemPanel owner;
        List<RTIO> connectedIOs;
        List<ProcessingConnection> connections;

        enum ProcessingNetType
        {
            Undefined,
            OneInput,
            Bidirectional    
        }
        ProcessingNetType type;
        Boolean valid;

        private Color _colorBack = Color.Black;
        private Pen penBack;
        public Color colorBack
        {
            set { _colorBack = value; penBack = new Pen(_colorBack,5); }
            get { return _colorBack; }
        }
        private Color _colorLineOk = Color.Blue;
        private Pen penLineOk;
        public Color colorLineOk
        {
            set { _colorLineOk = value; penLineOk = new Pen(_colorLineOk, 3); }
            get { return _colorLineOk; }
        }
        private Color _colorLineBad = Color.Orange;
        private Pen penLineBad;
        public Color colorLineBad
        {
            set { _colorLineBad = value; penLineBad = new Pen(_colorLineBad, 3); }
            get { return _colorLineBad; }
        }
        private Color _colorLineSelected = Color.Red;
        private Pen penLineSelected;
        public Color colorLineSelected
        {
            set { _colorLineSelected = value; penLineSelected = new Pen(_colorLineSelected, 3); }
            get { return _colorLineSelected; }
        }

        public DataBuffer input;
        public DataBuffer output;

        private void init()
        {
            type = ProcessingNetType.Undefined;
            valid = false;

            penBack = new Pen(_colorBack, 5);
            penLineOk = new Pen(_colorLineOk, 3);
            penLineBad = new Pen(_colorLineBad, 3);
            penLineSelected = new Pen(_colorLineSelected, 3);

            input = new DataBuffer(owner.blockSize);
            output = new DataBuffer(owner.blockSize);
        }

        public ProcessingNet(SystemPanel _owner)
        {
            owner = _owner;
            connectedIOs = new List<RTIO>();
            connections = new List<ProcessingConnection>();

            init();
        }

        public ProcessingNet(SystemPanel _owner, BinaryReader src)
        {
            owner = _owner;
            connectedIOs = new List<RTIO>();
            connections = new List<ProcessingConnection>();

            init();
                        
            int cios = src.ReadInt32();
            if (cios < 0)
                throw new Exception("Bad Input File: File corrupt in Net Read");
            for (int i=0;i< cios;i++)
            {
                String elementID = src.ReadString();
                int elementIO = src.ReadInt32();
                RTForm pe = owner.findElement(elementID);
                if (pe == null)
                    throw new Exception("Bad Input File: Linked Element not found");
                List<RTIO> rio = pe.GetIOs();
                if ((elementIO < 0) || (elementIO >= rio.Count))
                    throw new Exception("Bad Input File: Linked Element has not enough IOs");
                rio[elementIO].connectedTo = this;
                connectedIOs.Add(rio[elementIO]);
            }
            int cns = src.ReadInt32();
            if (cns < 0)
                throw new Exception("Bad Input File: File corrupt in Net Read");
            for (int i=0;i< cns;i++)
            {
                int a = src.ReadInt32();
                int b = src.ReadInt32();
                if ((a < 0) || (b < 0) || (a >= connectedIOs.Count) || (a >= connectedIOs.Count))
                    throw new Exception("Bad Input File: File corrupt in Net Read");
                connections.Add(new ProcessingConnection(a, b));
            }
            CheckValidity();
        }

        public void writeToFile(BinaryWriter tgt)
        {
            tgt.Write(connectedIOs.Count);
            for (int i=0;i<connectedIOs.Count;i++)
            {
                tgt.Write(connectedIOs[i].element.uniqueID);
                tgt.Write(connectedIOs[i].element.GetIOId(connectedIOs[i]));
            }
            tgt.Write(connections.Count);
            for (int i=0;i<connections.Count;i++)
            {
                tgt.Write(connections[i].i1);
                tgt.Write(connections[i].i2);
            }
        }

        public void tick()
        {
            output.CopyFrom(input);
            input.zero();
        }

        void CheckValidity()
        {
            int inputs = 0;
            int outputs = 0;
            int bidir = 0;
            for (int i = 0; i < connectedIOs.Count; i++)
            {
                if (connectedIOs[i].type == RTIO.ProcessingIOType.Input)
                    inputs++;
                if (connectedIOs[i].type == RTIO.ProcessingIOType.Output)
                    outputs++;
                if (connectedIOs[i].type == RTIO.ProcessingIOType.Bidirectional)
                    bidir++;
            }
            valid = true;
            if (outputs != 1)
                valid = false;
            if ((inputs > 0) && ((outputs + bidir) == 0))
                valid = false;
        }

        public void addConnection(RTIO IOstart, RTIO IOstop)
        {
            Boolean foundStart = false;
            Boolean foundStop = false;
            int idxStart = -1;
            int idxStop = -1;
            for (int i=0;i<connectedIOs.Count;i++)
            {
                if (connectedIOs[i] == IOstart) { foundStart = true; idxStart = i; }
                if (connectedIOs[i] == IOstop) { foundStop = true; idxStop = i; }
            }
            // Add new connection
            if (!foundStart) { idxStart = connectedIOs.Count; connectedIOs.Add(IOstart); }
            if (!foundStop) { idxStop = connectedIOs.Count; connectedIOs.Add(IOstop); }
            // Check for existing pair
            Boolean exists = false;
            foreach (ProcessingConnection pc in connections)
                if (pc.Connects(idxStart, idxStop)) exists = true;
            if (!exists)
                connections.Add(new ProcessingConnection(idxStart, idxStop));
            if ((IOstart.connectedTo != null) && (IOstart.connectedTo != this))
                throw new Exception("Connnection of two nets - not handled properly!");
            if ((IOstop.connectedTo != null) && (IOstop.connectedTo != this))
                throw new Exception("Connnection of two nets - not handled properly!");
            IOstart.connectedTo = this;
            IOstop.connectedTo = this;

            CheckValidity();
        }

        public void FixGraph()
        {
            // Step 1: Remove unreferenced IOs and unconnected IOs in the connection List
            List<Boolean> referenced = new List<bool>();
            foreach (RTIO io in connectedIOs)
                referenced.Add(false);
            foreach (ProcessingConnection cnct in connections)
            {
                referenced[cnct.i1] = true;
                referenced[cnct.i2] = true;
            }
            int i = 0;
            while (i < referenced.Count)
            {
                if (!referenced[i])
                {
                    connectedIOs[i].connectedTo = null;
                    connectedIOs.RemoveAt(i);
                    referenced.RemoveAt(i);
                    foreach (ProcessingConnection cnct in connections)
                        cnct.IntelliRemove(i);
                }
                else
                    i++;
            }

            // Step 2: Remove already unconnected IOs
            i = 0;
            while (i < connectedIOs.Count)
            {
                if (connectedIOs[i].connectedTo == null)
                { // Found one
                    foreach (ProcessingConnection cnct in connections)
                        cnct.IntelliRemove(i);
                    connectedIOs.RemoveAt(i);
                }
                else
                    i++;
            }

            // Step 3: Check for Valid Net at all
            if (connectedIOs.Count < 2)
            { // less than two nodes --> invalid
                foreach (RTIO pio in connectedIOs)
                    pio.connectedTo = null;
                owner.nets.Remove(this);
                return;
            }

            // Step 4: Check for disconnected Nets
            List<ProcessingConnectionRef> cr = new List<ProcessingConnectionRef>();
            foreach (ProcessingConnection cnct in connections)
                cr.Add(new ProcessingConnectionRef(connectedIOs[cnct.i1], connectedIOs[cnct.i2]));
            for (i = 0; i < cr.Count; i++) cr[i].group = i;
            for (i = 0; i < cr.Count; i++)
                for (int j = 0; j < cr.Count; j++)
                    if (j != i)
                    {
                        if (cr[j].ConnectedTo(cr[i]))
                        {
                            int grp = (cr[i].group < cr[j].group) ? cr[i].group : cr[j].group;
                            cr[i].group = cr[j].group = grp;
                        }
                    }
            List<int> groups = new List<int>();
            foreach (ProcessingConnectionRef c in cr)
                if (groups.IndexOf(c.group) < 0)
                    groups.Add(c.group);
            // Now groups contains the independant list of nets
            if (groups.Count > 1)
            {
                // Must Split
                // Remove all Links first
                foreach (RTIO io in connectedIOs)
                    io.connectedTo = null;

                List<ProcessingNet> newNets = new List<ProcessingNet>();
                foreach (int grp in groups)
                {
                    ProcessingNet pn = new ProcessingNet(owner);
                    foreach (ProcessingConnectionRef c in cr)
                        if (c.group == grp)
                            pn.addConnection(c.i1, c.i2);
                    newNets.Add(pn);
                }
                CopyFrom(newNets[0]);
                CheckValidity();
                newNets.RemoveAt(0);
                foreach (ProcessingNet n in newNets)
                {
                    owner.nets.Add(n);
                    n.CheckValidity();
                }
            }
            else
            {
                // Still one Set --> everything is ok
                CheckValidity();
            }
        }

        public void RemoveIO(RTIO node)
        {
            int idx = connectedIOs.IndexOf(node);
            node.connectedTo = null;
            if (idx < 0) throw new Exception("Bad call");
            int i = 0;
            while (i < connections.Count)
            {
                if (connections[i].Contains(idx))
                    connections.RemoveAt(i);
                else
                    i++;
            }

            FixGraph();            
        }

        // Completely remove Net
        public void Disconnect()
        {
            foreach (RTIO pio in connectedIOs)
                pio.connectedTo = null;
            connectedIOs.Clear();
            connections.Clear();
            owner.nets.Remove(this);
        }

        public void Disconnect(int idx)
        {
            connections.RemoveAt(idx);

            FixGraph();
        }

        public void removeSelectedConnections()
        {
            bool removeAll = true;
            foreach (ProcessingConnection pc in connections)
                if (!pc.selected) removeAll = false;
            if (removeAll)
            {
                Disconnect();
            } else
            {
                for (int i = 0; i < connections.Count; i++)
                    if (connections[i].selected) Disconnect(i);
            }
        }

        public void CopyFrom(ProcessingNet src)
        {
            connectedIOs = src.connectedIOs;
            connections = src.connections;
        }

        public void MergeFrom(ProcessingNet src)
        {
            int ofs = connectedIOs.Count;
            foreach (RTIO sio in src.connectedIOs)
            {
                connectedIOs.Add(sio);
                sio.connectedTo = this;
            }
            foreach (ProcessingConnection sc in src.connections)
            {
                connections.Add(new ProcessingConnection(sc.i1 + ofs, sc.i2 + ofs));
            }
            CheckValidity();
        }

        public void unSelect()
        {
            foreach (ProcessingConnection pc in connections)
                pc.selected = false;
        }

        public void unSelect(int c)
        {
            if (c < 0)
                unSelect();
            else
            {
                if (c < connections.Count)
                    connections[c].selected = false;
            }
        }

        public void doSelect(int net)
        {
            if (net < 0)
            {
                foreach (ProcessingConnection pc in connections)
                    pc.selected = true;
            }
            else
            {
                if (net < connections.Count)
                    connections[net].selected = true;
            }
        }

        public void doSelect()
        {
            doSelect(-1);
        }

        public bool anySelected()
        {
            foreach (ProcessingConnection pc in connections)
                if (pc.selected) return true;
            return false;
        }

        public void updateConnections()
        {
            for (int i = 0; i < connections.Count; i++)
            {
                Vector p1 = Vector.V();
                Vector p2 = Vector.V();
                Vector dir1 = Vector.V();
                Vector dir2 = Vector.V();
                VectorRect R1 = new VectorRect();
                VectorRect R2 = new VectorRect();
                int rank1 = 0, rank2 = 0;
                connectedIOs[connections[i].i1].getPosAndDir(ref p1, ref dir1, ref R1, ref rank1);
                connectedIOs[connections[i].i2].getPosAndDir(ref p2, ref dir2, ref R2, ref rank2);
                if (connections[i].bc == null)
                {
                    connections[i].bc = new GraphicsUtil.BlockConnection(
                        owner.toScreen(p1), dir1, owner.toScreen(R1), (10 + 5 * rank1) * owner.scale,
                        owner.toScreen(p2), dir2, owner.toScreen(R2), (10 + 5 * rank2) * owner.scale);
                }
                else
                {
                    connections[i].bc.A = owner.toScreen(p1);
                    connections[i].bc.B = owner.toScreen(p2);
                    connections[i].bc.VA = owner.toScreen(R1);
                    connections[i].bc.VB = owner.toScreen(R2);
                }
            }
        }

        public void draw(Graphics g)
        {
            updateConnections();
            foreach (ProcessingConnection pc in connections)
            {
                Pen drawpen = null;
                if (pc.selected)
                    drawpen = penLineSelected;
                else
                {
                    if (valid)
                        drawpen = penLineOk;
                    else
                        drawpen = penLineBad;
                }
                pc.bc.draw(g, penBack, drawpen);
            }
        }

        public void selectOnHit(Vector hv, APSelection sel)
        {
            updateConnections();
            Vector ps = owner.toScreen(hv);
            for (int i = 0; i < connections.Count; i++)
            {
                if (connections[i].bc.linedist(ps) < 5)
                    sel.select(this, i);
            }
        }

        public void selectOnContained(VectorRect vr, APSelection sel)
        {
            updateConnections();
            VectorRect v = owner.toScreen(vr);
            for (int i = 0; i < connections.Count; i++)
                if (connections[i].bc.inside(v))
                    sel.select(this, i);
        }
    }
}
