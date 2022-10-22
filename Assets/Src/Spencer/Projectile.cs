/*
 * Projectile.cs
 * Spencer Butler
 * Logic for simple projectiles
 */

using UnityEngine;


/*
 * Basic projectile logic
 *
 * member variables:
 * speed - how much the projectile moves every tick, as a multiplier on bearing
 * source - the ranged weapon that fired this projectile
 * bearing - the direction the projectile moves, should be a unit vector
 *
 * member functions:
 * FixedUpdate() - moves the projectile
 * OnCollisionEnter2D() - destroys the projectile, and if it hit an enemy, damage the enemy
 * setSpeed(float) - setter for speed
 * setSpeed(RangedWeapon) - setter for source
 */
public class Projectile : MonoBehaviour 
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private RangedWeapon source;
    private Vector3 bearing = new Vector3(1.0f, 0.0f, 0.0f);
    
    /*
     * Moves the projectile
     */
    private void FixedUpdate() 
    {
        this.transform.position += speed * bearing;
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
     * setter for speed
     */
    public void setSpeed(float newSpeed) { speed = newSpeed; }

    /*
     * setter for source
     */
    public void setSource(RangedWeapon newSource) { source = newSource; }

}


