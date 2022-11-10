/*
 * Projectile.cs
 * Spencer Butler
 * Logic for simple projectiles
 */

using System.Collections;
using UnityEngine;


/*
 * Basic projectile logic
 *
 * member variables:
 * lifetime - how long can the projectile exist without hitting something
 * speed - how much the projectile moves every tick, as a multiplier on bearing
 * source - the ranged weapon that fired this projectile
 * bearing - the direction the projectile moves, should be a unit vector
 * startTime - the time the projectile is fired
 *
 * member functions:
 * Sart() - start the automatic despawn timer
 * FixedUpdate() - moves the projectile
 * OnCollisionEnter2D() - destroys the projectile, and if it hit an enemy, damage the enemy
 * timeout() - destroys the projectile after its lifetime is over
 * setSpeed(float) - setter for speed
 * setSpeed(RangedWeapon) - setter for source
 * setBearing(Vector3) - setter for bearing
 */
public class Projectile : MonoBehaviour 
{
    private float lifetime = 10;
    [SerializeField]
    private float speed;
    [SerializeField]
    protected RangedWeapon source;
    protected Vector3 bearing;

    private float startTime;
    
    /*
     * Moves the projectile
     */
    private void FixedUpdate() 
    {
        this.transform.position += speed * bearing;
    }

    /*
     * Starts the death timer
     */
    private void Start()
    {
        StartCoroutine(timeout());
    }

    /*
     * Checks if the other object is an enemy
     * If so, have the source weapon process the hit
     * Destroy the projectile
     */
    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.tag == "Enemy") 
        {
            source.processProjectileHit(other.gameObject);
        }
        Destroy(gameObject);
    }

    /*
     * Destroy the projectile if it lives too long without hitting anything
     */
    private IEnumerator timeout() 
    {
        startTime = Time.fixedTime;
        while(Time.fixedTime < startTime + lifetime)
        {
            yield return new WaitForFixedUpdate();
        }
        Destroy(gameObject);
    }

    /*
     * setter for speed
     */
    public void setSpeed(float newSpeed) { speed = newSpeed; }

    /*
     * setter for source
     */
    public void setSource(RangedWeapon newSource) { source = newSource; }

    /*
     * setter for bearing
     */
    public void setBearing(Vector3 newBearing) {
        bearing = newBearing.normalized;
    }

}


