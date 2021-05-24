using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hombre_lava : MonoBehaviour
{   
    public GameObject bola_fuego;
    public Transform disparoCheck;
    float time;
    void Start()
    {
        
    }
    void Update()
    {  
        time += Time.deltaTime;
        if(time >= 3){
            Instantiate(bola_fuego,disparoCheck.position,disparoCheck.rotation);
            time = 0;
        }
    }
}
