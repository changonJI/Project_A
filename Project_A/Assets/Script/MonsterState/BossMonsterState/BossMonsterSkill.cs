using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMonsterSkill : MonsterState
{
    Transform getChildSkill;
    SkillData skillData;
    float skillDelay;

    override public void StateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log("보스몬스터 스킬1 발동");

        
        for (int i = 0; i < monster.transform.childCount; i++)
        {
            if (monster.transform.GetChild(i).CompareTag("Skill"))
            {
                getChildSkill = monster.transform.GetChild(i);
            }
        }
        
        //getChildSkill = GameHelper.Instant.GetChildGameObjectTag(monster.transform, "Skill");

        getChildSkill.gameObject.SetActive(true);

        monster.MONSTERATTACKPOINT = 0;

        skillData = SkillManager.inst.getSkill(getChildSkill.name);

    }


    override public void StateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        skillDelay += Time.deltaTime;

        if (skillDelay >= 1.5f)
        {
            getChildSkill.position =
                Vector3.Lerp(getChildSkill.position, monster.VEND, Time.deltaTime);
        }

        if (monster.TARGET != null &&
            getChildSkill.gameObject.activeSelf.Equals(true) &&
            Vector3.Distance(getChildSkill.position,monster.TARGET.position) <= 2.5f)
        {
            getChildSkill.gameObject.SetActive(false);
            monster.MonsterSkillAttack(skillData.skillPower);
            animator.SetInteger("aniIndex", 0);

        }
        else
            animator.SetInteger("aniIndex", 0);

        

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
        getChildSkill.localPosition = Vector3.zero;
        getChildSkill.gameObject.SetActive(false);

        skillDelay = 0f;
    }


}
