public interface IState
{
    void OnEnter();
    void OnExit();
    void Tick();
    void HandleInput();
    void ToState(IState state);
}

