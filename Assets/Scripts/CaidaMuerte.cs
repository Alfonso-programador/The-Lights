using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaidaMuerte : MonoBehaviour
{   
    public GameObject volver_intentar;
    public GameObject camara;
    void Start(){
            
    }
    private void OnTriggerEnter2D(Collider2D col){
        if(col.transform.tag == "Player"){
                 StartCoroutine(muerte());
        }
    }
    IEnumerator muerte(){
        camara.SetActive(false);
        yield return new WaitForSeconds(1f);
        volver_intentar.SetActive(volver_intentar);
    }
}
