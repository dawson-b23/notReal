/*
 *  Activity.cs
 *  Dawson Burgess
 *  Logic for creating scriptable activity objects
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
    public abstract class Activity : ScriptableObject
    {
        public abstract void Enter(BaseStateMachine stateMachine);

        public abstract void Execute(BaseStateMachine stateMachine);

        public abstract void Exit(BaseStateMachine stateMachine);
    }
}