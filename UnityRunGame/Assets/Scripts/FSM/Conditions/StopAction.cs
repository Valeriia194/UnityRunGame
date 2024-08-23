using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSM.Conditions
{
    public class StopAction : StateAction
    {
        public override void Perform(BasicAI basicAI)
        {
            basicAI.NavMeshAgent.destination = basicAI.transform.position;
        }
    }
}
