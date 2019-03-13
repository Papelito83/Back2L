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
        {
            character.MoveHorizontal(x);
        }
        else
        {
            character.NoMove();
        }

        if(Input.GetButtonDown("Jump"))
        {
            this.ToState(new JumpState(character));
        }
    }
}
