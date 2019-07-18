using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UnityEngine;

public class CustomDistanceRay2D
{
    private Ray2D ray2D;

    public float Distance { get; set; }

    public Vector2 Direction
    {
        get => ray2D.direction;
        set => ray2D.direction = value;
    }

    public Vector2 Origin
    {
        get => ray2D.origin;
        set => ray2D.origin = value;
    }

    public CustomDistanceRay2D(Vector2 direction, Vector2 origin, float distance)
    {
        ray2D = new Ray2D(origin, direction);

        Distance = distance;
    }

    public Vector2 GetPoint(float distance)
    {
        return ray2D.GetPoint(distance);
    }
}

