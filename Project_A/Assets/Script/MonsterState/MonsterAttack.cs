using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAttack : MonsterState
{
    float coolTime = 0f;

    override public void StateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log("AttackEnter");
        //coolTime += 1.1f;
        //monster.MonsterAttack();
    }


    override public void StateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        coolTime += Time.deltaTime;

        if (coolTime >= 0.55f) { 
                
            monster.MonsterAttack();
            coolTime -= 0.55f;
            animator.SetInteger("aniIndex", 0);
        }
                
        if (monster.MONSTERDEAD == false &&
            monster.DISTANCE > 3f)
        {
            animator.SetInteger("aniIndex", 1);
        }

        if (monster.MONSTERDEAD)
        {
            animator.SetInteger("aniIndex", 3);
        }

        if (GameManager.Inst.PLAYER.PLAYERDEAD)
        {
            monster.TARGET = null;
            animator.SetInteger("aniIndex", 0);
        }

    }


    override public void StateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        coolTime = 0f;

        GameManager.Inst.PLAYER.HPCOUNTTEXT.gameObject.SetActive(false);
    }

}
