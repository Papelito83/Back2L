using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UnityEngine;

class GroundState : PlayerMovementState
{
    // TEST
    private PlayerAttack playerAttack;

    private Animator animator;
    private Action Blink;

    public GroundState(PlayerMovement playerMovement, PlayerAttack playerAttack) : base(playerMovement)
    {
        this.playerAttack = playerAttack;

        animator = playerMovement.GetComponent<Animator>();
        Blink = BlinkEye();
    }

    protected override void PerformeTransition(StateMachine machine)
    {
        HandleMovement();

        if (playerAttack.CanAttack() && attackKeyPressed)
        {
            machine.ToMovementState(machine.attackState);
        }

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

