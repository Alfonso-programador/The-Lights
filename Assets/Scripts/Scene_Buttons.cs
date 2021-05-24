using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene_Buttons : MonoBehaviour
{       public GameObject Bloqueo;
        public Animator button_anim;
        public GameObject puente;
        private void OnCollisionEnter2D(Collision2D col) {
            if(col.transform.tag == "Player"){
                button_anim.SetBool("button",true);
                Destroy(Bloqueo);
                puente.SetActive(true);
            }
        }
}
