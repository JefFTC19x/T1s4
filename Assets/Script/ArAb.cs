
 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArAb : MonoBehaviour
{
    private Rigidbody2D rb;
    public float velocity  = -5;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
    }

     private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("suelo"))
        {
            rb.velocity = new Vector2(velocity, rb.velocity.y);
            rb.AddForce(Vector2.up * 30, ForceMode2D.Impulse);

            velocity *= -1;
            
        }

    }
}