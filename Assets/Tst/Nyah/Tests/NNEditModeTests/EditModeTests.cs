using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class EditModeTests : MonoBehaviour
{
    [Test]
    /*
     * test to see if the game was paused correctly
     */
    public void pauseTest()
    {
        // ARRANGE
        var gameObject = new GameObject();
        MenuManager menuObject = gameObject.AddComponent<MenuManager>();

        // ACT
        menuObject.pauseGame();

        // ASSERT
        Assert.That(Time.timeScale == 0f);
    }

    [Test]
    /*
     * test to see if the game was resumed after being paused
     * pause the game, check that it was paused
     * resume the game, check that it was resumed
     */
    public void resumeTest()
    {
        // ARRANGE
        var gameObject = new GameObject();
        MenuManager menuObject = gameObject.AddComponent<MenuManager>();

        // ACT
        menuObject.pauseGame();
        Assert.That(Time.timeScale == 0f);

        menuObject.resumeGame();

        // ASSERT
        Assert.That(Time.timeScale == 1f);
    }
}
