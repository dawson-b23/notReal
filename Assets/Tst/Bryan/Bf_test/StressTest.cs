using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StressTest : MonoBehaviour { 


public Transform[] WorldStartingPositions;
public GameObject[] rooms; //ROOM OPENINGS 0 = spawnroom 1 = left/right, 2 left/right/bottom, 3 left/right/top, 4 left/right/top/bottom
public LayerMask room;
public float moveAmount;
public float startTime = 0.25f;
public int roomCount = 0;
public float minX;
public float maxX;
public float minY;

private float timeBetweenRoom;
private bool stopGeneration;
private int direction;
    // Start is called before the first frame update
    void Start()
{
    int randStartingPos = Random.Range(0, WorldStartingPositions.Length);
    transform.position = WorldStartingPositions[randStartingPos].position;
    Instantiate(rooms[0], transform.position, Quaternion.identity);

    direction = Random.Range(1, 6);

}
private void Update()
{
    if (timeBetweenRoom <= 0 && stopGeneration == false)
    {
            System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
            stopwatch.Start();
        Move();
        timeBetweenRoom = startTime;
        roomCount = roomCount + 1;
            stopwatch.Stop();
            Debug.Log("roomCount = " + roomCount);
            Debug.Log("Time taken: " + (stopwatch.Elapsed));
            stopwatch.Reset();
    }
    else
    {
        timeBetweenRoom -= Time.deltaTime;
    }

}

private void Move()
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
            if (nextPosition.x > maxX)
            {
                int randBottomRoom = 4; //force room to have all four openings to deal with edge case
                Instantiate(rooms[randBottomRoom], transform.position, Quaternion.identity);
            }
            else if (direction == 5)
            {

                int randBottomRoom = Random.Range(2, 5);

                if (randBottomRoom == 3)
                {
                    randBottomRoom = 2;
                }

                Instantiate(rooms[randBottomRoom], transform.position, Quaternion.identity);
            }
            else
            {
                //added to give a room with a left opening
                int rand = Random.Range(1, rooms.Length);
                Instantiate(rooms[rand], transform.position, Quaternion.identity);

            }
        }
        else
        {//moved down if right boundary is reached
            direction = 5;
        }
    }//move left
    else if (direction == 3 || direction == 4)
    {
       
        if (transform.position.x > minX)
        {
            Vector2 newPosition = new Vector2(transform.position.x - moveAmount, transform.position.y);
            transform.position = newPosition;
            Vector2 nextPosition = new Vector2(transform.position.x - moveAmount, transform.position.y);

            direction = Random.Range(3, 6);// force direction to be left or down to prevent overlap


            if (nextPosition.x < minX)
            {
                int randBottomRoom = 4; //force room to have all four openings to deal with edge case
                Instantiate(rooms[randBottomRoom], transform.position, Quaternion.identity);
            }
            else if (direction == 5)
            {
                int randBottomRoom = 4;//force room to have all four openings to deal with edge case
                Instantiate(rooms[randBottomRoom], transform.position, Quaternion.identity);
            }
            else
            {

                //added to give a room with a right opening
                int rand = Random.Range(1, rooms.Length);
                Instantiate(rooms[rand], transform.position, Quaternion.identity);
            }



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



            if (direction == 5)
            {
                int randBottomRoom = 4;
                Instantiate(rooms[randBottomRoom], transform.position, Quaternion.identity);

            }
            else
            {
                //added to give a room with a top opening
                int rand = Random.Range(3, 5);
                Instantiate(rooms[rand], transform.position, Quaternion.identity);

            }
        }
        else
        {//stop generation
         //add end room here
         // add check for boss or no
            stopGeneration = true;
        }
    }

    //  Instantiate(rooms[0], transform.position, Quaternion.identity);



}

}
