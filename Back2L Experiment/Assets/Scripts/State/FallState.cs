using System.Linq;
using UnityEngine;

class FallState : PlayerMovementState
{
    private LedgeDetector ledgeDetector;
    private LedgeGrab ledgeGrabAbility;

    public FallState(PlayerMovement playerMovement, LedgeDetector ledgeDetector, LedgeGrab ledgeGrabAbility) : base(playerMovement)
    {
        this.ledgeDetector = ledgeDetector;
        this.ledgeGrabAbility = ledgeGrabAbility;
    }

    public override void OnEnter()
    {
        base.OnEnter();
    }

    public override void Tick(StateMachine machine)
    {
        HandleMovement();
       
        if (playerMovement.Grounded)
            machine.ToState(machine.groundState);

        if (ledgeDetector.DetectWallLedge())
        {
            ledgeGrabAbility.Grab(ledgeDetector.GetWallCollider());
            machine.ToState(machine.ledgeGrabState);
        }

        if(DashKeyPressed)
        {
            var dash = playerMovement.GetComponent<Dash>();

            if(!dash.OnCooldDown())
                machine.ToState(machine.dashState);
        }
    }
}

