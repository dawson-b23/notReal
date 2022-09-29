using UnityEngine;

public abstract class AbstractWeapon : MonoBehaviour {
   [SerializeField]
   private int damage;
   [SerializeField]
   private float cooldown;

   private float lastAttackTime;

   public void Start() {
      lastAttackTime = Time.time;
   }

   public void Attack() {
      if((Time.time - lastAttackTime) > cooldown) {
         lastAttackTime = Time.time;
         GameObject[] enemiesHit = AttackAnimation();
         foreach(GameObject enemy in enemiesHit) {
            //TODO REPLACE ENEMY DAMAGE LOGIC WITH INTEGRATION TO ENEMY SCRIPT
            // ENEMYSCRIPTNAME enemyScript;
            // if(enemy.TryGetComponent<ENEMYSCRIPTNAME>(out enemyScript)) {
            //    enemyScript.DAMAGEFUNCTION(damage);
            // } else {
            //    Debug.Log("Unable to find enemy script in enemy hit.");
            // }
         }
      } else {
         CooldownAnimation();
      }
   }

   protected abstract GameObject[] AttackAnimation();

   protected abstract void CooldownAnimation();

}
