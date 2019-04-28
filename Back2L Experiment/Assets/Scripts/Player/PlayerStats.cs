using System;
using System.Collections.Generic;
using UnityEngine;
using Shiva.Stats;
using System.Collections;

public class PlayerStats : MonoBehaviour, IDamageable
{
    public float Health { get; private set; }

    public PlayerStat maxHealthStat { get; private set; }
    public PlayerStat damageStat { get; private set; }
    public PlayerStat defenseStat { get; private set; }

    public void Awake()
    {
        maxHealthStat = new PlayerStat(100);
        damageStat = new PlayerStat(10);
        defenseStat = new PlayerStat(0);

        Health = maxHealthStat.Value;
    }


    public void Start()
    {
    
    }

    public void Update()
    {
        Debug.Log("Vie : " + Health);
        Debug.Log("Damage : " + damageStat.Value);
        Debug.Log("Defense : " + defenseStat.Value);

    }

    public void TakeDamage(float damage)
    {
        if (!Dead())
        {
            Health -= damage;
        }
    }

    public bool Dead()
    {
        return Health <= 0f;
    }
}

