using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDie : PlayerState
{
    float UI_Cool = 0f;
    override public void StateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }


    override public void StateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        UI_Cool += Time.deltaTime;
        
        if(UI_Cool >= 4f &&
           HudManager.Inst.Revive_Box_Menu.activeSelf.Equals(false))
        {
            HudManager.Inst.Revive_Box_Menu.SetActive(true);
        }


        if (player.PLAYERDEAD == false)
        {
            animator.SetInteger("aniIndex", 0);
        }


    }


    override public void StateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        UI_Cool = 0f;

    }
}
