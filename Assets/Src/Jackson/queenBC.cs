using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class queenBC : MonoBehaviour
{
    public Dialogue dialogueScript;


    private bool playerInRange;

    private void OnTriggerEnter2D(Collider2D other)
    {
          if(other.CompareTag("Player"))
          {
            playerInRange = true;
            dialogueScript.ToggleIndicator(playerInRange);
          }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
          if(other.CompareTag("Player"))
          {
            playerInRange = false;
            dialogueScript.ToggleIndicator(playerInRange);
            dialogueScript.EndDialogue();
          }
    }

    private void Update()
    {
        if(playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            dialogueScript.StartDialogue();
        }

    }
}
