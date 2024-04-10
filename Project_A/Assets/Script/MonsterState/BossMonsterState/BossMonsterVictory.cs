using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMonsterVictory : MonsterState
{
    float coolTime;
    override public void StateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log("보스몬스터 승리");
    }


    override public void StateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        coolTime += Time.deltaTime;
        if (coolTime >= 3f)
        {
    
            animator.SetInteger("aniIndex", 1);
            
        }
    }


    override public void StateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }


}
