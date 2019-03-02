﻿public class NoMove : ICommand
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
        
    }
}
