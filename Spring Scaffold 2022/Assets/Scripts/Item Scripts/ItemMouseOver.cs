using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemMouseOver : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
	Color original_color; // GameObject’s original color
	Color new_color = Color.red;

	// mesh renderer to access the GameObject’s material and color
	MeshRenderer mesh_renderer;

	
	[SerializeField] private InventoryUI inventoryUI;

	private ItemRecipes item_recipes;
	private GameObject[] craft_containers; 
	
	private GameObject obj;
	private Image image;
	private Item item;
	public int container_type;
	public int inventory_position;


	void Start()
	{
		item_recipes = this.GetComponent<ItemRecipes>();
		craft_containers = inventoryUI.GetCraftContainers();

		item = this.GetComponent<Item>();
		obj = this.transform.GetChild(0).gameObject;
		image = obj.GetComponent<Image>();

		//mesh_renderer = obj.GetComponent<MeshRenderer>();
		//original_color = mesh_renderer.material.color;
	}


	// Indicates when cursor is over an item
	public void OnPointerEnter(PointerEventData eventData)
	{
		// Visually indicate hover over an item
		if (container_type != -1 || CanCraft())
			image.color = new Color(image.color.r, image.color.g, image.color.b, 1f);

		// FUTURE: add a feature to indicate that you can't craft rn

		// change the color of the GameObject to red
		//mesh_renderer.material.color = new_color;
	}


	public void OnPointerExit(PointerEventData eventData)
	{
		// Visually indicate hover off of an item
		image.color = new Color(image.color.r, image.color.g, image.color.b, 0.39f);

		// Reset the color of the GameObject back to normal
		//mesh_renderer.material.color = original_color;
	}


	// Detects if an item is clicked on
	public void OnPointerClick(PointerEventData pointerEventData)
	{
		if (pointerEventData.button == PointerEventData.InputButton.Left && container_type == -1)
		{
			//Debug.Log("CRAFT clicked!");
			CommenceCrafting();
		}
		else if (pointerEventData.button == PointerEventData.InputButton.Left && container_type == -2)
		{
			//Debug.Log("RECIPE clicked!");
			inventoryUI.OpenRecipes();
		}
		else if (pointerEventData.button == PointerEventData.InputButton.Left && item.type != Item.ItemType.Default)
		{
			//Debug.Log(item.type + " clicked!");

			if (container_type == 0 || container_type == 1 || container_type == 2) 
				MoveItemCrafting(container_type);
		}
	}


	// Starts the process of removing an item from either the inventory or the crafting menu
	// crafting == false from inventory, true from crafting menu
	private void CommenceRemoveItem(int position, bool crafting)
    {
		item.Remove(position, crafting);
		item.type = Item.ItemType.Default;
	}


	// Moves an item from the inventory to the crafting menu or vice versa
	private void MoveItemCrafting(int container_type)
	{
		if (item.Move(inventory_position - 1, container_type))
		{
			if (container_type == 0) 
				CommenceRemoveItem(inventory_position - 1, false);
			else if (container_type == 1 || container_type == 2)
				CommenceRemoveItem(inventory_position - 1, true);
		}
	}


	// Starts the process of crafting an item:
	// Step 1, checks to see if there's currently 3 items in crafting menu and no currently crafted item
	// Step 2, checks to see if those 3 items form a valid recipe
	// Step 3, removes the 3 items and crafts the recipe
	private void CommenceCrafting()
	{
		if (CanCraft())
		{
			Item.ItemType recipe_type = FindRecipe();
			//Debug.Log("FindRecipe: " + recipe_type);
			
			// If finds a valid recipe, the crafting items are used then removed from the inventory permanently
			if (recipe_type != Item.ItemType.Default)
            {
				// Remove the crafting items
				for (int i = 0; i < 3; i++) 
					craft_containers[i].GetComponent<ItemMouseOver>().CommenceRemoveItem(i, true);

				// Craft the recipe
				GameObject crafted_obj = new GameObject();
				crafted_obj.AddComponent<Item>();
				Item crafted_item = crafted_obj.GetComponent<Item>();
				crafted_item.type = recipe_type;
				crafted_item.Craft();
			}
		}
	}


	// Checks to see if the bare minimum crafting requirements are met (3 items in crafting menu, no item currently crafted)
	// Does NOT check if crafting items make a valid recipe
	private bool CanCraft()
    {
		// There must be 3 items in the crafting menu
		for (int i = 0; i < 3; i++)
        {
			if (craft_containers[i].GetComponent<Item>().type == Item.ItemType.Default)
				return false;
        }

		// There must not be an item currently crafted
		if (craft_containers[3].GetComponent<Item>().type != Item.ItemType.Default)
			return false;

		//Debug.Log("CAN craft");
		return true;
	}

	
	// Checks to see if the 3 crafting items form a valid recipe by comparing it with all of the valid recipes
	private Item.ItemType FindRecipe()
	{
		List<Item.ItemType> craft_items = new List<Item.ItemType> {	
			craft_containers[0].GetComponent<Item>().type,
			craft_containers[1].GetComponent<Item>().type,
			craft_containers[2].GetComponent<Item>().type };

		for (int i = 0; i < item_recipes.recipes.Count; i++)
        {
			if (CompareRecipes(item_recipes.recipes[i], new List<Item.ItemType>(craft_items)) )
				return item_recipes.recipes[i][3];
        }

		// FUTURE: add a feature to let player know that they are not using a valid recipe
		return Item.ItemType.Default;
	}


	// Compares the 3 crafting items with the currently selected valid recipe
	// Returns true if is an exact match (order of items does not matter)
	private bool CompareRecipes(List<Item.ItemType> recipe, List<Item.ItemType> craft_items)
    {
		for (int i = 0; i < 3; i++)
        {
			for (int j = 0; j < craft_items.Count; j++)
			{
				if (recipe[i] == craft_items[j])
				{
					craft_items.RemoveAt(j);
					break;
				}
			}
        }

		if (craft_items.Count == 0)
			return true;
		else
			return false;
    }
}
