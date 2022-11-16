/*
 *  PatrolPoints.cs
 *  Dawson Burgess
 *  Logic for assigning patrol points on a list to be used in PatrolActivity.cs
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 *  This is a helper class that designates a patrol route for the AI. It has methods and data 
 *  necessary for a waypoint system. It stores Vector3 waypoints inside a list, then visits them.
 *
 *  member variables:
 *
 *  points      - the list of Vector3 points that the AI will use to traverse
 *  targetPoint - a reference to a location the AI should head towards 
 *  index       - the current list pointer
 *  point1      - used to auto assign a point
 *  point2      - used to auto assign a point
 *
 *  member functions:
 *
 *  HasReachedPoint()         - used to know if the AI has reached a certain point. Vector3.Distance
                                returns the measurement of a distance between 2 points. 
 *  SetNextTargetPoint()      - designates a new target location, this is where index is used 
 *  GetTargetPointDirection() - used to know the direction in which current target is. 
 */
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
            point1 = new Vector3(transform.position.x + 10, transform.position.y, transform.position.z);
            point2 = new Vector3(transform.position.x - 10, transform.position.y, transform.position.z);
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
