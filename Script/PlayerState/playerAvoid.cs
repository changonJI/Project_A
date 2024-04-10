using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAvoid : PlayerState
{
    Transform getChildSkill;
    Vector3 vEnd = Vector3.zero;
    
    override public void StateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        vEnd = player.transform.position;
        vEnd += (player.transform.forward * 4);


        for (int i = 0; i < HudManager.Inst.skillslot_Avoid.transform.childCount; i++)
        {
            if (HudManager.Inst.skillslot_Avoid.transform.GetChild(i).CompareTag("Skill"))
            {
                getChildSkill = HudManager.Inst.skillslot_Avoid.transform.GetChild(i);
            }
        }

        player.skillAvoidCoolOn(3f);

        
        HudManager.Inst.SKILLEFFECT_AVOID = getChildSkill.GetChild(0);
        HudManager.Inst.SKILLEFFECT_AVOID.transform.position = player.transform.position;
        HudManager.Inst.SKILLEFFECT_AVOID.gameObject.SetActive(true);
    }


    override public void StateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
        player.transform.position = 
            Vector3.MoveTowards(player.transform.position, vEnd, 20f * Time.deltaTime);

        HudManager.Inst.SKILLEFFECT_AVOID.transform.position =
            player.transform.position + new Vector3(0f,0.5f,0f);

        if (player.transform.position.Equals(vEnd))
        {
           animator.SetInteger("aniIndex", 0);
        }
    }


    override public void StateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player.AVOID = false;
        player.VEND = vEnd;

        HudManager.Inst.SKILLEFFECT_AVOID.gameObject.SetActive(false);
    }


}
