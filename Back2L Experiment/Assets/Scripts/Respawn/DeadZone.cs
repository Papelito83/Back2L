using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    public event EventHandler PlayerDead;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            InvokePlayerDead();
    }

    private void InvokePlayerDead()
    {
        PlayerDead?.Invoke(this, EventArgs.Empty);
    }
}
