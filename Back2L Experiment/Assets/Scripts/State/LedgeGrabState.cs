using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class LedgeGrabState : CharacterState
{
    private PhysicsObject characterPhysics;
    private LedgeDetector ledgeDetector;

    public LedgeGrabState(Character character, LedgeDetector ledgeDetector) : base(character)
    {
        this.ledgeDetector = ledgeDetector;
        characterPhysics = character.GetComponent<PhysicsObject>();
    }

    public override void OnEnter()
    {
        base.OnEnter();

        characterPhysics.EnableGravity = false;
    }

    public override void OnExit()
    {
        characterPhysics.EnableGravity = true;
    }

    public override void Tick(StateMachine machine)
    {
        if (character.DirectionFlipped())
        {
            if (Input.GetAxisRaw("Horizontal") > 0)
                machine.ToState(machine.fallState);
        }
        else
        {
            if (Input.GetAxisRaw("Horizontal") < 0)
                machine.ToState(machine.fallState);
        }

        if (Input.GetAxisRaw("Vertical") > 0)
        {
            SetPositionOnPlatform();
            machine.ToState(machine.fallState);
        }

        if (JumpKeyPressed)
            machine.ToState(machine.jumpState);
    }

    public void SetPositionOnPlatform()
    {
        float horizontalCorrection, verticalCorrection;
        Collider2D characterCollider = character.GetComponent<BoxCollider2D>();
        Collider2D wallCollider = ledgeDetector.GetWallCollider();

        verticalCorrection = wallCollider.bounds.max.y - characterCollider.bounds.min.y;

        if (character.DirectionFlipped())
            horizontalCorrection = wallCollider.bounds.max.x - characterCollider.bounds.max.x;
        else
            horizontalCorrection = wallCollider.bounds.min.x - characterCollider.bounds.min.x;

        Vector3 move = new Vector3(horizontalCorrection, verticalCorrection);

        character.transform.position += move;
    }
}

