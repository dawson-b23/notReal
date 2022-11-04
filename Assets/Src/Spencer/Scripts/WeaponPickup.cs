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
            Inventory.inventoryInstance.addWeapon(attachedWeapon);
            Destroy(gameObject);

            //Deprecated -- directly equipped the weapon rather than adding it to the inventory
            /*
            * PlayerController playerScript;
            * if(other.gameObject.TryGetComponent<PlayerController>(out playerScript)) 
            * {
            *     playerScript.equipWeapon(attachedWeapon);
            * } else 
            * {
            *     Debug.Log("Unable to find player script.");
            * }
            */
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
    protected void initializeDynamic(AbstractWeapon inputWeapon) 
    {
        attachedWeapon = inputWeapon;
        gameObject.transform.localScale = attachedWeapon.transform.localScale;

        SpriteRenderer attachedSR = gameObject.GetComponent<SpriteRenderer>();
        attachedSR.sprite = attachedWeapon.gameObject.GetComponentInChildren<SpriteRenderer>().sprite;
        CircleCollider2D attachedCC = gameObject.GetComponent<CircleCollider2D>();
        attachedCC.isTrigger = true;

        float x = attachedSR.sprite.bounds.extents.x;
        float y = attachedSR.sprite.bounds.extents.y;
        attachedCC.radius = Mathf.Sqrt(x * x + y * y);
    }

}


