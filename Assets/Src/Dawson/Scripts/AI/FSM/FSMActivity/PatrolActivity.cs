using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI.FSM.Activities
{
    [CreateAssetMenu(menuName = "AI/FSM/Activity/PatrolActivity")]
    public class PatrolActivity : Activity
    {
        public float speed = 1;


        public override void Enter(BaseStateMachine stateMachine)
        {
            var PatrolPoints    = stateMachine.GetComponent<PatrolPoints>();
            var SpriteRenderer  = stateMachine.GetComponent<SpriteRenderer>();
            //var Animator        = stateMachine.GetComponent<Animator>();
            SpriteRenderer.flipX = (PatrolPoints.GetTargetPointDirection().x > 0) ? true : false;
            //Animator.SetBool("isWalk", true);
        }


        public override void Execute(BaseStateMachine stateMachine)
        {

        }


        public override void Exit(BaseStateMachine stateMachine)
        {
            
        }
    }
}
