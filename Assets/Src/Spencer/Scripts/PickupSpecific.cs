/*
 * PickupRandom.cs
 * Spencer Butler
 * Logic for a pickup that uses a random weapon
 */

using UnityEngine;


/*
 * Logic for a pickup that sets its own weapon to a random weapon from the registry
 *
 * member functions:
 * Awake() - get a weapon, initialize pickup values
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


