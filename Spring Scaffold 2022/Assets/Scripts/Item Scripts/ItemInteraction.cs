using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInteraction : MonoBehaviour
{
    private Transform detectionPoint;
    private const float detectionRadius = 0.2f;
    private LayerMask detectionLayer;
    private GameObject detectedObject;

	[SerializeField] private InventoryUI inventoryUI;
	private PlayerInventory inventory;


	void Start()
    {
        detectionPoint = gameObject.transform;
        detectionLayer = LayerMask.GetMask("Item");
		
		inventory = new PlayerInventory();
	}

    
	// Update is called once per frame
    void Update()
    {
        // Interact with item on ground using "e"
		if(DetectObject() && !inventory.inventory_opened)
        {
            if(InteractInput())
            {
                Debug.Log("INTERACT");
                detectedObject.GetComponent<Item>().Interact();
            }
        }

		// Open/close inventory using "Tab"
		if (Input.GetKeyDown(KeyCode.Tab))
		{
			if (!inventory.inventory_opened)
			{
				inventoryUI.SetInventory(inventory);
				inventory.inventory_opened = true;
			}
			else
            {
				inventoryUI.CloseInventory();
				inventory.inventory_opened = false;
			}
		}
	}

    bool InteractInput()
    {
        return Input.GetKeyDown(KeyCode.E);
    }

    bool DetectObject()
    {
        Collider2D obj = Physics2D.OverlapCircle(detectionPoint.position, detectionRadius, detectionLayer);

		if (obj == null)
		{
            detectedObject = null;
            return false;
        }
        else
        {
            detectedObject = obj.gameObject;
            Debug.Log("TRUE");
            return true;
        }
    }

	public void PickUpItem(GameObject item)
    {
		inventory.AddItem(item);
	}
}
