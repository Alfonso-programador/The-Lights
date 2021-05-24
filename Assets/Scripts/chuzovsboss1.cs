using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chuzovsboss1 : MonoBehaviour
{   public Transform player;
    public Vector2 seguir;
    public int speed;
     public int espacio;
    bool perseguir = false;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {   
        Vector3 Scaler = player.transform.localScale;
           if(Scaler.x == 1){
                espacio = 3;
           }else if(Scaler.x == -1){
               espacio = -3;
           }
           
        seguir = new Vector2(player.transform.position.x - espacio,player.transform.position.y);
        Debug.Log(espacio);
        if(perseguir == true){
             transform.position = Vector2.MoveTowards(transform.position,seguir,speed * Time.deltaTime);
             transform.position = new Vector2(transform.position.x,player.position.y + 0.2f);
        }
    }
    private void OnTriggerEnter2D(Collider2D col) {
        if(col.transform.tag == "Player"){
            perseguir = true;   
        }
    }
}
