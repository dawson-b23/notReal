using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFeet : MonoBehaviour
{
    [SerializeField]
    [Range(0.0f, 90.0f)]
    private float slopeValue = 45.0f;

    private PlayerController refToPlayer = null;

    private void Start()
    {
        if(!this.transform.parent.TryGetComponent<PlayerController>(out refToPlayer))
        {
            Debug.LogError("Player feet couldn't find reference to PlayerController");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag != "Player")
        {
            refToPlayer.PlayerLanded();
        }
    }
}
