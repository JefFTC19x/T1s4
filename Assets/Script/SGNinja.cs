using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SGNinja : MonoBehaviour
{

    public float velocityx = 10;
    public float Salto = 50;
    public int VecesSalta = 0;

    private SpriteRenderer sr;    
    private Animator animator;
    private Rigidbody2D rb;
      
    // Variables de Estado
    private const int INI= 0;
    private const int RUN= 1;    
    private const int JUMP= 2;
    private const int DIE= 3;
    
     
    private bool isDead = false;

    private int NZomb=0;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animator =GetComponent<Animator>();
        animator.SetInteger("Estado", 1);
    }

    // Update is called once per frame
    void Update()
    {   
        if(NZomb <30)
        {    
            if(!isDead)
            {        
                sr.flipX = false;

                rb.velocity = new Vector2(velocityx,rb.velocity.y);
                changeAnimation(RUN);

                if(VecesSalta < 2)
                {
                    if(Input.GetKeyUp(KeyCode.Space))
                    {
                        //Saltar
                        rb.AddForce(Vector2.up *Salto,ForceMode2D.Impulse); //Salto
                        changeAnimation(JUMP);
                        VecesSalta +=1;
                        Debug.Log("Saltos "+ VecesSalta);
                    }
                }
                if(Input.GetKey(KeyCode.A))
                { 
                    //Correr en Reversa
                    rb.velocity = new Vector2(-velocityx, rb.velocity.y); 
                    sr.flipX = true;
                    changeAnimation(RUN);
                }
                
            }
        }
        else
        {
            if(NZomb <30)
            {Debug.Log("Fin del Juego");}
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Zombi"))
        {            
            velocityx*=0;
            isDead = true; 
            changeAnimation(DIE);                       
        }
        if(other.gameObject.CompareTag("suelo") && VecesSalta == 2)
        {
            VecesSalta =0;
        }          
        if (other.gameObject.CompareTag("Finish"))
        {
            velocityx=0;
            changeAnimation(INI);
        }
    }  

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.gameObject.tag);
        
        if(other.gameObject.CompareTag("rebasado"))      
        {            
            NZomb +=1;
            Debug.Log("Has Rebazado: "+NZomb+" Zombies");
        }
    }

    private void changeAnimation(int animation)
    {
        animator.SetInteger("Estado", animation);
    }
}

