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

    private GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        InitEnemy();
    }


    void Update()
    {
        Swarm();
        if(health <= 0)
        {
            Destroy(this);
        }
    }


    private void InitEnemy()
    {
        damage = data.damage;
        health = data.health;
        speed = data.speed;
    }


    private void Swarm()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }


    public void takeDamage(int damage) 
    {
        health = health - damage;
    }


    private void OnTriggerEnter2D(Collider2D collider)
    {
        //  [[ Still working on this, player needs health value]]
        if(collider.CompareTag("Player"))
        {
            //if(collider.GetComponent<PlayerController>().Health != null)
            //{
                //collider.GetComponent<PlayerController>().Damage(damage);
                health = health - 100000;
            //}
        }
    }
}
