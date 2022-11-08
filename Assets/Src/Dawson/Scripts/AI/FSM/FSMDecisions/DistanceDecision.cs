using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
