using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Boss2 : MonoBehaviour
{   [Header("Gameobjects")]
    public GameObject coco;
    public GameObject player;
    public Rigidbody2D rb;
    [Header("Posiciones")]
    public Transform lanzamiento;
    public Vector2 target;
    [SerializeField] Vector2 moving;
    public Transform point1,point2,point3;
    [Header("Variables")]
    float time;
    public float Force;
    [SerializeField] float JumpForce;
    [SerializeField] int num_disparos;
    [SerializeField] float CheckRadius;
    private bool isTouchingPoint1;
    private bool isTouchingPoint2;
    private bool isTouchingPoint3;
    private bool canShoot = true;
    [SerializeField] LayerMask BossLayer;
    [SerializeField] PlatformEffector2D effector1;
    [SerializeField] PlatformEffector2D effector2;
    [SerializeField] PlatformEffector2D effector3;
    int ataco = 0;
    // Start is called before the first frame update
    void Start()
    {   
       transform.position = point2.position;
         
    }

    // Update is called once per frame
    void Update()
    {   
        isTouchingPoint1 = Physics2D.OverlapCircle(point1.position,CheckRadius,BossLayer);
        isTouchingPoint2 = Physics2D.OverlapCircle(point2.position,CheckRadius,BossLayer);
        isTouchingPoint3 = Physics2D.OverlapCircle(point3.position,CheckRadius,BossLayer);
        if(canShoot == true){
              time += Time.deltaTime;
        }
        if(time >= 1f){
            if(canShoot == true){
                  Shoot();
            }
            if(canShoot == false && time == 0){
                int desicion = Random.Range(0,2);
                if(desicion == 2){
                    Shoot();
                }
                if(desicion == 1){
                    Move();
                }
                if(desicion == 0){
                    Caer();
                }
            }
        }
    }

    public void Shoot(){
             num_disparos +=1;
             GameObject cocoIns = Instantiate(coco,lanzamiento.position,Quaternion.identity);
             target = player.transform.position - lanzamiento.position;
             target.Normalize();
             cocoIns.GetComponent<Rigidbody2D>().AddForce(target * Force);
             int parar = Random.Range(0,5);
             if(parar == 3  && num_disparos >= 3 || num_disparos >= 6){
                 Debug.Log("Para");
                 canShoot = false;
                 num_disparos = 0;
                 time = 0;
             }
             time = 0;
    }
    public void Move(){
            moving = new Vector2(point2.position.x,point2.position.y);
             if(isTouchingPoint1){
                 int random = Random.Range(1,3);
                 if(random == 2){
                     rb.AddForce(moving * JumpForce);
                 } 
                 if(random == 3){
                     rb.AddForce(moving * (JumpForce+200f));
                 }
             }
             if(isTouchingPoint2){
                 int random = Random.Range(1,3);
                 if(random == 1){
                     rb.AddForce(new Vector2(moving.x * -JumpForce,JumpForce+200f));
                 }
                 if(random == 2){
                     rb.AddForce(moving * JumpForce);
                 }
             }
             if(isTouchingPoint3){
                int random = Random.Range(1,3);
                 if(random == 2){
                     rb.AddForce(new Vector2(moving.x * -JumpForce,JumpForce+200f));
                 } 
                 if(random == 1){
                     rb.AddForce(new Vector2(moving.x * -JumpForce-150f,JumpForce+200f));
                 }
             }
             time = 0;
            StartCoroutine("can");
    }
    public void Caer(){
                canShoot = false;
                time = 0;
                 if(isTouchingPoint1){
                    effector1.rotationalOffset = 180f;
                }
                if(isTouchingPoint2){
                    effector2.rotationalOffset = 180f;
                } 
                if(isTouchingPoint3){
                    effector3.rotationalOffset = 180f;
                }
                rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
                StartCoroutine("Subir");
    }
    IEnumerator Subir(){
        yield return new WaitForSeconds(3f);
        effector1.rotationalOffset = 0f;
        effector2.rotationalOffset = 0f;
        effector3.rotationalOffset = 0f;
        rb.AddForce(new Vector2(0,600f));
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        time = 0;
        StartCoroutine("can");
    }
    IEnumerator can(){
                 yield return new WaitForSeconds(1f);
                 canShoot = true;
    }
    private void OnDrawGizmosSelected() {
        Gizmos.color= Color.cyan;
        Gizmos.DrawWireSphere(point1.position,CheckRadius);
        Gizmos.DrawWireSphere(point2.position,CheckRadius);
        Gizmos.DrawWireSphere(point3.position,CheckRadius);
    }
    private void OnCollisionEnter2D(Collision2D col) {
        if(col.transform.tag == "Player"){
            ataco += 1;
            Debug.Log(ataco);
            if(ataco == 3){
                Destroy(gameObject);
            }
        }
    }
}