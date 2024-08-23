using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSM
{
    public abstract class StateAction
    {
        public abstract void Perform(BasicAI basicAI);
    }
}
