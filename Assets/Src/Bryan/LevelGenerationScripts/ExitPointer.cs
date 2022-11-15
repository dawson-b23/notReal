/*
* ExitPointer.cs
  Bryan Frahm
  Allows a pointer to point to object "ExitDoor" 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitPointer : MonoBehaviour
{
public GameObject exit;

private Vector2 exitPosition;

    private void Update()
    {
      exit = GameObject.Find("ExitDoor");
//added if else statment to catch the null reference error that kept appearing. 
      if(exit){
        exitPosition = new Vector2(exit.transform.position.x, exit.transform.position.y);
        var dir = exit.transform.position - transform.position;

        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
      }else{
        //do nothing
      }
    }
}