using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Skill_1 : PlayerState
{
    Transform getChildSkill;
    SkillData skillData;

    float coolTime = 0f;


    override public void StateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        for (int i = 0; i < HudManager.Inst.skillslot_1.transform.childCount; i++)
        {
            if (HudManager.Inst.skillslot_1.transform.GetChild(i).CompareTag("Skill"))
            {
                 getChildSkill = HudManager.Inst.skillslot_1.transform.GetChild(i);
            }
        }

        skillData = SkillManager.inst.getSkill(getChildSkill.name);
        
        player.skillCoolOn(skillData.cool);

        HudManager.Inst.SKILLEFFECT_1 = getChildSkill.GetChild(0);

        HudManager.Inst.skillslot_1.interactable = false;
     
    }


    override public void StateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        coolTime += Time.deltaTime;

        if(coolTime >= 0.8f)
        {

            player.useActiveSkill(skillData.skillPower);

            coolTime -= 0.8f;

            player.NOWSKILLNUM = 0;

            animator.SetInteger("aniIndex", 0);
        }


        if(player.PLAYERDEAD)
        {
            animator.SetInteger("aniIndex", 3);
        }


    }


    override public void StateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player.NOWTARGETMONSTER.HPCOUNTTEXT.gameObject.SetActive(false);
        HudManager.Inst.SKILLEFFECT_1.gameObject.SetActive(false);

        coolTime = 0f;

        Debug.Log("skill_1_Exit");
    }
}

