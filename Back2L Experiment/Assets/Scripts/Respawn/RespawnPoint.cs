using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPoint : MonoBehaviour
{
    public event EventHandler PlayerFindRespawn;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            InvokePlayerFindRespawn();
    }

    private void InvokePlayerFindRespawn()
    {
        PlayerFindRespawn?.Invoke(this, EventArgs.Empty);
    }
}
