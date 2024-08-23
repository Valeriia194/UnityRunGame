using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSM;

namespace FSM
{

    public class State
    {
        public List<StateAction> actions = new List<StateAction>();
        public List<Transition> transitions = new List<Transition>();

        public void PerformActions(BasicAI basicAI)
        {
            foreach (var act in actions)
            {
                act.Perform(basicAI);
            }
        }

        public State GetNextState(BasicAI basicAI)
        {
            foreach (var transition in transitions)
            {
                if (transition.condition.Check(basicAI))
                    return transition.nextState;
            }

            return null;
        }
    }


}
