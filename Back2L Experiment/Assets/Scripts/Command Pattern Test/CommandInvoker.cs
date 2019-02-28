using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class CommandInvoker : MonoBehaviour
{
    [SerializeField]
    private float dirX;

    [SerializeField]
    private float dirY;

    private ICommand moveLeft;
    private ICommand moveRight;

    public GameObject otherGameObject;

    public void Start()
    {
        Character character = otherGameObject.GetComponent<Character>();
        moveLeft = new MoveLeft(character);
        moveRight= new MoveRight(character);
    }

    public void Update()
    {
        HandleInput();
    }

    private void HandleInput()
    {
        dirX = Input.GetAxisRaw("Horizontal");

        if (dirX > 0)
        {
            moveRight.Execute();
        }
        else if (dirX < 0)
        {
            moveLeft.Execute();
        }
    }
}

