/*
 *  Decision.cs
 *  Dawson Burgess
 *  Logic for creating scriptable Decision objects
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 *  On its own the class doesn’t contribute much to the framework. This can be changed by adding few more 
 *  classes implementing specific event-handling logic. This will allow lots of flexibility for the machine.
 */
namespace AI.FSM 
{
    public abstract class Decision : ScriptableObject
    {
        public abstract bool Decide(BaseStateMachine stateMachine);
    }
}