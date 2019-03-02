using UnityEngine;

public class Character : PhysicsObject, IDamageable
{
    private Inventory inventory;
    private IWeapon weapon;

    public float Health { get; private set; }

    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpSpeed;
         
    private void Awake()
    {
        inventory = new Inventory();

        // move and jump var
        moveSpeed = 5.0f;
        jumpSpeed = 7.0f;

        Health = 100;
    }

    public void UseWeapon(IWeapon weapon)
    {
        
    }


    public bool HasItem(IItem item)
    {
        return inventory.FindItem(item);
    }

    public void TakeDamage(float damage)
    {
        if(Health > 0)
            Health -= damage;
    }

    public void MoveHorizontal(float dir)
    {
        Debug.Log("move call");

        Vector2 move = Vector2.zero;

        move.x = dir;

        targetVelocity = move * moveSpeed;
    }

    public void NoMove()
    {
       targetVelocity = Vector2.zero;
    }
       
    public void Jump()
    {       
        if (grounded)          
            velocity.y = jumpSpeed;
    }

    public void JumpTakeOff()
    {
        if(velocity.y > 0)
        {
            velocity.y = velocity.y * 0.5f;
        }
    }

}

