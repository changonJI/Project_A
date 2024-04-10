using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMonsterGroggy : MonsterState
{
    float GroggyTime = 0f;
    override public void StateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log("그로기 상태");
    }


    override public void StateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        GroggyTime += Time.deltaTime;
        if (GroggyTime >= 3f)
        {
            GroggyTime -= 3f;
            animator.SetInteger("aniIndex", 0);
        }

        if (monster.MONSTERDEAD)
        {
            animator.SetInteger("aniIndex", 3);
        }
    }


    override public void StateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

}
