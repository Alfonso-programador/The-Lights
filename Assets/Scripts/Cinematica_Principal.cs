using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Cinematica_Principal : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator texto1;
    public Animator texto2;
    public Animator texto3;
    public Animator texto4;
    void Start()
    {
        texto1.SetBool("entrar",true);
         StartCoroutine(Texto_2());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator Texto_2(){
        yield return new WaitForSeconds(3f);
        texto2.SetBool("entrar",true);
        StartCoroutine(Texto_3());
    }
     IEnumerator Texto_3(){
        yield return new WaitForSeconds(3f);
        texto3.SetBool("entrar",true);
        StartCoroutine(Texto_4());
    }
    IEnumerator Texto_4(){
        yield return new WaitForSeconds(3f);
        texto4.SetBool("entrar",true);
        StartCoroutine(salida());
    }
    IEnumerator salida(){
        yield return new WaitForSeconds(5f);
        texto1.SetBool("entrar",false);
        texto2.SetBool("entrar",false);
        texto3.SetBool("entrar",false); 
        texto4.SetBool("entrar",false);         
    }
}
