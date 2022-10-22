/*
 * RangedWeapon.cs
 * Spencer Butler
 * Basic logic for projectile-firing weapons
 */

using System.Collections;
using UnityEngine;


/*
 * Basic logic for projectile-firing weapons
 *
 * member variables:
 * projectilePrototype - the projectile to be copied and fired
 * launchPoint - an empty containing the location new projectiles spawn at
 *
 * member functions:
 * Start() - initialize the weapon
 * attackAnimation() - fire a projectile
 * cooldownAnimation() - display the weapon is on cooldown
 * processProjectileHit(GameObject) - wrapper for processHit
 */
public class RangedWeapon : AbstractWeapon 
{
    [SerializeField]
    private Projectile projectilePrototype;
    [SerializeField]
    private GameObject launchPoint;

    /*
     * Initialize both the weapon and the associated projectile
     */
    new private void Start() 
    {
        base.Start();
        projectilePrototype.gameObject.SetActive(false);
        projectilePrototype.setSource(this);
    }

    /*
     * Create a new projectile, move it to the launchPoint
     */
    protected override void attackAnimation() 
    {
        Projectile newProj = Instantiate(projectilePrototype);
        newProj.gameObject.SetActive(true);
        newProj.transform.position = launchPoint.transform.position;
    }

    /*
     * Display that the weapon is on cooldown
     */
    protected override void cooldownAnimation() 
    {
        //TODO make ranged attack doolcown
    }

    /*
     * Wrapper for processHit, enabling the projectile to call it when it hits an enemy
     */
    public void processProjectileHit(GameObject enemy) 
    {
        processHit(enemy);
    }

}


