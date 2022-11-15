/*
 * CooldownTests.cs
 * Spencer Butler
 * Boundary tests for weapon attack cooldowns
 */

using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEditor;


/* 
 * class to test weapon attack cooldowns
 *
 * member functions:
 * attackBeforeCooldown() - attacks too fast
 * attackAfterCooldown() - attacks at a proper interval
 */
public class CooldownTests 
{

    /*
     * sends an attack signal at a shorter interval than the weapon's cooldown
     * test fails if the weapon attacks any time but the first signal
     */
    [Test]
    public void attackBeforeCooldown() 
    {
        AbstractWeapon testWeapon = WeaponRegistry.getWeaponRegistry().getSpecificWeapon("basicMelee");
        float lastAttack;
        testWeapon.attack();
        lastAttack = testWeapon.lastAttack();
        for(int i = 0; i < 5; i++) 
        {
            testWeapon.attack();
            Assert.That(lastAttack == testWeapon.lastAttack());
        }
    }

    /*
     * sends an attack signal at an interval equal to the weapon's cooldown
     * test fails if the weapon fails to attack on any of these signals
     */
    [UnityTest]
    public IEnumerator attackAfterCooldown() 
    {
        AbstractWeapon testWeapon = WeaponRegistry.getWeaponRegistry().getSpecificWeapon("basicMelee");
        float lastAttack;
        testWeapon.attack();
        lastAttack = testWeapon.lastAttack();
        for(int i = 0; i < 3; i++) 
        {
            yield return new WaitForSeconds(testWeapon.effectiveCooldown());
            testWeapon.gameObject.SetActive(true);
            testWeapon.attack();
            Assert.That(lastAttack != testWeapon.lastAttack());
            lastAttack = testWeapon.lastAttack();
        }
    }

}


