using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class GroundState : PlayerMovementState
{
    public GroundState(PlayerMovement playerMovement) : base(playerMovement)
    {

    }

    public override void OnEnter()
    {
        base.OnEnter();
    }

    public override void Tick(StateMachine machine)
    {
        HandleMovement();

        if (JumpKeyPressed && playerMovement.Grounded)
        {
            machine.ToState(machine.jumpState);
        }
        else if (!playerMovement.Grounded)
        {
            machine.ToState(machine.fallState);
        }

        if (DashKeyPressed)
        {
            var dash = playerMovement.GetComponent<Dash>();

            if (!dash.OnCooldDown())
                machine.ToState(machine.dashState);
            else
                DashKeyPressed = false;
        }       
    }
}

