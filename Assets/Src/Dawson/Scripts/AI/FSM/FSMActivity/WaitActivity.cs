/*
 *  WaitActivity.cs
 *  Dawson Burgess
 *  Logic for waiting between patrols
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 *  Description
 *
 *  member variables:
 *
 *  member functions:
 */
namespace AI.FSM.Activities
{
    [CreateAssetMenu(menuName = "AI/FSM/Activity/WaitActivity")]
    public class WaitActivity : Activity
    {
        public override void Enter(BaseStateMachine stateMachine)
        {
            stateMachine.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            //stateMachine.GetComponent<Animator>().SetBool("isWalk", false);
        }


        public override void Execute(BaseStateMachine stateMachine) { }


        public override void Exit(BaseStateMachine stateMachine) { }
    }
}