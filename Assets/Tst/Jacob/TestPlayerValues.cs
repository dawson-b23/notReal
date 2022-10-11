using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TestEnemyAmount
{
    [Test]
    public void EnemyAmount()
    {
        PlayerController testPlayer = new PlayerController();
        testPlayer.CurrentWeapon = null;
        testPlayer.PlayerSpeed = 0.0f;
        Assert.That(testPlayer.PlayerSpeed == 0.0f);
    }

    [Test]
    public void EnemyAmountAbove()
    {
        PlayerController testPlayer = new PlayerController();
        testPlayer.exp = 0;
        testPlayer.PlayerSpeed = 128.0f;
        Assert.That(testPlayer.PlayerSpeed == 128.0f);
    }

    [Test]
    public void EnemyAmountBelow()
    {
        PlayerController testPlayer = new PlayerController();
        testPlayer.CurrentWeapon = null;
        testPlayer.exp = 0;
        testPlayer.PlayerSpeed = -1.0f;
        Assert.That(testPlayer.PlayerSpeed == -1.0f);
    }
}
   

