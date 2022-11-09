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
    public List<GameObject> pooledEnemies;

    //acquireReusable(): Reusable
    public GameObject[] enemyToPool;

    //setMaxPoolSize(in size)
    public int amountToPool;

    


    // Start is called before the first frame update
    void Start()
    {
     
        pooledEnemies = new List<GameObject>();

        for (int i = 0; i < amountToPool; i++) {

            int rand = Random.Range(0,enemyToPool.Length);
            
            GameObject obj = (GameObject)Instantiate(enemyToPool[rand]);
            obj.SetActive(false); 
            pooledEnemies.Add(obj);
            
        }
            
    }

    // grabs enemy as it is set to active
    void Awake() {
        SharedInstance = this;
    }

    /* GetPooledObject() returns an object in the pooledEnemies array

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

    
}
