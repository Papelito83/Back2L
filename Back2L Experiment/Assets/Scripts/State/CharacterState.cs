public abstract class CharacterState : IState
{
    protected Character character;

    public CharacterState(Character character)
    {
        this.character = character;
    }

    public virtual void OnEnter() { }
    public virtual void OnExit() { }
    public abstract void Tick();

    public virtual void ToState(IState state)
    {
        character.MovementState.OnExit();
        character.MovementState = state;
        character.MovementState.OnEnter();
    }
}
