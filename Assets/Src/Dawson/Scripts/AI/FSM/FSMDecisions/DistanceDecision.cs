/*
 *  DistanceDecision.cs
 *  Dawson Burgess
 *  Logic for creating deciding what distance to stop running at the player
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 *  Since the player can outrun the enemy, AI must know how far away the player actually is. If too far,
 *  then the AI should resume patrolling. Otherwise it will follow player.
 *
 *  member variables:
 *
 *  target             - used with targetTag to give AI something to chase 
 *  targetTag          - Enemy will only chase game object with this tag value 
 *  distanceThreshould - distance to check against, if distance <= threshould return true
 */
namespace AI.FSM.Decisions
{
    [CreateAssetMenu(menuName = "AI/FSM/Decisions/DistanceDecision")]
    public class DistanceDecision : Decision
    {
        GameObject target;
        public string targetTag;
        public float distanceThreshold = 3f;

        public override bool Decide(BaseStateMachine stateMachine)
        {
            if(target == null) target = GameObject.FindWithTag(targetTag);

            return(Vector3.Distance(stateMachine.transform.position, target.transform.position) >= distanceThreshold) ? true : false;
        }
    }
}
