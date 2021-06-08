using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    public float moveSpeed;
    public float jumpForce;
    private Vector2 input;
    int direction = 1;

    //
    public Transform groundCheckPoint;
    public float radius;
    public LayerMask whatIsGround;
    public bool isGrounded = false;
    public bool canDoubleJump = true;

    //Respawn
    private Vector3 resetPos;
   
    public void ResetPlayerPosition()
    {
        transform.position = resetPos;
    }

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        resetPos = transform.position;
    }

    void Update()
    {
        Movement();

        GroundCheck();
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
    }

    void Movement()
    {
        input = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, _rigidbody.velocity.y);
       
        if (input.x > 0)
            direction = 1;
        else if (input.x < 0)
            direction = -1;
        
        _rigidbody.velocity = input;
        FlipSprite();
    }

    void Jump()
    {
        if (isGrounded)
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, jumpForce);
        }
        else if (canDoubleJump)
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, jumpForce);
            canDoubleJump = false;
        }
    }

    void GroundCheck()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, radius, whatIsGround);
        if (isGrounded)
        {
            canDoubleJump = true;
        }
    }
    void FlipSprite()
    {
        //By rotations
        transform.eulerAngles = new Vector3(0, direction == 1 ? 0 : 180, 0);
    }
}