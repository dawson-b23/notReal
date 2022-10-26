/*
 * SimpleParticle.cs
 * Spencer Butler
 * A basic short-lifespan particle
 */

using System.Collections;
using UnityEngine;


/*
 * Basic logic for a particle that travels randomly and vanishes
 *
 * member functions:
 * Start() - gives the particle a random initial velocity and starts the vanish timer
 * vanishTimer() - vanishes after a short, randomly-chosen period
 */
public class SimpleParticle : MonoBehaviour 
{
    /*
     * Launches the particle in a random direction and starts the vanish timer
     */
    private void Start()
    {
        Vector2 force = Random.insideUnitCircle;
        Rigidbody2D rb = gameObject.GetComponent(typeof(Rigidbody2D)) as Rigidbody2D;
        rb.AddForce(force, ForceMode2D.Impulse);
        StartCoroutine(vanishTimer());
    }

    /*
     * Waits a random duration then destroys the particle
     */
    private IEnumerator vanishTimer()
    {
        float lifeTime = 0.05f + 0.75f * Random.value;
        yield return new WaitForSeconds(lifeTime);
        if(gameObject.activeSelf) {
            Destroy(gameObject);
        }
    }

}


