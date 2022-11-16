/*
 *  State.cs
 *  Dawson Burgess
 *  Logic for creating a state that the FSM can transition to 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 *  Description
 *
 *  member variables:
 *
 *  Activities  - a list that stores activites for the FSM to carry out while in a state
 *  Transitions - a list that stores transitions between activites 
 *
 *  member functions:
 *
 *  Enter()   - gets the activities from scriptable object for the state
 *  Execute() - executes the activites and their associated transitions for the state 
 *  Exit()    - exits the state once executes have been compeleted
 */
namespace AI.FSM
{
    [CreateAssetMenu(menuName = "AI/FSM/State")]
    public sealed class State : BaseState
    {   
        public List<Activity>   Activities  = new List<Activity>();  
        public List<Transition> Transitions = new List<Transition>();


        public override void Enter(BaseStateMachine machine)
        {
            foreach(var activity in Activities)
                activity.Enter(machine);
        }


        public override void Execute(BaseStateMachine machine)
        {
            foreach(var activity in Activities)
                activity.Execute(machine);

            foreach(var transition in Transitions)
                transition.Execute(machine);
        }


        public override void Exit(BaseStateMachine machine)
        {
            foreach(var activity in Activities)
                activity.Exit(machine);
        }
    }
}