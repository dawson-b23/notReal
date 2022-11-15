/*
 * Explosion.cs
 * Spencer Butler
 * Logic for a simple projectile-triggered explosion
 */

using System.Collections;
using UnityEngine;


/*
 * Logic for a simple explosion
 *
 * member variables:
 * maxSize - the maximum value for localScale reached by the explosion
 * duration - how long it takes to reach that max size
 * source - the ranged weapon the explosion originates from
 *
 * member functions:
 * Start() - begin the explosion
 * OnTriggerEnter2D() - have the source weapon damage any enemy hit
 * explode() - visually perform the explosion
 * setSource() - setter for source 
 */
public class Explosion : MonoBehaviour
{
    [SerializeField]
    private float maxSize;
    [SerializeField]
    private float duration;
    [SerializeField]
    private RangedWeapon source;

    /*
     * Start the explosion
     */
    private void Start()
    {
        StartCoroutine(explode());
    }

    /*
     * If contact is made with an enemy, ask the source weapon to damage it
     */
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            source.processProjectileHit(other.gameObject);
        }
    }

    // Setter for source
    public void setSource(RangedWeapon newSource) { source = newSource; }

    /*
     * Grow from nothing to the maxSize
     * Then quickly fade out
     */
    private IEnumerator explode()
    {
        transform.localScale = Vector3.zero;
        float growthStep;
        for(double i = 0; i + Time.fixedDeltaTime / 2 < duration; i+= Time.fixedDeltaTime)
        {
            growthStep = (Time.fixedDeltaTime / duration) * maxSize;
            transform.localScale += new Vector3(growthStep, growthStep, growthStep);
            yield return new WaitForFixedUpdate();
        }
        
        SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer>();
        for(double i = 0; i + Time.fixedDeltaTime < duration; i += Time.fixedDeltaTime * 2.0)
        {
            sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, sr.color.a - (2 * Time.fixedDeltaTime) / duration);
            yield return new WaitForFixedUpdate();
        }

        Destroy(gameObject);
    }



}


