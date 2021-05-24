using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CambioEscena : MonoBehaviour
{   public Animator transitionAnim;
    [SerializeField] private PlayerController player;
    public AudioSource audio;
    private void OnTriggerEnter2D(Collider2D col) {
        if(col.transform.tag == "Player"){
            player.DontCanMove();
            int currentLevel = SceneManager.GetActiveScene().buildIndex;
            if(currentLevel >= PlayerPrefs.GetInt("levelsUnlocked")){
             PlayerPrefs.SetInt("levelsUnlocked",currentLevel+1);
        }
            StartCoroutine(LoadScene());
        }   
    }
     IEnumerator LoadScene(){
        transitionAnim.SetTrigger("end");
        yield return new WaitForSeconds(2.5f);
        UnityEngine.SceneManagement.SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1 );
    }
     public void ChangeSceneTo(string name){
         UnityEngine.SceneManagement.SceneManager.LoadScene(name);
         Time.timeScale = 1f;
    }
    public void Salir(){
        Application.Quit();
    }
    public void sonido(){
        audio.Play();
    }
}
