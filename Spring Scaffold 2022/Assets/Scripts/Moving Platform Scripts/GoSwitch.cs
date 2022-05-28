using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoSwitch : MonoBehaviour
{
	public void Interact()
    {
        Debug.Log("GO");
        GameObject item = gameObject;
        foreach (Switch s in FindObjectsOfType<Switch>())
        {
            s.switchChange = true;
        }
    }
}
