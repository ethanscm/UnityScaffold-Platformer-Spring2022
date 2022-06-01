using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlueWoodInteractor : MonoBehaviour
{
    private Transform detectionPoint;
    private const float detectionRadius = 0.5f;
    private LayerMask detectionLayer;
    private GameObject detectedObject;
    private bool built;

    [SerializeField] private GameObject wood;
    [SerializeField] private GameObject indicator;
    [SerializeField] private GameObject detector;
    
    void Start()
    {
        detectionPoint = gameObject.transform;
        detectionLayer = LayerMask.GetMask("GlueWood");
        indicator.SetActive(false);
        wood.SetActive(false);
        built = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(DetectObject())
        {
            if(gameObject.GetComponent<ItemInteraction>().hasItem(Item.ItemType.Glue) && InteractInput())
            {
                detector.SetActive(false);
                indicator.SetActive(false);
                wood.SetActive(true);
                built = true;
            }
        }
    }

    bool InteractInput()
    {
        return Input.GetKeyDown(KeyCode.E);
    }

    bool DetectObject()
    {
        Collider2D obj = Physics2D.OverlapCircle(detectionPoint.position, detectionRadius, detectionLayer);

		if (obj == null)
		{
            detectedObject = null;
            indicator.SetActive(false);
            return false;
        }
        else
        {
            detectedObject = obj.gameObject;
            if (!built && gameObject.GetComponent<ItemInteraction>().hasItem(Item.ItemType.Glue))
            {
                indicator.SetActive(true);
            }
            return true;
        }
    }
}
