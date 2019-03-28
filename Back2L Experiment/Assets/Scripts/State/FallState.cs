using UnityEngine;

class FallState : CharacterState
{

    public FallState(Character character) : base(character)
    {

    }

    public override void OnEnter()
    {
        base.OnEnter();
    }

    public override void Tick()
    {
        HandleMovement();

        var dash = character.GetComponent<Dash>();

        if (character.Grounded)
            ToState(new GroundState(character));

        if(DashKeyPressed)
        {
            if (dash != null & !dash.OnCooldDown())
                ToState(new DashState(character, dash));
        }
    }
}

