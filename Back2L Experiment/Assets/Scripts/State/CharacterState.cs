using UnityEngine;

public abstract class CharacterState : IState
{
    protected Character character;

    protected bool JumpKeyPressed;
    protected bool JumpKeyReleased;
    protected bool DashKeyPressed;

    public CharacterState(Character character)
    {
        JumpKeyPressed = false;
        JumpKeyReleased = false;
        DashKeyPressed = false;
        this.character = character;
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

    public virtual void OnEnter()
    {
        ResetInput();
    }
    public virtual void OnExit() { }

    public abstract void Tick(StateMachine machine);

    protected void HandleMovement()
    {
        float x = Input.GetAxisRaw("Horizontal");

        character.MoveHorizontal(x);
    }
}
