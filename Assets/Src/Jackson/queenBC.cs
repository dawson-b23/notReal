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
        if(playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            // Move console msg to trigger once to prevent spamming the console - JacobW
            //play sound?
            //enter shop/dialogue
            //print("Hello!! I'm Queen BC! Yep! Thats it!");
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
          if(other.CompareTag("Player"))
          {
            playerInRange = true;
            print("Hello!! I'm Queen BC! Yep! Thats it!");
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
