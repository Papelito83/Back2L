﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class WallJumpState : PlayerMovementState
{
    private float wallJumpTime = 0.2f;
    private float wallJumpLeft;

    private float direction;
    private bool started;


    public WallJumpState(PlayerMovement playerMovement) : base(playerMovement)
    {

    }

    public override void OnEnter()
    {       
        base.OnEnter();

        var playerPhysic = playerMovement.physic;
        var currentWallNormal = playerPhysic.currentWallNormal;

        playerMovement.CustomJump(12.0f);
        wallJumpLeft = wallJumpTime;

        direction = currentWallNormal.x;

        started = true;
    }

    public override void OnExit()
    {
        playerMovement.physic.StopVerticalVelocity();

        started = false;

        base.OnExit();
    }

    protected override void PerformTransition(StateMachine machine)
    {
        if (started)
        {
            playerMovement.MoveHorizontal(direction);

            wallJumpLeft -= Time.deltaTime;
        }

        if (playerMovement.Walled && JumpKeyPressed)
            machine.ToMovementState(this);

        if (wallJumpLeft <= 0f)
        {
            if (playerMovement.Grounded)
                machine.ToMovementState(machine.GroundState);

            if (playerMovement.IsFalling())
                machine.ToMovementState(machine.FallState);
        }
    }
}
