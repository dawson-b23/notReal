/* 
 * MeleeWeapon.cs
 * Spencer Butler
 * Functionality for basic short-range weapons
 */

using System.Collections;
using UnityEngine;


/*
 * Basic melee weapon functionality
 *
 * member variables:
 * contFilter - contact filter used for detecting collisions at the start of an attack
 * attacking - boolean keeping track of whether an attack is in progress
 * attackQueued - boolean indicating whether an attack is already scheduled after the current one finishes
 * normalPosition - local position of the weapon when no animation is in progress
 * normalRotation - local rotation of the weapon when no animation is in progress
 * normalScale - global scale of the weapon when no animation is in progress
 *
 * member functions:
 * Start() - store initial values of position/rotation/scale
 * OnTriggerEnter2D() - process collisions with enemies
 * OnDisable() - resets values if the weapon is unequipped in the middle of an attack
 * attackAnimation() - start an attack
 * cooldownAnimation() - show that the weapon is on cooldown
 * attackGate() - delays the start of an attack if the last one is still in progress
 * visualAttack() - logic for the actual visuals of an attack
 * visualCooldown() - logic for the actual visuals of a cooldown, largely unused
 */
public class MeleeWeapon : AbstractWeapon 
{
    private ContactFilter2D contFilter;
    protected bool attacking;
    private bool attackQueued;

    private Vector3 normalPosition;
    private Quaternion normalRotation;
    private Vector3 normalScale;

    new private void Start()
    {
        base.Start();
        attacking = false;
        attackQueued = false;
        normalPosition = transform.localPosition;
        normalRotation = transform.localRotation;
        normalScale = transform.lossyScale;
    }

    /* 
     * If the weapon is currently attacking, check if the other object is an enemy
     * If it is, call processHit with the enemy to damage it
     */
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(attacking) 
        {
            if(other.gameObject.tag == "Enemy") 
            {
                processHit(other.gameObject);
            }
        }
    }

    /*
     * Reset values, in case the player unequips a weapon in the middle of an attack
     */
    private void OnDisable()
    {
        if(attacking)
        {
            attacking = false;
            attackQueued = false;
            transform.localPosition = normalPosition;
            transform.localRotation = normalRotation;
            transform.localScale = new Vector3(normalScale.x / transform.parent.lossyScale.x,
                                               normalScale.y / transform.parent.lossyScale.y,
                                               normalScale.z / transform.parent.lossyScale.z);

        }
    }

    /*
     * Begin the visual attack sequence.
     * Additionally, check if the weapon is currently in contact with any enemies
     * If it is, call processHit to damage them, since they won't be caught by OnTriggerEnter
     */
    protected override void attackAnimation() 
    {
        // Debug.Log("Weapon attack.");
        StartCoroutine(attackGate());

        Collider2D[] collidersHit = new Collider2D[16];
        gameObject.GetComponentInChildren<Collider2D>().OverlapCollider(contFilter.NoFilter(), collidersHit);
        
        foreach(Collider2D col in collidersHit) 
        {
            if(col != null && col.tag == "Enemy") 
            {
                processHit(col.gameObject);
            }
        }
    }

    /*
     * Begin the visual cooldown sequence
     */
    protected override void cooldownAnimation() 
    {
        if(!attacking)
        {
            // Debug.Log("Weapon on cooldown.");
            StartCoroutine(visualCooldown());
        }
    }

    /*
     * Wait to begin an attack if the weapon is currently attacking
     */
    private IEnumerator attackGate()
    {
        // Verify that another attack isn't still in progress
        // The rounding-up to multiples of fixedDeltaTime can cause an attack to be called while the
        // last one is still in progress, which causes animation glitchiness
        if(attackQueued)
        {
            // immediately end the coroutine if another attack is waiting to begin
            // prevent attacks from infinitely queueing up if the user holds the mouse down
            yield break;
        }
        attackQueued = true;
        while(attacking)
        {
            yield return new WaitForFixedUpdate();
        }
        attackQueued = false;
        attacking = true;
        StartCoroutine(visualAttack());
    }

    /*
     * Visually display an attack.
     * Rotate the weapon 360 degrees around the player
     */
    protected virtual IEnumerator visualAttack() 
    {
        // round up to the nearest multiple of fixedDeltaTime to guarantee a full rotation
        float totalTime = Mathf.Ceil(effectiveCooldown() / Time.fixedDeltaTime) * Time.fixedDeltaTime;
        for(double i = 0; i + Time.fixedDeltaTime / 2 < totalTime; i += Time.fixedDeltaTime) 
        {
            transform.localRotation *= Quaternion.AngleAxis((Time.fixedDeltaTime / totalTime) * 360, Vector3.forward);
            yield return new WaitForFixedUpdate(); 
        }
        attacking = false;
    }
    
    /*
     * Visually display the cooldown.
     * Currently, this does nothing, since attack animations are scaled to match the length of the cooldown period
     */
    protected virtual IEnumerator visualCooldown() 
    {
        //Debug.Log("Displaying melee cooldown.....");
        yield return null;
        //for(int i = 0; i < 20; i++) 
        //{
        //    transform.localScale -= new Vector3(0.05f, 0.05f, 0f);
        //    yield return null;
        //}

        //for(int i = 0; i < 20; i++) 
        //{
        //    transform.localScale += new Vector3(0.05f, 0.05f, 0f);
        //    yield return null;
        //}
    }

}


