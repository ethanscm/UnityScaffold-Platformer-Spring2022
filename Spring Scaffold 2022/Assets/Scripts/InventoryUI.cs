using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
	private PlayerInventory inventory;

	// the inventory's UI, starts out inactive, activates when Tab is pressed
	private GameObject ui;

	// an array containing all the item slots of the inventory's ui
	public GameObject[] item_containers;

	// an array containing all the crafting slots of the inventory's ui
	public GameObject[] craft_containers;
	private GameObject craft_button;
	
	private GameObject recipe_button;
	[SerializeField] private RecipeBook recipe_book;

	[SerializeField] private InventoryAudioManager audioManager;


	private void Awake()
    {
		//item_containers = GameObject.FindGameObjectsWithTag("ItemContainer");
		//craft_containers = GameObject.FindGameObjectsWithTag("CraftContainer");
		craft_button = GameObject.Find("CraftButton");
		recipe_button = GameObject.Find("Recipes");

		ui = this.gameObject;
		ui.SetActive(false);
	}


	// "Opens" the inventory by activating it
	public void OpenInventory(PlayerInventory inventory)
    {
		this.inventory = inventory;
		ui.SetActive(true);
		UpdateInventory();
    }


	// "Closes" the inventory by de-activating it
	public void CloseInventory()
	{
		ui.SetActive(false);
	}


	public void UpdateInventory()
    {
		Item[] items = inventory.GetItems();
		Item[] craft_items = inventory.GetCraftItems();
		Item ui_item;
		GameObject ui_itemcontainer_image;
		GameObject ui_itemcontainer_background;
		Image background_image;

		for (int i = 0; i < 10; i++)
		{
			ui_item = item_containers[i].GetComponent<Item>();
			ui_itemcontainer_image = item_containers[i].transform.GetChild(1).gameObject;
			ui_itemcontainer_background = item_containers[i].transform.GetChild(0).gameObject;

			Debug.Log("Item " + i + " x position: " + ui_itemcontainer_image.transform.position.x);

			if (items[i] != null)
			{
				ui_item.type = items[i].type;
				
				ui_itemcontainer_image.SetActive(true);
				ui_itemcontainer_background.SetActive(true);

				background_image = ui_itemcontainer_background.GetComponent<Image>();
				background_image.color = new Color(background_image.color.r, background_image.color.g, background_image.color.b, 0.39f);

				Image image = ui_itemcontainer_image.GetComponent<Image>();
				image.sprite = ui_item.GetSprite();
			}
			else
			{
				ui_itemcontainer_image.SetActive(false);
				ui_itemcontainer_background.SetActive(false);
			}
		}

		Image craft_button_image = craft_button.transform.GetChild(0).gameObject.GetComponent<Image>();
		craft_button_image.color = new Color(craft_button_image.color.r, craft_button_image.color.g, craft_button_image.color.b, 0.39f);
		
		Image recipe_button_image = recipe_button.transform.GetChild(0).gameObject.GetComponent<Image>();
		recipe_button_image.color = new Color(recipe_button_image.color.r, recipe_button_image.color.g, recipe_button_image.color.b, 0.39f);

		for (int i = 0; i < 4; i++)
		{
			ui_item = craft_containers[i].GetComponent<Item>();
			ui_itemcontainer_image = craft_containers[i].transform.GetChild(1).gameObject;
			ui_itemcontainer_background = craft_containers[i].transform.GetChild(0).gameObject;
			if (craft_items[i] != null)
			{
				ui_item.type = craft_items[i].type;

				ui_itemcontainer_image.SetActive(true);
				ui_itemcontainer_background.SetActive(true);

				background_image = ui_itemcontainer_background.GetComponent<Image>();
				background_image.color = new Color(background_image.color.r, background_image.color.g, background_image.color.b, 0.39f);

				Image image = ui_itemcontainer_image.GetComponent<Image>();
				image.sprite = ui_item.GetSprite();
			}
			else
			{
				ui_itemcontainer_image.SetActive(false);
				ui_itemcontainer_background.SetActive(false);
			}
		}
	}

	
	public GameObject[] GetCraftContainers()
    {
		return craft_containers;
    }


	// "Opens" the recipe book by activating it & closes the inventory
	public void OpenRecipes()
	{
		inventory.recipes_opened = true;
		CloseInventory();

		recipe_book.Open();
		audioManager.Play("OpenRecipes");
	}


	// "Closes" the recipe book by deactivating it
	public void CloseRecipes()
	{
		recipe_book.Close();
		audioManager.Play("OpenRecipes");
	}
}
