using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityStandardAssets.CrossPlatformInput;
public class PlayerController : MonoBehaviour
{   
    [Header("Caracteristicas personaje")]
    public float speed;
    public bool isGrounded;
    public  Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGrounded;
    public float JumpForce;
    private int extraJumps;
    public int extraJumpsValue;
    public float moveInput;
    public float moveChuzo;
    public Rigidbody2D rb;
    public Animator anim;
    public GameObject camara;
    private bool facinRight = true;
    public VidaPersonaje vidaP;
    public bool canMov;
    [Header("Poder vueltas")]
    public int NumVueltas = 0;
    public float currentTime = 0f;
    public float startingTime;
    public bool todo_destruido = false; 
    [Header("Money")]
    public TextMeshProUGUI cashText;
    private int cash;
    [Header("Wall jump")]
    bool isTouchingFront;
    public Transform frontCheck;
    bool wallSliding;
    public float wallSlidingSpeed;
    bool wallJumping;
    public float xWallForce;
    public float yWallForce;
    public float walJumpTime;
    [Header("Dash")]
    public float dashSpeed;
    private float dashTime;
    public float starDashTime;
    private int direction;
    public float starResetDash;
    bool dashing;
    float resetDash;
    [Header("Trampolin")]
    float upspeed; 
    public int girar;
    [Header("Bola de fuego")]
    public GameObject bola_de_fuego;
    private float time_shoot;
    public float limit_time_shoot;
    [Header("Respawn")]
    [SerializeField] private Transform respawn1;
    [SerializeField] private Transform respawn2;
    [SerializeField] private Transform respawn3;
    [SerializeField] private Transform respawn4;
     [SerializeField] private GameObject volver_todo;
    [Header("Botones")]
    public Image boton_final1;
    public Image boton_final2;
    public Cambio_poder poder;
    void Start()
    {
           dashTime = starDashTime;
           extraJumps = extraJumpsValue;
           poder.boton_en_uso1 = PlayerPrefs.GetInt("boton1",0);
           poder.boton_en_uso2 = PlayerPrefs.GetInt("boton2",0);
    }

    // Update is called once per frame
    void Update()
    {   
        cash = PlayerPrefs.GetInt("money",1);
        cashText.text = "$"+cash.ToString();
         moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed,rb.velocity.y);
        //moveInput = CrossPlatformInputManager.GetAxis("Horizontal");
        if(!dashing){
           
       
        }
        if(moveInput > 0.1f){
            frontCheck.eulerAngles = new Vector3(0,0,0);
        }
         if(moveInput < -0.1f){
            frontCheck.eulerAngles = new Vector3(0,180,0);
        }
        //chuzo_script =  GameObject.FindWithTag("chuzos3").GetComponent<ChuzoFinal>();
        DashPower();
        Botones();
    }
    public void Botones(){
          if(poder.boton_en_uso1 == 1){
            boton_final1.sprite = poder.girar;
        }else if( poder.boton_en_uso1 == 2){
            boton_final1.sprite =  poder.dash;
        }else if( poder.boton_en_uso1 == 3){
            boton_final1.sprite =  poder.onda_mental;
        }else if( poder.boton_en_uso1 == 4){
            boton_final1.sprite =  poder.disparo_fuego;
        }else if( poder.boton_en_uso1 == 5){
            boton_final1.sprite =  poder.escudo;
        }else if( poder.boton_en_uso1 == 6){
            boton_final1.sprite =  poder.brazo_luz;
        }else if( poder.boton_en_uso1 == 7){
            boton_final1.sprite =  poder.disparo_luz;
        }
        if(poder.boton_en_uso2 == 1){
            boton_final2.sprite = poder.girar;
        }else if( poder.boton_en_uso2 == 2){
            boton_final2.sprite =  poder.dash;
        }else if( poder.boton_en_uso2 == 3){
            boton_final2.sprite =  poder.onda_mental;
        }else if( poder.boton_en_uso2 == 4){
            boton_final2.sprite =  poder.disparo_fuego;
        }else if( poder.boton_en_uso2 == 5){
            boton_final2.sprite =  poder.escudo;
        }else if( poder.boton_en_uso2 == 6){
            boton_final2.sprite =  poder.brazo_luz;
        }else if( poder.boton_en_uso2 == 7){
            boton_final2.sprite =  poder.disparo_luz;
        }
    }
    private void FixedUpdate() {
        currentTime -= 1 * Time.deltaTime;
          if(currentTime < 0f){
                currentTime = 0;
            }   
        isGrounded  = Physics2D.OverlapCircle(groundCheck.position,checkRadius,whatIsGrounded);
        if(isGrounded){
            upspeed = 500f;
            extraJumps = extraJumpsValue;
        }
        //CrossPlatformInputManager.GetButtonDown("Jump")
        if( Input.GetKeyDown(KeyCode.Space) && extraJumps > 0){
            rb.velocity = Vector2.up * JumpForce;
            extraJumps--;
        }
        if(Input.GetKeyDown(KeyCode.N)){
                 DisparoFuego();
        } 
        if( Input.GetKeyDown(KeyCode.Space) && extraJumps == 0 && isGrounded){
            rb.velocity = Vector2.up * JumpForce;
        }
        if(facinRight == false && moveInput > 0){
            Flip();
        }else if(facinRight == true && moveInput < 0){
            Flip();
        }
        isTouchingFront = Physics2D.OverlapCircle(frontCheck.position,checkRadius,whatIsGrounded);
        if(isTouchingFront == true && isGrounded == false && moveInput != 0){
            wallSliding = true;
        }else{
            wallSliding = false;
        }
        if(wallSliding){
            rb.velocity = new Vector2(rb.velocity.x,Mathf.Clamp(rb.velocity.y,-wallSlidingSpeed,float.MaxValue));
        }
        if( Input.GetKeyDown(KeyCode.Space) && wallSliding == true){
            wallJumping = true;
            Invoke("SetWallJumpingToFalse", walJumpTime);
        }
        if(wallJumping == true){
                rb.velocity  = new Vector2(xWallForce * -moveInput,yWallForce);
        }
       if(Input.GetKeyDown(KeyCode.M)){
           Ataque_luz();
       }
       
 }  
    public void Moving(){
        canMov = true;
    }
    public void primer_boton(int num_boton){
        num_boton = poder.boton_en_uso1;
        if(num_boton == 1){
            GirarEscenario();
        }
        if(num_boton == 2){
            Debug.Log("Dash");
        }
        if(num_boton == 3){
            Debug.Log("Onda mental");
        }
        if(num_boton == 4){
            Debug.Log("Fuego");
        }
        if(num_boton == 5){
            Debug.Log("Escudo");
        }
        if(num_boton == 6){
            Debug.Log("Luz");
        }
        if(num_boton == 7){
            Debug.Log("Disparo luz");
        }
    }
    public void segundo_boton(int num_boton2){
        num_boton2 = poder.boton_en_uso2;
        if(num_boton2 == 1){
            GirarEscenario();
        }
        if(num_boton2 == 2){
            Debug.Log("Dash");
        }
        if(num_boton2 == 3){
            Debug.Log("Onda mental");
        }
        if(num_boton2 == 4){
            Debug.Log("Fuego");
        }
        if(num_boton2 == 5){
            Debug.Log("Escudo");
        }
        if(num_boton2 == 6){
            Debug.Log("Luz");
        }
        if(num_boton2 == 7){
            Debug.Log("Disparo luz");
        }
    }
    public void GirarEscenario(){
        if(currentTime == 0 ){
           currentTime = startingTime;   
        }    
        girar = 1; 
    }
    public void Jump(){
        if(isGrounded){
             rb.velocity = Vector2.up * JumpForce;
        }
    }
    void Flip(){
        facinRight = !facinRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *=-1;
        transform.localScale = Scaler;
    }
    void SetWallJumpingToFalse(){
        wallJumping = false;
    }
    public void CanMove(){
        rb.bodyType = RigidbodyType2D.Dynamic;
    }
     public void DontCanMove(){
        rb.bodyType = RigidbodyType2D.Static;
    }
    public void DashPower(){
        if(direction == 0){
            resetDash -= Time.deltaTime;
            if(Input.GetKeyDown(KeyCode.LeftShift)){
                if(moveInput < 0){
                    direction = 1;
                }else if(moveInput > 0){
                    direction = 2;
                }
            }
        }else{
            if(dashTime <= 0){
                direction = 0;
                dashTime = starDashTime;
                if(resetDash >= 0){
                    rb.velocity = Vector2.zero;
                    dashing = false;
                }
      
            }else{
                dashTime -= Time.deltaTime;
                if(resetDash <= 0){
                if(direction == 1){
                    rb.velocity = Vector2.left * dashSpeed;
                    resetDash = starResetDash;
                    dashing = true;
                }else if(direction == 2){
                    rb.velocity = Vector2.right * dashSpeed;
                    resetDash = starResetDash;
                    dashing = true;
                }
                }
                
            }
        }
    }
    public void DisparoFuego(){
        Instantiate(bola_de_fuego,frontCheck.position,frontCheck.rotation);
    }
    public void Ataque_luz(){
        anim.SetBool("ataque",true);
    }
    public void QuitarVida(){
        vidaP.vida -= 1;
        if(vidaP.vida == 0){
                volver_todo.SetActive(true);
            } 
    }
    public void Respawn(){
        vidaP.vida = PlayerPrefs.GetInt("vida",0);
        StartCoroutine(camara_retomar());
    } 
    IEnumerator camara_retomar(){
        yield return new WaitForSeconds(1f);
        camara.SetActive(true);
           if(transform.position.x >= respawn1.position.x && transform.position.x <= respawn2.position.x){
            transform.position = respawn1.position;
        }else if(transform.position.x >= respawn2.position.x && transform.position.x <= respawn3.position.x){
            transform.position = respawn2.position;
        }else if(transform.position.x >= respawn3.position.x && transform.position.x <= respawn4.position.x){
            transform.position = respawn3.position;
        }else if(transform.position.x >= respawn4.position.x){
            transform.position = respawn4.position;
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.transform.tag == "Chuzos"){
            QuitarVida();
            GetComponent<TimeStop>().StopTime(0.05f,10,0.1f);
        }
        if(collision.transform.tag == "boss"){
            //Destroy(gameObject);
        }
        if(collision.transform.tag == "chuzos3"){
           todo_destruido = true;
        }
        if(collision.transform.tag == "Trampolin"){
            upspeed+=300f;
            if(upspeed > 2000f){
                upspeed = 500f;
            }
            rb.AddForce(new Vector2(0,upspeed));
        }
    }
}
