using System.Collections;
using UnityEngine;

public class MeleeWeapon : AbstractWeapon {
   private ContactFilter2D contFilter;

   protected override GameObject[] AttackAnimation() {
      Debug.Log("Weapon attack.");
      StartCoroutine(VisualAttack());

      Collider2D[] collidersHit = new Collider2D[16];
      GameObject[] enemiesHit = new GameObject[16];
      gameObject.GetComponentInChildren<Collider2D>().OverlapCollider(contFilter.NoFilter(), collidersHit);
      
      int i = 0;
      foreach(Collider2D col in collidersHit) {
         if(col != null && col.tag == "Enemy") {
            enemiesHit[i] = col.gameObject;
            i++;
         }
      }

      return enemiesHit;
   }

   protected override void CooldownAnimation() {
      Debug.Log("Weapon on cooldown.");
      StartCoroutine(VisualCooldown());
   }

   private IEnumerator VisualAttack() {
      for(int i = 0; i < 360; i += 5) {
         transform.rotation *= Quaternion.AngleAxis(5, Vector3.forward);
         yield return null;
      }
   }
   
   private IEnumerator VisualCooldown() {
      for(int i = 0; i < 20; i++) {
         transform.localScale -= new Vector3(0.05f, 0.05f, 0f);
         yield return null;
      }

      for(int i = 0; i < 20; i++) {
         transform.localScale += new Vector3(0.05f, 0.05f, 0f);
         yield return null;
      }
   }
}
