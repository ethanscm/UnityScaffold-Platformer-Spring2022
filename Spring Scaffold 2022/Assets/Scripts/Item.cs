using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Item : MonoBehaviour
{
    public enum InteractionType {NONE, PickUp}
    private InteractionType type;

    private void Reset()
    {
        GetComponent<Collider2D>().isTrigger = true;
        gameObject.layer = 10;
    }


    public void Interact()
    {
        switch(type)
        {
            case InteractionType.PickUp:
                //Add the obj to pickedItems list and destroys it
                Debug.Log("PICK UP");
                GameObject item = gameObject;
                FindObjectOfType<ItemInteraction>().PickUpItem(item);
                //Delete the obj
                Destroy(gameObject);
                break;
        }
    }
}
