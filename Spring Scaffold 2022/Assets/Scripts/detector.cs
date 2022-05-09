using System.Collections;
using UnityEngine;

public class detector : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "fragilePlatform")
        {
            Debug.Log("Landed on Fragile Platform.");
        }
    }
}
