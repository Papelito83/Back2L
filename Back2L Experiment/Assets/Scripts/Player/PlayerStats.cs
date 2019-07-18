using System;
using System.Collections.Generic;
using UnityEngine;

using Shiva.Stats;

using System.Collections;

public class PlayerStats : MonoBehaviour, IDamageable
{
    public event EventHandler OnTakeDamage;

    public float Health { get; private set; }

    public IStat MaxHealthStat { get; private set; }
    public IMutableStat DamageStat { get; private set; }
    public IMutableStat DefenseStat { get; private set; }

    public void Awake()
    {
        MaxHealthStat = new PlayerStat(3);
        DamageStat = new PlayerStat(10);
        DefenseStat = new PlayerStat(0);

        Health = MaxHealthStat.Value;
    }

    public void Update()
    {
        Debug.Log("Vie : " + Health);
        Debug.Log("Damage : " + DamageStat.Value);
        Debug.Log("Defense : " + DefenseStat.Value);
    }

    public void TakeDamage(float damage)
    {
        Health -= damage;

        if (Dead())
            Health = 0;

        OnTakeDamage?.Invoke(this, EventArgs.Empty);
    }

    public bool Dead()
    {
        return Health <= 0f;
    }
}

