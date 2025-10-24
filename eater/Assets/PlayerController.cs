using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Speed;
    public float JumpPower;
    private float inputMovement;

    public bool isSpiderDead = false;

    public SpriteRenderer  blueSlime;
    public SpriteRenderer blueSpider;

    public Rigidbody2D rbPlayer;

    public bool isGrounded;
    public Transform groundChecker;
    public LayerMask groundMask;

    public float radius;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rbPlayer = GetComponent<Rigidbody2D>();

        isGrounded = false;

        radius = 0.15f;
    }

    private void FixedUpdate()
    {
       HandleMovement();
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
        SpriteFlipper();
    }


    private void Jump()
    {
        if (groundChecker != null) 
        {
            isGrounded = Physics2D.OverlapCircle(groundChecker.position, radius, groundMask);
        }

        if (isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            rbPlayer.linearVelocity = Vector2.up * JumpPower;
            isGrounded = false;
        }
    }


    private void HandleMovement()
    {
        inputMovement = Input.GetAxis("Horizontal");
        rbPlayer.linearVelocity = new Vector2(inputMovement * Speed, rbPlayer.linearVelocity.y);

       

    }

    private void SpriteFlipper()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            blueSlime.flipX = true;
            blueSpider.flipY = true;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            blueSlime.flipX = false;
            blueSpider.flipY = false;
        }
    }
}
