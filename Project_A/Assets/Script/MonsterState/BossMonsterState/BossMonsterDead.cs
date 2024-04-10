using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMonsterDead : MonsterState
{

    float coolTime = 0f;


    override public void StateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log("BossDead");

        // 이펙트
        monster.SPAWNEFFECT.SetActive(false);

        // 체력 회복
        GameManager.Inst.PLAYER.PLAYEREXP += monster.MONSTEREXP;

        // 플레이어의 타겟 초기화
        GameManager.Inst.PLAYER.TARGET = null;

        // 퀘스트
        if (GameManager.Inst.PLAYER.PLAYERQUEST.Count > 0 &&
           GameManager.Inst.PLAYER.PLAYERQUEST[0].targetName.Equals(monster.name))
        {
            GameManager.Inst.PLAYER.PLAYERQUEST[0].targetScoremin += 1;
        }
    }


    override public void StateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        coolTime += Time.deltaTime;


        if (coolTime >= 1f)
        {
            monster.SPAWNEFFECT.SetActive(true);
        }

        if (coolTime >= 4f)
        {

            monster.gameObject.SetActive(false);

            monster.TARGET = null;


            animator.SetInteger("aniIndex", 0);

        }
    }


    override public void StateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        coolTime = 0f;
    }


}
