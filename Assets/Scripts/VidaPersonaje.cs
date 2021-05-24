using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class VidaPersonaje : MonoBehaviour
{
    public int vida;
    public int NumDeVidas;
    public Image[] vidas;
    public Sprite fullVidas;
    public Sprite emptyVidas;
    void Start(){
        vida =  PlayerPrefs.GetInt("vida",3);
        NumDeVidas = PlayerPrefs.GetInt("vida",3);
    }
    void Update(){
        if(vida > NumDeVidas){
            vida = NumDeVidas;
        }
        for(int i = 0;i < vidas.Length;i++){
            if(i < vida){
                vidas[i].sprite = fullVidas;
            }else{
                vidas[i].sprite = emptyVidas;
            }
            if(i<NumDeVidas){
                vidas[i].enabled = true;
            }else{
                vidas[i].enabled = false; 
            }
        }
    }
}
