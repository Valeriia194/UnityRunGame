using FSM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSM.Conditions
{
    public class ConditionNot : Condition
    {
        public Condition other;


        public ConditionNot(Condition other)
        {
            this.other = other;
        }

        public override bool Check(BasicAI basicAI)
        {
            return !other.Check(basicAI);
        }
    }
}
