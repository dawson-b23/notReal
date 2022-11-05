/*RoomDetection.cs
 * Bryan Frahm
 Used to detect roomspawn and then spawns rooms to fill out world after main path has been constructed
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomDetection: MonoBehaviour
{

    public LayerMask isRoom;
    public LevelGeneration levelGen;
    
    // Update is called once per frame
    void Update()
    {
        Collider2D roomDetection = Physics2D.OverlapCircle(transform.position, 1, isRoom);
        if (roomDetection == null && levelGen.stopGeneration == true)
        {
        
            //Instantiate(levelGen.rooms[Random.Range(1,5)], transform.position, Quaternion.identity);
            Instantiate(levelGen.rooms[5], transform.position, Quaternion.identity);
         
            Destroy(gameObject);
        }
    }
}
