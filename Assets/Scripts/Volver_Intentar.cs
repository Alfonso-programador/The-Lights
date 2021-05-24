using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Volver_Intentar : MonoBehaviour
{
    public Image fillImg;
    float timeAmt = 5;
    float time;
    private int cash;
    public GameObject volver_todo;
    public CambioEscena cambio;
    [SerializeField] private string name;
    [SerializeField] private PlayerController player;
    // Start is called before the first frame update
    void Start()
    {
        time = timeAmt;
        cash = PlayerPrefs.GetInt("money",1);
        
    }

    // Update is called once per frame
    void Update()
    {
        if(time > 0){
            time -= Time.deltaTime;
            fillImg.fillAmount = time/timeAmt;
            if(time <= 0){
                volver_todo.SetActive(false);
                cambio.ChangeSceneTo(name);
            }
        }
        
    }
   public void revivir_pago(){
        if(cash >= 50){
            fillImg.fillAmount = 1;
            time = timeAmt;
            player.Respawn();
            volver_todo.SetActive(false);
        }
    }
  public void Ver_anuncio(){
       fillImg.fillAmount = 1;
       time = timeAmt;
       player.Respawn();
       volver_todo.SetActive(false);
   }
   
}
