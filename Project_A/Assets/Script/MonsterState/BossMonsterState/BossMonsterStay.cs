using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMonsterStay : MonsterState
{
    float cooltime = 0f;

    override public void StateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //effect 추가하기
        Debug.Log("보스몬스터 스킬시전중");

    }


    override public void StateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        if (monster.TARGET != null)
        {
            monster.VEND = monster.TARGET.position;
        }
        else
            animator.SetInteger("aniIndex", 0);


        cooltime += Time.deltaTime;
        if(cooltime >= 3f)
        {
            animator.SetInteger("aniIndex", 6);
            cooltime -= 3f;
        }

        // 플레이어의 위치를 start에서 기억한뒤, 그 위치에 표식 남기기


        if (monster.MONSTERHP.Equals(monster.MONSTERMAXHP * 0.5f))
        {
            animator.SetInteger("aniIndex", 7);
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
        cooltime = 0f;
    }


}
