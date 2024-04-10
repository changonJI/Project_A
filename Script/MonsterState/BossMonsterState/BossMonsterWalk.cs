using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMonsterWalk : MonsterState
{

    override public void StateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log("Boss ÀÌµ¿Áß");
        //monster.transform.LookAt(monster.VEND);
    }

    override public void StateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        monster.TargetCheck(8f);
    
        if (monster.MONSTERDEAD)
        {
            animator.SetInteger("aniIndex", 3);
        }



        if (monster.MONSTERDEAD == false &&
            monster.TARGET != null) {

            if (monster.MONSTERATTACKPOINT >= 3)
            {
                animator.SetInteger("aniIndex", 5);
            }

            if (monster.DISTANCE < 3f)
            {
                animator.SetInteger("aniIndex", 4);
            }
            else
            {
                monster.MonsterMove();
                monster.transform.LookAt(monster.TARGET);
            }
        }
        else
        {
            monster.transform.localPosition =
            Vector3.MoveTowards(monster.transform.position, Vector3.zero, Time.deltaTime * 2f);
            monster.transform.LookAt(Vector3.zero);
        }


        if (monster.transform.position == monster.VEND)
        {
            animator.SetInteger("aniIndex", 0);
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
