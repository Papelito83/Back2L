using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class WallJumpState : PlayerMovementState
{
    public WallJumpState(PlayerMovement playerMovement) : base(playerMovement)
    {

    }

    public override void OnEnter()
    {
        base.OnEnter();

        playerMovement.WallJump();
    }

    protected override void PerformeTransition(StateMachine machine)
    {
        HandleMovement();

        if (playerMovement.Grounded)
            machine.ToMovementState(machine.groundState);

        if (playerMovement.IsFalling())
            machine.ToMovementState(machine.fallState);
    }
}
