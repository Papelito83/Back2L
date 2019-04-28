using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UnityEngine;

public abstract class PlayerAttackState : IState
{
    protected PlayerAttack playerAttack;

    protected bool AttackKeyPressed;

    public PlayerAttackState(PlayerAttack playerAttack)
    {
        this.playerAttack = playerAttack;
    }

    public void HandleInput()
    {
        if (Input.GetKey(KeyCode.F))
            AttackKeyPressed = true;
    }

    public void ResetInput()
    {
        AttackKeyPressed = false;
    }

    public virtual void OnEnter()
    {
        
    }

    public virtual void OnExit()
    {
        
    }

    public abstract void Tick(StateMachine machine);
}

