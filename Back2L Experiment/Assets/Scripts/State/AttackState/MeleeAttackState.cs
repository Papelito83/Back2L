using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class MeleeAttackState : PlayerAttackState
{
    public MeleeAttackState(PlayerAttack playerAttack) : base(playerAttack)
    {
    }

    public override void Tick(StateMachine machine)
    {
        
    }
}

