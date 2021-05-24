using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
public class Texts : MonoBehaviour
{   [Header("Primer Menu")]
    public Text play;
    public Text opciones;
    public Text salir;
    [Header("Menu de Opciones")]
    public Text opcion;
    public Text VolumeMusic;
    public Text idioma;
    public Text back;
    [Header("Menu de Mundos")]
    public Text Mundo1;
    public Text Mundo2;
    public Text Mundo3;
    public Text Mundo4;
    public Text backMundo;
    public Text tiendaM;
    [Header("Menus de Niveles")]
    public Text Nivel1;
    public Text Nivel2;
    public Text Nivel3;
    public Text Nivel4;
    public Text Nivel5;
    public Text Nivel6;
    public Text Nivel7;
    public Text Nivel8;
    public Text Nivel9;
    public Text Nivel10;
    public Text backNivel;
    [Header("Tienda")]
    public Text vidaShop;
    public Text backShop;
    [Header("Menu de Pausa")]
    public Text PauseTitle;
    public Text BackToTheMenu;
    public Text BackToTheGame;
    public Text VolumeMusicP;
    public Text idiomaP;
    [Header("Creditos")]
    public Text UnJuegoDe;
    public Text tecnico;
    public Text arte;
    public Text musica;
    public Text efectos_sonido;
    public Text agradecimientos;
    public Text gracias;
    [Header("Ajustes para guardar")]
    const string  PrefName = "optionvalue";
    public Dropdown _dropdown;
    void Start()
    {
        _dropdown.value = PlayerPrefs.GetInt(PrefName,0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void Awake() {
        _dropdown.onValueChanged.AddListener(new UnityAction<int>(index =>
        {
            PlayerPrefs.SetInt(PrefName, _dropdown.value);
            Debug.Log(_dropdown.value);
            PlayerPrefs.Save();
        }));
    }
    public void inicio(){
    
        if(_dropdown.value == 0){
            //Menu del principio
            play.text = "Jugar";
            opciones.text = "Opciones";
            salir.text = "Salir";
            //Menu de Opciones
            opcion.text = "Opciones";
            VolumeMusic.text = "Volumen de Musica";
            idioma.text = "Idioma";
            back.text = "Atras";
            //Menu de mundos
            Mundo1.text = "Mundo 1";
            Mundo2.text = "Mundo 2";
            Mundo3.text = "Mundo 3";
            Mundo4.text = "Mundo 4";
            backMundo.text = "Atras";
            tiendaM.text = "Tienda";
            //Menu de niveles
            Nivel1.text = "Nivel 1";
            Nivel2.text = "Nivel 2";
            Nivel3.text = "Nivel 3";
            Nivel4.text = "Nivel 4";
            Nivel5.text = "Nivel 5";
            Nivel6.text = "Nivel 6";
            Nivel7.text = "Nivel 7";
            Nivel8.text = "Nivel 8";
            Nivel9.text = "Nivel 9";
            Nivel10.text = "Nivel 10";
            backNivel.text = "Atras";
            //Tienda
            backShop.text = "Atras";
            vidaShop.text = "Vidas";
        }
        Debug.Log(_dropdown.value);
        if(_dropdown.value == 1){
            //Menu del principio
            play.text = "Play";
            opciones.text = "Options";
            salir.text = "Exit";
            //Menu de Opciones
            opcion.text = "Options";
            VolumeMusic.text = "Volume Music";
            idioma.text = "Language";
            back.text = "Back";
            //Menu de mundos
            Mundo1.text = "World 1";
            Mundo2.text = "World 2";
            Mundo3.text = "World 3";
            Mundo4.text = "World 4";
            backMundo.text = "Back";
            tiendaM.text = "Shop";
            //Menu de niveles
            Nivel1.text = "Level 1";
            Nivel2.text = "Level 2";
            Nivel3.text = "Level 3";
            Nivel4.text = "Level 4";
            Nivel5.text = "Level 5";
            Nivel6.text = "Level 6";
            Nivel7.text = "Level 7";
            Nivel8.text = "Level 8";
            Nivel9.text = "Level 9";
            Nivel10.text = "Level 10";
            backNivel.text = "Back";
            //Tienda
            backShop.text = "Back";
            vidaShop.text = "Lifes";
        }
    }
    public void pauseMenu(){
            if(_dropdown.value == 0){
            //Menu de pausa
            PauseTitle.text = "Pausa";
            BackToTheGame.text = "Volver al juego";
            BackToTheMenu.text = "Volvel al menu principal";
            VolumeMusicP.text = "Volumen de la musica";
            idiomaP.text = "Idioma";
            }if(_dropdown.value == 1){
            //Menu de pausa
            PauseTitle.text = "Pause";
            BackToTheGame.text = "Back to the game";
            BackToTheMenu.text = "Back to the Main Menu";
            VolumeMusicP.text= "Volume Music";
            idiomaP.text = "Lenguage";
            }
    }
    public void Creditos(){
        //creditos
        if(_dropdown.value == 0){
            UnJuegoDe.text = "Un juego de";
            tecnico.text = "Director Tecnico y Programador";
            arte.text = "Director de Arte y Animador";
            musica.text = "Musica";
            efectos_sonido.text = "Efectos de Sonido";
            agradecimientos.text = "Agradecimientos Especiales";
            gracias.text = "Gracias Por Jugar";
        }
        if(_dropdown.value == 1){
            UnJuegoDe.text = "A game by";
            tecnico.text = "Technical Director and Programmer";
            arte.text = "Art Director and Animator";
            musica.text = "Music";
            efectos_sonido.text = "Sound effects";
            agradecimientos.text = "Special thanks";
            gracias.text = "Thanks for playing";
        }
    }
}
