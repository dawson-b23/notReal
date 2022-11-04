/*
 * WeaponRegistry.cs
 * Spencer Butler
 * A datastore for weapons, supporting retrieval randomly or by id
 */

using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
 * count() - returns the length of the registry
 * getWeaponRegistry() - return the singleton
 * getSpecificWeapon() - returns a specific weapon, requested by id
 * getWeapon() - returns a single random weapon
 * getWeapons() - returns the specified number of random weapons
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
            Debug.Log("Loading WeaponRegistry");
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
        //Debug.Log("returning reg singleton");
        return singleton;
    }
    
    /*
     * Returns the number of weapons in the registry
     */
    public int length() {
        return weapons.Count;
    }

    /*
     * Return a specific requested weapon
     * Log an error if the requested ID is not in the registry
     */
    public AbstractWeapon getSpecificWeapon(string weaponID) 
    {
        if(weapons.ContainsKey(weaponID)) 
        {
            return(Instantiate(weapons[weaponID]));
        } else 
        {
            Debug.LogError("Invalid weaponID: " + weaponID);
            return null;
        }
    }

    /*
     * Returns a single random weapon from the registry
     */
    public AbstractWeapon getWeapon() 
    {
        return Instantiate(weapons.ElementAt(Random.Range(0, weapons.Count)).Value);
    }

    /*
     * Returns a specified number of random weapons from the registry
     * To avoid unnecessary duplicates, it first creates a list of all the possible numerical indices of weapons
     * It randomly samples from that list, removing the indices it chooses
     * If more weapons were requested than the total number contained, the list is repopulated
     */
    public AbstractWeapon[] getWeapons(int numberDesired) 
    {
        AbstractWeapon[] returnedWeapons = new AbstractWeapon[numberDesired];
        List<int> possibleIndices = new List<int>(weapons.Count);
        int currentRandom;
        for(int i = 0; i < numberDesired; i++) {
            if(possibleIndices.Count == 0) {
                for(int j = 0; j < weapons.Count; j++) {
                    possibleIndices.Add(j);
                }
            }
            currentRandom = Random.Range(0, possibleIndices.Count);
            returnedWeapons[i] = Instantiate(weapons.ElementAt(possibleIndices[currentRandom]).Value);
            possibleIndices.RemoveAt(currentRandom);
        }
        return returnedWeapons;
    }

}


