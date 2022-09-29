using UnityEngine;

public class WeaponPickup : MonoBehaviour {
   [SerializeField]
   private AbstractWeapon attachedWeapon;

   private void OnTriggerEnter2D(Collider2D other) {
      if(collider.gameObject.tag == "Player") {
         //TODO SET PLAYER EQUIPPED WEAPON
         //PS playerScript;
         //if(collider.gameObject.TryGetComponent<PS>(out playerScript)) {
         // playerScript.equippedWeapon = attachedWeapon;
         // attachedWeapon.transform = collider.gameObject.transform;
         // attachedWeapon.gameObject.SetActive(true);
         //} else {
         // Debug.Log("Unable to find player script.");
         //}
         Destroy(gameObject);
      }
   }
}
