/*
 * WeaponPickup.cs
 * Spencer Butler
 * Basic logic for an in-world pickup to collect weapons
 */

using UnityEngine;


/*
 * Basic logic for an in-world pickup to collect weapons
 *
 * member variables:
 * attachedWeapon - the weapon to give when the player walks into this pickup
 *
 * member functions:
 * OnTriggerEnter2D - give the player the weapon when they walk into this pickup
 */
public class WeaponPickup : MonoBehaviour 
{
    [SerializeField]
    private AbstractWeapon attachedWeapon;

    /*
     * When the player moves into this pickup, give them the weapon
     * Move the weapon to the player's location and set it to visually follow them
     * Then, destroy the pickup
     */
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Player") 
        {
            PlayerController playerScript;
            if(other.gameObject.TryGetComponent<PlayerController>(out playerScript)) 
            {
                playerScript.CurrentWeapon = attachedWeapon; 
                attachedWeapon.transform.parent = other.gameObject.transform;
                attachedWeapon.transform.position = other.gameObject.transform.position; 
                attachedWeapon.gameObject.SetActive(true);
            } else 
            {
                Debug.Log("Unable to find player script.");
            }
            Destroy(gameObject);
        }
 
    }
}


