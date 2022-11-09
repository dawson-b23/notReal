/*
 * NewTestScript.cs
 * Liam Mathews
 * Boundary Tests, ensure
 * Upgrade method functions properly
 * and proper amt of exp is exchanged  
 */

using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TestTools;


/*
 * NewTestScript class
 * contains methods for ensuring that upgrade function
 * behaves properly, with a control test, a test with too much exp,
 * and a test with too little exp 
 * 
 * member variables:
 * EXPTestControl() - control test, checks exp exchange with exact amount
 * EXPTestAbove() - above test, checks exp exchange with high amount
 * EXPTestBelow() - below test, checks exp exchange with a low amount
 * NewTestScriptWithEnumeratorPasses() - for PlayMode tests, unecessary here
 
public class NewTestScript
{
    [Test]
    //assign player exact amount of exp needed
    //call upgrade function to ensure exp removed does not exceed or 
    //go under required value
    //call again to make sure player.exp does not go under zero
    public void EXPTestControl()
        {   
            SkillTree skillTree = new SkillTree(); // initialize a skill tree
            
            PlayerController player = skillTree.GetPlayer(); //initalize player from SkillTree script

            // assign player 5 exp, check for success
            player.exp = 5; 
            Assert.That(player.exp == 5);

            //call upgrade method, ensure proper amount
            //of exp was removed, try again to make sure
            //no more exp is removed
            skillTree.Upgrade();
            Assert.That(player.exp == 0);
            skillTree.Upgrade();
            Assert.That(player.exp == 0);
        }

    [Test]
    //assign player one more exp than needed
    //call upgrade function to ensure exp removed does not exceed or 
    //go under required value
    //call again to make sure player.exp is not spent, 
    //will be less than required amt but greater than zero
    public void EXPTestAbove()
        {
            SkillTree skillTree = new SkillTree();
            
            PlayerController player = skillTree.GetPlayer();
            
            player.exp = 6; 
            Assert.That(player.exp == 6);

            //keep calling Upgrade
            skillTree.Upgrade();
            Assert.That(player.exp == 1);
            skillTree.Upgrade();
            Assert.That(player.exp == 1);
        }

        [Test]
        //assign player four more exp than needed, after first call to upgrade 
        //player.exp will be below the required amount
        //call upgrade function to ensure exp removed does not exceed or 
        //go under required value
        //call again to make sure player.exp is not spent, 
        //will be less than required amt but greater than zero
        public void EXPTestBelow()
        {  
            SkillTree skillTree = new SkillTree(); 
            
            PlayerController player = skillTree.GetPlayer();

            player.exp = 9; 
            Assert.That(player.exp == 9);

            //keep calling Upgrade
            skillTree.Upgrade();
            Assert.That(player.exp == 4);
            skillTree.Upgrade();
            Assert.That(player.exp == 4);
        }   
}
*/

public class NewTestScript
{
    [Test]
    public void testUpgrades(){ 
        SkillTree2 sk = new SkillTree2();
        //Debug.Log("Health value: " + sk.getHealth());
        Assert.That(sk.getHealth() == 10);
        Assert.That(sk.getAttack() == 10);
        Assert.That(sk.getSpeed() == 10);

        sk.updateHealth();
        Assert.That(sk.getHealth() == 12);
        Assert.That(sk.getAttack() == 10);
        Assert.That(sk.getSpeed() == 10);

        sk.updateHealth();
        Assert.That(sk.getHealth() == 14);
        Assert.That(sk.getAttack() == 10);
        Assert.That(sk.getSpeed() == 10);

        sk.updateAttack();
        Assert.That(sk.getHealth() == 14);
        Assert.That(sk.getAttack() == 12);
        Assert.That(sk.getSpeed() == 10);

        sk.updateMovement();
        Assert.That(sk.getHealth() == 14);
        Assert.That(sk.getAttack() == 12);
        Assert.That(sk.getSpeed() == 12);

    }

}