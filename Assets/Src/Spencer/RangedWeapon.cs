using System.Collections;
using UnityEngine;


public class RangedWeapon : AbstractWeapon {
   [SerializeField]
   private Projectile projectilePrototype;
   [SerializeField]
   private GameObject launchPoint;

   new private void Start() {
      base.Start();
      projectilePrototype.gameObject.SetActive(false);
      projectilePrototype.setSource(this);
   }

   protected override void AttackAnimation() {
      Projectile newProj = Instantiate(projectilePrototype);
      newProj.gameObject.SetActive(true);
      newProj.transform.position = launchPoint.transform.position;
   }

   protected override void CooldownAnimation() {
      //TODO make ranged attack doolcown
   }

   public void ProcessProjectileHit(GameObject enemy) {
      ProcessHit(enemy);
   }
}
