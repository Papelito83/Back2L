using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnManager : MonoBehaviour
{
    private RespawnPoint currentRespawn;
    public GameObject player;

    public void ChangeCurrentRespawn(RespawnPoint other)
    {
        if (currentRespawn != other)
        {
            currentRespawn = other;
            Debug.Log("Respawn point has changed : " + other.transform.position);
        }      
    }

    public void RespawnPlayer()
    {
        if(currentRespawn != null)
        {
            Vector3 respawnPosition = currentRespawn.transform.position;

            player.transform.position = respawnPosition;
        }
    }
}
