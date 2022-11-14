/*
 *  BaseState.cs
 *  Dawson Burgess
 *  Logic for not changing states in FSM
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
    [CreateAssetMenu(menuName = "AI/FSM/RemainInState")]
    public sealed class RemainInState : BaseState { }
}
