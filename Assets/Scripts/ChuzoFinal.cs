using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChuzoFinal : MonoBehaviour
{   public GameObject chuzo1;
    public GameObject chuzo2;
    public GameObject chuzo3;
    public Transform player;
    private void Start() {
        chuzo1 = GameObject.FindWithTag("chuzos1");
        chuzo2 = GameObject.FindWithTag("chuzos2");
        chuzo3 = GameObject.FindWithTag("chuzos3");

    }
    private void OnTriggerEnter2D(Collider2D col) {
          if(col.transform.tag == "Player"){
             gameObject.SetActive(false);
             Destroy(chuzo1);
             Destroy(chuzo2);
        } 
    }
    private void OnCollisionEnter2D(Collision2D col) {
           if(col.transform.tag == "Player"){
             gameObject.SetActive(false);
             Destroy(chuzo1);
             Destroy(chuzo2);
        } 
    }
}
