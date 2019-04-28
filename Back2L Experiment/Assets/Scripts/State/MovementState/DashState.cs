using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class DashState : PlayerMovementState
{
    private Dash dash;

    public DashState(PlayerMovement playerMovement, Dash dash) : base(playerMovement)
    {
        this.dash = dash;
    }

    public override void OnEnter()
    {
        base.OnEnter();
    }

    public override void Tick(StateMachine machine)
    {
        dash.Started();
        if (dash.Ended())
        {
            if (playerMovement.Grounded)
                machine.ToMovementState(machine.groundState);
            else
                machine.ToMovementState(machine.fallState);
        }
    }
}

