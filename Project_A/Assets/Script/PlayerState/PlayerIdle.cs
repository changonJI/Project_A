using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdle : PlayerState
{

    
    override public void StateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        Debug.Log("Idle Enter");
        
    }


    override public void StateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
        if(player.AVOID == true)
        {
            animator.SetTrigger("Avoid");
        }

        if (player.PLAYERDEAD == false &&
           player.TARGET == null &&
           player.transform.position != player.VEND)
        {                 
            animator.SetInteger("aniIndex", 1);           
        }

        if (player.PLAYERDEAD)
        {
            animator.SetInteger("aniIndex", 3);
        }

        if (player.PLAYERDEAD == false &&
            player.TARGET != null &&
            player.TARGET.gameObject.CompareTag("NPC") &&
            HudManager.Inst.ACTIVEUI.Count < 1 &&
            Vector3.Distance(player.TARGET.position, player.transform.position) < 2f)
        {
//          Debug.Log(player.TARGET.name);
            HudManager.Inst.NPC_Menu_Box.gameObject.SetActive(true);
            HudManager.Inst.ACTIVEUI.Add(HudManager.Inst.NPC_Menu_Box.gameObject);
            player.VEND = player.transform.position;
        }



        if (player.PLAYERDEAD == false &&
            player.TARGET != null &&
            player.TARGET.gameObject.CompareTag("Monster") &&
            player.transform.position != player.VEND
           )
        {
            float dis = Vector3.Distance(player.transform.position, player.TARGET.position);

            if (dis <= 2.0f)
            {
                if (player.NOWSKILLNUM == 0)
                {
                    animator.SetInteger("aniIndex", 4);
                }

                if(player.NOWSKILLNUM > 0)
                {
                    animator.SetInteger("aniIndex", player.NOWSKILLNUM);
                }

            }

            else
            {
                animator.SetInteger("aniIndex", 1);
            }
        }
        
        

    }


    override public void StateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log("Idle Exit");

    }


}
