using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class coinManager : MonoBehaviour
{   public Text coinText;
    int score;
    private void Start() {
        score = PlayerPrefs.GetInt("money",1);  
    }
    public void RaiseScore(int s){
        score = PlayerPrefs.GetInt("money",1);
        score += s;
        PlayerPrefs.SetInt("money",score);
        coinText.text = score.ToString();
    }
}
