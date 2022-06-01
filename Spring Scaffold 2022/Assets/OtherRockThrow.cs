using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherRockThrow : MonoBehaviour
{
    private Transform detectionPoint;
    private const float detectionRadius = 0.5f;
    private LayerMask detectionLayer;
    private GameObject detectedObject;
    private bool thrown;
    
    [SerializeField] private GameObject rock;
    [SerializeField] private GameObject indicator;
    [SerializeField] private GameObject detector;

    private ItemInteraction inv;

    void Start()
    {
        detectionPoint = gameObject.transform;
        detectionLayer = LayerMask.GetMask("RockThrow");
        indicator.SetActive(false);
        rock.SetActive(false);
        thrown = false;
    }

    void Update()
    {
        if(DetectObject())
        {
            if(!thrown && InteractInput())
            {
                indicator.SetActive(false);
                rock.SetActive(true);
                rock.transform.position = gameObject.transform.position;
                thrown = true;
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
            if (!thrown)
            {
                indicator.SetActive(true);
            }
            return true;
        }
    }
}
