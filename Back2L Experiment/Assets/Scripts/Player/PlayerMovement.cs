using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    private PhysicsObject physic;

    private float wallSlideMaxSpeed = -2f;

    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpSpeed;

    public bool Grounded
    {
        get { return physic.grounded; }
    }

    public bool Walled
    {
        get { return physic.walled; }
    }

    private void Awake()
    {
        moveSpeed = 5.0f;
        jumpSpeed = 15.0f;
    }

    private void Start()
    {
        physic = GetComponent<PhysicsObject>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void MoveHorizontal(float dir)
    {
        Vector2 move = Vector2.zero;

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
        GetComponent<malghor_sound>().jumpSound();
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
        bool flipSprite = (spriteRenderer.flipX ? (dir < 0.01f) : (dir > 0.01f));
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

    public void WallJump()
    {
        if (Walled)
        {
            Vector2 moveVector = physic.currentWallNormal * moveSpeed;
            moveVector.y = jumpSpeed;

            physic.targetVelocity = moveVector;
        }
    }
}