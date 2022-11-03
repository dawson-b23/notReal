/*
 * RangedMulti.cs
 * Spencer Butler
 * Override for ranged weapons that fire multiple projectiles
 */

using System.Collections;
using UnityEngine;


/*
 * Ranged weapons that fire multiple projectiles
 *
 * member variables:
 * launchPoints - an array of empties containing all the locations to spawn new projectiles
 *
 * member functions:
 * attackAnimation - fire projectiles from all launch points
 */
public class RangedMulti : RangedWeapon
{
    [SerializeField]
    private GameObject[] launchPoints;

    /*
     * Create multiple new projectiles, one at each launchpoint
     */
    protected override void attackAnimation() 
    {
        foreach(GameObject launchPoint in launchPoints)
        {
            Projectile newProj = Instantiate(projectilePrototype);
            newProj.gameObject.SetActive(true);
            newProj.transform.position = launchPoint.transform.position;
            newProj.transform.localRotation = transform.localRotation;
            newProj.setBearing(new Vector3(launchPoint.transform.position.x - transform.position.x,
                                           launchPoint.transform.position.y - transform.position.y,
                                           0));
        }
    }


}


