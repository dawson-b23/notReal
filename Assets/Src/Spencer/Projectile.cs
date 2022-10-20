using UnityEngine;

public class Projectile : MonoBehaviour {
   [SerializeField]
   private float speed;
   [SerializeField]
   private RangedWeapon source;
   private Vector3 bearing = new Vector3(1.0f, 0.0f, 0.0f);
   
   public void setSpeed(float newSpeed) { speed = newSpeed; }
   public void setSource(RangedWeapon newSource) { source = newSource; }

   private void FixedUpdate() {
      this.transform.position += speed * bearing;
   }

   private void OnCollisionEnter2D(Collision2D other) {
      if(other.gameObject.tag == "Enemy") {
         source.ProcessProjectileHit(other.gameObject);
      }
      Destroy(gameObject);
   }
}
