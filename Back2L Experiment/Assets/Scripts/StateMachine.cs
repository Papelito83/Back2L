using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    private Character character;

    private IState currentState;

    public IState groundState { get; private set; }
    public IState fallState { get; private set; }
    public IState dashState { get; private set; }
    public IState jumpState { get; private set; }
    public IState ledgeGrabState { get; private set; }

    public void Start()
    {
        Dash dash = GetComponent<Dash>();
        LedgeDetector ledgeDetector = GetComponent<LedgeDetector>();

        character = GetComponent<Character>();

        groundState = new GroundState(character);
        fallState = new FallState(character, ledgeDetector);
        dashState = new DashState(character, dash);
        jumpState = new JumpState(character);
        ledgeGrabState = new LedgeGrabState(character, ledgeDetector);

        currentState = groundState;
    }

    public void Update()
    {
        currentState.HandleInput();
    }

    public void FixedUpdate()
    {
        currentState.Tick(this);
    }

    public void ToState(IState nextState)
    {
        currentState.OnExit();
        currentState = nextState;
        currentState.OnEnter();
    }
}


