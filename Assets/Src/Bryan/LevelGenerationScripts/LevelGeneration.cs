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
    public GameObject[] rooms; //ROOM OPENINGS 0 = spawnroom 1 = left/right, 2 left/right/bottom, 3 left/right/top, 4 left/right/top/bottom, 5 Empty, 6 Exit
    public float moveAmount;
    public float startTime = 0.25f;
    public float minX;
    public float maxX;
    public float minY;
    public bool stopGeneration;
    
    private int direction;    
    private float timeBetweenRoom;
    private bool hasShop;
    

    // Start is called before the first frame update
    void Start()
    {
        int randStartingPos = Random.Range(0, worldStartingPositions.Length);
        transform.position = worldStartingPositions[randStartingPos].position;
        Instantiate(rooms[0], transform.position, Quaternion.identity);

        direction = Random.Range(1, 6);

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
     * 
     */
    private void move()
    {
        
        //move right
        if (direction == 1 || direction == 2)
        {
            Debug.Log("direction = " + direction);
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
                   
                    
                   // int randBottomRoom = 4; //force room to have all four openings to deal with edge case
                   // Instantiate(rooms[randBottomRoom], transform.position, Quaternion.identity);
                }
                else if (direction == 5)
                    {

                    rand = 4;
                  // int randBottomRoom = Random.Range(2, 5);
                   
                    /*
                    if (rand == 3)
                    {
                        rand = 2;
                    }
                    */

                    //Instantiate(rooms[randBottomRoom], transform.position, Quaternion.identity);
                }
                else
                {
                    //added to give a room with a left opening
                    rand = Random.Range(1, 4);
                    //Instantiate(rooms[rand], transform.position, Quaternion.identity);
                   
                }
                Instantiate(rooms[rand], transform.position, Quaternion.identity);
            }
            else
            {//moved down if right boundary is reached
          
                direction = 5;
            }
        }
        
        //move left
        else if (direction == 3 || direction == 4)
        {
            Debug.Log("direction = " + direction);
            if (transform.position.x > minX)
            {
                Vector2 newPosition = new Vector2(transform.position.x - moveAmount, transform.position.y);
                transform.position = newPosition;
                Vector2 nextPosition = new Vector2(transform.position.x - moveAmount, transform.position.y);

                direction = Random.Range(3, 6);// force direction to be left or down to prevent overlap
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

                    //added to give a room with a right opening
                    
                    rand = Random.Range(1, 4);
                    
                }
                Instantiate(rooms[rand], transform.position, Quaternion.identity);


            }
            else
            {//moved down if left boundary is reached
               
                direction = 5;
            }

        }


        //move down
        else if (direction == 5)
        {
            Debug.Log("direction = " + direction);
            if (transform.position.y > minY)
            {
                Vector2 newPosition = new Vector2(transform.position.x, transform.position.y - moveAmount);
                transform.position = newPosition;
                direction = Random.Range(1, 6);//any direction 
                int rand;


                if (direction == 5)
                {
                    //spawn an exit room point
                    rand = 4;
                   

                }
                else
                {
                    //added to give a room with a top opening
                    rand = 4;
                   
                    

                }
                Instantiate(rooms[rand], transform.position, Quaternion.identity);
            }
            else
            {
                //stop generation
               //Adds an exit room under the last room before stop generation
               
               
               
                Vector2 newPosition = new Vector2(transform.position.x, transform.position.y - moveAmount);
                transform.position = newPosition;
                Instantiate(rooms[6], transform.position, Quaternion.identity);
             
                //stopGeneration = true;
               

               //Added to guerantee that a solid room will spawn on the bottom after
               // the exit room has spawned in
                Vector2 bottomPosition = new Vector2(transform.position.x - moveAmount, transform.position.y);
                transform.position = bottomPosition;
                
                
                // adds rooms to the left of exit room
                while(transform.position.x > minX+5){
                    
                    Instantiate(rooms[5], transform.position, Quaternion.identity);
                    Vector2 nextPosition = new Vector2(transform.position.x - moveAmount, transform.position.y);
                    transform.position = nextPosition;
                }

                transform.position = newPosition;
                Vector2 rightbottomPosition = new Vector2(transform.position.x + moveAmount, transform.position.y);
                transform.position = rightbottomPosition;
                
                //adds rooms to the right of exit room 
                while(transform.position.x < maxX+5){
                   
                    Instantiate(rooms[5], transform.position, Quaternion.identity);
                    Vector2 nextPosition = new Vector2(transform.position.x + moveAmount, transform.position.y);
                    transform.position = nextPosition;
                }
                  stopGeneration = true;
        
            }
        }
                      
    }
}
