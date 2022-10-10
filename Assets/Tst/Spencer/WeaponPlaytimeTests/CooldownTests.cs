using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEditor;

public class CooldownTests {

   private AbstractWeapon getTestWeapon() {
      AbstractWeapon prefab = (AbstractWeapon)AssetDatabase.LoadAssetAtPath("Assets/Tst/Spencer/WeaponPlaytimeTests/TestWeapon.prefab", typeof(AbstractWeapon));
      return(GameObject.Instantiate(prefab, new Vector3(0f, 0f, 0f), Quaternion.identity));
   }

   [Test]
   public void AttackBeforeCooldown() {
      AbstractWeapon testWeapon = getTestWeapon();
      int trash;
      float lastAttack;
      testWeapon.Attack(out trash);
      lastAttack = testWeapon.LastAttack();
      for(int i = 0; i < 5; i++) {
         testWeapon.Attack(out trash);
         Assert.That(lastAttack == testWeapon.LastAttack());
      }
   }

   [UnityTest]
   public IEnumerator AttackAfterCooldown() {
      AbstractWeapon testWeapon = getTestWeapon();
      int trash;
      float lastAttack;
      testWeapon.Attack(out trash);
      lastAttack = testWeapon.LastAttack();
      for(int i = 0; i < 3; i++) {
         yield return new WaitForSeconds(0.5f);
         testWeapon.gameObject.SetActive(true);
         testWeapon.Attack(out trash);
         Assert.That(lastAttack != testWeapon.LastAttack());
         lastAttack = testWeapon.LastAttack();
      }
      //yield return null;
   }

}
