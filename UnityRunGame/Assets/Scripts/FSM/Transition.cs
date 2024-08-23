using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSM;

namespace FSM
{
    public class Transition
    {
        public Condition condition;
        public State nextState;

        public Transition(Condition condition, State nextState)
        {
            this.condition = condition;
            this.nextState = nextState;
        }
    }
}
