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
            //chack if shop has spawned in main path
            //if hasShop is false then spawn one shop and set hasShop to true
            if(levelGen.hasShop == false){
                Instantiate(levelGen.rooms[7], transform.position, Quaternion.identity);
                levelGen.hasShop = true;
            }else{
                //continue spawning rooms to fill empty spots in level
            Instantiate(levelGen.rooms[Random.Range(1,5)], transform.position, Quaternion.identity);
            }
            
            Destroy(gameObject);
        }
    }
}
