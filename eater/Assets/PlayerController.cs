using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Speed;
    public float JumpPower;
    private float inputMovement;

    private Rigidbody2D rb;

    private bool touchesGround;
    public Transform groundChecker;
    public LayerMask groundMask;

    public float radius;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        touchesGround = Physics2D.OverlapCircle(groundChecker.position, radius, groundMask);

        inputMovement = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(inputMovement * Speed, rb.linearVelocity.y);
    }

    // Update is called once per frame
    void Update()
    {
        if (touchesGround && Input.GetKeyDown(KeyCode.Space))
        {
            rb.linearVelocity = Vector2.up * JumpPower;
        }
    }
}
