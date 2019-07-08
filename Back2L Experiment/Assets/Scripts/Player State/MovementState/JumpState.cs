using UnityEngine;

public class JumpState : PlayerMovementState
{
    private Animator animator;
    private MalgorSound malgorSound;

    public JumpState(PlayerMovement playerMovement) : base(playerMovement)
    {
        animator = playerMovement.GetComponent<Animator>();

        malgorSound = playerMovement.GetComponent<MalgorSound>();
    }

    public override void OnEnter()
    {
        animator.SetBool("IsJumping", true);

        malgorSound.PlayJumpSound();

        playerMovement.Jump();
    }

    public override void OnExit()
    {
        animator.SetBool("IsJumping", false);
    }

    protected override void PerformTransition(StateMachine machine)
    {
        HandleMovement();

        // Interuption du saut pendant l'ascendance
        if (JumpKeyReleased)
            playerMovement.JumpOff();

        // Si le personnage est en redescente il passe à l'état FallState
        if (playerMovement.IsFalling())
            machine.ToMovementState(machine.FallState);

        if(DashKeyPressed)
        {
            var dash = playerMovement.GetComponent<Dash>();

            if (!dash.OnCooldDown())
                machine.ToMovementState(machine.DashState);
        }
    }
}

