using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Jump : ICommand
{
    Character character;

    public Jump(Character character)
    {
        this.character = character;
    }

    public void Execute()
    {
        character.Jump();
    }

    public void Undo()
    {
        
    }
}

