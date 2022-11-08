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

    //Based on playerLevel: if < 4 then 1, if > 4 and < 7 then 2, if > 7 then 4
    // enemyComposition will spawn more enemies by a multiple of amountToPool and itself
    private int enemyComposition;

    //Need to be set to a global Player Level variable in the Player object
    // As of now is set in the inspector before load
    public int playerLevel;

    // Start is called before the first frame update
    void Start()
    {
        if(playerLevel <= 3){
            enemyComposition = 1;
        }else if(playerLevel > 3 && playerLevel <= 6){
            enemyComposition = 2;
        }else{
            enemyComposition = 4;
        }
  
        pooledEnemies = new List<GameObject>();

        for (int i = 0; i < amountToPool * enemyComposition; i++) {

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
