using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInteraction : MonoBehaviour
{
    private Transform detectionPoint;
    private const float detectionRadius = 0.5f;
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
                detectedObject.GetComponent<Item>().Interact();
            }
        }

		// Open/close inventory using "Tab"
		if (Input.GetKeyDown(KeyCode.Tab))
		{
			if (!inventory.inventory_opened)
			{
				inventoryUI.OpenInventory(inventory);
				inventory.inventory_opened = true;
			}
			else if(inventory.inventory_opened && inventory.recipes_opened)
            {
				inventoryUI.CloseRecipes(); 
				inventoryUI.OpenInventory(inventory);
				inventory.recipes_opened = false;
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
            return true;
        }
    }

	public void PickUpItem(GameObject item)
    {
		inventory.AddItem(item);
	}


	public void RemoveFromInventory(int position, bool crafting)
	{
		if (crafting)
			inventory.RemoveCraftingItem(position);
		else
			inventory.RemoveItem(position);
		
		inventoryUI.UpdateInventory();
	}


	public bool MoveCrafting(int position, int container_type)
	{
		if (container_type == 0)
			return inventory.AddCraftingItem(position);
		else if (container_type == 1 || container_type == 2)
			inventory.ReturnCraftingItem(position);

		return true;
	}


	public void Crafting(Item item)
    {
		inventory.CraftItem(item);
		inventoryUI.UpdateInventory();
	}
}
