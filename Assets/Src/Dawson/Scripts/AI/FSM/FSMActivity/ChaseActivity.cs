/*
 *  ChaseActivity.cs
 *  Dawson Burgess
 *  Logic for enemy chasing the player 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 *  This class is very similiar to the patrolActivity class, except its chasing the player instead of a point
 *
 *  member variables:
 *
 *  target    - reference to the gameObject the AI will chase
 *  targetTag - this combined with target will set something for the AI to chase 
 *  speed     - generic speed value 
 *
 *  member functions:
 *
 *  Enter()   - finds the targetTag and sets the GameObject as a target
 *  Execute() - this is similiar to the patrol points execute, but with a player target instead 
 */
namespace AI.FSM.Activities
{
    [CreateAssetMenu(menuName = "AI/FSM/Activity/ChaseActivity")]
    public class ChaseActivity : Activity
    {
        GameObject    target;
        public string targetTag;
        public float speed = 1;


        public override void Enter(BaseStateMachine stateMachine)
        {
            target = GameObject.FindWithTag(targetTag);
            //stateMachine.GetComponent<Animator>().SetBool("isWalk", true);
        }


        public override void Execute(BaseStateMachine stateMachine)
        {
            var RigidBody = stateMachine.GetComponent<Rigidbody2D>();
            var SpriteRenderer = stateMachine.GetComponent<SpriteRenderer>();

            Vector2 direction = (target.transform.position - stateMachine.transform.position).normalized;
            RigidBody.velocity = new Vector2(direction.x * speed, RigidBody.velocity.y);
            SpriteRenderer.flipX = (direction.x > 0) ? true : false;
        }


        public override void Exit(BaseStateMachine stateMachine) { }
    }
}