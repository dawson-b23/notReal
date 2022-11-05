using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitPointer : MonoBehaviour
{

private Vector2 exitPosition;
//public Transform Target;
public GameObject exit;
/*
 private void Awake(){
    exit = GameObject.Find("ExitDoor");
    exitPosition = new Vector2(exit.transform.position.x, exit.transform.position.y);
   
 }
 */
    private void Update(){
        exit = GameObject.Find("ExitDoor");
    exitPosition = new Vector2(exit.transform.position.x, exit.transform.position.y);
      var dir = exit.transform.position - transform.position;

      var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
      transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
