﻿using System.Linq;
using UnityEngine;

class FallState : PlayerMovementState
{
    private Animator animator;
    private CharacterLedgeDetector ledgeDetector;
    private LedgeGrab ledgeGrabAbility;

    public FallState(PlayerMovement playerMovement, CharacterLedgeDetector ledgeDetector, LedgeGrab ledgeGrabAbility) : base(playerMovement)
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
            var collider = ledgeDetector.GetWallCollider();
            ledgeGrabAbility.Grab(collider);
            machine.ToMovementState(machine.ledgeGrabState);
        }

        if (DashKeyPressed)
        {
            var dash = playerMovement.GetComponent<Dash>();

            if (!dash.OnCooldDown())
                machine.ToMovementState(machine.dashState);
        }

        if (playerMovement.Walled && JumpKeyPressed)
        {
            machine.ToMovementState(machine.wallJumpState);
        }
        
    }
}

