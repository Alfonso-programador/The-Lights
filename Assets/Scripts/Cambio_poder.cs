using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Cambio_poder : MonoBehaviour
{   [Header("Botones")]
    public Button[] botones;
    public int boton_en_uso1;
    public int boton_en_uso2;
    int touch_boton;
    [Header("Imagen_botones_uso")]
    public Image boton1;
    public Image boton2;
    [Header("Sprites_todos_botones")]
    public Sprite girar;
    public Sprite dash;
    public Sprite onda_mental;
    public Sprite disparo_fuego;
    public Sprite escudo;
    public Sprite brazo_luz;
    public Sprite disparo_luz;
    // Start is called before the first frame update
    void Start()
    {  
        
        
    }

    // Update is called once per frame
    void Update()
    {   
    }
    private void FixedUpdate() {
        boton_en_uso1 = PlayerPrefs.GetInt("boton1",0);
        boton_en_uso2 = PlayerPrefs.GetInt("boton2",0);
        //Boton 1
        if(boton_en_uso1 == 1 && boton_en_uso2 != 1){
            boton1.sprite = girar;
            botones[0].interactable = false;
        }else if(boton_en_uso1 == 2 && boton_en_uso2 != 2){
            boton1.sprite = dash;
            botones[1].interactable = false;
        }else if(boton_en_uso1 == 3 && boton_en_uso2 != 3){
            boton1.sprite = onda_mental;
            botones[2].interactable = false;
        }else if(boton_en_uso1 == 4 && boton_en_uso2 != 4){
            boton1.sprite = disparo_fuego;
            botones[3].interactable = false;
        }else if(boton_en_uso1 == 5 && boton_en_uso2 != 5){
            boton1.sprite = escudo;
            botones[4].interactable = false;
        }else if(boton_en_uso1 == 6 && boton_en_uso2 != 6){
            boton1.sprite = brazo_luz;
            botones[5].interactable = false;
        }else if(boton_en_uso1 == 7 && boton_en_uso2 != 7){
            boton1.sprite = disparo_luz;
            botones[6].interactable = false;
        }
        if(boton_en_uso1 != 1 && boton_en_uso2 != 1){
            botones[0].interactable = true;
        }
        if(boton_en_uso1 != 2 && boton_en_uso2 != 2){
            botones[1].interactable = true;
        }
        if(boton_en_uso1 != 3 && boton_en_uso2 != 3){
            botones[2].interactable = true;
        }
        if(boton_en_uso1 != 4 && boton_en_uso2 != 4){
            botones[3].interactable = true;
        }
        if(boton_en_uso1 != 5 && boton_en_uso2 != 5){
            botones[4].interactable = true;
        }
        if(boton_en_uso1 != 6 && boton_en_uso2 != 6){
            botones[5].interactable = true;

        }
        if(boton_en_uso1 != 7 && boton_en_uso2 != 7){
            botones[6].interactable = true;

        }
        //Boton 2
        if(boton_en_uso2 == 1 && boton_en_uso1 != 1){
            boton2.sprite = girar;
            botones[0].interactable = false;
        }else if(boton_en_uso2 == 2 && boton_en_uso1 != 2){
            boton2.sprite = dash;
            botones[1].interactable = false;
        }else if(boton_en_uso2 == 3 && boton_en_uso1 != 3){
            boton2.sprite = onda_mental;
            botones[2].interactable = false;
        }else if(boton_en_uso2 == 4 && boton_en_uso1 != 4){
            boton2.sprite = disparo_fuego;
            botones[3].interactable = false;
        }else if(boton_en_uso2 == 5 && boton_en_uso1 != 5){
            boton2.sprite = escudo;
            botones[4].interactable = false;
        }else if(boton_en_uso2 == 6 && boton_en_uso1 != 6){
            boton2.sprite = brazo_luz;
            botones[5].interactable = false;
        }else if(boton_en_uso2 == 7 && boton_en_uso1 != 7){
            boton2.sprite = disparo_luz;
            botones[6].interactable = false;
        }
        Debug.Log(boton_en_uso1);
        Debug.Log(boton_en_uso2);
    }
    public void boton_cambiar(int name){
        if(name == 1){
            touch_boton = 1;
        }else if(name == 2){
             touch_boton = 2;
        }
    }
   public void cambiar_poder(int boton){
       if(touch_boton == 1){
           if(boton == 1){
               PlayerPrefs.SetInt("boton1",1);
               Debug.Log("CAMBIO");
           }else if(boton == 2){
               PlayerPrefs.SetInt("boton1",2);
           }else if(boton == 3){
               PlayerPrefs.SetInt("boton1",3);
           }else if(boton == 4){
               PlayerPrefs.SetInt("boton1",4);
           }else if(boton == 5){
               PlayerPrefs.SetInt("boton1",5);
           }else if(boton == 6){
               PlayerPrefs.SetInt("boton1",6);
           }else if(boton == 7){
               PlayerPrefs.SetInt("boton1",7);
           }
       }else if(touch_boton == 2){
           if(boton == 1){
               PlayerPrefs.SetInt("boton2",1);
           }else if(boton == 2){
               PlayerPrefs.SetInt("boton2",2);
           }else if(boton == 3){
               PlayerPrefs.SetInt("boton2",3);
           }else if(boton == 4){
               PlayerPrefs.SetInt("boton2",4);
           }else if(boton == 5){
               PlayerPrefs.SetInt("boton2",5);
           }else if(boton == 6){
               PlayerPrefs.SetInt("boton2",6);
           }else if(boton == 7){
               PlayerPrefs.SetInt("boton2",7);
           }
       }
   }
}
