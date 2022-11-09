/*EnemySpawner.cs
Bryan Frahm
Spawns enemies from the pool to a random location just outside the player camera
Does not check if space is occupied, may spawn in occupied space as of now

*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private float timeBetweenEnemy;
    [SerializeField]
    private float enemyStartTime = 5.0f;
    
   
    // Start is called before the first frame update
    void Start()
    {
        //player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update(){
          if (timeBetweenEnemy <= 0)
        {
            SpawnEnemy();
            timeBetweenEnemy = enemyStartTime;
        }
        else
        {
            timeBetweenEnemy -= Time.deltaTime;
        }
    }
    /*SpawnEnemy
     Pulls an enemy initialized from EnemyPooler.cs
    */
    public void SpawnEnemy(){
       int range = Random.Range(0,2);
       float x;
       
        if(range == 0){
            x = -1.0f;
      
        }else{
            x = 1.0f;
      
        }
        //Grab the position of the camera and change it by x
       Vector3 spawnPoint = Camera.main.ViewportToWorldPoint(new Vector3(x, .5f, 0));
       
            GameObject enemy = EnemyPooler.SharedInstance.GetPooledObject(); 
            if (enemy != null) {
            enemy.transform.position = spawnPoint;
   
            enemy.SetActive(true);
        }
       
       //Instantiate(enemy[0], spawnPoint, Quaternion.identity);
          

    }



}