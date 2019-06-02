using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterLedgeDetector : MonoBehaviour
{
    private Collider2D wallCollider;

    private I2DRayProvider rayProvider;

    private RaycastHit2D[] hits = new RaycastHit2D[2]; 
    private float[] rayOffsets = new float[2];

    private int layerMask;

    bool firstRayHited;

    public void Start()
    {
        rayProvider = GetComponent<I2DRayProvider>();

        layerMask = ~LayerMask.GetMask("Player");

        // first and second Ray;
        rayOffsets[0] = 0.4f;
        rayOffsets[1] = 0.8f;

        firstRayHited = false;
    }

    public bool DetectWallLedge()
    {
        for (int i = 0; i < rayOffsets.Length; i++)
        {
            var ray2D = rayProvider.CreateRay(rayOffsets[i]);
            hits[i] = Physics2D.Raycast(ray2D.origin, ray2D.direction, ray2D.distance, layerMask);

            Debug.DrawRay(ray2D.origin, ray2D.direction, Color.blue);
        }

        return LedgeHitted(hits);
    }

    private bool LedgeHitted(RaycastHit2D[] hits)
    {
        bool ledgeWallDetected = false;

        if (hits[0].collider != null)
        {
            if (hits[1].collider != null)
            {
                if (firstRayHited)
                {                   
                    firstRayHited = false;

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
                firstRayHited = true;
            }
        }

        return ledgeWallDetected;
    }

    public Collider2D GetWallCollider()
    {
        return wallCollider;
    }
}
