using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Controller : MonoBehaviour
{
    [Header("Movement Variables")]
    public float speed;
    public Rigidbody2D rb;
    public Animator anim;
    public bool isFacingRight;

    [Header("Jump Variables")]
    public float jumpForce;
    public bool isJumping;
    public bool isGrounded;
    public LayerMask groundMask;
    public Transform groundCheck;
    public float groundCheckRadius;
    private int startHowManyJumps;
    public int howManyJumps;


    void Update()
    {
     
        MovementCheck();
        JumpCheck();

    }


    void MovementCheck()
    {

        float horizontal = Input.GetAxis("HorizontalConsole");
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        if (horizontal < 0)
        {
            isFacingRight = false;
        }
        else if (horizontal > 0)
        {
            isFacingRight = true;
        }
    }


    void JumpCheck()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundMask);

        if (isGrounded == true)
        {
            isJumping = false;

            startHowManyJumps = howManyJumps;
        }

        if (Input.GetButtonDown("Jump") && startHowManyJumps > 0 && isGrounded == true)
        {

            isJumping = true;
            startHowManyJumps--;
            rb.velocity = new Vector3(rb.velocity.x, jumpForce);
        }
        else if (Input.GetButtonDown("Jump") && startHowManyJumps > 0)
        {
            isJumping = true;

            startHowManyJumps--;
            rb.velocity = new Vector3(rb.velocity.x, jumpForce);
        }
    }
}
