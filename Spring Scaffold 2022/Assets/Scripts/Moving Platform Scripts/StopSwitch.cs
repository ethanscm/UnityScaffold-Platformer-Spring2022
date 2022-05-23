using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopSwitch : MonoBehaviour
{
    public void Interact()
    {
        Debug.Log("STOP");
        GameObject item = gameObject;
        FindObjectOfType<Switch>().switchChange = false;
    }
}
