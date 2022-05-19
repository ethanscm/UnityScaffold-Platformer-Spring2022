using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoSwitch : MonoBehaviour
{
	private void Reset()
    {
        GetComponent<Collider2D>().isTrigger = true;
        gameObject.layer = 10;
    }

    
	public void Interact()
    {
        Debug.Log("GO");
        GameObject item = gameObject;
    }


}
