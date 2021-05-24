using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fondo_oscuro : MonoBehaviour
{
    public Animator anim;
    public bool apagar = false;
    private void Update() {
        anim.SetBool("apagar",apagar);
    }
    private void OnTriggerEnter2D(Collider2D col) {
        if(col.transform.tag == "Player"){
            apagar = true;
        }
    }
    private void OnTriggerExit2D(Collider2D col) {
        if(col.transform.tag == "Player"){
            apagar = false;
        }
    }
}
