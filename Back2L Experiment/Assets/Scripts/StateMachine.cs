using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    private PlayerMovement playerMovement;

    private IState currentMovementState;
    private IState currentAttackState;

    public IState meleeAttackState { get; private set; }
    public IState noAttackState { get; private set; }

    public IState groundState { get; private set; }
    public IState fallState { get; private set; }
    public IState dashState { get; private set; }
    public IState jumpState { get; private set; }
    public IState ledgeGrabState { get; private set; }

    public void Start()
    {
        PlayerAttack playerAttack;

        Dash dash = GetComponent<Dash>();
        LedgeDetector ledgeDetector = GetComponent<LedgeDetector>();
        LedgeGrab ledgeGrabAbility = GetComponent<LedgeGrab>();

        playerMovement = GetComponent<PlayerMovement>();
        playerAttack = GetComponent<PlayerAttack>();

        groundState = new GroundState(playerMovement);
        fallState = new FallState(playerMovement, ledgeDetector, ledgeGrabAbility);
        dashState = new DashState(playerMovement, dash);
        jumpState = new JumpState(playerMovement);
        ledgeGrabState = new LedgeGrabState(playerMovement, ledgeGrabAbility);

        meleeAttackState = new MeleeAttackState(playerAttack);
        noAttackState = new NoAttackState(playerAttack);

        currentMovementState = groundState;
        currentAttackState = noAttackState;
    }

    public void Update()
    {
        currentMovementState.HandleInput();
        currentAttackState.HandleInput();
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

    public void ToAttackState(IState nextAttackState)
    {
        currentAttackState.OnExit();
        currentAttackState = nextAttackState;
        currentAttackState.OnEnter();
    }
}


