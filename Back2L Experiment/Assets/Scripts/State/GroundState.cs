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
        base.OnEnter();
    }

    public override void OnExit()
    {
        
    }

    public override void Tick()
    {
        HandleMovement();

        var dash = character.GetComponent<Dash>();

        if (JumpKeyPressed && character.Grounded)
        {          
            ToState(new JumpState(character));
        }
        else if (!character.Grounded)
        {
            ToState(new FallState(character));
        }

        if (DashKeyPressed)
        {
            if (dash != null & !dash.OnCooldDown())
                ToState(new DashState(character, dash));
        }
        
    }
}

