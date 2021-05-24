using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuertaLlave : MonoBehaviour
{
    [SerializeField] private Llave llave_script;
    public GameObject puerta;
    private void OnTriggerEnter2D(Collider2D col) {
        if(col.transform.tag == "Player"){
           if(llave_script.llave){
            Destroy(puerta);
           }   
        }
    }
}
