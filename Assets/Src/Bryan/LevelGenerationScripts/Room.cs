using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public int roomType;
    public int enemyAmount;
    int enemy_lvl;
    int loot_lvl;
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
            return enemy_lvl;
        }
        int setLootlvl(int playerlvl)
        {
            return loot_lvl;
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
