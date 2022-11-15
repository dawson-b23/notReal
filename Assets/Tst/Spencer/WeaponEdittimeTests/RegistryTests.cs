/*
 * RegistryTests.cs
 * Spencer Butler
 * Some edit-time tests for the weapon registry
 */


using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TestTools;


/*
 * class to test the weapon registry
 *
 * member functions:
 * requestZeroWeapons() - requests an array of 0 random weapons
 * requestAllWeapons() - requests as many weapons as are in the registry
 * requestExtraWeapon() - requests 1 more weapon than in the registry
 * requestTwiceAllWeapons() - requests 2x as many weapons as in the registry
 * requestFakeWeapon() - requests a weapon that is not in the registry
 * countDuplicates() - helper function to count duplicate weapons in an array
 */
public class RegistryTests
{
    /*
     * Request no weapons
     * This should return an array of length 0
     */
    [Test]
    public void requestZeroWeapons()
    {
        AbstractWeapon[] arr = WeaponRegistry.getWeaponRegistry().getWeapons(0);
        Assert.That(arr.Length == 0);
    }

    /*
     * Requests the exact number of weapons that exist in the array
     * There should be no duplicates
     */
    [Test]
    public void requestAllWeapons()
    {
        WeaponRegistry wR = WeaponRegistry.getWeaponRegistry();
        AbstractWeapon[] arr = wR.getWeapons(wR.length());
        Assert.That(countDuplicates(arr) == 0);
    }

    /*
     * Requests one more weapon than exists in the array
     * There should then be one duplicate
     */
    [Test]
    public void requestExtraWeapon()
    {
        WeaponRegistry wR = WeaponRegistry.getWeaponRegistry();
        AbstractWeapon[] arr = wR.getWeapons(wR.length() + 1);
        Assert.That(countDuplicates(arr) == 1);
    }

    /*
     * Requests twice as many weapons as exist in the registry
     * This should return every weapon two times
     * The number of duplicates should thus be equal to the number of items in the registry
     */
    [Test]
    public void requestTwiceAllWeapons()
    {
        WeaponRegistry wR = WeaponRegistry.getWeaponRegistry();
        AbstractWeapon[] arr = wR.getWeapons(wR.length() * 2);
        Assert.That(countDuplicates(arr) == wR.length());
    }

    /*
     * Requests a weapon that does not exist in registry
     * Expects a particular error message and for the return to be null
     */ 
    [Test]
    public void requestFakeWeapon()
    {
        string fakeName = "weaponThatDoesNotExist";
        LogAssert.Expect(LogType.Error, "Invalid weaponID: " + fakeName);
        AbstractWeapon weapon = WeaponRegistry.getWeaponRegistry().getSpecificWeapon(fakeName);
        Assert.That(weapon == null);
    }

    /*
     * helper function to count and return duplicates in an array
     * for an example array of {A, A} this would return 1
     * for an example array of {A, A, A} this would return 3
     * for an example array of {A, B, C} this would return 0
     */
    private int countDuplicates(AbstractWeapon[] arr)
    {
        int ret = 0;
        for(int i = 0; i < arr.Length - 1; i++) 
        {
            for(int j = i + 1; j < arr.Length; j++)
            {
                if(arr[i].getDisplayName() == arr[j].getDisplayName())
                {
                    ret++;
                }
            }
        }
        return ret;
    }

}


