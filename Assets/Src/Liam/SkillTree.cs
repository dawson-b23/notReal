/*
 * SkillTree.cs
 * Liam Mathews
 * Boosts Player stats and 
 * adds additional abilities when
 * Player aquires sufficient exp
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/* Pattern integration outline
   Create new class of player that inherits from PlayerController
   Create class of upgrades, linked to new player class
   Upgrade classes will be linked to original


//now all methods and attributes are inherited from the PlayerController
//we only care about attributes, since that's what we'll be adjusting 
//though there are some methods such as LevelUp() which exist in PlayerController
//that we will want to access here

private class FullPlayer : PlayerController{



}

private class Upgrade : PlayerController{

}

private class AttackUpgrade : Upgrade{

}

private class StaminaUpgrade : Upgrade{

}

private class MovementUpgrade : Upgrade{

}

*/


/*
 * SkillTree class
 * 
 * member variables:
 * PlayerController - will hold reference to Player
 * Start() - initalize player
 * GetPlayer() - allows us to initialize Player in other files associated with this one
 * upgradeval - contains current amount of exp player holds
 * requiredexp - cost of an upgrade
 * Upgrade() - check if player has enough exp, apply if true, otherwise do nothing
 */
public class SkillTree : MonoBehaviour
{
    //create a variable of PlayerController type to hold 
    //Player item from PlayerController.cs (Assets -> Src -> Jacob)
    private PlayerController player = null;
    
    //Intializes variables/method calls upon start of program
    private void Start(){
        //Initialize PlayerController variable with player from PlayerController file
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    //Allows us to initalize Player in files linked to this file, check to see if player
    //variable is not null, initialize if true, and return the value of player
    public PlayerController GetPlayer(){
        if(player == null){
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        }
        //returns initalized player variable
        return player;
    }

    //how much is added to a selected Player
    //stat when upgrading
    int upgradeval = 10;

    //cost of upgrade
    int requiredexp = 5;

    //Checks if Player has sufficient exp, 
    //if true selected stat is upgraded by upgradeval
    //cost amt is subtracted from Player exp
    //If Player does not have enough exp, do nothing
    public void Upgrade(){
        Debug.Log("Current Exp: " + player.exp);
        if(player.exp >= requiredexp){
            player.PlayerSpeed += upgradeval;
            player.exp -= requiredexp;
    
            Debug.Log("exp = " + player.exp);
            Debug.Log("Upgrading");

            player.LevelUp();
        }else{
            Debug.Log("Not enough exp!");
        }
    }
}