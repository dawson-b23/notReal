/*
 *  PatrolPoints.cs
 *  Dawson Burgess
 *  Logic for assigning patrol points on a list to be used in PatrolActivity.cs
 */

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
        private Vector3 point1;
        private Vector3 point2;

        private void Start()
        {
            index = 0;
            point1 = new Vector3(transform.position.x + 5, transform.position.y, transform.position.z);
            point2 = new Vector3(transform.position.x - 5, transform.position.y, transform.position.z);
            points.Add(point1);
            points.Add(point2);
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
