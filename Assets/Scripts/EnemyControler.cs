using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControler : MonoBehaviour
{
    public float moveSpeed;
    private Rigidbody2D _rigidbody;
    public int direction = 0;

    float timer;
    public float maxTime;
    bool canMove;

    public Sprite inconsciente;
    public Sprite normal;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        FlipSprite();

        timer = maxTime;
        canMove = true;
    }

    void Update()
    {
        if (canMove)
        {
            Move();
        }
        else
        {
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                canMove = true;
                gameObject.layer = 0;
                GetComponent<SpriteRenderer>().sprite = normal;
                timer = maxTime;
            }
        }
    }

    public void StopMoving()
    {
        canMove = false;
        gameObject.layer = 9;
        _rigidbody.velocity = Vector2.zero;
        GetComponent<SpriteRenderer>().sprite = inconsciente;
    }

    void Move()
    {
        _rigidbody.velocity = new Vector2(direction * moveSpeed, _rigidbody.velocity.y);
    }

    void FlipSprite()
    {
        transform.eulerAngles = new Vector3(0, direction == 1 ? 180 : 0, 0);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            direction *= -1;
            FlipSprite();
        }
    }
}
