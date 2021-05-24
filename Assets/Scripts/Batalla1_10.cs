using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Batalla1_10 : MonoBehaviour
{       [Header("Rigidbodys")]
        public Rigidbody2D rb_chuzo;
        public Rigidbody2D player_rb;
         public Rigidbody2D chuzofinal;
        [Header("Scripts")]
        public PlayerController playercontrol;
        public ChuzoFinal chuzofinalcontrol;
        public ChuzoFinalVerdadero chuzo_script_verdadero;
        [Header("Variables")]
        public bool canChuzo = false;
        public float moveChuzo;
        public float timer;
        public bool timer_can = false;
        [Header("Objetos")]
        public GameObject chuzofinal_object;
        public GameObject player;
        public SpriteRenderer boss_object;
        
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate() {
        if(canChuzo){
                 MoveChuzo();
        }else if(canChuzo == false){
                    chuzofinal.velocity = new Vector2(0,0);
                    rb_chuzo.bodyType = RigidbodyType2D.Static;
        }
        if(playercontrol.todo_destruido == true){
            chuzofinal_object.SetActive(true);
            canChuzo = true;
          }
        if(chuzo_script_verdadero.ataco == true){
            timer_can = true;
            boss_object.color = Color.red;
        }
        if(timer_can == true){
            timer = timer + Time.deltaTime;
            if(timer > 3){
                 boss_object.color = Color.white;
                 timer = 0;
                 chuzo_script_verdadero.ataco = false;
            }
        }
    }
    public void MoveChuzo(){;
            Quieto();
            moveChuzo = Input.GetAxis("Horizontal");
            chuzofinal.velocity = new Vector2(moveChuzo * 20,player_rb.velocity.y);
            if(Input.GetMouseButtonDown(0)){
                player_rb.bodyType = RigidbodyType2D.Dynamic;
                canChuzo = false;
                playercontrol.todo_destruido = false;
            }
    }
      public void Quieto(){
            playercontrol.moveInput = 0;
            player_rb.bodyType = RigidbodyType2D.Static;
            rb_chuzo.bodyType = RigidbodyType2D.Dynamic;
    }
}
