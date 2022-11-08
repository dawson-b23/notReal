using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
