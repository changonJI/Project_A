using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMonsterAttack : MonsterState
{

    float coolTime = 0f;

    override public void StateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log("BossAttack");
    }


    override public void StateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        coolTime += Time.deltaTime;

        if (monster.MONSTERDEAD == false) 
        {
            if (monster.MONSTERATTACKPOINT >= 3)
            {
                animator.SetInteger("aniIndex", 5);
            }

            if (coolTime >= 1f)
            {
                monster.MonsterAttack();
                coolTime -= 1;
                animator.SetInteger("aniIndex", 0);
            }

            if(monster.DISTANCE > 3f) 
            { 
                animator.SetInteger("aniIndex", 1);
            }
        }

        if (monster.MONSTERDEAD)
        {
            animator.SetInteger("aniIndex", 3);
        }


        if (monster.MONSTERHP <= monster.MONSTERMAXHP * 0.5f &&
            monster.MONSTERPAGE == 1)
        {
            monster.MONSTERPAGE += 1;
            animator.SetInteger("aniIndex", 7);
        }

        if (GameManager.Inst.PLAYER.PLAYERDEAD)
        {
            monster.TARGET = null;
            animator.SetInteger("aniIndex", 8);
        }
    }


    override public void StateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        coolTime = 0f;

        GameManager.Inst.PLAYER.HPCOUNTTEXT.gameObject.SetActive(false);
    }

}
