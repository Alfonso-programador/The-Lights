using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolaDeFuego : MonoBehaviour
{
    
    public Rigidbody2D rb;
    public float speed;
    // Update is called once per frame
    public void Start() {
  
    }
    void Update()
    {
       rb.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D col) {
       if(col.tag != "Player" && col.tag != "GameController" ){
           Destroy(gameObject);
       }
    }
   
}
