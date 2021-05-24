using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySimple : MonoBehaviour
{
     public float speed;
    public float distance;
    private bool movingRight = true;
    public int numPermitido;
    public Transform groundDetection;
    public VueltasAnim vueltasAnim;
    public PlayerController player;
    public Animator anim;
    public bool move;
    public Rigidbody2D rb;
    private void Start() {
         rb.bodyType = RigidbodyType2D.Dynamic;
    }
    private void Update()
    {  
       if(vueltasAnim.numVueltas == numPermitido && player.currentTime == 0 || vueltasAnim.numVueltas == 0){
            move = true;
            rb.bodyType = RigidbodyType2D.Dynamic;
            Move();
        }else{
            move = false;
            rb.bodyType = RigidbodyType2D.Static;
            Move();
        }
        anim.SetBool("can",move);
    }   
    void Move(){
    if(move){
            if(gameObject.transform.localScale.x == -1){
                 transform.Translate(Vector2.left * speed * Time.deltaTime);
            }else{
                transform.Translate(Vector2.right * speed * Time.deltaTime);
            }
            RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);
        if (groundInfo.collider == false)
        {   
                if(movingRight == true)
                {
                    transform.eulerAngles = new Vector3(0, -180, 0);
                    movingRight = false;
                }else
                {
                    transform.eulerAngles = new Vector3(0, 0, 0);
                   movingRight = true;
                }
        }
        }
    }
    private void OnCollisionEnter2D(Collision2D col) {
            if(col.transform.tag == "enemy" || col.transform.tag == "Chuzos"  ){
                    if(movingRight == true)
                {
                    transform.eulerAngles = new Vector3(0, -180, 0);
                    movingRight = false;
                }else
                {
                    transform.eulerAngles = new Vector3(0, 0, 0);
                   movingRight = true;
                }
            }
            if(col.transform.tag == "Player"){
                player.QuitarVida();
                col.gameObject.GetComponent<TimeStop>().StopTime(0.05f,10,0.1f);
                Debug.Log("PLAYEEEER");
                    if(movingRight == true)
                {
                    transform.eulerAngles = new Vector3(0, -180, 0);
                    movingRight = false;
                }else
                {
                    transform.eulerAngles = new Vector3(0, 0, 0);
                   movingRight = true;
                }
            }
             
    }
}
