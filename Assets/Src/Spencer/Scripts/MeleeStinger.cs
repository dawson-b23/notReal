/*
 * MeleeStinger.cs
 * Spencer Butler
 * Animation override for certain melee weapons, giving a small rotation arc
 */

using System.Collections;
using UnityEngine;

/*
 * Overrides the animation for certain melee weapons, making them swing and swing back, rather than
 * swinging in a full circle
 *
 * member functions:
 * visualAttack() - logic for the actual visuals of an attack
 */
public class MeleeStinger : MeleeWeapon
{
    /*
     * Rotate 90 degrees, then take 3 times that time to rotate 90 degrees back
     */
    protected override IEnumerator visualAttack() 
    {

        float totalTime;
        totalTime = Mathf.Ceil((1.0f / 4.0f) * effectiveCooldown() / Time.fixedDeltaTime) * Time.fixedDeltaTime;
        for(double i = 0; i + Time.fixedDeltaTime / 2 < totalTime; i += Time.fixedDeltaTime) {
            yield return new WaitForFixedUpdate();
            transform.localRotation *= Quaternion.AngleAxis((Time.fixedDeltaTime / totalTime) * 90, Vector3.forward);
        }

        totalTime *= 3.0f;
        for(double i = 0; i + Time.fixedDeltaTime / 2 < totalTime; i += Time.fixedDeltaTime) {
            yield return new WaitForFixedUpdate();
            transform.localRotation *= Quaternion.AngleAxis((Time.fixedDeltaTime / totalTime) * -90, Vector3.forward);
        }
        attacking = false;
    }

}


