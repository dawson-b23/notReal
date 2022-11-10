/*
 * ProjectileExplosive.cs
 * Spencer Butler
 * Logic for a projectile that spawns an explosion on impact
 */

using UnityEngine;


/*
 * Logic for a projectile that explodes
 *
 * member variables:
 * explosionPrototype - the explosion to spawn on impact
 * hasCollided - keeps track of whether this projectile has hit anything
 *
 * member functions:
 * Awake() - initialize the explosion prototype
 * OnCollisionEnter2D() - process the projectile hitting something
 */
public class ProjectileExplosive : Projectile
{
    [SerializeField]
    private Explosion explosionPrototype;
    private bool hasCollided = false;

    /*
     * Initialize the explosion prototype by settings its source
     */
    private void Awake()
    {
        explosionPrototype.gameObject.SetActive(false);
        explosionPrototype.setSource(source);
    }
    

    /*
     * Damage any enemy hit, spawn an explosion, and destroy this projectile
     */
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            source.processProjectileHit(other.gameObject);
        }

        // prevent explosion from being duplicated when hitting two objects in the same frame
        if(hasCollided)
        {
            return;
        }
        hasCollided = true;
        
        Explosion newExplode = Instantiate(explosionPrototype);
        newExplode.gameObject.SetActive(true);
        newExplode.transform.position = transform.position;
        newExplode.transform.localRotation = transform.localRotation;
        newExplode.transform.localRotation *= Quaternion.AngleAxis(Random.Range(-120, 120), Vector3.forward);

        Destroy(gameObject);
    }
    
}


