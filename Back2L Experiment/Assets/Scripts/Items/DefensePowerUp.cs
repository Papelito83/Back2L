using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UnityEngine;

class DefensePowerUp : MonoBehaviour
{
    public float Radius { get; private set; }

    DefenseBuffEffect defenseEffect;

    public void Start()
    {
        defenseEffect = new DefenseBuffEffect(2);
        Radius = 0.5f;
    }

    public void ExecuteEffect(Transform target)
    {
        defenseEffect.ExecuteEffect(target);
        Destroy(gameObject);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Transform target = collision.GetComponent<Transform>();
            ExecuteEffect(target);          
        }           
    }
}

