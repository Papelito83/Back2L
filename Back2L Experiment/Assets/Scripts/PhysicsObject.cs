using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PhysicsObject : MonoBehaviour
{
    private float minGroundNormalY = .65f;
    [SerializeField] private float gravityModifier = 1f;

    public bool grounded { get; private set; }
    public bool walled { get; private set; }

    [HideInInspector] public Vector2 targetVelocity;
    [HideInInspector] public Vector2 velocity;
    private Vector2 groundNormal;

    private Collider2D mainCollider;
    private Rigidbody2D rb2d;

    private ContactFilter2D contactFilter;
    private RaycastHit2D[] hitBuffer = new RaycastHit2D[16];
    private List<RaycastHit2D> hitBufferList = new List<RaycastHit2D>(16);

    private const float minMoveDistance = 0.001f;
    private const float shellRadius = 0.01f;

    void OnEnable()
    {
        rb2d = GetComponent<Rigidbody2D>();

        Collider2D[] colliders = GetComponents<Collider2D>();
        mainCollider = colliders.Where(x => !x.isTrigger).Single();       
    }

    void Start()
    {
        contactFilter.useTriggers = false;
        contactFilter.SetLayerMask(Physics2D.GetLayerCollisionMask(gameObject.layer));
        contactFilter.useLayerMask = true;
    }

    void FixedUpdate()
    {
        // Apply Gravity
        velocity += gravityModifier * Physics2D.gravity * 2*Time.deltaTime;

        // Apply custom velocity
        velocity.x = targetVelocity.x;
        velocity.y += targetVelocity.y;

        grounded = false;
        walled = false;

        Vector2 deltaPosition = velocity * Time.deltaTime;

        Vector2 moveAlongGround = new Vector2(groundNormal.y, -groundNormal.x);

        Vector2 move = moveAlongGround * deltaPosition.x;

        Movement(move, false);

        move = Vector2.up * deltaPosition.y;

        Movement(move, true);
    }

    void Movement(Vector2 move, bool yMovement)
    {
        float distance = move.magnitude;

        if (distance > minMoveDistance)
        {
            int count = mainCollider.Cast(move, contactFilter, hitBuffer, distance + shellRadius);
            hitBufferList.Clear();
            for (int i = 0; i < count; i++)
            {
                hitBufferList.Add(hitBuffer[i]);
            }

            for (int i = 0; i < hitBufferList.Count; i++)
            {
                Vector2 currentNormal = hitBufferList[i].normal;
                Debug.DrawRay(hitBufferList[i].point, new Vector3(currentNormal.x, currentNormal.y, 0), Color.red, 1.25f);

                if (Mathf.Abs(currentNormal.x) > 0)
                {
                    walled = true;
                }

                if (currentNormal.y > minGroundNormalY)
                {
                    grounded = true;
                    if (yMovement)
                    {
                        groundNormal = currentNormal;
                        currentNormal.x = 0;
                    }
                }

                float projection = Vector2.Dot(velocity, currentNormal);
                if (projection < 0)
                {
                    velocity = velocity - projection * currentNormal;
                }

                float modifiedDistance = hitBufferList[i].distance - shellRadius;
                distance = modifiedDistance < distance ? modifiedDistance : distance;
            }
        }

        Debug.DrawRay(transform.position, velocity, Color.blue, 0.25f);
        rb2d.position = rb2d.position + move.normalized * distance;
    }

    public void StopVerticalMovement()
    {
        velocity.y = 0;
    }
}

