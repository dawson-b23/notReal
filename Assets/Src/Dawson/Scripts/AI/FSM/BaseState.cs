/*
 *  BaseState.cs
 *  Dawson Burgess
 *  Logic for creating scriptable BaseState objects
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 *  This class represents the abstraction of a state.
 *  Extends the scriptable object and has 3 virtual methods that will be overridden.
 *  
 *
 *  member functions:
 *  
 *  Enter()   - executes when FSM enters the state
 *  Execute() - constantly executed when FSM is in a state
 *  Exit()    - executes when FSM leaves the state
 */
namespace AI.FSM
{
    public class BaseState : ScriptableObject
    {
        public virtual void Enter(BaseStateMachine machine) { }

        public virtual void Execute(BaseStateMachine machine) { }

        public virtual void Exit(BaseStateMachine machine) { }
    }
}