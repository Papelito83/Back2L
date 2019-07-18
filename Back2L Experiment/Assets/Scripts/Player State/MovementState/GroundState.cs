using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UnityEngine;

class GroundState : PlayerMovementState
{
    // TEST
    private readonly PlayerAttack playerAttack;

    private readonly Animator animator;
    private readonly Action Blink;

    public GroundState(PlayerMovement playerMovement, PlayerAttack playerAttack) : base(playerMovement)
    {
        this.playerAttack = playerAttack;

        animator = playerMovement.GetComponent<Animator>();
        Blink = BlinkEye();
    }

    protected override void PerformTransition(StateMachine machine)
    {
        HandleMovement();

        if (playerAttack.CanAttack() && attackKeyPressed)
        {
            machine.ToMovementState(machine.AttackState);
        }

        if (JumpKeyPressed && playerMovement.Grounded)
        {
            machine.ToMovementState(machine.JumpState);
        }
        else if (!playerMovement.Grounded)
        {
            machine.ToMovementState(machine.FallState);
        }

        if (DashKeyPressed)
        {
            var dash = playerMovement.GetComponent<Dash>();

            if (!dash.OnCooldDown())
                machine.ToMovementState(machine.DashState);
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

