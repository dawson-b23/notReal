/*
* ShopPointer.cs
  Bryan Frahm
  Allows a pointer to point to object "Shop 1" 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopPointer : MonoBehaviour
{
public GameObject shop;

private Vector2 shopPosition;

    private void Update()
    {
      shop = GameObject.Find("ShopKeeper");
      
      //added if else statment to catch the null reference error that kept appearing. 
      if(shop){
        
        shopPosition = new Vector2(shop.transform.position.x, shop.transform.position.y);
        var dir = shop.transform.position - transform.position;

        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
      
      }else{
      
       //do nothing
      
      }
    }
}