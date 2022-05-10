using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
	private PlayerInventory inventory;

	private GameObject ui;
	private GameObject[] item_containers;
	private GameObject[] craft_containers;
	private GameObject craft_button;


	private void Awake()
    {
		ui = this.gameObject;
		item_containers = GameObject.FindGameObjectsWithTag("ItemContainer");
		craft_containers = GameObject.FindGameObjectsWithTag("CraftContainer");
		craft_button = GameObject.Find("CraftButton");
		ui.SetActive(false);
	}

	
	public void SetInventory(PlayerInventory inventory)
    {
		this.inventory = inventory;
		ui.SetActive(true);
		UpdateInventory();
    }


	public void CloseInventory()
	{
		ui.SetActive(false);
	}


	public void UpdateInventory()
    {
		Item[] items = inventory.GetItems();
		GameObject obj;
		GameObject obj2;

		for (int i = 0; i < 10; i++)
		{
			obj = item_containers[i].transform.GetChild(1).gameObject;
			obj2 = item_containers[i].transform.GetChild(0).gameObject;
			if (items[i] != null)
			{
				obj.SetActive(true);
				obj2.SetActive(true);

				Image image = obj.GetComponent<Image>();
				image.sprite = items[i].GetSprite();
			}
			else
			{
				obj.SetActive(false);
				obj2.SetActive(false);
			}
		}
	}


	/*// Update is called once per frame
	void Update()
    {
		void OnMouseOver()
		{
			//If your mouse hovers over the GameObject with the script attached, output this message
			Debug.Log("Mouse is over GameObject.");
		}

		void OnMouseExit()
		{
			//The mouse is no longer hovering over the GameObject so output this message each frame
			Debug.Log("Mouse is no longer on GameObject.");
		}
	}*/
}
