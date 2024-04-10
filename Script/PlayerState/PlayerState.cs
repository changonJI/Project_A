using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : StateMachineBehaviour
{
    protected Player player = null;

    virtual public void StateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
    }


    virtual public void StateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }


    virtual public void StateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }



    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (player == null)
        {
            player = animator.GetComponent<Player>();
        }

        StateEnter(animator,stateInfo,layerIndex);
    }


    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        StateUpdate(animator, stateInfo, layerIndex);
    }


    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        StateExit(animator, stateInfo, layerIndex);
    }

}
