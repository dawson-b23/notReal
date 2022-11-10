/*
 *  Enemy.cs
 *  Dawson Burgess  
 *  Enemy class contains functions for interaction with the player and world
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 *  This class helps enemies generally interact with the player
 *
 *  member variables:
 *  damage - enemy damage to player
 *  health - enemy health 
 *  speed - enemy speed 
 *  honeyAmt - amount of honey rewarded to player on kill
 *  enemyData - reference to data object for enemy
 *
 *  member functions:
 *  InitEnemy() - initialized enemy with values set by data object
 *  takeDamage() - logic for player to inflict damage to enemy 
 *  OnTriggerEnter2D() - detects collisions with player and inflicts damage 
 *  enemyDeath() - logic for when enemies die, deactivates enemy and associated scripts
 *
 */
public class Enemy : MonoBehaviour
{

    // generic initialzed stats, data objects will adjust based on enemy type 
    [SerializeField]
    private int damage = 5;

    [SerializeField]
    private int health = 100;

    [SerializeField]
    private float speed = 1.5f;

    [SerializeField]
    private int honeyAmt = 0;

    [SerializeField]
    private EnemyData data;


    // rigid body and sprite for death

    void Start()
    {
        InitEnemy();
    }


    void Update()
    {
        if(health <= 0)
        {
            enemyDeath();
        }
    }


    private void InitEnemy()
    {
        damage = data.damage;
        health = data.health;
        speed = data.speed;
        honeyAmt = data.honeyAmt;
    }



    public void takeDamage(int damage) 
    {
        health = health - damage;
    }


    private void OnTriggerEnter2D(Collider2D collider)
    {
        GameObject playerObject = GameObject.FindWithTag("Player");
        health -= 50;
        playerObject.GetComponent<PlayerController>().takeDamage(damage);
    }


    private void enemyDeath()
    {
        GameObject playerObject = GameObject.FindWithTag("Player");
        playerObject.GetComponent<PlayerController>().addHoney(honeyAmt); // rewards player with honey

        // deletes components and scripts associted with enemy   
        Destroy(GetComponent<Rigidbody2D>());
        Destroy(GetComponent<SpriteRenderer>());
        Destroy(GetComponent<BoxCollider2D>());
        MonoBehaviour[] scripts = gameObject.GetComponents<MonoBehaviour>();
        foreach(MonoBehaviour script in scripts)
        {
            script.enabled = false;
        }
        Destroy(this);
    }
}
