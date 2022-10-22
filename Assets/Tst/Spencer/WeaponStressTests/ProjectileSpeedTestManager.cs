/* 
 * ProjectileSpeedTestManager.cs
 * Spencer Butler
 * Stress test to determine maximum useable projectile speed
 */

using System.Collections;
using UnityEditor;
using UnityEngine;


/*
 * Runs a stress test to determine the maximum useable projectile speed
 *
 * member variables:
 * launcher - the weapon firing the projectile
 * launched - the projectile being fired
 * speed - the current speed of the projectile
 * launchInterval - the time in seconds between firing projectiles
 * speedInterval - the amount to increase the speed of each projectile by
 *
 * member functions:
 * Start() - begin the test by firing the first projectile
 * OnTriggerEnter2D() - end the test when a projectile enters the out-of-bounds area
 * launch() - fire a projectile and call launch to fire the next projectile
 */
public class ProjectileSpeedTestManager : MonoBehaviour 
{
    public RangedWeapon launcher;
    public Projectile launched;
    public float speed;
    public float launchInterval;
    public float speedInterval;

    private int wastebin;

    /*
     * calls launch to fire the first projectile
     */
    private void Start() 
    {
        StartCoroutine(launch());
    }
    
    /* 
     * when a projectile enters the out-of-bounds area, the function is called
     * it prints the final speed reached and ends the test
     */
    private void OnTriggerEnter2D() 
    {
        Debug.Log("Final speed: " + speed);
        UnityEditor.EditorApplication.isPlaying = false;
    }

    /*
     * handle the firing of a single projectile
     * calls itself to fire the next projectile
     */
    private IEnumerator launch() 
    {
        launcher.gameObject.SetActive(true);
        launched.setSpeed(speed);
        launcher.Attack(out wastebin);
        speed += speedInterval;
        yield return new WaitForSeconds(launchInterval);
        StartCoroutine(launch());
    }

}


