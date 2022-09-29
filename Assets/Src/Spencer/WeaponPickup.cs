using UnityEngine;

public class WeaponPickup : MonoBehaviour {
   [SerializeField]
   private AbstractWeapon attachedWeapon;

   private void OnTriggerEnter2D(Collider2D other) {
      if(other.gameObject.tag == "Player") {
         PlayerController playerScript;
         if(other.gameObject.TryGetComponent<PlayerController>(out playerScript)) {
            //TODO REPLACE SETTER WITH PROPER NAME
            playerScript.GiveWeapon(attachedWeapon); 
            attachedWeapon.transform.parent = other.gameObject.transform;
            attachedWeapon.transform.position = other.gameObject.transform.position; 
            attachedWeapon.gameObject.SetActive(true);
         } else {
            Debug.Log("Unable to find player script.");
         }
         Destroy(gameObject);
      }
   }
}
