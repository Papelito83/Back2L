using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class CommandInvoker : MonoBehaviour
{
    private ICommand moveLeft;
    private ICommand moveRight;
    private ICommand jump;

    public GameObject playerObject;

    public void Start()
    {
        Character character = playerObject.GetComponent<Character>();
        moveLeft = new MoveLeft(character);
        moveRight= new MoveRight(character);
        jump = new Jump(character);
    }

    public void Update()
    {
        HandleInput();
    }

    private void HandleInput()
    {
        float dirX = Input.GetAxisRaw("Horizontal");
        float dirY = Input.GetAxisRaw("Vertical");

        if (dirX > 0)
        {
            moveRight.Execute();
        }
        else if (dirX < 0)
        {
            moveLeft.Execute();
        }

        if(dirY > 0)
        {
            jump.Execute();
        }
    }
}

