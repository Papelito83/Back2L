using System.Linq;
using UnityEngine;

class FallState : CharacterState
{
    LedgeDetector ledgeDetector;

    public FallState(Character character, LedgeDetector ledgeDetector) : base(character)
    {
        this.ledgeDetector = ledgeDetector;
    }

    public override void OnEnter()
    {
        base.OnEnter();
    }

    public override void Tick(StateMachine machine)
    {
        HandleMovement();
       
        if (character.Grounded)
            machine.ToState(machine.groundState);

        if (ledgeDetector.DetectWallLedge())
            machine.ToState(machine.ledgeGrabState);

        if(DashKeyPressed)
        {
            var dash = character.GetComponent<Dash>();

            if(!dash.OnCooldDown())
                machine.ToState(machine.dashState);
        }
    }
}

