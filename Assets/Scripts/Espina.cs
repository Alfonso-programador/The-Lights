using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Espina : MonoBehaviour
{   public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D col) {
        if(col.transform.tag == "Player"){
            rb.AddForce(new Vector2(0,50f * 5));
        }
    }
    private void OnCollisionEnter2D(Collision2D col) {
        rb.AddForce(new Vector2(0,-50f * 5));
    }
}
