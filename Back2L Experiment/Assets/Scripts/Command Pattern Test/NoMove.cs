using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class NoMove : ICommand
{
    Character character;

    public NoMove(Character character)
    {
        this.character = character;
    }

    public void Execute()
    {
        character.NoMove();
    }

    public void Undo()
    {
        throw new NotImplementedException();
    }
}

