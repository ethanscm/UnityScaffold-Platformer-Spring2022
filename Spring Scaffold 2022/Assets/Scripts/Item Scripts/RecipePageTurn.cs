using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class RecipePageTurn : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
	public int arrow_type;

	private GameObject obj_active;

	[SerializeField] private RecipeBook recipe_book;
	[SerializeField] private InventoryAudioManager audioManager;


	void Start()
	{
		obj_active = this.transform.GetChild(1).gameObject;
	}


	// Indicates when cursor is over an arrow
	public void OnPointerEnter(PointerEventData eventData)
	{
		// Visually indicate hover over an item
		obj_active.SetActive(true);
	}


	public void OnPointerExit(PointerEventData eventData)
	{
		// Visually indicate hover off of an arrow
		obj_active.SetActive(false);
	}


	// Detects if an arrow is clicked on
	public void OnPointerClick(PointerEventData pointerEventData)
	{
		if (pointerEventData.button == PointerEventData.InputButton.Left)
		{
			//Debug.Log(arrow_type + "ARROW clicked!");
			TurnPage();
			audioManager.Play("TurnPage");
		}
	}


	private void TurnPage()
	{
		// Turns the page left or right
		recipe_book.page_num += arrow_type;

		// If going left on the first page or right on the last page, loop the recipe book
		if (recipe_book.page_num < 0)
			recipe_book.page_num = recipe_book.RecipeBookLength() - 1;
		else if (recipe_book.page_num >= recipe_book.RecipeBookLength())
			recipe_book.page_num = 0;

		recipe_book.UpdateRecipes();
	}
}
