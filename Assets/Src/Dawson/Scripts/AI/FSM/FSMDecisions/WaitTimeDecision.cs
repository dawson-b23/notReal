/*
 *  WaitTimeDecision.cs
 *  Dawson Burgess
 *  Logic for waiting between patrols
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 *  When the finite state machine enters the wait state, there is a timer that count towards certain amount of seconds. 
 *  After, an invoke to an event will start the transition to the new state.
 *
 *  member variables:
 *
 *  waitTime - time to wait 
 *
 *  member functions:
 *
 *  Decide() - makes the AI wait in this state before transitioning to the next 
 */
namespace AI.FSM.Decisions
{
    [CreateAssetMenu(menuName = "AI/FSM/Decisions/WaitTimeDecision")]
    public class WaitTimeDecision : Decision
    {
        public float waitTime = 3f;
        float timer = 0;

        public override bool Decide(BaseStateMachine stateMachine)
        {
            timer += Time.deltaTime;
            if(timer >= waitTime)
            {
                timer = 0;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
