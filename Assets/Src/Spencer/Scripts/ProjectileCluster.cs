/*
 * ProjectileCluster.cs
 * Spencer Butler
 * Logic for a projectile that bursts into multiple projectiles on impact
 */

using UnityEngine;


/*
 * Projectile that bursts into multiple.
 *
 * member variables:
 * projectilePrototype - the projectile to be created when this projectile hits something
 * minimumFragments - the minimum number of projectiles created on impact
 * maximumFragments - the maximum number of projectiles created on impact
 * hasCollided - keeps track of if this has hit anything yet
 *
 * member functions:
 * Awake() - initialize the projectilePrototype
 * OnCollisionEnter2D() - destroy this projectile, spawn several fragments
 */
public class ProjectileCluster : Projectile
{
    [SerializeField]
    private Projectile projectilePrototype;
    [SerializeField]
    int minimumFragments;
    [SerializeField]
    int maximumFragments;
    private bool hasCollided = false;

    /*
     * Initialize the projectile prototype by giving it the same source as the cluster
     */
    private void Awake()
    {
        projectilePrototype.gameObject.SetActive(false);
        projectilePrototype.setSource(source);
    }

    /*
     * Spawn several smaller projectiles at this projectile's point of impact
     * Send them in random directions and remove this projectile
     */
    private void OnCollisionEnter2D(Collision2D other)
    {
        // This check patches a glitch where the projectile would sometimes collide with two objects
        // in the exact same frame, and produce two sets of fragments, one set being nonfunctional
        if(hasCollided)
        {
            return;
        }
        hasCollided = true;

        int numFragments = Random.Range(minimumFragments, maximumFragments);
        for(int i = 0; i < numFragments; i++) 
        {
            Projectile newProj = Instantiate(projectilePrototype);
            newProj.gameObject.SetActive(true);
            newProj.transform.position = transform.position;
            newProj.transform.localRotation = transform.localRotation;
            newProj.transform.localRotation *= Quaternion.AngleAxis(Random.Range(-120, 120), Vector3.forward);
            Vector3 origin = -1 * bearing;
            float angle = Random.Range(-0.4f * Mathf.PI, 0.4f * Mathf.PI);
            Vector3 newBearing = new Vector3(origin.x * Mathf.Cos(angle) - origin.y * Mathf.Sin(angle),
                                             origin.x * Mathf.Sin(angle) + origin.y * Mathf.Cos(angle),
                                             0);

            newProj.setBearing(newBearing);
            newProj.transform.position += newBearing * 0.25f;

        }
        Destroy(gameObject);
    }

}


