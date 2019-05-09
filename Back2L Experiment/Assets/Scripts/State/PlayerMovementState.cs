﻿using UnityEngine;

public abstract class PlayerMovementState : IState
{
    protected PlayerMovement playerMovement;

    protected bool JumpKeyPressed;
    protected bool JumpKeyReleased;
    protected bool DashKeyPressed;

    public PlayerMovementState(PlayerMovement playerMovement)
    {
        JumpKeyPressed = false;
        JumpKeyReleased = false;
        DashKeyPressed = false;
        this.playerMovement = playerMovement;
    }

    public void HandleInput()
    {
        if (Input.GetButtonDown("Jump"))
            JumpKeyPressed = true;

        if (Input.GetKeyDown("left shift"))
            DashKeyPressed = true;

        if (Input.GetButtonUp("Jump"))
            JumpKeyReleased = true;
}

    protected void ResetInput()
    {
        JumpKeyPressed = false;
        JumpKeyReleased = false;
        DashKeyPressed = false;
    }

    public virtual void OnEnter() { }
    public virtual void OnExit() { }

    public void Tick(StateMachine machine)
    {
        PerformeTransition(machine);

        ResetInput();
    }

    protected abstract void PerformeTransition(StateMachine machine);

    protected void HandleMovement()
    {
        float x = Input.GetAxisRaw("Horizontal");

        playerMovement.MoveHorizontal(x);
    }
}
