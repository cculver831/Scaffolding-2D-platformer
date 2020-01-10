using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    [Header("Player Speed")]
    [Range(1, 7)]
    public float speed;

    // Variables for Jump
    [Range(1, 10)]
    public float fallMultiplier = 2.5f;
    [Range(1, 10)]
    public float lowJumpMultiplier = 2;
    [Range(1, 10)]
    public float jumpVelocity;
    public int Jumps = 2;

    // Key Bindings
    private float MoveInput;


    // Gets rigidbosy component from player
    private Rigidbody2D rb;

    //Ground check for infinite jumping
    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatisGround;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        playerMove();
        playerJump();

        
   
    }

    // Get input from any key mapped "horizontal" on console
    public void playerMove()
    {
        MoveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(MoveInput * speed, rb.velocity.y);
    }

    public void playerJump()
    {
        if(isGrounded)
        {
            Jumps = 2;
        }
        // This line returns true/false if the player is on the ground
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatisGround);

        if(Input.GetKeyDown(KeyCode.Space) && Jumps > 1)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.up * jumpVelocity;
            if(rb.velocity.y > 0 )
            {
                rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;

            } else if(rb.velocity.y > 0 && !Input.GetKeyDown(KeyCode.Space))
            {
                rb.velocity +=  Vector2.up *Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
            }
            Jumps--;
        }
    }
}
