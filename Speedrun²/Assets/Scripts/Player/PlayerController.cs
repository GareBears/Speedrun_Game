using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{
    //Movement
    public float speed;
    public float jumpforce;
    private float moveInput;
    private float slowtimer;
    private bool slow;

    GameManager gameManager;

    //RigidBody
    private Rigidbody2D rb;

    //Turning
    private bool facingRight = true;

    //Jumping
    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    //Extra Jumps
    private int extraJumps;
    public int extraJumpsValue;

    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        rb = GetComponent<Rigidbody2D>();
        speed = 25;
        slowtimer = 0;
        slow = false;
    }

    void Update()
    {
        //Jumping
        if(isGrounded == true)
        {
            extraJumps = extraJumpsValue;
        }

        if(Input.GetKeyDown(KeyCode.Space) && extraJumps > 0)
        {
            rb.velocity = Vector2.up * jumpforce;
            extraJumps--;
        }
        else if(Input.GetKeyDown(KeyCode.Space) && extraJumps == 0 && isGrounded == true)
        {
            rb.velocity = Vector2.up * jumpforce;
        }

        if (slow)
        {
            
            slowtimer += Time.deltaTime;
            if(slowtimer >= 3)
            {
                speed = 25;
                slowtimer = 0;
                slow = false;
            }
        }
    }

    private void FixedUpdate()
    {
        //Figuring out if player is on Ground
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius,whatIsGround);

        //Moving
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        //Calling Flip Method
        if(facingRight == false && moveInput > 0)
        {
            Flip();
        }
        else if(facingRight == true && moveInput < 0)
        {
            Flip();
        }
    }

    //Flipping Position
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    void Loop()
    {
    transform.Translate (0f, 0.01f, 0f);
    }

    public void JumpBoost()
    {
        rb.AddForce(transform.up * jumpforce * 75);
        //Debug.Log("This works");
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Spikes")
        {
            gameManager.PlayerSlow();
            slow = true;
            speed = 10;
        }
    }
}
