using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : PlayerState
{
    float coolTime = 0f;

    override public void StateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log("AttackEnter");
        coolTime = 0f;


    }

    
    override public void StateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {   
        
        coolTime += Time.deltaTime;

        if (player.AVOID == true)
        {
            animator.SetTrigger("Avoid");
        }

        if (coolTime >= 0.8f) { 
            
            player.Attack();
            coolTime -= 0.8f;
            animator.SetInteger("aniIndex", 0);
        }


        if (player.PLAYERDEAD == false &&
            player.TARGET == null 
            //&& player.transform.position == player.VEND
            )
        {
            player.VEND = player.transform.position;
            animator.SetInteger("aniIndex", 0);
        }


        if (player.PLAYERDEAD == false &&
            player.TARGET != null &&
            player.transform.position != player.VEND)
        {
            float dis = Vector3.Distance(player.transform.position, player.TARGET.position);
            if (dis > 2.0f)
            {
                animator.SetInteger("aniIndex", 1);
            }
        }

        if(player.PLAYERDEAD == false &&
            player.TARGET != null &&
            player.NOWSKILLNUM > 0)
        {
            animator.SetInteger("aniIndex", player.NOWSKILLNUM);
        }



        if (player.PLAYERDEAD)
        {
            animator.SetInteger("aniIndex", 3);
        }
    }


    override public void StateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        coolTime = 0f;

        player.NOWTARGETMONSTER.HPCOUNTTEXT.gameObject.SetActive(false);
        Debug.Log("Attack Exit");
    }
}
