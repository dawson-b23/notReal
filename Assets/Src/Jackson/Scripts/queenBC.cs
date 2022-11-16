/*
 * Jackson Baldwin - 11/10/2022        
 * QueenBC.cs - NotReal        
 *                                    
 * Script for QueenBC behavior
 *...nearly identical to ShopKeeper, but does not need certain
 *attributes that ShopKeeper does (static/dynamic binding)
 *                                    
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * QueenBC Class
 * used by QueenBC prefab
 * 
 * member variables:
 * dialogueScript - instance of SetDialogue prefab...made public to easily set what BC says
 * playerInRange - boolean to track if a player has entered the 2D Box Collider
 */
public class QueenBC : MonoBehaviour
{
    public SetDialogue dialogueScript;
    private bool playerInRange;

    //checks if players in Range. If so, Indicator will turn on and inRange boolean set to true
    private void OnTriggerEnter2D(Collider2D other)
    {
          if(other.CompareTag("Player"))
          {
            playerInRange = true;
            dialogueScript.toggleIndicator(playerInRange);
          }
    }

    //if player leaves the Range, turn off Indicator, end the dialogue, set inRange boolean to false
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
