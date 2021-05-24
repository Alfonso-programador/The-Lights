using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotherSquare : MonoBehaviour
{
    [Header("Idel")]
        [SerializeField] float idelMoveSpeed;
        [SerializeField]  Vector2 idelMoveDirection;
    [Header("AttackUpDown")]
        [SerializeField] float attackMoveSpeed;
        [SerializeField]  Vector2 attackMoveDirection;
    [Header("AttackPlayer")]
       [SerializeField] float attackPlayerSpeed;
       [SerializeField] Transform player;
       private Vector2 playerPosition; 
       private bool hasPlayerPosition;
    [Header("Other")]
       [SerializeField] Transform groundCheckUp;
       [SerializeField] Transform groundCheckDown;
       [SerializeField] Transform groundCheckWall;
       [SerializeField] float groundCheckRadius;
       [SerializeField] LayerMask groundLayer;
       private bool isTouchingUp;
       private bool isTouchingDown;
       private bool isTouchingWall;
       private bool goingUp = true;
       private bool facingLeft = true;
       public int instanceate = 0;
       public Rigidbody2D enemyRB;
       public Animator enemyAnim; 
       public Animator camara;
       public GameObject chuzo1;
       public GameObject chuzo2;
       public GameObject chuzo3;
       public GameObject chuzofinal;
       public int espacio_dejado; 
       public PlayerController player_script;
       public empezar empieza;
       public int salud = 3;
       public AudioSource audio1;
       public AudioSource audio2;
       public AudioSource audio3;
       public AudioSource audio4;
       public AudioSource impactAudio;
       [Header("Effects")]
       public GameObject impactGround;
       public GameObject gritoboss;
    void Start()
    {
        idelMoveDirection.Normalize();
        attackMoveDirection.Normalize();
    }

    // Update is called once per frame
    void Update()
    {   
        if(empieza.iniciar == true){
            enemyAnim.SetBool("iniciar",true);
        }
        isTouchingUp = Physics2D.OverlapCircle(groundCheckUp.position,groundCheckRadius,groundLayer);
        isTouchingDown = Physics2D.OverlapCircle(groundCheckDown.position,groundCheckRadius,groundLayer);
        isTouchingWall = Physics2D.OverlapCircle(groundCheckWall.position,groundCheckRadius,groundLayer);
        if(facingLeft){
                espacio_dejado = 3;
        }else{
             espacio_dejado = -3;
        }
        if(player_script.todo_destruido == true){
                      enemyRB.bodyType = RigidbodyType2D.Static;
        }else{
            enemyRB.bodyType = RigidbodyType2D.Dynamic;
        }
        if(salud == 0){
            Destroy(gameObject);
        }
    }
    void randomStatePicker(){
        int randomState = Random.Range(0,2);
        if(randomState == 0){
                //attackUpdown anim
                enemyAnim.SetTrigger("AttackUpDown");
        }else if(randomState == 1){
            //attackPlayer animation
                enemyAnim.SetTrigger("AttackPlayer");
        }
    }
    public void IdelState(){
        if(isTouchingUp && goingUp){
            ChangeDirection();
        }else if(isTouchingDown && !goingUp){
            ChangeDirection();
        }
        if(isTouchingWall){
            if(facingLeft){
                Flip();
            }else if(!facingLeft){
                
                Flip();
            }

        }
        enemyRB.velocity = idelMoveSpeed * idelMoveDirection;
    }
    public void AttackUpDown(){
        if(isTouchingUp && goingUp){
             if(instanceate == 6){
                    Vector2 position_chuzo2 = new Vector2 (transform.position.x + espacio_dejado,transform.position.y + 1);
                   Quaternion rotation2 = new Quaternion();
                   Instantiate(chuzo2,position_chuzo2,rotation2);
            }if(instanceate == 12){
                   Vector2 position_chuzo = new Vector2 (transform.position.x + espacio_dejado,transform.position.y + 1);
                   Quaternion rotation = new Quaternion();
                   Instantiate(chuzo1,position_chuzo,rotation);
            }if(instanceate == 18){
                   Vector2 position_chuzo3 = new Vector2 (transform.position.x + espacio_dejado,transform.position.y + 1);
                   Quaternion rotation3 = new Quaternion();
                   Instantiate(chuzo3,position_chuzo3,rotation3);
                   instanceate = 0;
            }
            instanceate+=1;;
            impactAudio.Play();
            GameObject impact = Instantiate(impactGround,groundCheckUp.position,Quaternion.Euler(0f,0f, 180f));
            ChangeDirection();
        }else if(isTouchingDown && !goingUp){
            impactAudio.Play();
             GameObject impact = Instantiate(impactGround,groundCheckDown.position,transform.rotation);
            ChangeDirection();
        }
        if(isTouchingWall){
            if(facingLeft){
                Flip();
            }else if(!facingLeft){
                Flip();
            }
        }
        enemyRB.velocity = attackMoveDirection * attackMoveSpeed;
    }
    public void AttackPlayer(){
        if(!hasPlayerPosition){
            //tomar la posicion del jugador
             playerPosition = player.position - transform.position;
            //Normalize la posicion del player
             playerPosition.Normalize();
             hasPlayerPosition = true;
        }
        if(hasPlayerPosition){
             enemyRB.velocity = playerPosition * attackPlayerSpeed;
        }
        if(isTouchingWall || isTouchingDown || isTouchingUp ){// || isTouchingUp 
            enemyRB.velocity = Vector2.zero;
            hasPlayerPosition = false;
            //play slamed animation
            impactAudio.Play();
            enemyAnim.SetTrigger("Slamed");
        }
        //Atacar en esa posicion
       
    }
   public void FlipTowardsPlayers()
    {
        float playerDirection = player.position.x - transform.position.x;
        if(playerDirection > 0 && facingLeft){
            Flip();
        }else if(playerDirection < 0  && !facingLeft){
            Flip();
        }
    }
    public void ChangeDirection(){
        goingUp = !goingUp;
        idelMoveDirection.y *= -1;
        attackMoveDirection.y *= -1;
    }
   public void Flip(){
        facingLeft = !facingLeft;
        idelMoveDirection.x *= -1;
        attackMoveDirection.x *= -1;
        transform.Rotate(0,180,0);
    }
    public void InicarIdle(){
        enemyAnim.SetBool("empezar",true);
    }
    public void Audio1(){
            audio1.Play();
    }
    public void Audio2(){
            audio1.Stop();
            audio2.Play();
            GameObject grito = Instantiate(gritoboss,transform.position,transform.rotation);
    }
    public void PararseAudio(){
        audio3.Play();
    }
    public void chuzosAudio(){
        audio4.Play();
    }
    public void gritar(){
        camara.SetBool("gritar",true);
    }
    public void no_gritar(){
        camara.SetBool("gritar",false);
    }
    public void MovingPlayer(){
        player_script.CanMove();
    }
     public void DontMovingPlayer(){
        player_script.DontCanMove();
    }
    public void moverCamara(){
        camara.SetTrigger("gritar");
    }
    private void OnDrawGizmosSelected() {
        Gizmos.color= Color.cyan;
        Gizmos.DrawWireSphere(groundCheckUp.position,groundCheckRadius);
        Gizmos.DrawWireSphere(groundCheckDown.position,groundCheckRadius);
        Gizmos.DrawWireSphere(groundCheckWall.position,groundCheckRadius);
    }
}
