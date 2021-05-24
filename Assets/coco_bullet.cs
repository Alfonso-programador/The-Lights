using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coco_bullet : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col) {
        if(col.transform.tag == "Player" || col.transform.tag == "ground"){
            Destroy(gameObject);
        }
    }
     private void OnCollisionEnter2D(Collision2D col) {
         if(col.transform.tag == "Player" || col.transform.tag == "ground"){
            Destroy(gameObject);
        }
    }
}
