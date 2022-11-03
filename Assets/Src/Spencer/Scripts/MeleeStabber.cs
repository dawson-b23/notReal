/*
 * MeleeStabber.cs
 * Spencer Butler
 * Animation override for certain melee weapons, making them thrust
 */

using System.Collections;
using UnityEngine;


/*
 * Overrides the animation for certain melee weapons, making them move forwards and backwards,
 * rather than rotating
 *
 * member functions:
 * visualAttack() - logic for the actual visuals of an attack
 */
public class MeleeStabber : MeleeWeapon 
{
    /*
     * Move locally left 1.5 units, then take 5 times that time to move back
     */
    protected override IEnumerator visualAttack()
    {
        attacking = true;
        float totalTime;
        totalTime = Mathf.Ceil((1.0f / 6.0f) * cooldown / Time.fixedDeltaTime) * Time.fixedDeltaTime;
        for(double i = 0; i + Time.fixedDeltaTime / 2 < totalTime; i += Time.fixedDeltaTime) {
            yield return new WaitForFixedUpdate();
            transform.localPosition += transform.right * (Time.fixedDeltaTime / totalTime) * -1.5f;
        }

        totalTime *= 5;
        for(double i = 0; i + Time.fixedDeltaTime / 2 < totalTime; i += Time.fixedDeltaTime) {
            yield return new WaitForFixedUpdate();
            transform.localPosition += transform.right * (Time.fixedDeltaTime / totalTime) * 1.5f;
        }
        attacking = false;
    }
}


