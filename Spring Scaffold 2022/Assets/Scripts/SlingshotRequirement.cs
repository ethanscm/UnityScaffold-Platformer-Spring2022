using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlingshotRequirement : MonoBehaviour
{
    [SerializeField] private GameObject player;
    
    void Update()
    {
        if (player.GetComponent<ItemInteraction>().hasItem(Item.ItemType.Slingshot))
        {
            gameObject.SetActive(false);
        }
    }
}
