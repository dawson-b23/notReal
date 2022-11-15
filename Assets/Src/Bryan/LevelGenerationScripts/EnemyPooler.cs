/*EnemyPooler.cs
Bryan Frahm
Creates a pool of enemies to spawn from periodically
Amount of enemies in the pool correlates to the players level

*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPooler : MonoBehaviour
{
    public static EnemyPooler SharedInstance;
    //Pool Design Pattern and their class diagram descriptions listed above applicable function/variable
    //static getInstance(): ReusablePool


    // list of enemies in the pool
    public List<GameObject> pooledEnemies;
   
   // array of enemies to spawn into the pool
    public GameObject[] enemyToPool;

    //sets the maximum pool size
    //currently set to 0 until 2 worlds have been complete
    public static int amountToPool;

    // Start is called before the first frame update
    //Start sets the pool currently upon world generation
    void Start()
    {
     
        pooledEnemies = new List<GameObject>();

        for (int i = 0; i < amountToPool; i++) {

            int rand = Random.Range(0,enemyToPool.Length);
            
            GameObject obj = (GameObject)Instantiate(enemyToPool[rand]);
            obj.SetActive(false); 
            pooledEnemies.Add(obj);
            
        }
        /*added to allow dawsons enemies to function properly for the oral exam
        Takes 2 passes through the world to start enemypool 
        because amounttoPool= 0 until this point after the first world so no pool is instantiated
        */
        if(ExitLevel.amountNavigated >= 1){

            amountToPool = 20;
        }
    }

    // grabs enemy as it is set to active
    void Awake() {
        SharedInstance = this;
    }



    /* GetPooledObject() returns an object in the pooledEnemies array
    * Used in enemySpawner to return an enemy from the pool and spawn it in a random position nearby
    * acquireReusable(): Reusable
    *
    */
    public GameObject GetPooledObject() {

        for (int i = 0; i < pooledEnemies.Count; i++) {

            if (!pooledEnemies[i].activeInHierarchy) {
                return pooledEnemies[i];
            }
        }
  
    return null;
    }
    
    


    //Prototype, may not make it to final version
    public GameObject GetSpawnedObject() {

        for (int i = 0; i < pooledEnemies.Count; i++) {

            if (pooledEnemies[i].activeInHierarchy) {
                return pooledEnemies[i];
            }
        }
  
    return null;
    }

    
    
    /*Despawns an object passed to the function 
        and sets it back into the pool
    */
    public void DespawnEnemy(GameObject enemy){

    
        if(enemy != null){
        //if( enemy.activeInHierarchy){

        enemy.SetActive(false); 
    }
    }

    
}
