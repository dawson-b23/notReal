using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class queenBC : MonoBehaviour
{
    // Start is called before the first frame update
  private bool playerInRange;


    // Update is called once per frame
    void Update()
    {
        if(playerInRange)
        {
            print("Hello!! I'm Queen BC! Yep! Thats it!");
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
          if(other.CompareTag("Player"))
          {
            playerInRange = true;
          }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
          if(other.CompareTag("Player"))
          {
            playerInRange = false;
          }
    }
}
