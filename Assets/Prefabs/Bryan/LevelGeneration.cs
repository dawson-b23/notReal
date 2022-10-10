using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviour
{
    public Transform[] WorldStartingPositions;
    public GameObject[] rooms;

    public int direction;
    public float moveAmount;

    private float timeBetweenRoom;
    public float startTime = 0.25f;


    public float minX;
    public float maxX;
    public float minY;
    private bool stopGeneration;
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
            Move();
            timeBetweenRoom = startTime;
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

                direction = Random.Range(1, 6);// force direction to be 1,2 or 5 to prevent overlap
                if(direction == 3)// move right
                {
                    direction = 2;
                }else if(direction == 4)//move down
                {
                    direction = 5;
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

                direction = Random.Range(3, 6);// force direction to be left or down to prevent overlap
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
            }
            else
            {//stop generation
             //add end room here
             // add check for boss or no
                stopGeneration = true;
            }
        }

        Instantiate(rooms[0], transform.position, Quaternion.identity);
        

        
    }
}
