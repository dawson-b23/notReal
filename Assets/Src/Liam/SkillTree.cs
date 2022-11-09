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


   //Pattern integration outline
   //Create new class of player that inherits from PlayerController
   //Create class of upgrades, linked to new player class
   //Upgrade classes will be linked to original


//now all methods and attributes are inherited from the PlayerController
//we only care about attributes, since that's what we'll be adjusting 
//though there are some methods such as LevelUp() which exist in PlayerController
//that we will want to access here

/* to use SkillTree, use 
   FullPlayer boost;
   public void Start(){
    boost = new upPlayer();
   }
  
   void updateAttack(){}
   void updateHealth(){
    boost = new HealthUpgrade(boost);
   }

    //anwhere call
        boost.getAttack();
        boost.getHealth();
        boost.getSpeed();
*/

//GET RID OF THIS !! ============================================/
public class SkillTree : MonoBehaviour{
    //DELETE ME
    //DO NOT USE! MUST BE REMOVED FROM YOUR CODE
    //IF YOU USED IT PREVIOUSLY
    public void Upgrade(){}

}


public class SkillTree2{ 
   FullPlayer boost;
 
 /*
   public void Start(){
    boost = new upPlayer();
   }
*/

public SkillTree2(){
    boost = new upPlayer();
}

   //USE THESE INSTEAD  |
   //                   V
   public void updateAttack(){
    boost = new AttackUpgrade(boost);
   }

   public void updateHealth(){
    boost = new HealthUpgrade(boost);
   }

    public int getAttack(){return boost.getAttack();}
    public int getHealth(){return boost.getHealth();}

    //anwhere call
    //public int getAttackVal{return boost.getAttack();}
    //public int getHealthVal{return boost.getHealth();}
    //int getSpeedVal{}
        //boost.getAttack();
        //boost.getHealth();
        //boost.getSpeed();
}

//interface, links concrete 
public abstract class FullPlayer{
//player varibles (speed, health, damage, etc)
  //only allows for changes in subclasses
  //protected FullPlayer wrappee; 

    //incomplete class, will be finished in decorators/FullPlayer
    abstract public int getAttack();
    abstract public int getHealth();
}

//
public class upPlayer : FullPlayer{
    override public int getAttack(){return 10;}
    
    override public int getHealth(){return 10;}

}

//Upgrade class acts as concrete Decorator
public class Upgrade : FullPlayer{
    //public Upgrade(FullPlayer newwrappee){wrappee = newwrappee;}

    protected FullPlayer wrappee; 

    override public int getAttack(){return wrappee.getAttack();}

    override public int getHealth(){return wrappee.getHealth();}
}

//implementation of
public class AttackUpgrade : Upgrade{
    public AttackUpgrade(FullPlayer newwrappee){wrappee = newwrappee;}
    override public int getAttack(){return wrappee.getAttack() + 2;} 
}

public class HealthUpgrade : Upgrade{
    public HealthUpgrade(FullPlayer newwrappee){wrappee = newwrappee;}
    override public int getHealth(){return wrappee.getHealth() + 2;}
}

public class MovementUpgrade : Upgrade{
    public MovementUpgrade(FullPlayer newwrappee){wrappee = newwrappee;}
}




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
*/