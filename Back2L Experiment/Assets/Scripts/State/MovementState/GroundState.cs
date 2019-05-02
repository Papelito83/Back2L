using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UnityEngine;

class GroundState : PlayerMovementState
{
    private Animator animator;
    private Action Blink;

    public GroundState(PlayerMovement playerMovement) : base(playerMovement)
    {
        animator = playerMovement.GetComponent<Animator>();
        Blink = BlinkEye();
    }

    public override void OnEnter()
    {
        base.OnEnter();
    }

    public override void Tick(StateMachine machine)
    {
        HandleMovement();

        if (JumpKeyPressed && playerMovement.Grounded)
        {
            machine.ToMovementState(machine.jumpState);
        }
        else if (!playerMovement.Grounded)
        {
            machine.ToMovementState(machine.fallState);
        }

        if (DashKeyPressed)
        {
            var dash = playerMovement.GetComponent<Dash>();

            if (!dash.OnCooldDown())
                machine.ToMovementState(machine.dashState);
            else
                DashKeyPressed = false;
        }

        Blink();
    }

    private Action BlinkEye()
    {
        float blinkEyeRate = 0;
        float previousBlinkEyeRate = 0;
        float blinkEyeTime = 0;

        Action Blink = () =>
        {
            if (Time.time > blinkEyeTime)
            {
                previousBlinkEyeRate = blinkEyeRate;
                blinkEyeTime = Time.time + blinkEyeRate;
                animator.SetTrigger("Blink");

                while(previousBlinkEyeRate == blinkEyeRate)
                {
                    blinkEyeRate = UnityEngine.Random.Range(1f, 1.5f);
                }
            }
        };

        return Blink;
}
}

