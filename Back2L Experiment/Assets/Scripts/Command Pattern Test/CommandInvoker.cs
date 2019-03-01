using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class CommandInvoker : MonoBehaviour
{
    private float dirX;
    private float dirY;

    private ICommand moveRight;
    private ICommand moveLeft;
    private ICommand noMove;
    private ICommand jump;

    public GameObject playerObject;

    public void Start()
    {
        Character character = playerObject.GetComponent<Character>();

        moveRight = new Move(character, MoveDirection.RIGHT);
        moveLeft = new Move(character, MoveDirection.LEFT);
        noMove = new NoMove(character);
        jump = new Jump(character);
    }

    public void Update()
    {
        HandleInput();
    }

    private void HandleInput()
    {
        dirX = Input.GetAxis("Horizontal");
        dirY = Input.GetAxis("Vertical");

        if(Mathf.Abs(dirX) > 0)
        {
            if(dirX > 0)
            {
                moveRight.Execute();
            }
            else
            {
                moveLeft.Execute();
            }
        }
        else
        {
            noMove.Execute();
        }

        if(dirY > 0)
        {
            jump.Execute();
        }
    }
}

