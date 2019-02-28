using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour, IDamageable
{
    private Inventory inventory;
    private IWeapon weapon;

    [SerializeField]
    private Rigidbody2D rigid;

    [SerializeField]
    public float Health { get; private set; }

    private void Awake()
    {       
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
        rigid.velocity = new Vector2(dir * 5.0f, 0);
    }
}

