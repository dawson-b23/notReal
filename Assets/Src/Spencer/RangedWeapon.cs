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
 * FixedUpdate() - turns the weapon to face the mouse
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
     * Turns the weapon to face the mouse
     */
    private void FixedUpdate() 
    {
        Vector3 originPos = Camera.main.WorldToViewportPoint(transform.position);
        Vector3 mousePos = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        Vector2 delta = new Vector2(mousePos.x - originPos.x, mousePos.y - originPos.y);

        float targetAngle = Mathf.Acos(delta.normalized.x) * Mathf.Rad2Deg * Mathf.Sign(delta.y);
        transform.localRotation = Quaternion.Euler(0, 0, targetAngle);
    }

    /*
     * Create a new projectile, move it to the launchPoint
     */
    protected override void attackAnimation() 
    {
        Projectile newProj = Instantiate(projectilePrototype);
        newProj.gameObject.SetActive(true);
        newProj.transform.position = launchPoint.transform.position;
        newProj.transform.localRotation = transform.localRotation;
        newProj.setBearing(new Vector3(launchPoint.transform.position.x - transform.position.x,
                                       launchPoint.transform.position.y - transform.position.y,
                                       0));
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


