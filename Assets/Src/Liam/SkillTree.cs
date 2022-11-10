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

/*GET RID OF THIS !! ============================================/
public class SkillTree : MonoBehaviour{
    //DELETE ME
    //DO NOT USE! MUST BE REMOVED FROM YOUR CODE
    //IF YOU USED IT PREVIOUSLY
    public void Upgrade(){}

}*/


public class SkillTree{
   public static SkillTree Instance; //{get; private set;}

     public static SkillTree makeSkillTree(){
       if(Instance == null){
        Instance = new SkillTree();
       }
       return Instance;  
     }  

   FullPlayer boost;
 
 /*
   public void Start(){
    boost = new upPlayer();
   }
*/

//TEMPORARY NAME, WILL BE SKILL TREE WHEN TEMP 
//CLASS IS ERASED
private SkillTree(){
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

   public void updateMovement(){
    boost = new MovementUpgrade(boost);
   }

    //changing to multiplier, int -> float
    public float getAttack(){return boost.getAttack();}
    public float getHealth(){return boost.getHealth();}
    public float getSpeed(){return boost.getSpeed();}

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
    abstract public float getAttack();
    abstract public float getHealth();
    abstract public float getSpeed();
}

//
public class upPlayer : FullPlayer{
    //changing to multiplier, return 1
    override public float getAttack(){return 1;}
    
    override public float getHealth(){return 1;}

    override public float getSpeed(){return 1;}
}

//Upgrade class acts as concrete Decorator
public class Upgrade : FullPlayer{
    //public Upgrade(FullPlayer newwrappee){wrappee = newwrappee;}

    protected FullPlayer wrappee; 

    override public float getAttack(){return wrappee.getAttack();}

    override public float getHealth(){return wrappee.getHealth();}

    override public float getSpeed(){return wrappee.getSpeed();}
}

//implementation of
public class AttackUpgrade : Upgrade{
    public AttackUpgrade(FullPlayer newwrappee){wrappee = newwrappee;}
    override public float getAttack(){return wrappee.getAttack() + (wrappee.getAttack() * 0.15f);} 
}

public class HealthUpgrade : Upgrade{
    public HealthUpgrade(FullPlayer newwrappee){wrappee = newwrappee;}
    override public float getHealth(){return wrappee.getHealth() + (wrappee.getHealth() * 0.15f);}
}

public class MovementUpgrade : Upgrade{
    public MovementUpgrade(FullPlayer newwrappee){wrappee = newwrappee;}
    override public float getSpeed(){return wrappee.getSpeed() + (wrappee.getSpeed() * 0.15f);}
}