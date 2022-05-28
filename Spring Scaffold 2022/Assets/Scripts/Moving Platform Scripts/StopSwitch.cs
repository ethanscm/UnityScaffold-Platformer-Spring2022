using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopSwitch : MonoBehaviour
{
    public void Interact()
    {
        Debug.Log("STOP");
        GameObject item = gameObject;
        foreach (Switch s in FindObjectsOfType<Switch>())
        {
            s.switchChange = false;
        }
    }
}
