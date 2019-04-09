using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class GroundState : CharacterState
{
    public GroundState(Character character) : base(character)
    {

    }

    public override void OnEnter()
    {
        base.OnEnter();
    }

    public override void Tick(StateMachine machine)
    {
        HandleMovement();

        if (JumpKeyPressed && character.Grounded)
        {
            machine.ToState(machine.jumpState);
        }
        else if (!character.Grounded)
        {
            machine.ToState(machine.fallState);
        }

        if (DashKeyPressed)
        {
            var dash = character.GetComponent<Dash>();

            if (!dash.OnCooldDown())
                machine.ToState(machine.dashState);
            else
                DashKeyPressed = false;
        }       
    }
}

