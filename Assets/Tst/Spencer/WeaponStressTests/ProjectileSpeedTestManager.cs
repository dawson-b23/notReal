using System.Collections;
using UnityEditor;
using UnityEngine;

public class ProjectileSpeedTestManager : MonoBehaviour {
   public RangedWeapon launcher;
   public Projectile launched;
   public float speed;
   public float launchInterval;
   public float speedInterval;

   private int wastebin;

   private void Start() {
      StartCoroutine(launch());
   }

   private IEnumerator launch() {
      launcher.gameObject.SetActive(true);
      launched.setSpeed(speed);
      launcher.Attack(out wastebin);
      speed += speedInterval;
      yield return new WaitForSeconds(launchInterval);
      StartCoroutine(launch());
   }

   private void OnTriggerEnter2D() {
      Debug.Log("Final speed: " + speed);
      UnityEditor.EditorApplication.isPlaying = false;
   }
}
