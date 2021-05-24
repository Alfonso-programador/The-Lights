using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class Desicion_Final : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    private int index;
    public float typingSpeed;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Type());
    }

    // Update is called once per frame
    void Update()
    {
        //StartCoroutine(Type());
        if(index < sentences.Length - 1){
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        }
    }
     IEnumerator Type(){
       foreach(char letter in sentences[index].ToCharArray()){
           textDisplay.text += letter;
           yield return  new WaitForSeconds(typingSpeed);
       }
    }
    public void desicion(string name){
         UnityEngine.SceneManagement.SceneManager.LoadScene(name);
         Time.timeScale = 1f;
    }

}
