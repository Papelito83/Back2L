public abstract class CharacterState : IState
{
    protected Character character;

    public CharacterState(Character character)
    {
        this.character = character;
    }

    public abstract void OnEnter();
    public abstract void OnExit();
    public abstract void Tick();

    public virtual void ToState(IState state)
    {
        character.MovementState.OnExit();
        character.MovementState = state;
        character.MovementState.OnEnter();
    }
}
