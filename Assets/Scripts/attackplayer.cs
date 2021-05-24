using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackplayer : StateMachineBehaviour
{
    [SerializeField] MotherSquare boss;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        boss = GameObject.FindGameObjectWithTag("boss").GetComponent<MotherSquare>();
    }

        override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
          boss.AttackPlayer();
    }

}
