using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class LedgeGrabState : PlayerMovementState
{ 
    private readonly LedgeGrab ledgeGrabAbility;

    public LedgeGrabState(PlayerMovement playerMovement, LedgeGrab ledgeGrabAbility) : base(playerMovement)
    {
        this.ledgeGrabAbility = ledgeGrabAbility;
    }

    protected override void PerformTransition(StateMachine machine)
    {
        var ledgeGrabExitAction = SelectExitAction();

        if (!ledgeGrabAbility.OnCoolDown())
            ledgeGrabExitAction?.Invoke(machine); 
    }

    private Action<StateMachine> SelectExitAction()
    {
        if (LeaveGoodSide() || AttemptToFall())
            return FallTransition;

        if (Jump())
            return JumpTransition;

        return null;
    }

    private bool AttemptToFall()
    {
        float verticalDirection = Input.GetAxisRaw("Vertical");

        if (verticalDirection < 0)
            return true;

        return false;
    }

    private bool LeaveGoodSide()
    {
        var horizontalDirection = Input.GetAxisRaw("Horizontal");

        if (playerMovement.DirectionFlipped() && horizontalDirection < 0)
            return true;

        if (!playerMovement.DirectionFlipped() && horizontalDirection > 0)
            return true;

        return false;
    }

    private void JumpTransition(StateMachine machine)
    {
        ledgeGrabAbility.UnGrab();
        machine.ToMovementState(machine.JumpState);
    }

    private void FallTransition(StateMachine machine)
    {
        ledgeGrabAbility.UnGrab();
        machine.ToMovementState(machine.FallState);
    }

    private bool Jump()
    {
        return JumpKeyPressed;
    }
}

