using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
     public Transform Jugador;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var x  = Jugador.position.x;     
        var y  = Jugador.position.y + 10;

        transform.position = new Vector3(x,y,transform.position.z);  
    }
}
