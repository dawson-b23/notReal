using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnWallObjects : MonoBehaviour
{
    public GameObject[] objects;
    // Start is called before the first frame update
    void Start()
    {
        // Added check for valid # of objects - JacobW
        if(objects.Length != 0)
        {
            // Random selection of objects[] array
            int rand = Random.Range(0, objects.Length);
            // Instantiate(objects[rand], transform.position, Quaternion.identity);
            var newObj = GameObject.Instantiate(objects[rand], transform.position, Quaternion.identity);
            newObj.transform.parent = GameObject.Find("WallObjectContainer").transform;
        }
    }
}