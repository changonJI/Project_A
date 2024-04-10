using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterIdle : MonsterState
{
    float walkCool = 0f;
    

    override public void StateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }


    override public void StateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        walkCool += Time.deltaTime;

        monster.TargetCheck(5f);

        if (monster.MONSTERDEAD)
        {
            animator.SetInteger("aniIndex", 3);
        }


        if(monster.MONSTERDEAD == false)            
        {
            if (walkCool >= 4.0f)
            {
                walkCool -= 4.0f;
                animator.SetInteger("aniIndex", 1);
            }

            if (monster.MONSTERAUTOATTACK == true &&
                monster.TARGET != null)
            {
                if (monster.DISTANCE < 3.0f)
                {
                    animator.SetInteger("aniIndex", 4);
                }
                else
                    animator.SetInteger("aniIndex", 1);

            }
        }

    }


    override public void StateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        walkCool = 0f;
    }


}
