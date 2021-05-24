using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bealen : MonoBehaviour
{
    public float speed;
    public float timeMax;
    float time;
    private bool cambio = true;
    private bool facinRight;
    public Transform disparoCheck;
    public GameObject coco;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        fly();
    }
    public void fly(){
        time += Time.deltaTime; 
        Debug.Log(cambio);
        if(time >= timeMax){
            cambio = !cambio;
            time = 0;
        }
        if(cambio == true){

             transform.Translate(Vector2.right * speed * Time.deltaTime);
        }else{
             transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
    }
    private void OnTriggerEnter2D(Collider2D col) {
        if(col.transform.tag == "Player"){
            Instantiate(coco,disparoCheck.position,disparoCheck.rotation);
        }
    }
}
