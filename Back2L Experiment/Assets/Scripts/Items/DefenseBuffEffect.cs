using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Shiva.Stats;
using UnityEngine;

public class DefenseBuffEffect
{
    private float defenseBuff;

    public DefenseBuffEffect(int defenseBuff)
    {
        this.defenseBuff = defenseBuff;
    }

    public void ExecuteEffect(Transform target)
    {
        StatModifier modifier = new StatModifier(defenseBuff, this);
        PlayerStats playerStats = target.GetComponent<PlayerStats>();

        PlayerStat defenseStat = playerStats.defenseStat;
        if (!defenseStat.IsModified)
        {
            defenseStat.AddModifier(modifier);
        }
        else
        {
            defenseStat.RemoveAllModifierFromSource(this);
            defenseStat.AddModifier(modifier);
        }
    }
}

