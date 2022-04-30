using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    private void Reset()
    {
        GetComponent<Collider2D>().isTrigger = true;
        gameObject.layer = 10;
    }


    public void Interact()
    {
        Debug.Log("PICK UP");
        GameObject item = gameObject;
        FindObjectOfType<ItemInteraction>().PickUpItem(item);
        //Disable the obj
        gameObject.SetActive(false);
    }
}
