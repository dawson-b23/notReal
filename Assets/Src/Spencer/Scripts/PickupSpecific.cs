/*
 * PickupRandom.cs
 * Spencer Butler
 * Logic for a pickup that uses a specific weapon
 */

using UnityEngine;


/*
 * Logic for a pickup that sets its own weapon to a specific weapon from the registry
 *
 * member variables:
 * weaponID - the ID of the weapon to be retrieved from the registry
 *
 * member functions:
 * Awake() - gets the weapon, initialize pickup values
 */
public class PickupSpecific : WeaponPickup
{
    [SerializeField]
    private string weaponID;

    /*
     * Gets a random weapon, calls initializeDynamic
     */
    private void Awake() 
    {
        WeaponRegistry weapons = WeaponRegistry.getWeaponRegistry();
        initializeDynamic(weapons.getSpecificWeapon(weaponID));
    }

}


