using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour, IDamageable
{
    private Inventory inventory;
    private IWeapon weapon;

    public float Health { get; private set; }

    [SerializeField] private Rigidbody2D rigid;

    [SerializeField] private LayerMask groundMask;
    [SerializeField] private Transform groundCheck;

    [SerializeField] private float groundRadius;
    [SerializeField] private bool grounded;

    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpSpeed;
         
    private void Awake()
    {
        moveSpeed = 5.0f;
        jumpSpeed = 10.0f;

        inventory = new Inventory();
        groundRadius = 0.6f;
        Health = 100;
    }

    private void Start()
    {
        groundMask = LayerMask.GetMask("Ground");
        rigid = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        grounded = false;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, groundRadius, groundMask);

        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
                grounded = true;
        }
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
        rigid.velocity = new Vector2(dir * moveSpeed, rigid.velocity.y);
    }

    public void Jump()
    {
        if(grounded)
            rigid.velocity = new Vector2(rigid.velocity.x, jumpSpeed);
    }

    // Debug circle collier
    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheck.position, groundRadius);
    }
}

