using UnityEngine;

public class Character : PhysicsObject
{
    private IState movementState;
    private SpriteRenderer spriteRenderer;

    public IState MovementState {
        get { return movementState; }
        set { movementState = value; }
    }

    public bool Grounded {
        get{ return grounded; }
        set { grounded = value; }
    }

    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpSpeed;
         
    private void Awake()
    {
        // move and jump var
        moveSpeed = 5.0f;
        jumpSpeed = 10.0f;
        movementState = new GroundState(this);

        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        name = "Character State : " + movementState.ToString(); 
        movementState.Tick();
    }

    public void MoveHorizontal(float dir)
    {
        Vector2 move = Vector2.zero;

        move.x = dir;

        Flip(move.x);

        targetVelocity = move * moveSpeed;
    }

    public void Dash()
    {
        
    }

    private void Flip(float dir)
    {
        bool flipSprite = (spriteRenderer.flipX ? (dir > 0.01f) : (dir < 0.01f));
        if (flipSprite)
        {
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }
    }

    public void NoMove()
    {
       targetVelocity = Vector2.zero;
    }
       
    public void Jump()
    {              
       velocity.y = jumpSpeed;
    }

    public void JumpOff()
    {
        if(velocity.y > 0)
        {
            velocity.y = velocity.y * 0.5f;
        }
    }
}

