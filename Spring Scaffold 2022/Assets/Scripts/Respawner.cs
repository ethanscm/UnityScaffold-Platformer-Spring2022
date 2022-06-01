using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawner : MonoBehaviour
{
    public GameManager gameManager;
    [SerializeField] public float delay;

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("detected");
        if(collision.tag == "Player")
        {
            Debug.Log("RESPAWN");
            gameManager.GameOver(delay);
        }
    }
}
