using UnityEngine;

public abstract class AbstractWeapon : MonoBehaviour {
   [SerializeField]
   private int damage;
   [SerializeField]
   private float cooldown;
   [SerializeField]
   private SkillTree upgrade;

   private float lastAttackTime;

   public float LastAttack(){return lastAttackTime;}

   private void Start() {
      lastAttackTime = Time.time;
      gameObject.SetActive(false);
   }

   public void Attack(out int expGained) {
      expGained = 0;
      if ((Time.time - lastAttackTime) > cooldown) {
         lastAttackTime = Time.time;
         AttackAnimation();
      } else {
         CooldownAnimation();
      }
   }

   protected void ProcessHit(GameObject enemy) {
      EnemyTracking enemyScript;
      if(enemy.TryGetComponent<EnemyTracking>(out enemyScript)) {
         //enemyScript.takeDamage(damage);
         Destroy(enemyScript.gameObject);
         upgrade.Upgrade();
      } else {
         Debug.Log("Unable to find enemy script in enemy hit.");
      }
   }

   protected abstract void AttackAnimation();

   protected abstract void CooldownAnimation();

}
