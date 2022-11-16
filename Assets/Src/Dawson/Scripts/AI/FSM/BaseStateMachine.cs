/*
 *  BaseStateMachine.cs
 *  Dawson Burgess
 *  Logic for the enemy Finite State Machine - will execute initial state and update after
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 *  This class includes fundamental logic behind FSM.
 *  It will call Enter() function of initial state, then it
 *  will constantly run Execute() function of current state.
 *
 *  member variables:
 *
 *  _initialState - gets the starting state of for the FSM
 *  CurrentState  - gets the current state for the machine
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
