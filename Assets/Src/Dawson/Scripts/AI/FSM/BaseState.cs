/*
 *  BaseState.cs
 *  Dawson Burgess
 *  Logic for creating scriptable BaseState objects
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
namespace AI.FSM
{
    public class BaseState : ScriptableObject
    {
        public virtual void Enter(BaseStateMachine machine) { }

        public virtual void Execute(BaseStateMachine machine) { }

        public virtual void Exit(BaseStateMachine machine) { }
    }
}