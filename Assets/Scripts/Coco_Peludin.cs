using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coco_Peludin : MonoBehaviour
{   
    public float speed;
    public float distance;
    private bool movingRight = true;
    private bool atacar;
    int version;
    public Transform groundDetection;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        if(atacar == true){
            StartCoroutine(Atacar());
        }
        Debug.Log(atacar);
    }
   public void Move(){
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
   private void OnTriggerEnter2D(Collider2D col) {
       if(col.transform.tag == "Player"){
           atacar = true;
       }
   }
   private void OnCollisionEnter2D(Collision2D col) {
       if(col.transform.tag == "Player"){
        atacar = false;
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
   IEnumerator Atacar(){
       yield return new WaitForSeconds(0.5f);
       if(atacar){
           if(movingRight){
                rb.AddForce(new Vector2(100*speed,0));
               atacar = false;
           }else{
                rb.AddForce(new Vector2(100*-speed,0));
               atacar = false;
           }
        }
   }
}
