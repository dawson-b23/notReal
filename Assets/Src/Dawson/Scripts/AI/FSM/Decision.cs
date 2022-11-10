/*
 *  Decision.cs
 *  Dawson Burgess
 *  Logic for creating scriptable Decision objects
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI.FSM 
{
    public abstract class Decision : ScriptableObject
    {
        public abstract bool Decide(BaseStateMachine stateMachine);
    }
}