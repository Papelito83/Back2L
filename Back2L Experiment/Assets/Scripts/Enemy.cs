using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    private PhysicsObject physics;
    public float Health { get; private set; }

    private bool isAttacking;
    private float attackCd = 2f;
    private float attackCdTimeleft;

    public void Start()
    {
        physics = GetComponent<PhysicsObject>();
        Health = 10;
    }

    public void Update()
    {
        Debug.Log("Enemy Health : " + Health);

        if (attackCdTimeleft > 0f)
            attackCdTimeleft -= Time.deltaTime;

        if (attackCdTimeleft <= 0f)
            isAttacking = false;

        if (Dead())
            Kill();

        Move();
    }

    private void Move()
    {
        physics.targetVelocity = Vector2.left * 10 ;
    }

    public void Kill()
    {
        Destroy(gameObject);
    }

    public void TakeDamage(float damage)
    {
        if (!Dead())
        {
            Health -= damage;
        }
    }

    private bool Dead()
    {
        return Health <= 0f;
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        if(isAttacking) return;

        if (!collider.CompareTag("Player")) return;

        isAttacking = true;
        var player = collider.GetComponent<IDamageable>();
        player.TakeDamage(1);
        attackCdTimeleft = attackCd;
    }
}




