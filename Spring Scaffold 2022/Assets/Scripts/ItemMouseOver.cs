using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemMouseOver : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
	Color original_color; // GameObject’s original color
	Color new_color = Color.red;

	// mesh renderer to access the GameObject’s material and color
	MeshRenderer mesh_renderer;

	private GameObject obj;
	private Image image;

	void Start()
	{
		obj = this.transform.GetChild(0).gameObject;
		image = obj.GetComponent<Image>();

		//mesh_renderer = obj.GetComponent<MeshRenderer>();
		//original_color = mesh_renderer.material.color;
	}


	public void OnPointerEnter(PointerEventData eventData)
	{
		image.color = new Color(image.color.r, image.color.g, image.color.b, 1f);

		// change the color of the GameObject to red
		//mesh_renderer.material.color = new_color;
	}


	public void OnPointerExit(PointerEventData eventData)
	{
		//image = obj.GetComponent<Image>();
		image.color = new Color(image.color.r, image.color.g, image.color.b, 0.39f);

		// Reset the color of the GameObject back to normal
		//mesh_renderer.material.color = original_color;
	}
}
