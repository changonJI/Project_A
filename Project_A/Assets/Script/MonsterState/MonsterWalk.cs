using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterWalk : MonsterState
{

    override public void StateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        monster.VEND = new Vector3(monster.transform.position.x + Random.Range(-2f, 2f),       
            0, monster.transform.position.z + Random.Range(-2f, 2f));

        monster.transform.LookAt(monster.VEND);
    }


    override public void StateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        monster.TargetCheck(5f);

        if (monster.MONSTERDEAD)
        {
            animator.SetInteger("aniIndex", 3);
        }

        if (monster.MONSTERDEAD == false)
        {
            if (monster.MONSTERAUTOATTACK == false)
            {
                monster.transform.position =
                    Vector3.MoveTowards(monster.transform.position, monster.VEND, Time.deltaTime * 2f);
            }

            if (monster.MONSTERAUTOATTACK == true) 
            {
                if (monster.TARGET != null)
                {
                    if (monster.DISTANCE < 3f)
                    {
                        animator.SetInteger("aniIndex", 4);
                    }
                    else
                    {
                        monster.MonsterMove();
                        monster.transform.LookAt(monster.TARGET);
                    }
                }
                else
                {
                    monster.transform.position =
                   Vector3.MoveTowards(monster.transform.position, monster.VEND, Time.deltaTime * 2f);
                    monster.transform.LookAt(monster.VEND);
                }
            }

            if (monster.transform.position == monster.VEND)
            {
                animator.SetInteger("aniIndex", 0);
            }
        }
    }

   
    override public void StateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

  
}
