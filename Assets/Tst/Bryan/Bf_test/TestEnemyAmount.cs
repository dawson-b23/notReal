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

        Room room1 = new Room();
        room1.setEnemy(0);
        //player level of 0
        Assert.That(room1.enemyAmount == 2);

    }
    [Test]
    public void EnemyAmountAbove()
    {

        Room room1 = new Room();
        room1.setEnemy(100);
        //player level of 100
        Assert.That(room1.enemyAmount == 5);

    }
    [Test]
    public void EnemyAmountBelow()
    {

        Room room1 = new Room();
        room1.setEnemy(-1);
        //player level of -1
        Assert.That(room1.enemyAmount == 2);

    }
}
   

