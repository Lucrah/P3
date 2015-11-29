using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace i_hate_windows.Helpers
{
    class BoolPropMsg
    {
        public string Prop
        {
            get;
            private set;
        }
        public bool Val
        {
            get;
            private set;
        }
        public BoolPropMsg(string prop, bool val)
        {
            Prop = prop;
            Val = val;
        }
    }
}
