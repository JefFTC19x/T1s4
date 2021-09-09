using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IzDr : MonoBehaviour
{
    private Rigidbody2D rb;
    
    
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
            rb.AddForce(Vector2.up * 30, ForceMode2D.Impulse);
        }
        

    }
}
