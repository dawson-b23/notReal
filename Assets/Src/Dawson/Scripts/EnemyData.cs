using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObject/Enemy", order = 1)]
public class EnemyData : ScriptableObject
{
    public int health;
    public int damage;
    // public int detectionRange;
    //public int attackRange;
    public float speed; 
}
