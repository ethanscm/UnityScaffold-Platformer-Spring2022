using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
	public enum ItemType
    {
		Default,

		// Materials
		Sap,
		Stick,
		String,
		Rock,
		Wood,

		// Crafted items
		Axe,
		Glue,
		Ladder,
		Slingshot
	}

	public ItemType type;

	
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



	// Removes an item from the inventory
	public void Remove(int position, bool crafting)
	{
		if (type != ItemType.Default)
		{
			//Debug.Log("REMOVE");
			FindObjectOfType<ItemInteraction>().RemoveFromInventory(position, crafting);
		}
	}


	// Moves an item from the inventory to the crafting menu
	public bool Move(int position, int container_type)
	{
		//Debug.Log("MOVE");
		return FindObjectOfType<ItemInteraction>().MoveCrafting(position, container_type);
	}


	public void Craft()
	{
		//Debug.Log("CRAFT");
		FindObjectOfType<ItemInteraction>().Crafting(this);
	}


	public Sprite GetSprite()
    {
		switch (type)
        {
			default:
			// Materials
			case ItemType.Sap: return ItemAssets.Instance.sap_sprite;
			case ItemType.Stick: return ItemAssets.Instance.stick_sprite;
			case ItemType.String: return ItemAssets.Instance.string_sprite;
			case ItemType.Rock:	return ItemAssets.Instance.rock_sprite;
			case ItemType.Wood: return ItemAssets.Instance.wood_sprite;
			
			// Crafted Items
			case ItemType.Axe: return ItemAssets.Instance.axe_sprite;
			case ItemType.Glue: return ItemAssets.Instance.glue_sprite;
			case ItemType.Ladder: return ItemAssets.Instance.ladder_sprite;
			case ItemType.Slingshot: return ItemAssets.Instance.slingshot_sprite;
		}
    }
}
