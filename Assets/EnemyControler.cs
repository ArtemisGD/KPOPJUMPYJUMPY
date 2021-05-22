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
}
