using FSM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSM
{
    public class FireAction : StateAction
    {
        public override void Perform(BasicAI basicAI)
        {
            //basicAI.WeaponController.FireProjectile();
        }
    }
}
