/*
 * ProjectileCluster.cs
 * Spencer Butler
 * Logic for a projectile that bursts into multiple projectiles on impact
 */

using UnityEngine;


/*
 * Projectile that bursts into multiple.
 * Currently very glitchy, needs refinement
 *
 * member variables:
 * projectilePrototype - the projectile to be created when this projectile hits something
 * minimumFragments - the minimum number of projectiles created on impact
 * maximumFragments - the maximum number of projectiles created on impact
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
        int numFragments = Random.Range(minimumFragments, maximumFragments);
        for(int i = 0; i < numFragments; i++) 
        {
            //TODO: Resolve problems with newly created projectiles being dead
            Projectile newProj = Instantiate(projectilePrototype);
            newProj.gameObject.SetActive(true);
            newProj.transform.position = transform.position;
            newProj.transform.localRotation = transform.localRotation;
            newProj.transform.localRotation *= Quaternion.AngleAxis(Random.Range(-120, 120), Vector3.forward);
            Vector3 bearingInverse = -1 * bearing;
            Vector3 newBearing = (Vector3.RotateTowards(bearingInverse, bearing, 
                                                       Random.Range(-0.75f * Mathf.PI, 0.75f * Mathf.PI),
                                                       0.0f));
            newProj.setBearing(newBearing);
            newProj.transform.position += newBearing * 0.25f;

        }
        Destroy(gameObject);
    }

}


