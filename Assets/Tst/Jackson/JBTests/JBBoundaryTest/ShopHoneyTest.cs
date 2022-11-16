using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class ShopTestScript
{
    // A Test behaves as an ordinary method
    [Test]
    public void HoneyTestHigh()
    {
        Shop shop = new Shop();

        int playerHoney = 30;
        //will be player.honey...need reference within playerController for full capabilities

        Assert.That(playerHoney == 30);
        Debug.Log("Pass1");

        playerHoney = shop.buyWeapon(playerHoney);
        Assert.That(playerHoney == 10);
        Debug.Log("Pass2");

        playerHoney = shop.buyWeapon(playerHoney);
        Assert.That(playerHoney == 10);
        Debug.Log("Pass3");

        playerHoney = shop.buyHealth(playerHoney);
        Assert.That(playerHoney == 5);
        Debug.Log("Pass4");



    }

    [Test]
    public void HoneyTestLow()
    {
        Shop shop = new Shop();

        //PlayerController player = shop.GetPlayer();
        //needs PlayerController reference

        int playerHoney = 10;
        Assert.That(playerHoney == 10);
        Debug.Log("Pass1");

        playerHoney = shop.buyWeapon(playerHoney);
        Assert.That(playerHoney == 10);
        Debug.Log("Pass2");

        playerHoney = shop.buyHealth(playerHoney);
        Assert.That(playerHoney == 5);
        Debug.Log("Pass3");

        playerHoney = shop.buyHealth(playerHoney);
        Assert.That(playerHoney == 0);
        Debug.Log("Pass4");

        playerHoney = shop.buyHealth(playerHoney);
        Assert.That(playerHoney == 0);
        Debug.Log("Pass5");


    }
    //A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    //`yield return null;` to skip a frame.
    
    [UnityTest]
    public IEnumerator FriendlyAITestScriptWithEnumeratorPasses()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
       yield return null;
    }
    
}
