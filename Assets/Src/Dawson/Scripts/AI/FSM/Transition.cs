/*
 *  Transition.cs
 *  Dawson Burgess
 *  Logic for creating scriptable Transition objects
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 *  transitions in the finite state machine are invoked by events. The machine only changes its 
 *  state when the event invokes the trigger for that change. The AI requires two separate pieces 
 *  of data so that it can make up a decision about the transition.
 *
 *  member variables:
 *
 *  decision   - holds a reference to an object that contains its own logic on handling the event, similiar to a conditional statement
 *  TrueState  - reference to the states participating in the transition
 *  FalseState - reference to the states participating in the transition
 */
namespace AI.FSM 
{
    [CreateAssetMenu(menuName = "AI/FSM/Transition")]
    public sealed class Transition : ScriptableObject
    {
        public Decision  decision;
        public BaseState TrueState;
        public BaseState FalseState; 


        public void Execute(BaseStateMachine stateMachine)
        {
            if(decision.Decide(stateMachine) && !(TrueState is RemainInState))
            {
                stateMachine.CurrentState.Exit(stateMachine);
                stateMachine.CurrentState = TrueState;
                stateMachine.CurrentState.Enter(stateMachine);
            }
            else if(!(FalseState is RemainInState))
            {
                stateMachine.CurrentState.Exit(stateMachine);
                stateMachine.CurrentState = FalseState;
                stateMachine.CurrentState.Enter(stateMachine);
            }
        }
    }
}