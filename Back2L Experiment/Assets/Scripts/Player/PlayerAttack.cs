using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField]
    private readonly float timeBtwAttack;

    [SerializeField]
    private readonly Transform initialAttackPos;

    private Transform relativeAttackPos;

    private LayerMask whatIsEnemies;

    [SerializeField]
    private readonly float attackRadius;
    [SerializeField]
    private readonly int damage;

    private PlayerMovement playerMovement;
    private Collider2D playerCollider;

    private bool canAttack = true;
    private bool attackPosFlipped;

    private void Awake()
    {
        relativeAttackPos = initialAttackPos;
    }

    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        playerCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        FlipAttackPos();
    }

    private void FlipAttackPos()
    {
        var position = relativeAttackPos.position;

        var flipCenter = new Vector3(playerCollider.bounds.center.x, position.y);
        var difference = position - flipCenter;
        var newRelativePosition = position - 2 * difference;

        if (playerMovement.DirectionFlipped() && !attackPosFlipped)
        {
            relativeAttackPos.position = newRelativePosition;
            attackPosFlipped = true;
        }

        if (!playerMovement.DirectionFlipped() && attackPosFlipped)
        {
            relativeAttackPos.position = newRelativePosition;
            attackPosFlipped = false;
        }
    }

    public bool CanAttack()
    {
        return canAttack;
    }
    
    public void Execute()
    {
        canAttack = false;

        Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(relativeAttackPos.position, attackRadius);
        for (int i = 0; i < enemiesToDamage.Length; i++)
        {
            var enemie = enemiesToDamage[i].GetComponent<IDamageable>();
            enemie.TakeDamage(damage);
        }

        Invoke(nameof(ResetAttackFlag), timeBtwAttack);
    }

    private void ResetAttackFlag()
    {
        canAttack = true;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(initialAttackPos.position, attackRadius);
    }
}

