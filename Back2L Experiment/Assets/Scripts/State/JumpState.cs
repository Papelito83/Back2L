using UnityEngine;

public class JumpState : PlayerMovementState
{
    public JumpState(PlayerMovement playerMovement) : base(playerMovement)
    {
  
    }

    public override void OnEnter()
    {
        base.OnEnter();

        playerMovement.Jump();
    }

    public override void Tick(StateMachine machine)
    {
        HandleMovement();

        // Interuption du saut pendant l'ascendance
        if (JumpKeyReleased)
            playerMovement.JumpOff();

        // Si le personnage est en redescente il passe à l'état FallState
        if (playerMovement.IsFalling())
            machine.ToState(machine.fallState);

        if(DashKeyPressed)
        {
            var dash = playerMovement.GetComponent<Dash>();

            if (!dash.OnCooldDown())
                machine.ToState(machine.dashState);
        }
    }
}

