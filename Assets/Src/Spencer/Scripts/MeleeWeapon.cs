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
 *
 * member functions:
 * OnTriggerEnter2D - process collisions with enemies
 * attackAnimation() - start an attack
 * cooldownAnimation() - show that the weapon is on cooldown
 * visualAttack() - logic for the actual visuals of an attack
 * visualCooldown() - logic for the actual visuals of a cooldown
 */
public class MeleeWeapon : AbstractWeapon 
{
    private ContactFilter2D contFilter;
    protected bool attacking;

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
     * Begin the visual attack sequence.
     * Additionally, check if the weapon is currently in contact with any enemies
     * If it is, call processHit to damage them, since they won't be caught by OnTriggerEnter
     */
    protected override void attackAnimation() 
    {
        // Debug.Log("Weapon attack.");
        StartCoroutine(visualAttack());

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
     * Visually display an attack.
     * Rotate the weapon 360 degrees around the player
     */
    protected virtual IEnumerator visualAttack() 
    {
        attacking = true;
        // round up to the nearest multiple of fixedDeltaTime to guarantee a full rotation
        float totalTime = Mathf.Ceil(cooldown / Time.fixedDeltaTime) * Time.fixedDeltaTime;
        for(double i = 0; i + Time.fixedDeltaTime / 2 < totalTime; i += Time.fixedDeltaTime) 
        {
            transform.localRotation *= Quaternion.AngleAxis((Time.fixedDeltaTime / totalTime) * 360, Vector3.forward);
            yield return new WaitForFixedUpdate(); 
        }
        attacking = false;
    }
    
    /*
     * Visually display the cooldown.
     * Shrink the weapon, then grow it back to regular size
     * Currently, this should never be called, since the attack length is equal to the cooldown
     */
    protected virtual IEnumerator visualCooldown() 
    {
        for(int i = 0; i < 20; i++) 
        {
            transform.localScale -= new Vector3(0.05f, 0.05f, 0f);
            yield return null;
        }

        for(int i = 0; i < 20; i++) 
        {
            transform.localScale += new Vector3(0.05f, 0.05f, 0f);
            yield return null;
        }
    }

}


