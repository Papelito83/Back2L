﻿using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class RespawnManager : MonoBehaviour
{
    [SerializeField] private RespawnPoint[] points;
    [SerializeField] private DeadZone[] zones;
    private RespawnPoint currentRespawn;

    public GameObject player;

    public void Start()
    {
        foreach (var point in points)
            point.PlayerFindRespawn += new EventHandler(OnPlayerFindRespawn);

        foreach (var zone in zones)
            zone.PlayerDead += new EventHandler(OnPlayerDead);
    }

    private void OnPlayerDead(object sender, EventArgs args)
    {
        RespawnPlayer();
    }

    private void OnPlayerFindRespawn(object sender, EventArgs args)
    {
        var respawnPoint = (RespawnPoint)sender;
        ChangeCurrentRespawn(respawnPoint);
    }

    private void ChangeCurrentRespawn(RespawnPoint other)
    {
        if (currentRespawn != other)
        {

            currentRespawn = other;
            Debug.Log("Respawn point has changed : " + other.transform.position);
        }      
    }

    private void RespawnPlayer()
    {
        if(currentRespawn != null)
        {
            Vector3 respawnPosition = currentRespawn.transform.position;

            player.transform.position = respawnPosition;
        }
    }
}
