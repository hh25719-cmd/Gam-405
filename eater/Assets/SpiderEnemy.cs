using UnityEngine;

public class SpiderEnemy : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private float range;
    [SerializeField] private float colliderDistance;
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private LayerMask playerLayer;
    private Rigidbody2D rb;
    public float JumpPower;
    private float cooldowntimer = Mathf.Infinity;



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    private void Update()
    {
        cooldowntimer += Time.deltaTime;
        if (PlayerInSight())
        {
            if (cooldowntimer >= attackCooldown)
            {
                cooldowntimer = 0;
                rb.linearVelocity = Vector2.up * JumpPower;
            }
        }
    }

    private bool PlayerInSight()
    {
        RaycastHit2D hit =
            Physics2D.BoxCast(boxCollider.bounds.center + transform.up * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z),
            0,Vector2.left, 0, playerLayer);

        return hit.collider != null;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.up * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }
}
