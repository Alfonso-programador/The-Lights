using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Llave : MonoBehaviour
{   
    public GameObject imagen_llave;
    public bool llave;
    private void OnTriggerEnter2D(Collider2D col) {
        if(col.transform.tag == "Player"){
                imagen_llave.SetActive(true);
                llave = true;
                Destroy(gameObject);
        }

    }
}
