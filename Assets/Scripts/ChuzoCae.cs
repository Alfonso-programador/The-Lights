using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChuzoCae : MonoBehaviour
{
    public Rigidbody2D rb;
    private void OnTriggerEnter2D(Collider2D col) {
        if(col.transform.tag == "Player"){
            rb.isKinematic = false;
        }
    }
}
