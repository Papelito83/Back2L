using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class LedgeGrab : MonoBehaviour
{
    private PlayerMovement playerMovement;
    private PhysicsObject playerPhysics;

    public Collider2D colliderLedgeOwner;

    public float coolDownBeforeAction = 1f;
    public float coolDownLeft;

    private void Start()
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

    /*public void Climb()
    {
        UnGrab();

        SetPlayerOnPlatform();

        // and Animation logic
    }
    */

    /*private void SetPlayerOnPlatform()
    {
        float horizontalCorrection, verticalCorrection;
        Collider2D PlayerMovementCollider = playerMovement.GetComponent<BoxCollider2D>();

        verticalCorrection = colliderLedgeOwner.bounds.max.y - PlayerMovementCollider.bounds.min.y;

        horizontalCorrection = playerMovement.DirectionFlipped() ? colliderLedgeOwner.bounds.max.x - PlayerMovementCollider.bounds.max.x
                                                                 : colliderLedgeOwner.bounds.min.x - PlayerMovementCollider.bounds.min.x;

        Vector3 correction = new Vector3(horizontalCorrection, verticalCorrection);

        playerMovement.transform.position += correction;
    }
    */
}

