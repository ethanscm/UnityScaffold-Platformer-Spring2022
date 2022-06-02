using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingSpike : MonoBehaviour
{
    Rigidbody2D rb;
    public GameManager gameManager;
    [SerializeField] public float delay;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnTriggerEnter2D (Collider2D col)
    {
        if (col.gameObject.name.Equals ("Player"))
        {
            rb.isKinematic = false;
        }
        if (col.gameObject.name.Equals ("SpikeDestroy"))
        {
            StartCoroutine(waitToDestroy());
        }
    }
    
    void OnCollisionEnter2D (Collision2D col)
    {
        if (col.gameObject.name.Equals ("Player"))
        {
            Debug.Log("RESPAWN!");
            gameManager.GameOver(delay);
        }
    }

    IEnumerator waitToDestroy()
    {
        yield return new WaitForSeconds(2f);
        gameObject.SetActive(false);
    }
}
