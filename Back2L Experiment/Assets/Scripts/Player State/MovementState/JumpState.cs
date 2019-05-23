using UnityEngine;

public class JumpState : PlayerMovementState
{
    Animator animator;

    public JumpState(PlayerMovement playerMovement) : base(playerMovement)
    {
        animator = playerMovement.GetComponent<Animator>();
    }

    public override void OnEnter()
    {
        animator.SetBool("IsJumping", true);
        playerMovement.Jump();
    }

    public override void OnExit()
    {
        animator.SetBool("IsJumping", false);
    }

    protected override void PerformeTransition(StateMachine machine)
    {
        HandleMovement();

        // Interuption du saut pendant l'ascendance
        if (JumpKeyReleased)
            playerMovement.JumpOff();

        // Si le personnage est en redescente il passe à l'état FallState
        if (playerMovement.IsFalling())
            machine.ToMovementState(machine.fallState);

        /*if(playerMovement.Walled && JumpKeyPressed)
        {
            machine.ToMovementState(machine.wallJumpState);
        }
        */

        if(DashKeyPressed)
        {
            var dash = playerMovement.GetComponent<Dash>();

            if (!dash.OnCooldDown())
                machine.ToMovementState(machine.dashState);
        }
    }
}

