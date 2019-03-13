using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class JumpState : CharacterState
{
    public JumpState(Character character) : base(character)
    {
  
    }

    public override void OnEnter()
    {
        character.Grounded = false;
        character.Jump();
    }

    public override void OnExit()
    {
        
    }

    public override void Tick()
    {
        float x = Input.GetAxisRaw("Horizontal");

        if (Mathf.Abs(x) > 0)
            character.MoveHorizontal(x);

        if(character.Grounded)
        {
            this.ToState(new GroundState(character));
        }
    }
}

