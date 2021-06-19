using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControler : MonoBehaviour
{
    public float moveSpeed;
    private Rigidbody2D _rigidbody;
    public int direction = 0;
  
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        FlipSprite(); 
    }

    // Update is called once per frame
    void Update()
    {
        _rigidbody.velocity = new Vector2(x: direction * moveSpeed, _rigidbody.velocity.y);
    }

    void FlipSprite()
    {
        transform.eulerAngles = new Vector3(0, direction == 1 ? 180 : 0,  0);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerController>().ResetPlayerPosition();
            collision.gameObject.GetComponent<PlayerController>().playerHealth.UpdateHealthBar_Damage();
        }
        if (collision.gameObject.CompareTag("Wall"))
        {
            direction = direction * -1;
            FlipSprite();
        }
    }
}
