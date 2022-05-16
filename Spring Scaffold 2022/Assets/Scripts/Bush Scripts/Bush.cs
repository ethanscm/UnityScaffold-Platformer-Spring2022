using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bush : MonoBehaviour
{
    private void Reset()
    {
        GetComponent<Collider2D>().isTrigger = true;
        gameObject.layer = 11;
    }

    public void RespawnBush()
    {
        gameObject.SetActive(true);
    }

    public void UnravelBush()
    {
        Debug.Log("Bush unraveled");
        //Disable the obj
        gameObject.SetActive(false);
    }
}
