using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vulnerable : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("detected");
        if(other.gameObject.tag == "Rock")
        {
            Debug.Log("HitBird");
            gameObject.SetActive(false);
        }
    }
}
