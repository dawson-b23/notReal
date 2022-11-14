/*
 *  InLineOfSight.cs
 *  Dawson Burgess
 *  Logic for deciding if the player is in enemy line of sight
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
namespace AI.FSM.Decisions
{
    [CreateAssetMenu(menuName = "AI/FSM/Decisions/InLineOfSight")]
    public class InLineOfSight : Decision
    {
        public LayerMask layermask;
        public float distanceThreshold = 3f;
        Vector3 prevPosition = Vector3.zero;
        Vector3 prevDirection = Vector3.zero;

        public override bool Decide(BaseStateMachine stateMachine)
        {
            Vector3 direction = (stateMachine.transform.position - prevPosition).normalized;
            direction         = (direction.Equals(Vector3.zero)) ? prevDirection : direction;
            RaycastHit2D hit  = Physics2D.Raycast(stateMachine.transform.position, direction, distanceThreshold, layermask);
            prevPosition      = stateMachine.transform.position;
            prevDirection     = direction;

            return(hit.collider != null) ? true : false;
        }
    }
}
