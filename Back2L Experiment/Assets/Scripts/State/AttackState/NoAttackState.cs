using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class NoAttackState : PlayerAttackState
{
    public NoAttackState(PlayerAttack playerAttack) : base(playerAttack)
    {

    }

    public override void Tick(StateMachine machine)
    {
        Action<StateMachine> attackTransition = SelectAttackTransition();

        attackTransition?.Invoke(machine);
    }

    private Action<StateMachine> SelectAttackTransition()
    {
        if (AttackKeyPressed)
            return MeleeAttackTransition;

        return null;
    }

    private void MeleeAttackTransition(StateMachine machine)
    {
        
    }
}

