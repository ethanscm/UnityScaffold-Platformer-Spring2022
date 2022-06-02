using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectRockThrow : MonoBehaviour
{
    [SerializeField] private GameObject indicator;
    [SerializeField] private GameObject rock;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject acorn;
    private bool playerIn;
    private bool thrown;
    private ItemInteraction inv;
    [SerializeField] private AudioManager audioManager;
    

    void Start()
    {
        playerIn = false;
        indicator.SetActive(false);
        rock.SetActive(false);
        thrown = false;
        inv = player.GetComponent<ItemInteraction>();
        acorn.SetActive(false);
    }

    void Update()
    {
        if (playerIn && !thrown)
        {
            if (Input.GetKeyDown(KeyCode.E) && inv.hasItem(Item.ItemType.Slingshot) && inv.hasItem(Item.ItemType.Rock))
            {
                rock.SetActive(true);
                thrown = true;
                StartCoroutine(delayBirdCry());
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            playerIn = true;
            if (!thrown && inv.hasItem(Item.ItemType.Slingshot) && inv.hasItem(Item.ItemType.Rock))
            {
                indicator.SetActive(true);
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            playerIn = false;
        }
        indicator.SetActive(false);
    }


    IEnumerator delayBirdCry()
    {
        yield return new WaitForSeconds(0.5f);
        audioManager.Play("BirdCry");
        audioManager.Play("WingFlap");
    }

}
