using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Aldeanos : MonoBehaviour
{   
    [Header("Botones")]
    public GameObject boton_español;
    public GameObject boton_ingles;
    [Header("Animators")]
    public Animator anim_español;
    public Animator anim_ingles;
    [Header("Dropdown")]
    public Dropdown _dropdown;
   private void OnTriggerEnter2D(Collider2D col) {
       Debug.Log(_dropdown.value);
      
       if(col.transform.tag == "Player"){
            //Boton en español
           if(_dropdown.value == 0){
                    boton_español.SetActive(true);
                    anim_español.SetInteger("entrar",1);
           }
            //Boton en ingles
           if(_dropdown.value == 1){
                    boton_ingles.SetActive(true);
                    anim_ingles.SetInteger("entrar",1);
           }
       }
   }
   private void OnTriggerExit2D(Collider2D col) {
          if(col.transform.tag =="Player"){
               //Boton en español
                if(_dropdown.value == 0){
                          anim_español.SetInteger("entrar",2);
                } //Boton en Ingles
                if(_dropdown.value == 1){
                           anim_ingles.SetInteger("entrar",2);
                }
          }  
   }
}
