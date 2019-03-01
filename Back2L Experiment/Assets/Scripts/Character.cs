using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : PhysicsObject, IDamageable
{
    private Inventory inventory;
    private IWeapon weapon;

    public float Health { get; private set; }

    [SerializeField] private Rigidbody2D rigid;

    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpSpeed;

    private bool isJumping;
         
    private void Awake()
    {
        isJumping = false;
        moveSpeed = 5.0f;
        jumpSpeed = 7.0f;

        inventory = new Inventory();
        Health = 100;
    }

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    public void UseWeapon(IWeapon weapon)
    {
        
    }


    public bool HasItem(IItem item)
    {
        return inventory.FindItem(item);
    }

    public void TakeDamage(float damage)
    {
        if(Health > 0)
            Health -= damage;
    }

    public void MoveHorizontal(float dir)
    {
        Debug.Log("move call");

        Vector2 move = Vector2.zero;

        move.x = dir;

        targetVelocity = move * moveSpeed;
    }

    public void NoMove()
    {
       targetVelocity = Vector2.zero;
    }
       
    public void Jump()
    {
        if (grounded)
            velocity.y = jumpSpeed;
    }

}

