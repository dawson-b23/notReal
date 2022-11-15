/*
 * LevelGeneration.cs
 * Bryan Frahm
 * Generates a path through the world
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * 
 * worldStartingPositions - gives position of where to start generating
 * rooms - an array that holds room prefabs with reference to directional openings
 *        0 = spawnroom 1 = left/right, 2 left/right/bottom, 3 left/right/top, 4 left/right/top/bottom     
 * moveAmount - the amount moved for the next room to spawn in, based on room size
 * startTime - delay added between each room spawning
 * minX - minimum X value to act as border
 * maxX - max x value
 * minY - minimum y value to initiate stopGeneration
 * direction - int value to determine direction 1,2 right 3,4 left 5 down
 * stopGeneration - stops spawning new rooms
 * timeBetweenRoom - temp variable to hold time to add delay when spawning rooms
 *
 * Move() - function to spawn and place rooms
 */
public class LevelGeneration : MonoBehaviour
{
    public Transform[] worldStartingPositions;
    public GameObject[] rooms; 
         //ROOM OPENINGS 0 = spawnroom 1 = left/right, 2 left/right/bottom, 3 left/right/top, 4 left/right/top/bottom
         // 5 EmptyRoom, 6 ExitRoom, 7 Shop Room

    public bool stopGeneration;   
    public bool hasShop;
    //added to fix majority or outside bounds array error
    //used in ExitLevel.cs to reset to false
    public static bool hasLoaded = false;

    [SerializeField]
    private float moveAmount;
    [SerializeField]
    private float startTime = 0.25f;
    [SerializeField]
    private float minX;
    [SerializeField]
    private float maxX;
    [SerializeField]
    private float minY;
    
    private int direction;    
    private float timeBetweenRoom;
    private int shopIter = 0;
    private int spawnShop;
 
   
    // Start is called before the first frame update
    void Start()
    {
       
        //causing the error outside bounds off array    
        //int randStartingPos = Random.Range(0, worldStartingPositions.Length);
    // hasLoaded added to fix error in array
    // seems to stem in how the rooms are spawned after the initial start room spawn    
    if(hasLoaded == false){
        int randStartingPos = 0;
 
//causing the error outside bounds off array  
        transform.position = worldStartingPositions[randStartingPos].position;
        
        if(PlayerController.playerLevel == 0){
            //Spawn StartRoom
            Instantiate(rooms[0], transform.position, Quaternion.identity);
        }else{
            //Spawn StartRoomSecondary
            Instantiate(rooms[8], transform.position, Quaternion.identity);
        }
        direction = Random.Range(1, 6);
        spawnShop = Random.Range(1,6);
        hasLoaded = true;
    }
    }
    private void Update()
    {
        if (timeBetweenRoom <= 0 && stopGeneration == false)
        {
            move();
            timeBetweenRoom = startTime;
        }
        else
        {
            timeBetweenRoom -= Time.deltaTime;
        }

   
       
    
    }



    /*move()
     * funciton to move and spawn a room in a determined direction
     * Right(1||2)
     * Left(3||4)
     * Down(5)
     *
     */
    private void move()
    {
        
        //move right
        if (direction == 1 || direction == 2)
        {
            if (transform.position.x < maxX)
            {
                
                Vector2 newPosition = new Vector2(transform.position.x + moveAmount, transform.position.y);
                transform.position = newPosition;
                Vector2 nextPosition = new Vector2(transform.position.x + moveAmount, transform.position.y);
               
                direction = Random.Range(1, 6);// force direction to be 1,2 or 5 to prevent overlap
                int rand;

                //prevents moving back left onto itself
                if (direction == 3)// move right
                {
                    direction = 2;
                }
                else if (direction == 4)//move down
                {
                    direction = 5;
                }

               
                // ensure bottom opening 
               if(nextPosition.x > maxX)
                {                 
                    rand = 4;                                    
                }
                else if (direction == 5)
                {
                    rand = 4;                  
                }
                else
                {   //spawns shop when shopIter == spawnShop
                    if(hasShop == false && spawnShop == shopIter){
                        rand = 7;
                        hasShop = true;
                    }else{
                    
                    //added to give a room with a left opening
                    rand = Random.Range(1, 4);
                    }
                }
                //spawn room with a left opening
                Instantiate(rooms[rand], transform.position, Quaternion.identity);
                shopIter = shopIter + 1;
                
            }
            else
            {//moved down if right boundary is reached
          
                direction = 5;
            }
        }
        
        //move left
        else if (direction == 3 || direction == 4)
        {
        
            if (transform.position.x > minX)
            {
                Vector2 newPosition = new Vector2(transform.position.x - moveAmount, transform.position.y);
                transform.position = newPosition;
                Vector2 nextPosition = new Vector2(transform.position.x - moveAmount, transform.position.y);
                
                // force direction to be left or down to prevent overlap
                direction = Random.Range(3, 6);
                int rand;
               
                if (nextPosition.x < minX)
                {
                
                    rand = 4;
                            
                }
                else if (direction == 5)
                {
                    rand = 4;
                   
                }
                else {

                    //spawn shop same as other direction
                     if(hasShop == false && spawnShop == shopIter){
                        rand = 7;
                        hasShop = true;
                    }else{
                    //added to give a room with a right opening
                    rand = Random.Range(1, 4);
                    }
                }
              //spawn either room with right opening or shop depending on value of rand
                Instantiate(rooms[rand], transform.position, Quaternion.identity);
                shopIter = shopIter + 1;
                


            }
            else
            {//moved down if left boundary is reached
               
                direction = 5;
            }

        }


        //move down
        else if (direction == 5)
        {
           
            if (transform.position.y > minY)
            {
                Vector2 newPosition = new Vector2(transform.position.x, transform.position.y - moveAmount);
                transform.position = newPosition;
                direction = Random.Range(1, 6);//any direction 
                int rand;


                if (direction == 5)
                {   //Seems redundent but also breaks when else is removed so it stays
                    //spawn a room with a top opening
                    rand = 4;
                   

                }
            
                else
                {
                    //added to give a room with a top opening
                    rand = 4;
                   
                    

                }
                Instantiate(rooms[rand], transform.position, Quaternion.identity);
              /*  
                if(spawnShop != shopIter)
                {
                shopIter = shopIter + 1;
                }
                */
            }
            else
            {
               
               //Adds an exit room under the last room before stop generation                                     
                Vector2 newPosition = new Vector2(transform.position.x, transform.position.y - moveAmount);
                transform.position = newPosition;
                Instantiate(rooms[6], transform.position, Quaternion.identity);
              

               //Added to guerantee that a solid room will spawn on the bottom after
               // the exit room has spawned in
                Vector2 bottomPosition = new Vector2(transform.position.x - moveAmount, transform.position.y);
                transform.position = bottomPosition;
                
                
                // adds rooms to the left of exit room
                // subtract 5 from minX because of cases where it wasnt catching the edge
                while(transform.position.x > minX-5){
                    
                    Instantiate(rooms[5], transform.position, Quaternion.identity);
                    Vector2 nextPosition = new Vector2(transform.position.x - moveAmount, transform.position.y);
                    transform.position = nextPosition;
                }

                transform.position = newPosition;
                Vector2 rightbottomPosition = new Vector2(transform.position.x + moveAmount, transform.position.y);
                transform.position = rightbottomPosition;
                
                //adds rooms to the right of exit room 
                // add 5 to maxX to get edge case 
                while(transform.position.x < maxX+5){
                   
                    Instantiate(rooms[5], transform.position, Quaternion.identity);
                    Vector2 nextPosition = new Vector2(transform.position.x + moveAmount, transform.position.y);
                    transform.position = nextPosition;
                }

                    // path is full and left and right exit is filled
                    // stop generation
                    //
                  stopGeneration = true;
                 
                //Added for Jackson
                 AudioManager.instance.PlayMusic("mainGame");
            }
        }
                      
    }
}
