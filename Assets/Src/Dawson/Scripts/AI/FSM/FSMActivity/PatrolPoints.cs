using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI.FSM 
{ 
    public class PatrolPoints : MonoBehaviour
    {
        public List<Vector3> points;
        private Vector3 targetPoint;
        private int index;


        private void Start()
        {
            index = 0;
            targetPoint = points[index];
        }


        public bool HasReachedPoint()
        {
            return(Vector3.Distance(transform.position, targetPoint) <= 0.5f);
        }


        public void SetNextTargetPoint()
        {
            index = (index == points.Count - 1) ? 0 : index + 1;
            targetPoint = points[index];
        }


        public Vector3 GetTargetPointDirection()
        {
            return(targetPoint - transform.position).normalized;
        }
    }
}