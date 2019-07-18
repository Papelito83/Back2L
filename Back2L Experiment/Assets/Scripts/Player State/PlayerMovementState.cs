using UnityEngine;

public abstract class PlayerMovementState : IState
{
    protected PlayerMovement playerMovement;

    protected bool JumpKeyPressed;
    protected bool JumpKeyReleased;
    protected bool DashKeyPressed;

    // TEST
    protected bool attackKeyPressed; 

    public PlayerMovementState(PlayerMovement playerMovement)
    {
        ResetInput();

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

        if (Input.GetKeyDown(KeyCode.C))
            attackKeyPressed = true;
    }

    protected void ResetInput()
    {
        JumpKeyPressed = false;
        JumpKeyReleased = false;
        DashKeyPressed = false;

        // TEST
        attackKeyPressed = false;
    }

    public virtual void OnEnter() { }
    public virtual void OnExit() { }

    public void Tick(StateMachine machine)
    {
        PerformTransition(machine);

        ResetInput();
    }

    protected abstract void PerformTransition(StateMachine machine);

    protected void HandleMovement()
    {
        var x = Input.GetAxisRaw("Horizontal");

        playerMovement.MoveHorizontal(x);
    }

    protected void HandleMovement(float divideCoeff)
    {
        var x = Input.GetAxisRaw("Horizontal");

        playerMovement.MoveHorizontal(divideCoeff * x);
    }
}
