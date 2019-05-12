using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    [SerializeField]
    private RespawnManager respawnManager;

    public void Start()
    {
        respawnManager = FindObjectOfType<RespawnManager>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            respawnManager.RespawnPlayer();
        }
    }
}
