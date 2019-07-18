using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UnityEngine;

public class Character2DRayProvider : MonoBehaviour, I2DRayProvider
{
    private Collider2D playerCollider;
    private PlayerMovement playerMovement;

    private Vector2 rayOrigin;
    private float rayDistance;

    public void Start()
    {
        // Maximum ray distance
        rayDistance = 0.2f;

        playerCollider = GetComponent<BoxCollider2D>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    /// <summary>
    /// Create Custom Ray2D front of the character collider with a custom vertical offset
    /// </summary>
    /// <param name="rayOffset">Vertical offset</param>
    /// <returns>Ray2D wrapper with information for the distance</returns>
    public CustomDistanceRay2D CreateRay(float rayOffset)
    {
        var direction = playerMovement.DirectionFlipped() ? 1 : -1;
        var bounds = playerCollider.bounds;
        
        var adjustPositionOnX = direction * bounds.extents.x;
        var adjustPositionOnY = rayOffset * bounds.extents.y;

        Vector2 playerColliderCenter = bounds.center;
        Vector2 adjustingPosition = new Vector2(adjustPositionOnX, adjustPositionOnY);
        
        rayOrigin = playerColliderCenter + adjustingPosition;

        return new CustomDistanceRay2D(Vector2.right * direction, rayOrigin, rayDistance);
    }
}

