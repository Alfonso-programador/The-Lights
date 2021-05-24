using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moneda : MonoBehaviour
{   
    public int valor;
           
    
    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.transform.tag == "Player"){
     
            GetComponent<coinManager>().RaiseScore(valor);
            StartCoroutine(destruir());
        }
    }
    IEnumerator destruir(){
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
