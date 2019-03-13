using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


class GroundState : CharacterState
{
    public GroundState(Character character) : base(character)
    {

    }

    public override void OnEnter()
    {
        
    }

    public override void OnExit()
    {
        
    }

    public override void Tick()
    {
        float x = Input.GetAxisRaw("Horizontal");

        if(Mathf.Abs(x)>0)
            character.MoveHorizontal(x);
        else
            character.NoMove();

        //Si la touche de saut et utilisée et que le perso est "physiquement" grounded alors passage à JumpState
        //Sinon si il n'est pas "physiquement" grounded il passe à FallState
        if (Input.GetButtonDown("Jump") && character.Grounded)
        {
            ToState(new JumpState(character));
        }
        else if (!character.Grounded)
        {
            ToState(new FallState(character));
        }
    }
}
