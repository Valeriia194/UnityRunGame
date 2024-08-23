using FSM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace FSM.Conditions
{
    public class RangeCondition : Condition
    {
        public float radius;
        public RangeCondition(float radius)
        {
            this.radius = radius;
        }

        public override bool Check(BasicAI basicAI)
        {
            var targets = Physics.OverlapSphere(basicAI.transform.position, radius ,basicAI.TargetLayerMask);
            return targets.Length != 0;
        }
    }
}
