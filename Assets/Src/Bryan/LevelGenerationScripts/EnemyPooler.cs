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

    // Start is called before the first frame update
    void Start()
    {
        pooledEnemies = new List<GameObject>();
    
        for (int i = 0; i < amountToPool; i++) {
            GameObject obj = (GameObject)Instantiate(enemyToPool[0]);
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
}
