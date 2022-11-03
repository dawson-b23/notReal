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
 * createPickup - create and return a pickup holding a provided weapon
 * initializeDynamic - initialize values for dynamically created pickups
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
            //TODO -- make this add the new weapon to the inventory, not the player directly
            PlayerController playerScript;
            if(other.gameObject.TryGetComponent<PlayerController>(out playerScript)) 
            {
                playerScript.CurrentWeapon = attachedWeapon; 
                attachedWeapon.transform.parent = other.gameObject.transform;
                attachedWeapon.transform.position = other.gameObject.transform.position; 
                attachedWeapon.gameObject.SetActive(true);
                Debug.Log("status: " + attachedWeapon.gameObject.activeSelf);
            } else 
            {
                Debug.Log("Unable to find player script.");
            }
            Destroy(gameObject);
        }
 
    }

    /*
     * Create and return a pickup from a provided weapon
     */
    public static WeaponPickup createPickup(AbstractWeapon inputWeapon)
    {
        GameObject raw = new GameObject("weaponPickup", typeof(WeaponPickup), typeof(SpriteRenderer), typeof(CircleCollider2D));
        WeaponPickup ret = raw.GetComponent<WeaponPickup>();
        ret.initializeDynamic(inputWeapon);
        return ret;
    }

    /*
     * Initialize values for a newly created pickup for a given weapon
     */
    private void initializeDynamic(AbstractWeapon inputWeapon) 
    {
        attachedWeapon = inputWeapon;
        gameObject.transform.localScale = attachedWeapon.transform.localScale;

        SpriteRenderer attachedSR = gameObject.GetComponent<SpriteRenderer>();
        CircleCollider2D attachedCC = gameObject.GetComponent<CircleCollider2D>();
        attachedSR.sprite = attachedWeapon.gameObject.GetComponentInChildren<SpriteRenderer>().sprite;
        attachedCC.isTrigger = true;

        float x = attachedSR.sprite.bounds.extents.x;
        float y = attachedSR.sprite.bounds.extents.y;
        attachedCC.radius = Mathf.Sqrt(x * x + y * y);
    }

}


