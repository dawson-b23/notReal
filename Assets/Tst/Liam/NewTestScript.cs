using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class NewTestScript
{
    // A Test behaves as an ordinary method
    [Test]
    public void NewTestScriptSimplePasses()
    {
        // Use the Assert class to test conditions
    }


    [Test]
    public void EXPTestControl()
        {
            
            SkillTree skillTree = new SkillTree();
            //PlayerController player = new PlayerController(); 
            
            PlayerController player = skillTree.GetPlayer();
            //exp = 100;
            player.exp = 5; 
            Assert.That(player.exp == 5);

            //keep calling Upgrade
            skillTree.Upgrade();
            Assert.That(player.exp == 0);
            skillTree.Upgrade();
            Assert.That(player.exp == 0);
        }

    [Test]
    public void EXPTestAbove()
        {
            
            SkillTree skillTree = new SkillTree();
            //PlayerController player = new PlayerController(); 
            
            PlayerController player = skillTree.GetPlayer();
            //exp = 100;
            player.exp = 6; 
            Assert.That(player.exp == 6);

            //keep calling Upgrade
            skillTree.Upgrade();
            Assert.That(player.exp == 1);
            skillTree.Upgrade();
            Assert.That(player.exp == 1);
        }

        [Test]
        public void EXPTestBelow()
        {
            
            SkillTree skillTree = new SkillTree();
            //PlayerController player = new PlayerController(); 
            
            PlayerController player = skillTree.GetPlayer();
            //exp = 100;
            player.exp = 9; 
            Assert.That(player.exp == 9);

            //keep calling Upgrade
            skillTree.Upgrade();
            Assert.That(player.exp == 4);
            skillTree.Upgrade();
            Assert.That(player.exp == 4);
        }

   

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator NewTestScriptWithEnumeratorPasses()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
    }
}
