using UnityEngine;

public abstract class AbstractWeapon : MonoBehaviour {
   [SerializeField]
   private int damage;
   [SerializeField]
   private float cooldown;
   [SerializeField]
   private SkillTree upgrade;

   private float lastAttackTime;

   private void Start() {
      lastAttackTime = Time.time;
      gameObject.SetActive(false);
   }

   public void Attack() {
      if((Time.time - lastAttackTime) > cooldown) {
         lastAttackTime = Time.time;
         GameObject[] enemiesHit = AttackAnimation();
         if(enemiesHit != null) {
            foreach(GameObject enemy in enemiesHit) {
               EnemyTracking enemyScript;
               if(enemy != null) {
                  if(enemy.TryGetComponent<EnemyTracking>(out enemyScript)) {
                     //enemyScript.takeDamage(damage);
                     Destroy(enemyScript.gameObject);
                     upgrade.Upgrade();
                  } else {
                     Debug.Log("Unable to find enemy script in enemy hit.");
                  }
               }
            }
         }
      } else {
         CooldownAnimation();
      }
   }

   protected abstract GameObject[] AttackAnimation();

   protected abstract void CooldownAnimation();

}
