using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bola_hombre_lava : MonoBehaviour
{  
    public Rigidbody2D rb_bola;
    public GameObject bola_pequeña; 
    public GameObject bola_pequeña2; 
    public Transform bola_chiqita_derecha;
    public Transform bola_chiqita_izquierda;

    // Start is called before the first frame update
    void Start()
    {
        rb_bola.AddForce(new Vector2(-100f,250f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D col) {
       Dividirse();
    }
    public void Dividirse(){
            Instantiate(bola_pequeña,bola_chiqita_izquierda.position,bola_chiqita_izquierda.rotation);
            Instantiate(bola_pequeña2,bola_chiqita_derecha.position,bola_chiqita_derecha.rotation);
            Destroy(gameObject);
        }
}

