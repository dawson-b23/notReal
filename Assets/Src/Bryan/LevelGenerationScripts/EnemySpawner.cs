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
    private float enemyStartTime = 8.0f;
  
    //Based on playerLevel which is set in LevelGeneration: 
    // enemyComposition will spawn enemies faster
    private int enemyComposition;
    private float timeBetweenEnemy = 0.0f;

    public float spawnCollisionRadius;   
    // Start is called before the first frame update
    void Start()
    {   
       
        
        if(PlayerController.playerLevel <= 1){
            enemyComposition = 0;
        }else if(PlayerController.playerLevel > 1 && PlayerController.playerLevel <= 3){
            enemyComposition = 2;
        }else if(PlayerController.playerLevel > 3 && PlayerController.playerLevel <=5){
            enemyComposition = 4;
        }else{
            enemyComposition = 6;
        }

       
    }

    // Update is called once per frame
    void Update(){

       
            if (timeBetweenEnemy <= 0)
            {

                SpawnEnemy();
                timeBetweenEnemy = enemyStartTime - enemyComposition;
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
       float y = .5f;
        if(range == 0){
            x = -.1f;
      
        }else{
            x = 1.1f;
      
        }
        //Grab the position of the camera and change it by x
     
        Vector3 spawnPoint = Camera.main.ViewportToWorldPoint(new Vector3(x,y,1));
       
      
            GameObject enemy = EnemyPooler.SharedInstance.GetPooledObject(); 
            if (enemy != null) {
 
 
               if(!Physics.CheckSphere(spawnPoint, spawnCollisionRadius)){
     

                    enemy.transform.position = spawnPoint;
                    enemy.SetActive(true);
                }else{
                     Debug.Log("collisiondetected");
                    SpawnEnemy();
                }


        }
       
          

    }

}
