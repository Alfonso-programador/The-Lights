using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChuzoFinalVerdadero : MonoBehaviour
{   
    public Transform player;
    public Batalla1_10 player_script;
    public MotherSquare boss; 
    public bool ataco;
    public AudioSource hitAudio;
    public ParticleSystem particulas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
           
       
    }
    private void OnCollisionEnter2D(Collision2D col) {
        if(col.transform.tag == "Player"){
                Flip();
        }
        if(col.transform.tag == "boss"){
                if(player_script.canChuzo == false){
                          hitAudio.Play();
                          particulas.Play();
                          boss.salud -= 1;
                          boss.IdelState();
                          ataco = true;
                          gameObject.SetActive(false);
                }
        }
    }
    void Flip(){
        if(player_script.canChuzo){
                 Vector3 Scaler = transform.localScale;
                if(Scaler.x == 1){
                 
                   transform.position = new Vector2 (player.position.x + 4 ,transform.position.y);
                   Scaler.x = -1;
                   transform.localScale = Scaler;
            }else if(Scaler.x == -1){
                    transform.position = new Vector2 (player.position.x - 4 ,transform.position.y);
                    Scaler.x = 1;
                    transform.localScale = Scaler;
            }
        }
       
    }
}
