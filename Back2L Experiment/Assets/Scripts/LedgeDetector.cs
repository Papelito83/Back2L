using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LedgeDetector : MonoBehaviour
{
    private PlayerMovement playerMovement;
    private Collider2D playerCollider;
    private Collider2D wallCollider;

    private Vector2[] rayLedgeDetector = new Vector2[2];
    private RaycastHit2D[] hits = new RaycastHit2D[2];

    private float rayDistance = 0.2f;
    private float firstRayOffset = 0.4f;
    private float secondRayOffset = 0.8f;
    private float[] rayOffset = new float[2];

    private int layerMask;

    bool firstRayHited;

    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        playerCollider = GetComponent<BoxCollider2D>();

        layerMask = ~(LayerMask.GetMask("Player"));

        firstRayHited = false;

        rayOffset[0] = firstRayOffset;
        rayOffset[1] = secondRayOffset;
    }

    public bool DetectWallLedge()
    {
        int direction = -1;

        if (playerMovement.DirectionFlipped())
            direction = 1;

        for (int i = 0; i < rayLedgeDetector.Length; i++)
            rayLedgeDetector[i] = playerCollider.bounds.center;

        ComputeRayCasting(direction);

        return CheckForLedgeHits(hits);
    }

    private void ComputeRayCasting(int direction)
    {
        for (int i = 0; i < rayLedgeDetector.Length; i++)
        {
            rayLedgeDetector[i] += new Vector2(direction * playerCollider.bounds.extents.x, rayOffset[i] * playerCollider.bounds.extents.y);
            hits[i] = Physics2D.Raycast(rayLedgeDetector[i], direction * Vector3.right, rayDistance, layerMask);

            Debug.DrawRay(rayLedgeDetector[i], direction * rayDistance * Vector3.right, Color.blue);
        }
    }

    private bool CheckForLedgeHits(RaycastHit2D[] hits)
    {
        bool ledgeWallDetected = false;

        if (hits[0].collider != null)
        {
            Debug.Log("Detect collider first ray");
            if (hits[1].collider != null)
            {
                Debug.Log("Detect collider second ray");
                if (firstRayHited)
                {
                    ledgeWallDetected = true;
                    firstRayHited = false;

                    wallCollider = hits[0].collider;
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
