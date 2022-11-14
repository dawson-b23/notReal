/*
 *  BaseStateMachine.cs
 *  Dawson Burgess
 *  Logic for the enemy Finite State Machine - will execute initial state and update after
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
    public class BaseStateMachine : MonoBehaviour
    {
        [SerializeField] 
        private BaseState _initialState;
        public BaseState CurrentState { get; set; }

        private void Awake()
        {
            CurrentState = _initialState;
        }


        private void Start()
        {
            CurrentState.Enter(this);
        }


        private void Update()
        {
            CurrentState.Execute(this);
        }
    }
}
