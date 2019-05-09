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
        animator.SetBool("IsFalling", true);
    }

    public override void OnExit()
    {
        animator.SetBool("IsFalling", false);
    }

    protected override void PerformeTransition(StateMachine machine)
    {
        HandleMovement();

        playerMovement.WallSlide();

        if (playerMovement.Grounded)
            machine.ToMovementState(machine.groundState);

        if (ledgeDetector.DetectWallLedge())
        {
            ledgeGrabAbility.Grab(ledgeDetector.GetWallCollider());
            machine.ToMovementState(machine.ledgeGrabState);
        }

        if (playerMovement.Walled && JumpKeyPressed)
        {
            machine.ToMovementState(machine.wallJumpState);
        }

        if (DashKeyPressed)
        {
            var dash = playerMovement.GetComponent<Dash>();

            if(!dash.OnCooldDown())
                machine.ToMovementState(machine.dashState);
        }
    }
}

