using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShopScript : MonoBehaviour
{   
    public Slider vidaSlider;
    public int maxVida;
    public int currentVida;
    private int cash;
    public int price;
    public Text cashText;
    public Text precioText;
    // Start is called before the first frame update
    void Start()
    {   
       cash = PlayerPrefs.GetInt("money",1);
    }
    void SetDefs(){
        cashText.text = "$"+cash;
        currentVida = PlayerPrefs.GetInt("vida",3);
        switch(currentVida){
            case 3: price = 200;
            break;
            case 4: price = 400;
            break;
            case 5: price = 600;
            break;
            case 6: price = 800;
            break;
            case 7: price = 1000;
            break; 
            case 8: price = 2000;
            break;
        }
        if(currentVida == maxVida){
            precioText.text = "Maximo";
        }else{
            precioText.text = "$"+price.ToString();
        }
        vidaSlider.maxValue = maxVida;
        vidaSlider.value = currentVida;  
    }
    public void Comprarvida(){
        if(currentVida < maxVida){
            if(cash >= price){
            cash -= price;
            cashText.text = cash+"$";
            currentVida +=  1;
            PlayerPrefs.SetInt("vida",currentVida);
            vidaSlider.value = currentVida;
            }else{
                Debug.Log("Falta dinero");
            }
        }else{
            Debug.Log("Vida full;");
        }
    }
    void Update(){
        if(Input.GetKeyDown(KeyCode.Space)){
            PlayerPrefs.DeleteAll();
        }
         SetDefs();
    }
}
