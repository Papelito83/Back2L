using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class DefensePowerUp : MonoBehaviour
{
    public float Radius { get; set; }

    private DefenseBuffEffect defenseEffect;

    public void Start()
    {
        defenseEffect = new DefenseBuffEffect(2);
        Radius = 0.5f;
    }

    private void ExecuteEffect(Transform target)
    {
        var playerStat = target.GetComponent<PlayerStats>();
        var defenseStat = playerStat.DefenseStat;

        defenseEffect.ExecuteEffect(defenseStat);

        Destroy(gameObject);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;

        var target = collision.GetComponent<Transform>();
        ExecuteEffect(target);
    }
}