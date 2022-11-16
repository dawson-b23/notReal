/*
 * Jackson Baldwin - 11/14/2022        
 * ShopKeeper.cs - NotReal        
 *                                    
 * Script for ShopKeeper behavior
 *...nearly identical to QueenBC, but requires certain
 *additional attributes (static/dynamic binding)
 *                                    
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * ShopKeeper Class
 * used by ShopKeeper prefab
 * 
 * member variables:
 * uiShop - instance of UI_Shop to be triggered on enter/exit
 * dialogueScript - instance of SetDialogue prefab...made public to easily set what ShopKeeper says
 * playerInRange - boolean to track if a player has entered the 2D Box Collider
 */
public class ShopKeeper : MonoBehaviour
{

    [SerializeField] private UI_Shop uiShop;

    public SetDialogue dialogueScript;
    private bool playerInRange;

    //if player enters box collider, turn on ShopIndicator, begin to play ShopKeeper theme, and set playerInRange boolean to true
    private void OnTriggerEnter2D(Collider2D other)
    {
          if(other.CompareTag("Player"))
          {
            playerInRange = true;
            //when player is in range of the ShopKeeper, begin the shopKeeper music
            AudioManager.instance.PlayMusic("shopKeeper");
            dialogueScript.toggleIndicator(playerInRange);
          }
    }

    //if player exits box collider, turn off ShopIndicator, endDialogue, and turn off Shop HUD
    //Begin to play mainGame theme and set playerInRange boolean to false
    private void OnTriggerExit2D(Collider2D other)
    {
          if(other.CompareTag("Player"))
          {
            playerInRange = false;
            //when player leaves the range of ShopKeeper, restart mainGame theme...area for improvement
            AudioManager.instance.PlayMusic("mainGame");
            dialogueScript.toggleIndicator(playerInRange);
            dialogueScript.endDialogue();
            uiShop.toggleUI_Shop(false);
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
