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

//TEMPORARY NAME, WILL BE SKILL TREE WHEN TEMP 
//CLASS IS ERASED
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

   public void updateMovement(){
    boost = new MovementUpgrade(boost);
   }

    public int getAttack(){return boost.getAttack();}
    public int getHealth(){return boost.getHealth();}
    public int getSpeed(){return boost.getSpeed();}

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
    abstract public int getSpeed();
}

//
public class upPlayer : FullPlayer{
    override public int getAttack(){return 10;}
    
    override public int getHealth(){return 10;}

    override public int getSpeed(){return 10;}
}

//Upgrade class acts as concrete Decorator
public class Upgrade : FullPlayer{
    //public Upgrade(FullPlayer newwrappee){wrappee = newwrappee;}

    protected FullPlayer wrappee; 

    override public int getAttack(){return wrappee.getAttack();}

    override public int getHealth(){return wrappee.getHealth();}

    override public int getSpeed(){return wrappee.getSpeed();}
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
    override public int getSpeed(){return wrappee.getSpeed() + 2;}
}