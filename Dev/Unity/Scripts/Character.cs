using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : IDamageable
{
    private Inventory inventory;
    private IWeapon weapon;

    public float Health { get; private set; }

    public Character()
    {
        Health = 100;
        inventory = new Inventory();
    }

    public void UseWeapon(IWeapon weapon)
    {
        // do some stuff
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
}
