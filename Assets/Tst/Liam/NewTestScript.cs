/*
 * NewTestScript.cs
 * Liam Mathews
 * Boundary Tests, ensure
 * Upgrade method functions properly
 * and Player stats are changed 
 * to proper amt  
 */

using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TestTools;


/*
 * NewTestScript class
 * contains methods for ensuring decorator upgrade functions
 * behave properly, calls to each and checks that specified
 * Player stats are the correct value
 * 
 * member variables:
 * testUpgrades() - create an instance of the Skill Tree, make sure
 * targeted player stats are increased by the proper amount
 */
public class NewTestScript
{  
    /* creates an instance of the Skill Tree, initalizes variables
     * that will be used for comparison of original values and new values
     * init variables will hold values of sk.get____(); and
     * will be modified as though they are the actual variables.
     *
     * update functions are called, then get functions, 
     * check to make sure that init functions multiplied by 1.15^n is 
     * equal to get functions where n is the number of times the associated
     * update function has been called  
     */
    [Test]
    public void testUpgrades()
    {
        SkillTree sk = SkillTree.makeSkillTree(); 
        
        float initHealth = sk.getHealth();
        float initAttack = sk.getAttack();
        float initSpeed = sk.getSpeed();

        float upHealth = initHealth;
        float upAttack = initAttack;
        float upSpeed = initSpeed;

        sk.updateHealth();
        //Test fails for unknown reason, Debug Logs prove 
        //Value returned should be true.
        Debug.Log("sk.getHealth() =========" + sk.getHealth());
        Debug.Log("initHealth" + (1.15f*initHealth));

        Assert.That(sk.getHealth() == (1.15f*initHealth));
        Assert.That(sk.getAttack() == initAttack);
        Assert.That(sk.getSpeed() == initSpeed);

        sk.updateHealth();
        Assert.That(sk.getHealth() == (1.15f*1.15f*initHealth));
        Assert.That(sk.getAttack() == initAttack);
        Assert.That(sk.getSpeed() == initSpeed);

        sk.updateAttack();
        Assert.That(sk.getHealth() == (1.15f*1.15f*initHealth));
        Assert.That(sk.getAttack() == (1.15f*initAttack));
        Assert.That(sk.getSpeed() == initSpeed);

        sk.updateMovement();
        Assert.That(sk.getHealth() == (1.15f*1.15f*initHealth));
        Assert.That(sk.getAttack() == (1.15f*initAttack));
        Assert.That(sk.getSpeed() == (1.15f*initSpeed));

    }

}

