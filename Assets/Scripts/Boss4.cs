using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss4 : MonoBehaviour
{  [Header("Componentes")]
    public Rigidbody2D rb;
    public Transform player;
    float tiempo;
    float time_triangulito;
   [Header("Animacion")]
    public Animator anim;    
    [Header("Teletransportarse")]
    public Transform punto1;
    public Transform punto2;
    public Transform punto3;
    public Transform punto4;
    public Transform punto5;
    bool tele;
    [Header("Tirarse")]
    public float attackSpeedPlayer;
    [Header("Triangulo Aparecer")]
    public GameObject triangulito;
    [Header("Enemigos simples")]
    public GameObject enemigo1;
    public GameObject enemigo2;
    public GameObject enemigo3;
    public GameObject enemigo4; 
    public GameObject enemigo5; 
    public Transform puntoEnemigo1;
    public Transform puntoEnemigo2;
    public Transform puntoEnemigo3;
    [Header("Rayo")]
    public GameObject rayo;
    public Transform eyeCheck;
    void Start()
    {
         Tirarse();
    }

    // Update is called once per frame
    void Update()
    {      
        tiempo += Time.deltaTime;
        if(tiempo >= 2f){
            int random_action = Random.Range(1,3);
            if(random_action == 3){
                Tirarse();
                tiempo = 0;
            }
            if(random_action == 2){
                SpawnEnemigos();
                tiempo = 0;
            }
            if(random_action == 1){
                  RayoLaser();
                  tiempo = 0;
            }
    }
        time_triangulito+= Time.deltaTime;
        if(time_triangulito >= 2f){
            SimpleBulletFollow();
            time_triangulito = 0;
        }
    }
    public void Idle(){
        
    }
    public void Tirarse(){
        transform.position = new Vector2(player.position.x,player.position.y+10f);
        StartCoroutine(atacar_player());
    }
    IEnumerator atacar_player(){
        yield return new WaitForSeconds(1f);
        anim.SetInteger("ataque",1);
        rb.velocity = new Vector2(0,attackSpeedPlayer*Time.deltaTime);
        if(tele = true){
            StartCoroutine(Teletransportarse());
        }
    }
  IEnumerator Teletransportarse(){
      yield return new WaitForSeconds(0.5f);
        rb.velocity = new Vector2(0,0);
        anim.SetInteger("ataque",0);
        if(tele == true){
            int random = Random.Range(1,5);
            switch(random){
                case 1:
                transform.position = punto1.position;
                tele = false;
                break;
                case 2:
                transform.position = punto2.position;
                tele = false;
                break;
                case 3:
                transform.position = punto3.position;
                tele = false;
                break;
                case 4:
                transform.position = punto4.position;
                tele = false;
                break;
                case 5:
                transform.position = punto5.position;
                tele = false;
                break;
            }
        }
    }
    public void SimpleBulletFollow(){
        int random_triangulito = Random.Range(1,8);
        switch(random_triangulito){
            case 1:
            Instantiate(triangulito,punto1.position,punto1.rotation);
            break;
            case 2:
            Instantiate(triangulito,punto2.position,punto2.rotation);
            break;
            case 3:
            Instantiate(triangulito,punto3.position,punto3.rotation);
            break;
            case 4:
            Instantiate(triangulito,punto4.position,punto4.rotation);
            break;
            case 5:
            Instantiate(triangulito,punto5.position,punto5.rotation);
            break;
            case 6:
            Instantiate(triangulito,puntoEnemigo1.position,puntoEnemigo1.rotation);
            break;
            case 7:
            Instantiate(triangulito,puntoEnemigo2.position,puntoEnemigo2.rotation);
            break;
            case 8:
            Instantiate(triangulito,puntoEnemigo3.position,puntoEnemigo3.rotation);
            break;
        }
    }
    public void RayoLaser(){
        Instantiate(rayo,eyeCheck.position,eyeCheck.rotation);
        StartCoroutine(DestruirRayo());
    }
    IEnumerator DestruirRayo(){
        yield return new WaitForSeconds(2f);
        Destroy(rayo);
    }
    public void SpawnEnemigos(){
        int random_enemy = 1;//Random.Range(1,5);
        if(random_enemy == 1){
            Instantiate(enemigo1,puntoEnemigo1.position,puntoEnemigo1.rotation);
        }else if(random_enemy == 2){
            Instantiate(enemigo2,puntoEnemigo1.position,puntoEnemigo1.rotation);
        }else if(random_enemy == 3){
            Instantiate(enemigo3,puntoEnemigo1.position,puntoEnemigo1.rotation);
        }else if(random_enemy == 4){
            Instantiate(enemigo4,puntoEnemigo1.position,puntoEnemigo1.rotation);
        }else if(random_enemy == 2){
            Instantiate(enemigo5,puntoEnemigo1.position,puntoEnemigo1.rotation);
        }   
        int random_enemy2 = 1; //Random.Range(1,5);
         if(random_enemy2 == 1){
            Instantiate(enemigo1,puntoEnemigo2.position,puntoEnemigo2.rotation);
        }else if(random_enemy2 == 2){
            Instantiate(enemigo2,puntoEnemigo2.position,puntoEnemigo2.rotation);
        }else if(random_enemy2 == 3){
            Instantiate(enemigo3,puntoEnemigo2.position,puntoEnemigo2.rotation);
        }else if(random_enemy2 == 4){
            Instantiate(enemigo4,puntoEnemigo2.position,puntoEnemigo2.rotation);
        }else if(random_enemy2 == 2){
            Instantiate(enemigo5,puntoEnemigo2.position,puntoEnemigo2.rotation);
        } 
        int random_enemy3 = 1; //Random.Range(1,5);
         if(random_enemy3 == 1){
            Instantiate(enemigo1,puntoEnemigo3.position,puntoEnemigo3.rotation);
        }else if(random_enemy3 == 2){
            Instantiate(enemigo2,puntoEnemigo3.position,puntoEnemigo3.rotation);
        }else if(random_enemy3 == 3){
            Instantiate(enemigo3,puntoEnemigo3.position,puntoEnemigo3.rotation);
        }else if(random_enemy3 == 4){
            Instantiate(enemigo4,puntoEnemigo3.position,puntoEnemigo3.rotation);
        }else if(random_enemy3 == 2){
            Instantiate(enemigo5,puntoEnemigo3.position,puntoEnemigo3.rotation);
        } 
    }
    private void OnCollisionEnter2D(Collision2D col) {
        if(col.transform.tag == "ground"){
            tele = true;
        }
    }
}
