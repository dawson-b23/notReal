/*
 *  BaseState.cs
 *  Dawson Burgess
 *  Logic for not changing states in FSM
 */
 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 *  Most times we want the AI to stick with the same state when incoming 
 *  events don’t fulfil the conditions of a transition. It acts as an empty game object the machine can
 *  use to transition not change states.
 */
namespace AI.FSM 
{
    [CreateAssetMenu(menuName = "AI/FSM/RemainInState")]
    public sealed class RemainInState : BaseState { }
}
