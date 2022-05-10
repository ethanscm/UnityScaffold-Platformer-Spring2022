using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAssets : MonoBehaviour
{
    public static ItemAssets Instance { get; private set; }
	
	private void Awake()
    {
		Instance = this;
    }

	// Materials
	public Sprite stick_sprite;
	public Sprite string_sprite;
	public Sprite rock_sprite;
	public Sprite wood_sprite;
	
	// Crafted Items
	public Sprite axe_sprite;
	public Sprite slingshot_sprite;
}
