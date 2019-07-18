using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PhysicsObject))]
public class PlayerMovement : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    public PhysicsObject physic;

    // TEST
    private LayerMask platformOneWayLayer;
    private LayerMask playerLayer;
    private bool platformCoroutineIsRunning;


    private float wallSlideMaxSpeed = -2f;

    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpSpeed;

    public bool Grounded => physic.grounded;

    public bool Walled => physic.walled;

    private void Awake()
    {
        moveSpeed = 5.0f;
        jumpSpeed = 15.0f;

        platformOneWayLayer = LayerMask.NameToLayer("OneWayPlatform");
        playerLayer = LayerMask.NameToLayer("Player");
        platformCoroutineIsRunning = false;
    }

    private void Start()
    {
        physic = GetComponent<PhysicsObject>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void MoveHorizontal(float dir)
    {
        var move = Vector2.zero;

        move.x = dir;

        if(Mathf.Abs(move.x) > 0f)
            Flip(move.x);

        physic.targetVelocity = move * moveSpeed;
    }

    public void MoveHorizontal(float dir, float speedOffset)
    {
        MoveHorizontal(dir);

        physic.targetVelocity = physic.targetVelocity * speedOffset;
    }

    public void Jump()
    {
        physic.targetVelocity.y = jumpSpeed;
    }

    public void CustomJump(float jumpSpeed)
    {
        physic.targetVelocity.y = jumpSpeed;
    }

    public void JumpOff()
    {
        if (physic.velocity.y > 0)
        {
            physic.targetVelocity.y = -physic.velocity.y * 0.5f;
        }
    }

    public bool IsFalling()
    {
        return physic.velocity.y < -0.0001f;
    }

    public bool DirectionFlipped()
    {
        return spriteRenderer.flipX;
    }

    private void Flip(float dir)
    {
        var leftDir = dir < 0.01f;
        var rightDir = dir > 0.01f;

        bool flipSprite = spriteRenderer.flipX ? leftDir : rightDir;
        if (flipSprite)
        {
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }
    }

    public void WallSlide()
    {
        if(Walled)
        {
            if(physic.velocity.y < 0)
            {
                physic.velocity.y = wallSlideMaxSpeed;
            }
        }
    }
}