public class MoveLeft : ICommand
{
    Character character;

    public MoveLeft(Character character)
    {
        this.character = character;
    }

    public void Execute()
    {
        character.MoveHorizontal(-1);
    }

    public void Undo()
    {

    }
}
