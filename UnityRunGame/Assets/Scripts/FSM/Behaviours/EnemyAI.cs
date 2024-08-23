using FSM.Conditions;
using FSM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSM
{    public class EnemyAI : BasicAI
    {
        private float attackRadius = 10;

        protected override State GetInitialState()
        {
            State patrol = new State();
            State chase = new State();
            State attack = new State();

            patrol.actions.Add(new GoToSpawnPoint());
            patrol.transitions.Add(new Transition(new RangeCondition(ChaseRadius), chase));

            chase.actions.Add(new SetClosestTarget());
            chase.actions.Add(new GoToTargetAction());
            chase.transitions.Add(new Transition(new ConditionNot(new RangeCondition(ChaseRadius)), patrol));
            chase.transitions.Add(new Transition(new RangeCondition(attackRadius), attack));

            attack.actions.Add(new FireAction());
            attack.actions.Add(new StopAction());
            attack.transitions.Add(new Transition(new ConditionNot(new RangeCondition(attackRadius)), chase));

            return patrol;
        }
    }
}
