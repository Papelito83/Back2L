using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField]
    private float timeBtwAttack;

    [SerializeField]
    private Transform initialAttackPos;
    private Transform relativeAttackPos;

    private LayerMask whatIsEnemies;

    [SerializeField]
    private float attackRadius;
    [SerializeField]
    private int damage;

    private PlayerMovement playerMovement;
    private Collider2D playerCollider;

    private bool canAttack = true;
    private bool attackPosFlipped = false;

    private void Awake()
    {
        relativeAttackPos = initialAttackPos;
    }

    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        playerCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        FlipAttackPos();
    }

    private void FlipAttackPos()
    {
        Vector3 flipCenter = new Vector3(playerCollider.bounds.center.x, relativeAttackPos.position.y);
        Vector3 difference = relativeAttackPos.position - flipCenter;
        Vector3 newRelativePosition = relativeAttackPos.position - 2 * difference;

        if (playerMovement.DirectionFlipped() && !attackPosFlipped)
        {
            relativeAttackPos.position = newRelativePosition;
            attackPosFlipped = true;
        }

        if (!playerMovement.DirectionFlipped() && attackPosFlipped)
        {
            relativeAttackPos.position = newRelativePosition;
            attackPosFlipped = false;
        }
    }

    public bool CanAttack()
    {
        return canAttack;
    }
    
    public void Execute()
    {
        canAttack = false;

        Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(relativeAttackPos.position, attackRadius);
        for (int i = 0; i < enemiesToDamage.Length; i++)
        {
            enemiesToDamage[i].GetComponent<IDamageable>().TakeDamage(damage);
        }

        Invoke("ResetAttackFlag", timeBtwAttack);
    }

    private void ResetAttackFlag()
    {
        canAttack = true;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(initialAttackPos.position, attackRadius);
    }
}

