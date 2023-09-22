using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Movement
    public float speed;
    public float jumpforce;
    private float moveInput;

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
        rb = GetComponent<Rigidbody2D>();
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
        //GetComponent<Rigidbody2D>().AddForce(transform.up * jumpforce * 100);
        rb.AddForce(transform.up * jumpforce * 100);
        Debug.Log("This works");
    }
}
