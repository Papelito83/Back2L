using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterUI : MonoBehaviour
{
    public PlayerStats playerStats;
    public Image[] hearts;

    private float health;
    private float defense;

    void Start()
    {
        health = playerStats.Health;
        defense = playerStats.DefenseStat.Value;
        playerStats.OnTakeDamage += HandleDamageEvent;
    }

    
    void Update()
    {
        throw new NotImplementedException();
    }

    private void HandleDamageEvent(object sender, EventArgs args)
    {
        for (int i = (int) health-1; i > playerStats.Health-1; i--) 
        {
            hearts[i].enabled = false;
            health = playerStats.Health;
        }
    }


}
