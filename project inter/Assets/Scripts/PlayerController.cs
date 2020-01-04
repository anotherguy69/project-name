using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public float speed;
    public Rigidbody rb;
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
       
        float horizontal = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        if (horizontal < 0)
        {
            
            isFacingRight = false;
        }
        else if(horizontal > 0)
        {
            isFacingRight = true;
        }

        if (horizontal != 0)
        {
            anim.SetBool("IsMoving", true);
        }
        else
        {
            anim.SetBool("IsMoving", false);
        }
    }


    void JumpCheck()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckRadius, groundMask);

        anim.SetBool("Jump", isJumping);
       
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
