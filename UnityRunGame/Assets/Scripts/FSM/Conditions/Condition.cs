using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSM
{
    public abstract class Condition
    {
        public abstract bool Check(BasicAI basicAI);
    }
}
