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


/* class to test weapon attack cooldowns
 *
 * member functions:
 * attackBeforeCooldown() - attacks too fast
 * attackAfterCooldown() - attacks at a proper interval
 * getTestWeapon() - instantiates a basic weapon
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
        AbstractWeapon testWeapon = getTestWeapon();
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
     * sends an attack signal at a longer interval than the weapon's cooldown
     * test fails if the weapon fails to attack on any of these signals
     */
    [UnityTest]
    public IEnumerator attackAfterCooldown() 
    {
        AbstractWeapon testWeapon = getTestWeapon();
        float lastAttack;
        testWeapon.attack();
        lastAttack = testWeapon.lastAttack();
        for(int i = 0; i < 3; i++) 
        {
            yield return new WaitForSeconds(0.5f);
            testWeapon.gameObject.SetActive(true);
            testWeapon.attack();
            Assert.That(lastAttack != testWeapon.lastAttack());
            lastAttack = testWeapon.lastAttack();
        }
    }

    /*
     * instantiates a TestWeapon.prefab
     * returns it as an AbstractWeapon
     */
    private AbstractWeapon getTestWeapon() 
    {
        AbstractWeapon prefab = (AbstractWeapon)AssetDatabase.LoadAssetAtPath("Assets/Tst/Spencer/WeaponPlaytimeTests/TestWeapon.prefab", typeof(AbstractWeapon));
        return(GameObject.Instantiate(prefab, new Vector3(0f, 0f, 0f), Quaternion.identity));
    }

}


