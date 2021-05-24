using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class empezar : MonoBehaviour
{
    public bool iniciar;
    public GameObject bloqueo;
    public GameObject camara;
    public Animator camaraAnim;
    public Batalla1_10 script;
    void Start()
    {
        iniciar = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D col) {
            if(col.transform.tag == "Player"){
                destruir();
                camaraAnim.SetTrigger("empezar");
                iniciar = true;
                bloqueo.SetActive(true);
            }
    }
    public void destruir(){
        camara.SetActive(false);
    }
}
