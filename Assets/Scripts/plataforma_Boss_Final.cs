using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plataforma_Boss_Final : MonoBehaviour
{   
    public bool fase3;
    private void OnCollisionEnter2D(Collision2D col) {
        if(col.transform.tag == "Player"){
            fase3 = true;
        }
    }
}
