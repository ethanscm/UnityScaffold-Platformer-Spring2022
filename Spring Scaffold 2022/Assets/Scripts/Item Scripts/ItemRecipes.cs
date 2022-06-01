using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRecipes : MonoBehaviour
{
	public List<List<Item.ItemType>> recipes = new List<List<Item.ItemType>> { };

	List<Item.ItemType> axe_recipe = new List<Item.ItemType> { Item.ItemType.Stick, Item.ItemType.String, Item.ItemType.Rock, Item.ItemType.Axe };
	List<Item.ItemType> glue_recipe = new List<Item.ItemType> { Item.ItemType.Sap, Item.ItemType.Sap, Item.ItemType.Sap, Item.ItemType.Glue };
	List<Item.ItemType> ladder_recipe = new List<Item.ItemType> { Item.ItemType.Stick, Item.ItemType.Stick, Item.ItemType.Wood, Item.ItemType.Ladder };
	List<Item.ItemType> slingshot_recipe = new List<Item.ItemType> { Item.ItemType.Stick, Item.ItemType.Stick, Item.ItemType.String, Item.ItemType.Slingshot };

	void Start()
    {
		recipes.Add(axe_recipe);
		recipes.Add(glue_recipe);
		recipes.Add(ladder_recipe);
		recipes.Add(slingshot_recipe);
	}
}
