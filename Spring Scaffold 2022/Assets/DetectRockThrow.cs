using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectRockThrow : MonoBehaviour
{
    [SerializeField] private GameObject indicator;
    [SerializeField] private GameObject rock;
    private bool playerIn;
    private bool thrown;

    void Start()
    {
        playerIn = false;
        indicator.SetActive(false);
        rock.SetActive(false);
        thrown = false;
    }

    void Update()
    {
        if (playerIn && !thrown)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                rock.SetActive(true);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            playerIn = true;
        }
        indicator.SetActive(true);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            playerIn = false;
        }
        indicator.SetActive(false);
    }
}
