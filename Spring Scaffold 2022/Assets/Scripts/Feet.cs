using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feet : MonoBehaviour
{
    public GameObject player;
    PlayerMovement playerMvt;
    
    void Start()
    {
        playerMvt = GetComponentInParent<PlayerMovement>();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("LeafPlatform"))
        {
            playerMvt.jump = false;
            player.transform.parent = other.gameObject.transform;
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("LeafPlatform"))
        {
            player.transform.parent = null;
        }
    }
}
