using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory
{
	public bool inventory_opened = false;
	public bool recipes_opened = false;
	private Item[] inventory_data;
	private Item[] crafting_data;


	public PlayerInventory()
    {
		inventory_data = new Item[10];
		for (int i = 0; i < 10; i++)
		{
			inventory_data[i] = null;
		}

		//Debug.Log("inventory");

		crafting_data = new Item[4];
		for (int i = 0; i < 4; i++)
		{
			crafting_data[i] = null;
		}

		//Debug.Log("crafting");
	}

	
	// Adds an item from the ground to the inventory
	public void AddItem(GameObject obj)
	{
		Item item = obj.GetComponent<Item>();
		for (int i = 0; i < 10; i++)
        {
			if (inventory_data[i] == null)
            {
				Debug.Log("Found a spot in cell " + i);
				inventory_data[i] = item;
				break;
			}
		}
	}


	// Adds an item to the crafting menu, but ONLY if it is not full
    // (meaning there are currently less than 3 items in the crafting menu)
	// Returns true if item was successfully added and false otherwise
	public bool AddCraftingItem(int position)
	{
		for (int i = 0; i < 3; i++)
		{
			if (crafting_data[i] == null)
			{
				crafting_data[i] = inventory_data[position];
				return true;
			}
		}

		return false;
	}


	// Moves crafting item back into inventory
	public void ReturnCraftingItem(int position)
	{
		for (int i = 0; i < 10; i++)
		{
			if (inventory_data[i] == null)
			{
				inventory_data[i] = crafting_data[position];
				break;
			}
		}
	}


	// Removes an item from the inventory
	public void RemoveItem(int position)
	{
		inventory_data[position] = null;

		// temp debug statements
		/*Debug.Log("REMOVE inventory");
		for (int i = 0; i < 10; i++)
		{
			if (inventory_data[i] != null) Debug.Log("inventory:" + inventory_data[i].type);
		}

		for (int i = 0; i < 4; i++)
		{
			if (crafting_data[i] != null) Debug.Log("crafting:" + crafting_data[i].type);
		}*/
	}


	// Removes an item from the crafting menu
	public void RemoveCraftingItem(int position)
	{
		crafting_data[position] = null;
	}


	public Item[] GetItems()
    {
		return inventory_data;
    }


	public Item[] GetCraftItems()
	{
		return crafting_data;
	}


	public void CraftItem(Item item)
    {
		crafting_data[3] = item;
	}


	// Returns true if there is an item of item_type in the inventory, false otherwise
	// Does NOT account for items that are in the crafting menu
	public bool FindItem(Item.ItemType item_type)
    {
		for (int i = 0; i < 10; i++)
		{
			if (inventory_data[i] == null)
			{
				break;
			}
			if (inventory_data[i].type == item_type)
			{
				return true;
			}
		}

		return false;
	}
}
