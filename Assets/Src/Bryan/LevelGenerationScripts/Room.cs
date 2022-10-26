/*
 * Room.cs
 * Bryan Frahm
 * Sets contents of rooms
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * roomType - work in progress
 * enemyAmount - amount of enemies
 * enemyLevel - work in pregress
 * lootLevel - work in progress
 * 
 * Room() - constructor/ work in progress
 * setEnemy() - take playerLevel and return enemyAmount
 * RoomDestruction() - destroy a room/ work in progress
 * 
 */

public class Room : MonoBehaviour
{
    public int roomType;
    public int enemyAmount;
    
    private int enemyLevel;
    private int lootLevel;

    // Start is called before the first frame update
    public Room()
    {
        
    }
        public int setEnemy(int playerlvl)
        {
           
            if(playerlvl >= 0 && playerlvl < 3)
            {
                enemyAmount = 2;
            }else if(playerlvl >= 3 && playerlvl < 6)
            {
                enemyAmount = 3;
            }else if(playerlvl >= 6 && playerlvl < 10)
            {
                enemyAmount = 4;
            }
            else
            {
                enemyAmount = 5;
            }
            
            return enemyAmount;
        }
        int setEnemylvl(int playerlvl)
        {
            return enemyLevel;
        }
        int setLootlvl(int playerlvl)
        {
            return lootLevel;
        }
    
        public void RoomDestruction()
    {
        Destroy(gameObject);
    }
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
