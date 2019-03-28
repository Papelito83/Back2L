using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class DashState : CharacterState
{
    private Dash dash;

    public DashState(Character character, Dash dash) : base(character)
    {
        this.dash = dash;
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
        dash.Started();
        if (dash.Ended())
        { 
            if (character.Grounded)
                ToState(new GroundState(character));
            else
                ToState(new FallState(character));
        }
    }
}

