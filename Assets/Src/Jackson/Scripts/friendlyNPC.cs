/*
 * Jackson Baldwin - 11/10/2022        
 * FriendlyNPC.cs - NotReal        
 *                                    
 * Script for FriendlyNPC behavior
 * ...non-specific friendly NPC that makes use of 
 * random Dialogue
 *                                    
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * FriendlyNPC Class
 * used by non-specific friendly NPC prefabs
 * 
 * member variables:
 * dialogueScript - instance of RandomDialogue prefab to hold script...public so some specific dialogue can be added to this sprite
 * playerInRange - boolean to track if a player has entered the 2D Box Collider
 */
public class FriendlyNPC : MonoBehaviour
{
    //call instance of randomDialogue script...contains 25 tips for the player to cycle through..
    public RandomDialogue dialogueScript;
    private bool playerInRange;

    //checks if players in Range. If so, Indicator will turn on
    private void OnTriggerEnter2D(Collider2D other)
    {
          if(other.CompareTag("Player"))
          {
            playerInRange = true;
            dialogueScript.toggleIndicator(playerInRange);
          }
    }

    //if player leaves the Range, turn off Indicator and end the dialogue
    private void OnTriggerExit2D(Collider2D other)
    {
          if(other.CompareTag("Player"))
          {
            playerInRange = false;
            dialogueScript.toggleIndicator(playerInRange);
            dialogueScript.endDialogue();
          }
    }

    //if player is in range AND presses "E", begin Dialogue
    private void Update()
    {
        if(playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            dialogueScript.startDialogue();
        }

    }
}
