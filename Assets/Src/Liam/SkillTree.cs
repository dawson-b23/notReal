/*
 * SkillTree.cs
 * Liam Mathews
 * Boosts Player stats and 
 * adds additional abilities when
 * Player acquires sufficient exp
 * 
 * 
 * ORAL EXAM NOTES ============================/
 * 
 * Introduce self, team name, Team Lead position, 
 * contributions. Use Microsoft Edge as browser,
 * Prefab Demo video format may be unsupported
 * elsewhere.
 *
 * 
 * Static/Dynamic Binding =====================/
 * 
 * Super Class: public abstract class FullPlayer{abstract public float getAttack();}
 * (FullPlayer is the static type.)
 *
 * Sub Class: public class Upgrade : FullPlayer{override public float getAttack(){return wrappee.getAttack();}}
 * (Upgrade is the dynamic type. It inherits from FullPlayer and can add/change
 * change characteristics to/from it.)
 * 
 * Virtual Function: abstract public float getAttack();
 * (Abstract delcares an incomplete function that will be completed
 * as it is implemented into a subclass, unlike virtual, which is 
 * complete in the superclass and will have its behavior altered by the
 * subclass.) 
I*
 *
 * Class Diagram   ============================/ 
 * 
 * Singleton Class Diagram
 *  -----------------------
 * |       Singleton       |
 * |-----------------------|
 * |static uniqueInstance()| <-holds Singleton instance
 * |//Other data           |
 * |-----------------------|
 * |static getInstance()   | <-can be accessed anywhere (static)
 * |//Other methods        |
 * |_______________________|
 *
 *
 * Pattern Justification ======================/
 *
 * For my primary design pattern I chose the Decorator pattern,
 * better suited for an Upgrade system than inheritance (dynamically
 * adds features to a class instance at runtime.)
 *
 *  
 * Copyright Violation ======================/
 *
 * Music track used is a musical piece licensed as an expression
 * of ideas (performance), owned by SEGA. Since we plan to "monetize" 
 * the product, I am violating copyright law.
 * 
 * Argue fair use by stating only one song is used compared to the
 * dozens of other tracks from the OST. The OST does not impact the func
 * functionality of the original game (Sonic Adventure 2). (Unlikely?) 
 * Argue that inclusion will not affect sales of original game, may even
 * encourage players of Bee Brawler: Exit the Hive to find the original game
 * containing the music track.   
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * SkillTree class
 * 
 * member variables:
 * Instance - instance of SkillTree class
 * boost - 
 * makeSkillTree() - create Singleton instance of SkillTree
 * SkillTree() - class constructor
 * updateAttack() - retrieve value from AttackUpgrade()
 * updateHealth() - retrieve value from HealthUpgrade()
 * updateMovement() - retrieve value from MovementUprade()
 * getAttack() - retrieve attack value  
 * getHealth() - retrieve health value
 * getSpeed() - retrieve speed value
 */
public class SkillTree
{
    
    public static SkillTree Instance;
    FullPlayer boost;

    /*
     * Singelton instance of SkillTree, allow only 
     * one instance to exist  
     */
    public static SkillTree makeSkillTree()
    {
        if(Instance == null)
        {
            Instance = new SkillTree();
        }
        return Instance;  
    }  

    /*
     * create new instance of upPlayer in boost   
     */
    private SkillTree()
    {
        boost = new upPlayer();
    }

    /*
     * create new instance of AttackUpgrade in boost   
     */
    public void updateAttack()
    {
        boost = new AttackUpgrade(boost);
    }

    /*
     * create new instance of HealthUpgrade in boost   
     */
    public void updateHealth()
    {
        boost = new HealthUpgrade(boost);
    }

    /*
     * create new instance of MovementUpgrade in boost  
     */
    public void updateMovement()
    {
        boost = new MovementUpgrade(boost);
    }

    /* 
     * return Attack value in boost   
     */
    public float getAttack()
    {
        return boost.getAttack();
    }

    /*
     * return Health value in boost   
     */
    public float getHealth()
    { 
        return boost.getHealth(); 
    }
    
    /*
     * return Speed value in boost  
     */
    public float getSpeed()
    {
        return boost.getSpeed();
    }

}


/*
 * FullPlayer class 
 * 
 * serves as interface of Decorator, links concrete class to 
 * concrete decorator
 *
 * member variables:
 * getAttack() - abstract method to retrieve attack value, is finished in subclass
 * getHealth() - abstract method to retrieve health value, is finished in subclass
 * getSpeed() - abstract method to retrieve speed value, is finished in subclass
 */
public abstract class FullPlayer
{
    //player varibles (speed, health, damage, etc)
    //only allows for changes in subclasses 

    //incomplete (abstract) class to retrieve Attack value, 
    //will be finished in decorators/FullPlayer
    abstract public float getAttack();
    
    //incomplete (abstract) class to retrieve Health value, 
    //will be finished in decorators/FullPlayer
    abstract public float getHealth();
    
    //incomplete (abstract) class to retrieve Speed value, 
    //will be finished in decorators/FullPlayer
    abstract public float getSpeed();    

}

/*
 * upPlayer class, inherits from FullPlayer class
 * 
 * member variables:
 * getAttack() - return 1 for attack
 * getHealth() - return 1 for health
 * getSpeed() - return 1 for speed
 */
public class upPlayer : FullPlayer
{
    /*
     * return Attack value as 1 
     */
    override public float getAttack()
    {
        return 1; 
    }
    
    /*
     * return Health value as 1  
     */
    override public float getHealth()
    {
        return 1;
    }

    /*
     * return Speed value as 1  
     */
    override public float getSpeed()
    {
        return 1; 
    }

}

/*
 * Upgrade class, inherits from FullPlayer class
 * 
 * acts as concrete Decorator 
 *
 * member variables:
 * wrappee - value we will apply to Player component
 * getAttack() - return "wrapped" attack value
 * getHealth() - return "wrapped" health value
 * getSpeed() - return "wrapped" speed value
 */
public class Upgrade : FullPlayer
{
    protected FullPlayer wrappee; 

    //return attack value in wrappee
    override public float getAttack()
    {
        return wrappee.getAttack();
    }

    //return health value in wrappee
    override public float getHealth()
    {
        return wrappee.getHealth();
    }

    return speed value in wrappee
    override public float getSpeed()
    {
        return wrappee.getSpeed();
    }

}

//Use this as second example for Oral Exam
/*
 * AttackUpgrade class, inherits from Upgrade class
 *
 * Decorator for Player's attack variable (Concrete?)
 * 
 * member variables:
 * AttackUprade() - get new wrappee from FullPlayer
 * getAttack() - change value of Attack using wrappee
 */
public class AttackUpgrade : Upgrade
{
    //assign wrappee value passed in from FullPlayer
    public AttackUpgrade(FullPlayer newwrappee)
    {
        wrappee = newwrappee; 
    }

    //return modified attack value
    override public float getAttack()
    {
        return wrappee.getAttack() + (wrappee.getAttack() * 0.15f); 
    } 

}

/*
 * HealthUprade class, inherits from Uprade
 * 
 * Decorator for Player's health variable
 *
 * member variables:
 * HealthUprade() - get new wrappee from FullPlayer 
 * getHealth() - change value of Health using wrappee
 */
public class HealthUpgrade : Upgrade
{
    //assign wrappee value passed in from FullPlayer
    public HealthUpgrade(FullPlayer newwrappee)
    {
        wrappee = newwrappee; 
    }

    //return modified Health value
    override public float getHealth()
    {
        return wrappee.getHealth() + (wrappee.getHealth() * 0.15f); 
    }

}

/*
 * Movement class, inherits from Uprade
 * 
 * Decorator for Player's speed variable
 *
 * member variables:
 * MovementUpgrade() - get new wrappee from FullPlayer 
 * getSpeed() - change value of Speed using wrappee   
 */
public class MovementUpgrade : Upgrade
{
    //assign wrappee value passed in from FullPlayer
    public MovementUpgrade(FullPlayer newwrappee)
    {
        wrappee = newwrappee;
    }

    //return modified Speed value
    override public float getSpeed()
    { 
        return wrappee.getSpeed() + (wrappee.getSpeed() * 0.15f);
    }

}

