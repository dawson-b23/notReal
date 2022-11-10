/*
 *  EnemyData.cs
 *  Dawson Burgess
 *  This script is used to make scriptable objects, that makes adjusting enemy data plug and drop
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 *  A class that allows creations of scriptable objects for enemy data
 *
 *  member variables:
 *  health - enemy health
 *  damage - enemy damage
 *  honeyAmt - amount of honey rewarded to player on kill
 *  speed - the speed that the enemy will move at
 */
[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObject/Enemy", order = 1)]
public class EnemyData : ScriptableObject
{
    public int health;
    public int damage;
    public int honeyAmt;
    // public int detectionRange;
    //public int attackRange;
    public float speed; 
}
