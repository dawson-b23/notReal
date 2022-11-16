/*
 *  WaitActivity.cs
 *  Dawson Burgess
 *  Logic for waiting between patrols
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 *  This class inherits from the activity class. The overidden methods correspond to
 *  the states we have assumed for the model. This class is the wait class that gets
 *  called between other activities.
 *
 *  member functions:
 *
 *  Enter() - makes the AI stop and wait before entering its next state. 
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