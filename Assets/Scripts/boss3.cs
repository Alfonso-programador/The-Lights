using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss3 : MonoBehaviour
{   [Header("Gameobjects")]
    public GameObject lugar1_lava;
    public GameObject lugar2_lava;
    public Rigidbody2D rb;
    public GameObject player;
    [Header("Variables")]
    public float force;
    public float force_lava;
    public float force_one_lava;
    private float time;
    private int intentos_shoot = 0;
    private int intentos_move = 0;
    [Header("Bola de lava")]
      public GameObject ball_lava;
    [Header("Bolas de lava")] 
    public Transform ball2_lava;
    public Transform ball3_lava;
    public Transform ball4_lava;
    public Transform ball5_lava;
    public Transform ball6_lava;
    public Transform ball7_lava;
    public Transform ball8_lava;
    public Transform ball9_lava; 
    public Transform ball10_lava;
    public Transform ball11_lava;
    public Transform ball12_lava;         
    [Header("Posiciones")]
    public Vector2 target;
    public Transform lanzamiento;
    [Header("Atacar player")] 
    public float attackPlayerSpeed;
    private Vector2 playerPosition; 
    [Header("Caer lava")]
    public Transform caer1;
    public Transform caer2;
    public Transform caer3;
    public Transform caer4;
    public Transform caer5;
    public Transform caer6;
    public Transform caer7;
    public Transform caer8;
    public Transform caer9;
    public GameObject lava_caer;
    [Header("Lugar_Player")]
    public Transform lugar1,lugar2,lugar3;
    [SerializeField] float CheckRadius;
    private bool isTouchingPoint1;
    private bool isTouchingPoint2;
    private bool isTouchingPoint3;
    [SerializeField] LayerMask PlayerLayer;
    [Header("Atacado")]
    public Animator anim_collider;
    public int atacado;
    // Start is called before the first frame update
    void Start()
    {   
        gameObject.transform.position = lugar1_lava.transform.position;
        Saltar();
    }

    // Update is called once per frame
    void Update()
    {   
        isTouchingPoint1 = Physics2D.OverlapCircle(lugar1.position,CheckRadius,PlayerLayer);
        isTouchingPoint2 = Physics2D.OverlapCircle(lugar2.position,CheckRadius,PlayerLayer);
        isTouchingPoint3 = Physics2D.OverlapCircle(lugar3.position,CheckRadius,PlayerLayer);
        time += Time.deltaTime;
        if(time >= 5f){
            Mover();
            time = 0;
            atacado += 1;
        }
         if (Input.GetMouseButton(0))
        {
            anim_collider.SetBool("sube",true);
        }
         if (Input.GetMouseButton(1))
        {
            anim_collider.SetBool("sube",false);
        }
    }
    void Saltar(){
        rb.AddForce(new Vector2(0f,10f*force));
        CaerLava();
        int ataque = Random.Range(1,2);
        if(ataque == 1){
             if(intentos_shoot <= 3){
                    StartCoroutine("Shoot");
             }
              intentos_shoot += 1;
             if(intentos_shoot == 4){
                 StartCoroutine("MultipleShoot");
                 intentos_shoot = 0;
             }

        }
        if(ataque == 2){
            if(intentos_shoot <= 3){
                    StartCoroutine("MultipleShoot");
            }
            intentos_shoot += 1;
            if(intentos_shoot == 4){
                    StartCoroutine("Shoot");
                    intentos_shoot = 0;
            }
        }
    }
    void Mover(){
        int posicion = Random.Range(1,2);
        if(posicion == 1){
            if(intentos_move < 3){
                  gameObject.transform.position = lugar1_lava.transform.position;
            }
             intentos_move += 1;
             if(intentos_move >= 3){
                 gameObject.transform.position = lugar2_lava.transform.position;
                  intentos_move = 0;
             }
        }
       if(posicion == 2){
           if(intentos_move < 3){
                gameObject.transform.position = lugar2_lava.transform.position;
           }
            intentos_move += 1;
            if(intentos_move == 3){
                gameObject.transform.position = lugar1_lava.transform.position;
                intentos_move = 0;
            }
        }
        Saltar();
    }
    IEnumerator Shoot(){
        yield return new WaitForSeconds(1f);
        Debug.Log("SHOT");
        GameObject lavaIns = Instantiate(ball_lava,lanzamiento.position,Quaternion.identity);
        target = player.transform.position - lanzamiento.position;
        target.Normalize();
        lavaIns.GetComponent<Rigidbody2D>().AddForce(target * force_one_lava);
    }
    IEnumerator MultipleShoot(){
        yield return new WaitForSeconds(1f);
        Debug.Log("MULTIPLE");
        //1
        GameObject lavaIns = Instantiate(lava_caer,lanzamiento.position,Quaternion.identity);
        lavaIns.GetComponent<Rigidbody2D>().AddForce(new Vector2(0,10f * force_lava));
        //2
        GameObject lavaIns2 = Instantiate(ball_lava,ball2_lava.position,Quaternion.identity);
        lavaIns2.GetComponent<Rigidbody2D>().AddForce(new Vector2(10f * force_lava,30f *force_lava));
        //3
        GameObject lavaIns3 = Instantiate(ball_lava,ball3_lava.position,Quaternion.identity);
        lavaIns3.GetComponent<Rigidbody2D>().AddForce(new Vector2(10f * force_lava,30f *force_lava));
        //4
        GameObject lavaIns4 = Instantiate(ball_lava,ball4_lava.position,Quaternion.identity);
        lavaIns4.GetComponent<Rigidbody2D>().AddForce(new Vector2(10f * force_lava,0f));
        //5
        GameObject lavaIns5 = Instantiate(ball_lava,ball5_lava.position,Quaternion.identity);
        lavaIns5.GetComponent<Rigidbody2D>().AddForce(new Vector2(20f * force_lava,-10f *force_lava));
        //6
        GameObject lavaIns6 = Instantiate(ball_lava,ball6_lava.position,Quaternion.identity);
        lavaIns6.GetComponent<Rigidbody2D>().AddForce(new Vector2(10f * force_lava,-10f *force_lava));
        //7
        GameObject lavaIns7 = Instantiate(ball_lava,ball7_lava.position,Quaternion.identity);
        lavaIns7.GetComponent<Rigidbody2D>().AddForce(new Vector2(0,-10f * force_lava));
        //8
        GameObject lavaIns8 = Instantiate(ball_lava,ball8_lava.position,Quaternion.identity);
        lavaIns8.GetComponent<Rigidbody2D>().AddForce(new Vector2(-10f * force_lava,-10f *force_lava));
        //9
        GameObject lavaIns9 = Instantiate(ball_lava,ball9_lava.position,Quaternion.identity);
        lavaIns9.GetComponent<Rigidbody2D>().AddForce(new Vector2(-20f * force_lava,-10f *force_lava));
        //10
        GameObject lavaIns10 = Instantiate(ball_lava,ball10_lava.position,Quaternion.identity);
        lavaIns10.GetComponent<Rigidbody2D>().AddForce(new Vector2(-10f * force_lava,0f));
        //11
        GameObject lavaIns11 = Instantiate(ball_lava,ball11_lava.position,Quaternion.identity);
        lavaIns11.GetComponent<Rigidbody2D>().AddForce(new Vector2(-20f * force_lava,10f *force_lava));
        //12
        GameObject lavaIns12 = Instantiate(ball_lava,ball12_lava.position,Quaternion.identity);
        lavaIns12.GetComponent<Rigidbody2D>().AddForce(new Vector2(-10f * force_lava,10f *force_lava));
    }
    public void CaerLava(){
         int posicion = Random.Range(1,9);;
         if(posicion == 1){
             GameObject lava= Instantiate(lava_caer,new Vector3(caer1.position.x,caer1.position.y,0),Quaternion.identity);
         }if(posicion == 2){
             GameObject lava= Instantiate(lava_caer,new Vector3(caer2.position.x,caer2.position.y,0),Quaternion.identity);
         }if(posicion == 3){
             GameObject lava= Instantiate(lava_caer,new Vector3(caer3.position.x,caer3.position.y,0),Quaternion.identity);
         }if(posicion == 4){
             GameObject lava= Instantiate(lava_caer,new Vector3(caer4.position.x,caer4.position.y,0),Quaternion.identity);
         }if(posicion == 5){
             GameObject lava= Instantiate(lava_caer,new Vector3(caer5.position.x,caer5.position.y,0),Quaternion.identity);
         }if(posicion == 6){
             GameObject lava= Instantiate(lava_caer,new Vector3(caer6.position.x,caer6.position.y,0),Quaternion.identity);
         }if(posicion == 7){
             GameObject lava= Instantiate(lava_caer,new Vector3(caer7.position.x,caer7.position.y,0),Quaternion.identity);
         }
         if(posicion == 8){
             GameObject lava= Instantiate(lava_caer,new Vector3(caer8.position.x,caer8.position.y,0),Quaternion.identity);
         }if(posicion == 9){
             GameObject lava= Instantiate(lava_caer,new Vector3(caer9.position.x,caer9.position.y,0),Quaternion.identity);
         }
}

    public void Atacado(){
      
    }
    private void OnDrawGizmosSelected() {
        Gizmos.color= Color.cyan;
        Gizmos.DrawWireSphere(lugar1.position,CheckRadius);
        Gizmos.DrawWireSphere(lugar2.position,CheckRadius);
        Gizmos.DrawWireSphere(lugar3.position,CheckRadius);
    }
 }