using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChopDetector : MonoBehaviour
{
    private Transform detectionPoint;
    private const float detectionRadius = 0.2f;
    private LayerMask detectionLayer;
    private GameObject detectedObject;
    private bool chopped;
    [SerializeField] private GameObject ctm;
    [SerializeField] private GameObject helper;

	void Start()
    {
        detectionPoint = gameObject.transform;
        detectionLayer = LayerMask.GetMask("Chop");
        helper.SetActive(false);
        chopped = false;
	}

    void Update()
    {
        // Interact with tree using "e"
		if(DetectObject())
        {
            if(InteractInput())
            {
                ctm.GetComponent<ChopTreeManager>().chopDownTree();
                helper.SetActive(false);
                chopped = true;
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
            helper.SetActive(false);
            return false;
        }
        else
        {
            detectedObject = obj.gameObject;
            if (!chopped)
            {
                helper.SetActive(true);
            }
            return true;
        }
    }
}
