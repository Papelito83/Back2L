using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Move : ICommand
{
    private Character character;
    private MoveDirection direction;

    public Move(Character character, MoveDirection direction)
    {
        this.character = character;
        this.direction = direction;
    }

    public void Execute()
    {
        switch(direction)
        {
            case MoveDirection.RIGHT:
                character.MoveHorizontal(1.0f);
                break;
            case MoveDirection.LEFT:
                character.MoveHorizontal(-1.0f);
                break;
        }
    }

    public void Undo()
    {

    }
}

public enum MoveDirection
{
    LEFT,
    RIGHT
}
