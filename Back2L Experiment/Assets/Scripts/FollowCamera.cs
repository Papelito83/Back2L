using UnityEngine;
using System.Collections;

public class FollowCamera : MonoBehaviour
{
    public float interpVelocity;
    public float minDistance;
    public float followDistance;
    public GameObject target;
    public Vector3 offset;
    private Vector3 targetPos;

    void Start()
    {
        targetPos = transform.position;
    }

    void FixedUpdate()
    {
        if (!target) return;

        var position = transform.position;
        var targetCurrentPosition = target.transform.position;

        Vector3 posNoZ = transform.position;
        posNoZ.z = targetCurrentPosition.z;

        Vector3 targetDirection = (targetCurrentPosition - posNoZ);

        interpVelocity = targetDirection.magnitude * 15f;

        if (interpVelocity <= 2)
        {
            interpVelocity = 0;
        }

        var deltaPos = interpVelocity * Time.deltaTime * targetDirection.normalized;
        targetPos = position + deltaPos;

        position = Vector3.Lerp(position, targetPos + offset, 0.25f);
        transform.position = position;
    }
}