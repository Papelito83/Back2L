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

    public override void OnEnter()
    {
        base.OnEnter();
    }

    public override void Tick(StateMachine machine)
    {
        Action<StateMachine> ledgeGrabExitAction = SelectExitAction();

        if (!ledgeGrabAbility.OnCoolDown())
            ledgeGrabExitAction?.Invoke(machine); 
    }

    private Action<StateMachine> SelectExitAction()
    {
        if (LeaveGoodSide())
            return FallTransition;

        /*if (Input.GetAxisRaw("Vertical") > 0)
            return ClimbTransition;*/

        if (JumpKeyPressed)
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

    /*private void ClimbTransition(StateMachine machine)
    {
        ledgeGrabAbility.Climb();
        machine.ToMovementState(machine.fallState);
    }
    */
}

