using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Dialogo : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    private int index;
    public float typingSpeed;
    public GameObject continuarBoton;
    public Aldeanos aldeano;
    public Animator animCamara;
    public GameObject boton;
    public GameObject boton_pausa;
    private void Start() {
        
        
        
    }
    private void Update() {
        if(textDisplay.text == sentences[index]){
            continuarBoton.SetActive(true);
        }
    }
    IEnumerator Type(){
       foreach(char letter in sentences[index].ToCharArray()){
           textDisplay.text += letter;
           yield return  new WaitForSeconds(typingSpeed);
       }
    }
    IEnumerator esperar(){
         yield return new WaitForSeconds(3f);
         StartCoroutine(Type());
    }
    public void NextSentence(){
        continuarBoton.SetActive(false);
        if(index < sentences.Length - 1){
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        }else{
            textDisplay.text = "";
            continuarBoton.SetActive(false);
            index = 0;
            animCamara.SetInteger("subir",2);
            boton_pausa.SetActive(true);
        }
    }
    public void Empezar(){
            boton_pausa.SetActive(false);
            boton.SetActive(false);
            StartCoroutine(esperar());
            animCamara.SetInteger("subir",1);
    }
}
