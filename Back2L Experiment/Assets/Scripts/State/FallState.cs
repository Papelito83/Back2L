using UnityEngine;

class FallState : CharacterState
{
    public FallState(Character character) : base(character)
    {

    }

    public override void Tick()
    {
        float x = Input.GetAxisRaw("Horizontal");

        if (Mathf.Abs(x) > 0)
            character.MoveHorizontal(x);
        else
            character.NoMove();
        
        // Si le personnage est "physiquement" grounded il repasse à l'état GroundState
        if (character.Grounded)
            ToState(new GroundState(character));
    }
}

