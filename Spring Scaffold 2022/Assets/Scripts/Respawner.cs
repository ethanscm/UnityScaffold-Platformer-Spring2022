using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawner : MonoBehaviour
{
    public GameManager gameManager;

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Player is stepping");
        if(collision.tag == "Player")
        {
            gameManager.GameOver();
        }
    }
}
