using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalk : PlayerState
{
    
    override public void StateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
        Debug.Log("walk Enter");
        
    }


    override public void StateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        player.MovePlayer();
        player.RoTatePlayer();



        if (player.AVOID == true)
        {
            animator.SetTrigger("Avoid");
        }

        if (player.transform.position == player.VEND)
        {
            animator.SetInteger("aniIndex", 0);
           
        }

        if(player.MOVESPEED >= 3f)
        {
            animator.SetInteger("aniIndex", 2);

        }

        if (player.PLAYERDEAD)
        {
            animator.SetInteger("aniIndex", 3);
        }


        if (player.PLAYERDEAD == false &&
            player.TARGET != null &&
            player.TARGET.gameObject.CompareTag("NPC") &&
            player.transform.position != player.TARGET.position)
        {
            float dis = Vector3.Distance(player.transform.position, player.TARGET.position);

            if (dis <= 2f)
            {
                animator.SetInteger("aniIndex", 0);
            }

        }

        if (player.PLAYERDEAD == false &&
            player.TARGET != null &&
            player.TARGET.gameObject.CompareTag("Monster") &&
            player.transform.position != player.TARGET.position)
        {
            float dis = Vector3.Distance(player.transform.position, player.TARGET.position);

            if(dis <= 2f)
            {
                if (player.NOWSKILLNUM == 0)
                {
                    animator.SetInteger("aniIndex", 4);
                }

                if (player.NOWSKILLNUM > 0)
                {
                    animator.SetInteger("aniIndex", player.NOWSKILLNUM);
                }

            }
          
        }




    }


    override public void StateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log("walk Exit");
    }
}
