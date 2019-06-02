using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterUI : MonoBehaviour
{
    public PlayerStats playerStats;
    public Image[] hearts;

    float health;
    float defense;

    void Start()
    {
        health = playerStats.Health;
        defense = playerStats.DefenseStat.Value;
        playerStats.OnTakeDamage += new EventHandler(OnTakeDamageUI);
    }

    
    void Update()
    {
        
    }

    private void OnTakeDamageUI(object sender, EventArgs args)
    {
        for (int i = (int) health-1; i > playerStats.Health-1; i--) 
        {
            hearts[i].enabled = false;
            health = playerStats.Health;
        }
            
    }


}
