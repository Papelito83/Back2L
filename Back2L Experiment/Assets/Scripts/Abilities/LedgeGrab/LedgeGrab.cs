using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement), typeof(PhysicsObject))]
public class LedgeGrab : MonoBehaviour
{
    private PlayerMovement playerMovement;
    private PhysicsObject playerPhysics;

    public Collider2D colliderLedgeOwner;

    public float coolDownBeforeAction = 1f;
    public float coolDownLeft;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        playerPhysics = GetComponent<PhysicsObject>();

        coolDownLeft = 0f;
    }

    private void Update()
    {
        if(OnCoolDown())
            coolDownLeft -= Time.deltaTime;
    }

    public bool OnCoolDown()
    {
        return coolDownLeft >= 0f;
    }

    public void Grab(Collider2D colliderOwner)
    {
        if (colliderOwner != null)
        {
            coolDownLeft = coolDownBeforeAction;
            colliderLedgeOwner = colliderOwner;
            playerPhysics.EnableGravity = false;
        }
    }

    public void UnGrab()
    {
        playerPhysics.EnableGravity = true;
    }
}

