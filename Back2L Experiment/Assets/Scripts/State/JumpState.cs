using UnityEngine;

public class JumpState : CharacterState
{
    public JumpState(Character character) : base(character)
    {
  
    }

    public override void OnEnter()
    {
        base.OnEnter();

        character.Grounded = false;
        character.Jump();
    }

    public override void OnExit()
    {
        
    }

    public override void Tick()
    {
        HandleMovement();

        var dash = character.GetComponent<Dash>();

        // Interuption du saut pendant l'ascendance
        if (JumpKeyReleased)
            character.JumpOff();

        // Si le personnage est en redescente il passe à l'état FallState
        if (character.IsFalling())
            ToState(new FallState(character));

        if(DashKeyPressed)
        {
            if(dash != null & !dash.OnCooldDown())
                ToState(new DashState(character, dash));
        }
    }
}

