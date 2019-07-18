using System.Linq;
using JetBrains.Annotations;
using UnityEngine;

class FallState : PlayerMovementState
{
    private readonly Animator animator;
    private readonly CharacterLedgeDetector ledgeDetector;
    private readonly LedgeGrab ledgeGrabAbility;
    private static readonly int IsFalling = Animator.StringToHash("IsFalling");

    public FallState(PlayerMovement playerMovement, CharacterLedgeDetector ledgeDetector, LedgeGrab ledgeGrabAbility) : base(playerMovement)
    {
        animator = playerMovement.GetComponent<Animator>();

        this.ledgeDetector = ledgeDetector;
        this.ledgeGrabAbility = ledgeGrabAbility;
    }

    public override void OnEnter()
    {
        animator.SetBool(IsFalling, true);
    }

    public override void OnExit()
    {
        animator.SetBool(IsFalling, false);
    }

    protected override void PerformTransition(StateMachine machine)
    {
        HandleMovement();

        playerMovement.WallSlide();

        if (playerMovement.Grounded)
            machine.ToMovementState(machine.GroundState);

        if (ledgeDetector.DetectWallLedge())
        {
            var collider = ledgeDetector.GetWallCollider();
            ledgeGrabAbility.Grab(collider);
            machine.ToMovementState(machine.LedgeGrabState);
        }

        if (DashKeyPressed)
        {
            var dash = playerMovement.GetComponent<Dash>();

            if (!dash.OnCooldDown())
                machine.ToMovementState(machine.DashState);
        }

        if (playerMovement.Walled && JumpKeyPressed)
        {
            machine.ToMovementState(machine.WallJumpState);
        }
        
    }
}

