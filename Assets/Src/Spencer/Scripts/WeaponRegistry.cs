/*
 * WeaponRegistry.cs
 * Spencer Butler
 * A datastore for weapons, supporting retrieval randomly or by id
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * A datastore for weapons
 *
 * member variables:
 * inputWeapons - workaround to allow entry of a dictionary via unity's inspector
 * weapons - the dictionary of weapons
 * singleton - static reference to the single allowed weapon registry
 *
 * member functions:
 * OnEnable() - initialize singleton
 * OnValidate() - populate weapons from inputWeapons
 * getWeaponRegistry() - return the singleton
 * getSpecificWeapon() - returns a specific weapon, requested by id
 * getWeapons() - UNIMPLEMENTED, will return the specified number of random weapons
 */
[CreateAssetMenu(fileName = "WeaponRegistry", menuName="ScriptableObject/WeaponRegistry")]
public class WeaponRegistry : ScriptableObject 
{

    // Unity doesn't support serialization of dictionaries, so this struct/array of it
    // are used, then converted into a dictionary
    [System.Serializable]
    public struct WeaponListing 
    {
        public string weaponID;
        public AbstractWeapon weapon;
    }
    [SerializeField]
    private WeaponListing[] inputWeapons;

    private Dictionary<string, AbstractWeapon> weapons = new Dictionary<string, AbstractWeapon>();
    private static WeaponRegistry singleton;

    /*
     * Sets singleton to the current instance of the class
     * If singleton is set to another instance, log an error, since only one instance is allowed
     */
    private void OnEnable() 
    {
        if(singleton == null) 
        {
            singleton = this;
        } else if(singleton != this) 
        {
            Debug.LogError("Extra WeaponRegistry -- there should be only one.");
        }
    }

    /*
     * Convert the array inputWeapons into a dictionary
     * Log any duplicate IDs as an error
     */
    private void OnValidate() 
    {
        //Debug.Log("WeaponRegistry converting entered weapon list to dictionary.");
        weapons.Clear();
        foreach(WeaponListing i in inputWeapons) 
        {
            if(weapons.ContainsKey(i.weaponID)) 
            {
                Debug.LogError("Duplicate weaponID: " + i.weaponID);
            } else 
            {
                weapons.Add(i.weaponID, i.weapon);
            }
        }
        //Debug.Log("WeaponRegistry conversion finished.");
    }

    /*
     * Static getter allowing other classes to access the singleton
     */
    public static WeaponRegistry getWeaponRegistry() 
    {
        return singleton;
    }

    /*
     * Return a specific requested weapon
     * Log an error if the requested ID is not in the registry
     */
    public AbstractWeapon getSpecificWeapon(string weaponID) 
    {
        if(weapons.ContainsKey(weaponID)) 
        {
            return(weapons[weaponID]);
        } else 
        {
            Debug.LogError("Invalid weaponID: " + weaponID);
            return null;
        }
    }

    /*
     * Unimplemented
     * Will return a specified number of random weapons from the registry
     */
    public AbstractWeapon[] getWeapons(int number) 
    {
        //TODO: implement random weapon retrieval
        return null;
    }

}


