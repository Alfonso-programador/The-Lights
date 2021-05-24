using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VueltasAnim : MonoBehaviour
{
    
   [SerializeField] private Animator anim1;
   [SerializeField] private  Animator anim2;
   [SerializeField] private  Animator anim3;
   [SerializeField] private  Animator anim4;
   [SerializeField] private Animator anim5;
   [SerializeField] private  Animator anim6;
   [SerializeField] private  Animator anim7;
   [SerializeField] private  Animator anim8;
   [SerializeField] private  Animator anim9;
   [SerializeField] private  Animator anim10;
   [SerializeField] private  Animator anim11;
   [SerializeField] private  Animator anim12;
   [SerializeField] private  Animator anim13;
   [SerializeField] private  Animator anim14;
   [SerializeField] private  Animator anim15;
   [SerializeField] private  Animator anim16;
   [SerializeField] private  Animator anim17;
   [SerializeField] private  Animator anim18;
   [SerializeField] private  Animator anim19;
   [SerializeField] private  Animator anim20;
   [SerializeField] private  Animator anim21;
    public PlayerController playerController;
    public GameObject player;
    public int numVueltas;
    public bool canMov;
    public int time;
    public int limiteVueltas;
    void Start()
    {
         numVueltas = 0;
         
    }

    // Update is called once per frame
    void Update()
    {    
        
        if(playerController.currentTime == time){
                canMov = true;
        }else{
                canMov = false;
        }
        if(playerController.girar == 1){
              if(canMov == true ){
                        numVueltas = numVueltas+1;
                        playerController.girar = 0;
                }
            if(numVueltas > limiteVueltas){
               numVueltas = 1;
            }  
       }
       
       if(numVueltas == 1 && canMov == true){
                 Move1();    
            }
       if(numVueltas == 2 && canMov == true){
                 Move2();
            }
    }

    void Move1(){
            anim1.SetInteger("mov",1);
            anim2.SetInteger("mov",1);
            anim3.SetInteger("mov",1);
            anim4.SetInteger("mov",1);
            anim5.SetInteger("mov",1);
            anim6.SetInteger("mov",1);
            anim7.SetInteger("mov",1);
            anim8.SetInteger("mov",1);
            anim9.SetInteger("mov",1);
            anim10.SetInteger("mov",1);
            anim11.SetInteger("mov",1);
            anim12.SetInteger("mov",1);
            anim13.SetInteger("mov",1);
            anim14.SetInteger("mov",1);
            anim15.SetInteger("mov",1);
            anim16.SetInteger("mov",1);
            anim17.SetInteger("mov",1);
            anim18.SetInteger("mov",1);
            anim19.SetInteger("mov",1);
            anim20.SetInteger("mov",1);
            anim21.SetInteger("mov",1);
    }
    void Move2(){
            anim1.SetInteger("mov",2);
            anim2.SetInteger("mov",2);
            anim3.SetInteger("mov",2);
            anim4.SetInteger("mov",2);
            anim5.SetInteger("mov",2);
            anim6.SetInteger("mov",2);
            anim7.SetInteger("mov",2);
            anim8.SetInteger("mov",2);
            anim9.SetInteger("mov",2);
            anim10.SetInteger("mov",2);
            anim11.SetInteger("mov",2);
            anim12.SetInteger("mov",2);
            anim13.SetInteger("mov",2);
            anim14.SetInteger("mov",2);
            anim15.SetInteger("mov",2);
            anim16.SetInteger("mov",2);
            anim17.SetInteger("mov",2);
            anim18.SetInteger("mov",2);
            anim19.SetInteger("mov",2);
            anim20.SetInteger("mov",2);
            anim21.SetInteger("mov",2);
    }
}
