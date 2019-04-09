using UnityEngine;

public class JumpState : CharacterState
{
    public JumpState(Character character) : base(character)
    {
  
    }

    public override void OnEnter()
    {
        base.OnEnter();

        character.Jump();
    }

    public override void Tick(StateMachine machine)
    {
        HandleMovement();

        // Interuption du saut pendant l'ascendance
        if (JumpKeyReleased)
            character.JumpOff();

        // Si le personnage est en redescente il passe à l'état FallState
        if (character.IsFalling())
            machine.ToState(machine.fallState);

        if(DashKeyPressed)
        {
            var dash = character.GetComponent<Dash>();

            if (!dash.OnCooldDown())
                machine.ToState(machine.dashState);
        }
    }
}

