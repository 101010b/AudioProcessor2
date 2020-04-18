using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioProcessor
{
    public abstract class RTObjectReference
    {
        public RTObjectReference() { }
        public abstract List<string> GetAddress();
        public abstract RTForm Instantiate();
    }
}
