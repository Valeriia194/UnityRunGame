using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace FSM
{
    public class SetClosestTarget : StateAction
    {
        public override void Perform(BasicAI basicAI)
        {
            var targets = Physics.OverlapSphere(basicAI.transform.position, basicAI.ChaseRadius, basicAI.TargetLayerMask);
            if (targets.Length != 0)
            {
                basicAI.Target = targets[0].transform;
            }
        }
    }
}
