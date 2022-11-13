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
 * cooldownParticlePrototype - a particle to be spawned when the weapon is on cooldown
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
    protected Projectile projectilePrototype;
    [SerializeField]
    protected SimpleParticle cooldownParticlePrototype = null;
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
        if(cooldownParticlePrototype != null) {
            cooldownParticlePrototype.gameObject.SetActive(false);
        }
    }

    
    /*
     * Turns the weapon to face the mouse
     */
    private void FixedUpdate() 
    {
        // get the angle pointing towards the mouse from the weapon's position
        // this sets targetAngle to a value from -180 to 180 where 0 points to the right, 90 points up, etc
        Vector3 originPos = transform.position; 
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 delta = new Vector2(mousePos.x - originPos.x, mousePos.y - originPos.y);
        float targetAngle = Mathf.Acos(delta.normalized.x) * Mathf.Rad2Deg * Mathf.Sign(delta.y);


        // constrain targetAngle to a 240 degree arc centered on the current player direction
        // also flip the sprite if the player's facing left, to prevent weapons from being upside down when they shouldn't be
        float pary = transform.parent.rotation.eulerAngles.y;
        Transform child = transform.GetChild(0);
        if(pary < 1) // pary should always be 180 or 0, but equality checks with low-precision floats often fail
        {
            targetAngle = Mathf.Clamp(targetAngle, -120, 120);
            child.localScale = new Vector3(1, 1, 1);
        } else
        {
            if(-60 < targetAngle && targetAngle <= 0)
            {
                targetAngle = -60;
            }
            if(0 < targetAngle && targetAngle < 60)
            {

                targetAngle = 60;
            }
            // some sprites are rotated -90 degrees about the z axis to change from facing up to facing right
            // this flips them by the proper axis -- y if they're not rotated, x if they are
            if(child.localRotation.eulerAngles.z > 1)
            {
                child.localScale = new Vector3(-1, 1, 1);
            } else
            {
                child.localScale = new Vector3(1, -1, 1);
            }
        } 
        
        // face the desired direction
        transform.localRotation = Quaternion.Euler(0, pary, targetAngle);
    }

    /*
     * Create a new projectile, move it to the launchPoint
     */
    protected override void attackAnimation() 
    {
        Projectile newProj = Instantiate(projectilePrototype);
        newProj.gameObject.SetActive(true);
        newProj.transform.position = launchPoint.transform.position;
        newProj.transform.localRotation = transform.rotation;
        newProj.setBearing(new Vector3(launchPoint.transform.position.x - transform.position.x,
                                       launchPoint.transform.position.y - transform.position.y,
                                       0));
    }

    /*
     * Display that the weapon is on cooldown
     * Creates several small particles with random velocities and lifetimes instead of a projectile
     */
    protected override void cooldownAnimation() 
    {
        if(cooldownParticlePrototype != null) {
            int numParticles = 3 + (int) (Random.value * 6);
            for(int i = 0; i < numParticles; i++) {
                SimpleParticle newParticle = Instantiate(cooldownParticlePrototype);
                newParticle.gameObject.SetActive(true);
                newParticle.transform.position = launchPoint.transform.position;
            }
        }
    }

    /*
     * Wrapper for processHit, enabling the projectile to call it when it hits an enemy
     */
    public void processProjectileHit(GameObject enemy) 
    {
        processHit(enemy);
    }

}


