using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    public override void Tick(StateMachine machine)
    {
        dash.Started();
        if (dash.Ended())
        {
            if (character.Grounded)
                machine.ToState(machine.groundState);
            else
                machine.ToState(machine.fallState);
        }
    }
}

