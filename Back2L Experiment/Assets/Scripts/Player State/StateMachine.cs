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

    public IState GroundState { get; private set; }
    public IState FallState { get; private set; }
    public IState DashState { get; private set; }
    public IState JumpState { get; private set; }
    public IState LedgeGrabState { get; private set; }

    //TESST
    public IState AttackState { get; private set; }

    public IState WallJumpState { get; private set; }

    public void Start()
    {
        var dash = GetComponent<Dash>();
        var ledgeDetector = GetComponent<CharacterLedgeDetector>();
        var ledgeGrabAbility = GetComponent<LedgeGrab>();

        playerMovement = GetComponent<PlayerMovement>();
        playerAttack = GetComponent<PlayerAttack>();

        GroundState = new GroundState(playerMovement, playerAttack);
        FallState = new FallState(playerMovement, ledgeDetector, ledgeGrabAbility);
        DashState = new DashState(playerMovement, dash);
        JumpState = new JumpState(playerMovement);
        LedgeGrabState = new LedgeGrabState(playerMovement, ledgeGrabAbility);

        //TEST
        AttackState = new AttackState(playerMovement, playerAttack);

        WallJumpState = new WallJumpState(playerMovement);

        currentMovementState = GroundState;
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


