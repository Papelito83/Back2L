using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    private PlayerMovement playerMovement;
    private PlayerAttack playerAttack;

    private IState currentMovementState;

    public IState groundState { get; private set; }
    public IState fallState { get; private set; }
    public IState dashState { get; private set; }
    public IState jumpState { get; private set; }
    public IState ledgeGrabState { get; private set; }

    //TESST
    public IState attackState { get; private set; }

    // public IState wallJumpState { get; private set; }

    public void Start()
    {
        Dash dash = GetComponent<Dash>();
        LedgeDetector ledgeDetector = GetComponent<LedgeDetector>();
        LedgeGrab ledgeGrabAbility = GetComponent<LedgeGrab>();

        playerMovement = GetComponent<PlayerMovement>();
        playerAttack = GetComponent<PlayerAttack>();

        groundState = new GroundState(playerMovement, playerAttack);
        fallState = new FallState(playerMovement, ledgeDetector, ledgeGrabAbility);
        dashState = new DashState(playerMovement, dash);
        jumpState = new JumpState(playerMovement);
        ledgeGrabState = new LedgeGrabState(playerMovement, ledgeGrabAbility);

        //TEST
        attackState = new AttackState(playerMovement, playerAttack);

        // wallJumpState = new WallJumpState(playerMovement);

        currentMovementState = groundState;
    }

    public void Update()
    {
        currentMovementState.HandleInput();
    }

    public void FixedUpdate()
    {
        name = currentMovementState.ToString();

        currentMovementState.Tick(this);
    }

    public void ToMovementState(IState nextMovementState)
    {
        currentMovementState.OnExit();
        currentMovementState = nextMovementState;
        currentMovementState.OnEnter();
    }
}


