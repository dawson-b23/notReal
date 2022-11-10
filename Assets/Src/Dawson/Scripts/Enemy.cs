/*
 *
 *
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


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
    private EnemyData data;

    private PlayerController player;


    // rigid body and sprite for death

    void Start()
    {
        InitEnemy();
    }


    void Update()
    {
        if(health <= 0)
        {
            Destroy(GetComponent<Rigidbody2D>());
            Destroy(GetComponent<SpriteRenderer>());
            Destroy(GetComponent<BoxCollider2D>());
            Destroy(this);
        }
    }


    private void InitEnemy()
    {
        damage = data.damage;
        health = data.health;
        speed = data.speed;
    }



    public void takeDamage(int damage) 
    {
        health = health - damage;
    }


    private void OnTriggerEnter2D(Collider2D collider)
    {
        health = health - 50;
        player.takeDamage(10);
    }
}
