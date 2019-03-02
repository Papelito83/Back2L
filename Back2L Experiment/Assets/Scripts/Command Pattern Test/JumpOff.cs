public class JumpOff : ICommand
{
    Character character;

    public JumpOff(Character character)
    {
        this.character = character;
    }

    public void Execute()
    {
        character.JumpTakeOff();
    }

    public void Undo()
    {

    }
}

