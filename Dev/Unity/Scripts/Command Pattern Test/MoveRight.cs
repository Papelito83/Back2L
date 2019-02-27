public class MoveRight : ICommand
{
    Character character;

    public MoveRight(Character character)
    {
        this.character = character;
    }

    public void Execute()
    {
        character.MoveHorizontal(1);
    }

    public void Undo()
    {
        
    }
}

