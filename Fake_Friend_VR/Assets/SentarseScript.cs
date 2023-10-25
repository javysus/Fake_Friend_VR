using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SentarseScript : StateMachineBehaviour
{
    public GameObject vrrig;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    //override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        /*ControladorPrincipal controladorPrincipal = animator.GetComponent<ControladorPrincipal>();
        CamiControllerAlcoholica camiControllerAlcoholica = animator.GetComponent<CamiControllerAlcoholica>();
        controladorPrincipal.head.vrTarget.position = camiControllerAlcoholica.head.transform.position;
        controladorPrincipal.leftHand.vrTarget.position = camiControllerAlcoholica.leftHand.transform.position;
        controladorPrincipal.rightHand.vrTarget.position = camiControllerAlcoholica.rightHand.transform.position;*/


        //Debug.Log(camiControllerAlcoholica.head.transform.position);
        /*Vector3 movement = new Vector3(0f, 1f, 0f);
        vrrig.transform.position += movement;*/
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
