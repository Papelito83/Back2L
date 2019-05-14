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

    public void Start()
    {
        physics = GetComponent<PhysicsObject>();
        Health = 10;
    }

    public void Update()
    {
        Debug.Log("Enemy Health : " + Health);

        if (Dead())
            Kill();

        //Move();
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
}

