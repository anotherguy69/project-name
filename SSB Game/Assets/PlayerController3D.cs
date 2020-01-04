using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController3D : MonoBehaviour
{
    public CharacterController controller;

    public float speed;
    public float gravity;
    public float jumpForce;

    public Transform groundCheck;
    public float groundDistance;
    public LayerMask groundMask;


    Vector3 velocity;
    bool isGrounded;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void MovementCheck()
    {
        float horizontal = Input.GetAxis("Horizontal");

        Vector3 move = transform.right * horizontal;

        controller.Move(move * speed * Time.deltaTime);

    }

    void JumpCheck()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
        
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity);
        }

    }
}
