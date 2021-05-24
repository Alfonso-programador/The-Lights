using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Final_Boss : MonoBehaviour
{   
    [Header("Fase 1")]
    float tiempo_disparo_luz;
    public float force_luz;
    float tiempo_ataques_fase1;
    public float tiempo_limite_fase1;
    [Header("Objetos")]
    public GameObject chuzos;
    public GameObject plataformas;
    public GameObject plataformas2;
    public GameObject rayo_laser;
    public GameObject bola_luz;
    public GameObject bola_multi;
    public GameObject superLaser;
    public GameObject objeto_Fase1;
    [Header("Transform")]
    public Transform player;
    public Transform rotacion;
    Vector3 posicion_rayo;
    public Transform Check_izq;
    public Transform Check_der;
    public Transform check_multi1;
    public Transform check_multi2;
    public Transform check_multi3;
    public Transform check_multi4;
    public Transform check_multi5;
    public Transform check_multi6;
    public Transform check_multi7;
    public Transform check_multi8;
    public Transform check_multi9;
    public Transform check_multi10;
    public Transform point_super_laser;
    public Transform point_normal;
    [Header("Fase 2")]
    public GameObject plataformas_subir; 
    float time_laser; 
    public float time_laser_limit; 
    public Transform desaparecer; 
    public GameObject objeto_Fase2;
    [Header("Fase 3")]
    public GameObject objeto_Fase3;
    public Transform punto1_fase3;
    public Transform punto2_fase3;
    public Transform punto3_fase3;
    public Transform punto4_fase3;
    public Transform punto5_fase3; 
    public Transform punto6_fase3;
    public Transform punto7_fase3;
    float time_fase3;
    public GameObject bola_luz_fase3;
    public float force_luz_fase3;
    [Header("Bools")]
    bool Fase1;
    bool Fase2;
    bool Fase3;
    public plataforma_Boss_Final plataforma_fase3;
    public Text puntos;
    public int puntos_dados;
    public int empezar = 0;
    bool disparar_luz_bool;
    // Start is called before the first frame update
    void Puntos(){
        if (Input.GetMouseButtonDown(0)){
            puntos_dados += 1;
            puntos.text = puntos_dados.ToString();
        }
    }
    void Start()
    {   
        Fase1 = true;
        disparar_luz_bool = true;
    }
    // Update is called once per frame
    void Update()
    {   
        Puntos();
        if(disparar_luz_bool == true){
            tiempo_disparo_luz += Time.deltaTime;
            if(tiempo_disparo_luz >= 3f){
            Disparar_Luz();
            tiempo_disparo_luz = 0;
        }
    }
        
        if(Fase1 == true){
             tiempo_ataques_fase1 += Time.deltaTime;
             if(tiempo_ataques_fase1 >= tiempo_limite_fase1){
                    int random_attack = Random.Range(1,3);
                    switch(random_attack){
                        case 1:
                        chuzos_y_laser();
                        StartCoroutine(desactivar_ataque1_fase1());
                        break;
                        case 2:
                        super_laser();
                        StartCoroutine(desactivar_ataque2_fase1());
                        break;
                        case 3:
                         disparo_multiple();
                        break;
                    }
                   tiempo_ataques_fase1 = 0; 
             }
        }
        if(puntos_dados >= 15){
            Fase1 = false;
            Destroy(objeto_Fase1);
            if(empezar == 0 ){
                 Fase2 = true;
            }
        }
        if(Fase2 == true){
            Debug.Log("FASE 2 ACTIVAAAA");
            transform.position = desaparecer.position;
            Subir_Plataformas();
            time_laser +=Time.deltaTime;
            if(time_laser >= time_laser_limit){
                Laser_subir();
                time_laser = 0;
            } 
        }
        if(plataforma_fase3.fase3 == true){
             Fase3 = true;
             Fase2 = false;
        }
        if(Fase3 == true){
            disparar_luz_bool = false;
            objeto_Fase3.SetActive(true);
             time_fase3 += Time.deltaTime;
            if(time_fase3 >= 3){
                Teletransportar_fase3();
                time_fase3 = 0;
            }
            time_laser += Time.deltaTime;
            time_laser_limit = 5;
           if(time_laser >= time_laser_limit){
               Debug.Log("laser");
                Laser_subir();
                time_laser = 0;
            } 
        }
        if(puntos_dados >=40){
            Destroy(gameObject);
        }
    }
    // 1 fase
    // Primer Ataque
    void chuzos_y_laser(){
        //Plataformas
        plataformas.SetActive(true);
        //chuzos
        StartCoroutine(chuzos_aparecer());
        //Laser
        StartCoroutine(laser_aparecer());
    }
    IEnumerator chuzos_aparecer(){
        yield return new WaitForSeconds(1f);
        chuzos.SetActive(true);
    }
    IEnumerator laser_aparecer(){
        yield return new WaitForSeconds(3f);
        posicion_rayo.x = player.position.x;
        posicion_rayo.y = -7f;
        Instantiate(rayo_laser,posicion_rayo,rotacion.rotation);
    }
    void Disparar_Luz(){
        int random_luz = Random.Range(1,2);
        if(random_luz == 1){
            Instantiate(bola_luz,Check_der.position,Check_der.rotation);
        }
        if(random_luz == 2){
            Instantiate(bola_luz,Check_izq.position,Check_izq.rotation);
        }
    }
    public void destruir_laser(){
        Destroy(rayo_laser);
    }
    IEnumerator desactivar_ataque1_fase1(){
        yield return new WaitForSeconds(5f);
        plataformas.SetActive(false);
        chuzos.SetActive(false);
    }
    
    //Segundo Ataque
    void super_laser(){
        plataformas2.SetActive(true);
        transform.position = point_super_laser.position;
        StartCoroutine(super_laser_aparecer());
    }
    IEnumerator super_laser_aparecer(){
        yield return new WaitForSeconds(2f);
        Instantiate(superLaser,Check_izq.position,rotacion.rotation);
    }
     IEnumerator desactivar_ataque2_fase1(){
        yield return new WaitForSeconds(5f);
        plataformas2.SetActive(false);
        transform.position = point_normal.position;
    }
    //Tercer Ataque
    void disparo_multiple(){
        //1
        GameObject luzMultiIns = Instantiate(bola_multi,check_multi1.position,Quaternion.identity);
        luzMultiIns.GetComponent<Rigidbody2D>().AddForce(new Vector2(0,-10f * force_luz));
        //2
        GameObject luzMultiIns2 = Instantiate(bola_multi,check_multi2.position,Quaternion.identity);
        luzMultiIns2.GetComponent<Rigidbody2D>().AddForce(new Vector2(15f * force_luz ,-10f * force_luz ));
        //3
        GameObject luzMultiIns3 = Instantiate(bola_multi,check_multi3.position,Quaternion.identity);
        luzMultiIns3.GetComponent<Rigidbody2D>().AddForce(new Vector2(30f * force_luz ,-10f * force_luz ));
        //4
        GameObject luzMultiIns4 = Instantiate(bola_multi,check_multi4.position,Quaternion.identity);
        luzMultiIns4.GetComponent<Rigidbody2D>().AddForce(new Vector2(40f * force_luz ,force_luz));
        //5
        GameObject luzMultiIns5 = Instantiate(bola_multi,check_multi5.position,Quaternion.identity);
        luzMultiIns5.GetComponent<Rigidbody2D>().AddForce(new Vector2(40f * force_luz ,10f * force_luz));
        //6
        GameObject luzMultiIns6 = Instantiate(bola_multi,check_multi6.position,Quaternion.identity);
        luzMultiIns6.GetComponent<Rigidbody2D>().AddForce(new Vector2(0,50f * force_luz));
        //7
        GameObject luzMultiIns7 = Instantiate(bola_multi,check_multi7.position,Quaternion.identity);
        luzMultiIns7.GetComponent<Rigidbody2D>().AddForce(new Vector2(-40f * force_luz ,10f * force_luz));
        //8
        GameObject luzMultiIns8 = Instantiate(bola_multi,check_multi8.position,Quaternion.identity);
        luzMultiIns8.GetComponent<Rigidbody2D>().AddForce(new Vector2(-40f * force_luz ,force_luz));
        //9
        GameObject luzMultiIns9 = Instantiate(bola_multi,check_multi9.position,Quaternion.identity);
        luzMultiIns9.GetComponent<Rigidbody2D>().AddForce(new Vector2(-30f * force_luz ,-10f * force_luz ));
        //10
        GameObject luzMultiIns10 = Instantiate(bola_multi,check_multi10.position,Quaternion.identity);
        luzMultiIns10.GetComponent<Rigidbody2D>().AddForce(new Vector2(-15f * force_luz ,-10f * force_luz ));
    }
    //Fase 2
    void Subir_Plataformas(){
        plataformas_subir.SetActive(true);
    }
    void Laser_subir(){
        posicion_rayo.x = player.position.x;
        posicion_rayo.y = -7f;
        Instantiate(rayo_laser,posicion_rayo,rotacion.rotation);
    }
    void destruir_fase2(){
        Destroy(objeto_Fase2);
    }
    //Fase 3
    void Teletransportar_fase3(){
        if(empezar == 0){
            transform.position = punto1_fase3.position;
            empezar = 1;
        }else{
             int random_fase3 = Random.Range(1,7);
             switch(random_fase3){
                 case 1:
                 transform.position = punto1_fase3.position;
                 break;
                 case 2:
                 transform.position = punto2_fase3.position;
                 break;
                 case 3:
                 transform.position = punto3_fase3.position;
                 break;
                 case 4:
                 transform.position = punto4_fase3.position;
                 break;
                 case 5:
                 transform.position = punto5_fase3.position;
                 break;
                 case 6:
                 transform.position = punto6_fase3.position;
                 break;
                 case 7:
                 transform.position = punto7_fase3.position;
                 break;        
        }
            
        }
        disparo_multiple_fase3();
    }
    void disparo_multiple_fase3(){
        //1
        GameObject luzMultiIns_fase3 = Instantiate(bola_luz_fase3,check_multi1.position,Quaternion.identity);
        luzMultiIns_fase3.GetComponent<Rigidbody2D>().AddForce(new Vector2(0,-10f * force_luz_fase3));
        //2
        GameObject luzMultiIns2_fase3 = Instantiate(bola_luz_fase3,check_multi2.position,Quaternion.identity);
        luzMultiIns2_fase3.GetComponent<Rigidbody2D>().AddForce(new Vector2(15f * force_luz_fase3 ,-10f * force_luz_fase3 ));
        //3
        GameObject luzMultiIns3_fase3 = Instantiate(bola_luz_fase3,check_multi3.position,Quaternion.identity);
        luzMultiIns3_fase3.GetComponent<Rigidbody2D>().AddForce(new Vector2(30f * force_luz_fase3 ,-10f * force_luz_fase3 ));
        //4
        GameObject luzMultiIns4_fase3 = Instantiate(bola_luz_fase3,check_multi4.position,Quaternion.identity);
        luzMultiIns4_fase3.GetComponent<Rigidbody2D>().AddForce(new Vector2(40f * force_luz_fase3 ,force_luz_fase3));
        //5
        GameObject luzMultiIns5_fase3 = Instantiate(bola_luz_fase3,check_multi5.position,Quaternion.identity);
        luzMultiIns5_fase3.GetComponent<Rigidbody2D>().AddForce(new Vector2(40f * force_luz_fase3 ,10f * force_luz_fase3));
        //6
        GameObject luzMultiIns6_fase3 = Instantiate(bola_luz_fase3,check_multi6.position,Quaternion.identity);
        luzMultiIns6_fase3.GetComponent<Rigidbody2D>().AddForce(new Vector2(0,50f * force_luz_fase3));
        //7
        GameObject luzMultiIns7_fase3 = Instantiate(bola_luz_fase3,check_multi7.position,Quaternion.identity);
        luzMultiIns7_fase3.GetComponent<Rigidbody2D>().AddForce(new Vector2(-40f * force_luz_fase3 ,10f * force_luz_fase3));
        //8
        GameObject luzMultiIns8_fase3 = Instantiate(bola_luz_fase3,check_multi8.position,Quaternion.identity);
        luzMultiIns8_fase3.GetComponent<Rigidbody2D>().AddForce(new Vector2(-40f * force_luz_fase3 ,force_luz_fase3));
        //9
        GameObject luzMultiIns9_fase3 = Instantiate(bola_luz_fase3,check_multi9.position,Quaternion.identity);
        luzMultiIns9_fase3.GetComponent<Rigidbody2D>().AddForce(new Vector2(-30f * force_luz_fase3 ,-10f * force_luz_fase3 ));
        //10
        GameObject luzMultiIns10_fase3 = Instantiate(bola_luz_fase3,check_multi10.position,Quaternion.identity);
        luzMultiIns10_fase3.GetComponent<Rigidbody2D>().AddForce(new Vector2(-15f * force_luz_fase3 ,-10f * force_luz_fase3 ));
    }
}
