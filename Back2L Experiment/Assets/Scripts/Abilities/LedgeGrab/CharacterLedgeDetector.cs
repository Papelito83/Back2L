using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class CharacterLedgeDetector : MonoBehaviour
{
    private enum TouchedWallState
    {
        NONE,
        FIRST
    }

    private TouchedWallState state = TouchedWallState.NONE;

    private Collider2D wallCollider;

    private I2DRayProvider rayProvider;

    private readonly RaycastHit2D[] hits = new RaycastHit2D[2]; 
    private readonly float[] rayOffsets = new float[2];

    private int layerMask;

    private bool firstRayTouched;

    public void Start()
    {
        rayProvider = GetComponent<I2DRayProvider>();

        layerMask = ~LayerMask.GetMask("Player");

        // first and second Ray;
        rayOffsets[0] = 0.4f;
        rayOffsets[1] = 0.8f;

        firstRayTouched = false;
    }

    public bool DetectWallLedge()
    {
        for (int i = 0; i < rayOffsets.Length; i++)
        {
            var ray2D = rayProvider.CreateRay(rayOffsets[i]);
            hits[i] = Physics2D.Raycast(ray2D.Origin, ray2D.Direction, ray2D.Distance, layerMask);

            Debug.DrawRay(ray2D.Origin, ray2D.Direction, Color.blue);
        }

        return LedgeTouched(hits);
    }



    private bool LedgeTouched(RaycastHit2D[] hits)
    {
        bool ledgeWallDetected = false;

        if (hits[0].collider != null)
        {
            if (hits[1].collider != null)
            {
                if (firstRayTouched)
                {                   
                    firstRayTouched = false;

                    // petite astuce pour le système de respawn à corriger plus tard
                    if (!hits[0].collider.isTrigger)
                    {
                        ledgeWallDetected = true;
                        wallCollider = hits[0].collider;
                    }

                }
            }
            else
            {
                firstRayTouched = true;
            }
        }

        return ledgeWallDetected;
    }



    public Collider2D G etWallCollider()
    {
        return wallCollider;
    }
}
