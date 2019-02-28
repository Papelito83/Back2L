using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour, IDamageable
{
    private Inventory inventory;
    private IWeapon weapon;

    public float Health { get; private set; }

    [SerializeField] private Rigidbody2D rigid;

    [SerializeField] LayerMask groundMask;
    [SerializeField] Transform groundCheck;

    [SerializeField] private float groundRadius;
    [SerializeField] private bool grounded;
         
    private void Awake()
    {       
        inventory = new Inventory();
        groundRadius = 0.2f;
        Health = 100;
    }

    private void Start()
    {
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
        rigid.velocity = new Vector2(dir * 5.0f, rigid.velocity.y);
    }

    public void Jump()
    {
        if(grounded)
            rigid.velocity = new Vector2(rigid.velocity.x, 10.0f);
    }
}

