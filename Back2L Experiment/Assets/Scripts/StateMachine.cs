using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    private PlayerMovement playerMovement;

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
        LedgeGrab ledgeGrabAbility = GetComponent<LedgeGrab>();

        playerMovement = GetComponent<PlayerMovement>();

        groundState = new GroundState(playerMovement);
        fallState = new FallState(playerMovement, ledgeDetector, ledgeGrabAbility);
        dashState = new DashState(playerMovement, dash);
        jumpState = new JumpState(playerMovement);
        ledgeGrabState = new LedgeGrabState(playerMovement, ledgeGrabAbility);

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


