using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bolitas_fuego_2 : MonoBehaviour
{   
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {   
        rb.AddForce(new Vector2(50f,125f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D other) {
        Destroy(gameObject);
    }
}
