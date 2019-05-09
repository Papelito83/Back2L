using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class LedgeGrabState : PlayerMovementState
{ 
    private LedgeGrab ledgeGrabAbility;

    public LedgeGrabState(PlayerMovement playerMovement, LedgeGrab ledgeGrabAbility) : base(playerMovement)
    {
        this.ledgeGrabAbility = ledgeGrabAbility;
    }

    protected override void PerformeTransition(StateMachine machine)
    {
        Action<StateMachine> ledgeGrabExitAction = SelectExitAction();

        if (!ledgeGrabAbility.OnCoolDown())
            ledgeGrabExitAction?.Invoke(machine); 
    }

    private Action<StateMachine> SelectExitAction()
    {
        if (LeaveGoodSide())
            return FallTransition;

        if (Jump())
            return JumpTransition;

        return null;
    }

    private bool LeaveGoodSide()
    {
        float horizontalDirection = Input.GetAxisRaw("Horizontal");

        if (playerMovement.DirectionFlipped() && horizontalDirection < 0)
            return true;

        if (!playerMovement.DirectionFlipped() && horizontalDirection > 0)
            return true;

        return false;
    }

    private void JumpTransition(StateMachine machine)
    {
        ledgeGrabAbility.UnGrab();
        machine.ToMovementState(machine.jumpState);
    }

    private void FallTransition(StateMachine machine)
    {
        ledgeGrabAbility.UnGrab();
        machine.ToMovementState(machine.fallState);
    }

    private bool Jump()
    {
        return JumpKeyPressed;
    }
}

