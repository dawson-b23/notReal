/*
 *  ReachedWaypointDestination.cs
 *  Dawson Burgess
 *  Logic for deciding when waypoint is reached, invoking a transition to another state
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 *  This class will detect whether the NPC reached his current destination on patrol route.
 *
 *  member functions:
 * 
 *  Decide() - extended from decisions, it will decide true when it has reached a destination
 */
namespace AI.FSM.Decisions
{
    [CreateAssetMenu(menuName = "AI/FSM/Decisions/ReachedWaypointDestination")]
    public class ReachedWaypointDestination : Decision
    {
        public override bool Decide(BaseStateMachine stateMachine)
        {
            return(stateMachine.GetComponent<PatrolPoints>().HasReachedPoint()) ? true : false;
        }
    }
}
