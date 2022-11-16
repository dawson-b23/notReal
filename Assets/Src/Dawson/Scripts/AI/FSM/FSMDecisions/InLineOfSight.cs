/*
 *  InLineOfSight.cs
 *  Dawson Burgess
 *  Logic for deciding if the player is in enemy line of sight
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 *  This class decides if the player is in the AI's line of sight. This is slightly trickier in 2D
 *  versus 3D becuase the lack of the transform forward direction. This gets AI position at previous frame,
 *  and allows a new forward direction along x-axis to be calculated at current time. This is for ray casting. 
 *
 *  member variables:
 *
 *  layerMask          -  Only objects that’s been placed on that layer in Unity editor will be detected while others rejected
 *  distanceThreshould -  checks to see if player is in this distance, "vision/sight range"
 *  prevPosition       -  collaborate with each other to ensure this information at every frame
 *  prevDirection      -  collaborate with each other to ensure this information at every frame
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
