using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMonsterIdle : MonsterState
{

    override public void StateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log("BossMonster ÃâÇö");
    }


    override public void StateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        monster.TargetCheck(8f);


        if (monster.MONSTERDEAD)
        {
            animator.SetInteger("aniIndex", 3);
        }


        if (monster.MONSTERDEAD == false &&
            monster.TARGET != null)          
        {
            if(monster.DISTANCE < 3f)
            {
                animator.SetInteger("aniIndex", 4);
            }
            else
                animator.SetInteger("aniIndex", 1);
        }

        if (monster.MONSTERHP <= monster.MONSTERMAXHP * 0.5f &&
           monster.MONSTERPAGE == 1)
        {
            monster.MONSTERPAGE += 1;
            animator.SetInteger("aniIndex", 7);
        }


    }


    override public void StateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }


}
