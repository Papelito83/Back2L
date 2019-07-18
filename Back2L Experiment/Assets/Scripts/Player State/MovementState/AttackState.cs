using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UnityEngine;

public class AttackState : PlayerMovementState
{
    private Animator animator;
    private AnimationClip animClip;
    private PlayerAttack playerAttack;

    private float attackAnimTime;
    private static readonly int Attacking = Animator.StringToHash("Attacking");

    public AttackState(PlayerMovement playerMovement, PlayerAttack playerAttack) : base(playerMovement)
    {
        this.playerAttack = playerAttack;
        animator = playerMovement.GetComponent<Animator>();

        FindAttackClip();
    }

    public override void OnEnter()
    {
        animator.SetTrigger(Attacking);

        attackAnimTime = animClip.length;

        playerAttack.Execute();
    }

    protected override void PerformTransition(StateMachine machine)
    {       
        HandleMovement(0.3f);

        attackAnimTime -= Time.deltaTime;

        if (attackAnimTime <= 0f)
            machine.ToMovementState(machine.GroundState);
    }

    private void FindAttackClip()
    {
        var runTimeAnimatorController = animator.runtimeAnimatorController;
        foreach (var clip in runTimeAnimatorController.animationClips)
        {
            if (clip.name == "Malgor Attack")
                animClip = clip;
        }
    }
}

