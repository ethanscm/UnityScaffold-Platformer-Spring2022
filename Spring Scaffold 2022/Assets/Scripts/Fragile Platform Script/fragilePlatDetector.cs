using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fragilePlatDetector : MonoBehaviour
{
    public bool stepped = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            
            stepped = true;
        }
    }
}
