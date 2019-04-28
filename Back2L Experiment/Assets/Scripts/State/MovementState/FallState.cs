using System.Linq;
using UnityEngine;

class FallState : PlayerMovementState
{
    private Animator animator;
    private LedgeDetector ledgeDetector;
    private LedgeGrab ledgeGrabAbility;

    public FallState(PlayerMovement playerMovement, LedgeDetector ledgeDetector, LedgeGrab ledgeGrabAbility) : base(playerMovement)
    {
        animator = playerMovement.GetComponent<Animator>();

        this.ledgeDetector = ledgeDetector;
        this.ledgeGrabAbility = ledgeGrabAbility;
    }

    public override void OnEnter()
    {
        base.OnEnter();

        animator.SetBool("IsFalling", true);
    }

    public override void OnExit()
    {
        animator.SetBool("IsFalling", false);
    }

    public override void Tick(StateMachine machine)
    {
        HandleMovement();
       
        if (playerMovement.Grounded)
            machine.ToMovementState(machine.groundState);

        if (ledgeDetector.DetectWallLedge())
        {
            ledgeGrabAbility.Grab(ledgeDetector.GetWallCollider());
            machine.ToMovementState(machine.ledgeGrabState);
        }

        if(DashKeyPressed)
        {
            var dash = playerMovement.GetComponent<Dash>();

            if(!dash.OnCooldDown())
                machine.ToMovementState(machine.dashState);
        }
    }
}

