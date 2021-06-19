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
    public Inventory inventory;
    public PlayerHealth playerHealth;

    //Creamos un timer para el nuevo efecto
    float timer = 0;
    public float maxTime; // A esta variable le vas a dar tiempo por fuera para asignar la duración del poder
    public bool isShieldOn = false;

    public void ResetPlayerPosition()
    {
        transform.position = resetPos;
    }


    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        resetPos = transform.position;

        inventory = GetComponent<Inventory>();
        inventory.Init();

        playerHealth = GetComponent<PlayerHealth>();
        playerHealth.Init();

        //Aquí le asignamos el tiempo que pusiste desde unity para en caso agarres el objeto, este tiempo empiece a correr
        timer = maxTime;
    
    }

    void Update()
    {
        Movement();

        GroundCheck();
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
        //Esto lo vamos a cambiar cuando colisione con un objeto (en el script Shield...)
        if (isShieldOn)
        {
            Shield();
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

    //Función Shield
    void Shield()
    {
        //Asignamos el nuevo tag
        gameObject.tag = "Shield";
        //El contador del timer baja (esto indica que la duración de la habilidad esta limitada por tiempo)
        timer -= Time.deltaTime;

        //Cuando el timer es 0 o menor que 0
        if (timer <= 0)
        {
            //Le devolvemos el tag a player
            gameObject.tag = "Player";
            isShieldOn = false;
        }
    }
}