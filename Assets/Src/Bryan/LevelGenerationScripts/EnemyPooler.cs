using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPooler : MonoBehaviour
{
    public static EnemyPooler SharedInstance;
    public List<GameObject> pooledEnemies;
    public GameObject[] enemyToPool;
    public int amountToPool;

    // eventurally add if player level > certain amount spawn different enemies in pool
    private int enemyComposition;
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

    
    void Awake() {
        SharedInstance = this;
    }

    public GameObject GetPooledObject() {

        for (int i = 0; i < pooledEnemies.Count; i++) {

            if (!pooledEnemies[i].activeInHierarchy) {
                return pooledEnemies[i];
            }
        }
  
    return null;
    }

    public GameObject GetSpawnedObject() {

        for (int i = 0; i < pooledEnemies.Count; i++) {

            if (pooledEnemies[i].activeInHierarchy) {
                return pooledEnemies[i];
            }
        }
  
    return null;
    }
}
