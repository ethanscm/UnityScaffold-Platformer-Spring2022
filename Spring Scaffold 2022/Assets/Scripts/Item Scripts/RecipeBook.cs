using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeBook : MonoBehaviour
{
	// the recipe book's UI, starts out inactive
	private GameObject book_ui;

	private GameObject[] pages;
	public int page_num;

	
	private void Awake()
	{
		page_num = 0;
		pages = GameObject.FindGameObjectsWithTag("RecipePage");
		UpdateRecipes();

		book_ui = this.gameObject;
		book_ui.SetActive(false);
	}

	
	public void Open()
	{
		book_ui.SetActive(true);
		GameObject.Find("Left").transform.GetChild(1).gameObject.SetActive(false);
		GameObject.Find("Right").transform.GetChild(1).gameObject.SetActive(false);
	}

	
	public void Close()
	{
		book_ui.SetActive(false);
	}

	
	public void UpdateRecipes()
	{
		for (int i = 0; i < pages.Length; i++)
        {
			if (i == page_num)
				pages[i].transform.GetChild(0).gameObject.SetActive(true);
			else
				pages[i].transform.GetChild(0).gameObject.SetActive(false);
		}
	}


	public int RecipeBookLength()
    {
		return pages.Length;
    }
}
