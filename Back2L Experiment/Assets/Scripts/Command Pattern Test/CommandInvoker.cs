using UnityEngine;

public class CommandInvoker : MonoBehaviour
{
    private float dirX;
    private float dirY;

    private ICommand moveRight;
    private ICommand moveLeft;
    private ICommand noMove;
    private ICommand jump;
    private ICommand jumpOff;

    public GameObject playerObject;

    public void Start()
    {
        Character character = playerObject.GetComponent<Character>();

        moveRight = new Move(character, MoveDirection.RIGHT);
        moveLeft = new Move(character, MoveDirection.LEFT);
        noMove = new NoMove(character);
        jump = new Jump(character);
        jumpOff = new JumpOff(character);
    }

    public void Update()
    {
        HandleInput();
    }

    private void HandleInput()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        dirY = Input.GetAxisRaw("Vertical");

        if(Mathf.Abs(dirX) > 0)
        {
            if(dirX > 0)
                moveRight.Execute();
            else
                moveLeft.Execute();
        }
        else
        {
            noMove.Execute();
        }

        if (Input.GetButtonDown("Jump"))
            jump.Execute();
        else if (Input.GetButtonUp("Jump"))
            jumpOff.Execute();
    }
}

