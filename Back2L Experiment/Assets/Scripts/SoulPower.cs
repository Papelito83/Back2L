using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulPower : IProjectileWeapon
{
    private int reloadTime;
    private int range;

    public float Power { get; private set; }

    public SoulPower()
    {
        Power = 10;
    }

    public void Damage(IDamageable target)
    {
        target.TakeDamage(Power);
    }

    public IProjectile Shoot(Vector3 direction)
    {
        // do some stuff
        return null;
    }
}
