using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class manipulador_fuego : MonoBehaviour
{   
    public float distance;
    public GameObject bola_fuego;
    public Transform disparoCheck;
    public Rigidbody2D rb;
    public Transform groundDetection;
    float time;
    bool salto;
    bool escapar;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        if(escapar == true){
            rb.velocity = new Vector2(-100 * Time.deltaTime,0);
        }
        time += Time.deltaTime;
        if(time >= 2){
            DisparoFuego();
            salto = !salto;
            time = 0;
        }
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);
        if(groundInfo.collider == false){
            escapar = false;
            rb.velocity = Vector2.zero;
        }
    }
    public void DisparoFuego(){
        Instantiate(bola_fuego,disparoCheck.position,disparoCheck.rotation);
    }
    private void OnTriggerEnter2D(Collider2D col) {
        if(col.transform.tag == "Player"){
            escapar = true;
        }
        
    }
}
