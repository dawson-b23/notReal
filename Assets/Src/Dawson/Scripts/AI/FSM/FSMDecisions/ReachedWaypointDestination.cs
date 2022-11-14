/*
 *  ReachedWaypointDestination.cs
 *  Dawson Burgess
 *  Logic for deciding when waypoint is reached, invoking a transition to another state
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
    [CreateAssetMenu(menuName = "AI/FSM/Decisions/ReachedWaypointDestination")]
    public class ReachedWaypointDestination : Decision
    {
        public override bool Decide(BaseStateMachine stateMachine)
        {
            return(stateMachine.GetComponent<PatrolPoints>().HasReachedPoint()) ? true : false;
        }
    }
}
