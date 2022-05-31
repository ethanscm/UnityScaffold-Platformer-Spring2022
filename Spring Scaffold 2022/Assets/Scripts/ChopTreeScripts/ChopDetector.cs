using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChopDetector : MonoBehaviour
{
    private Transform detectionPoint;
    private const float detectionRadius = 0.2f;
    private LayerMask detectionLayer;
    private GameObject detectedObject;
    [SerializeField] private GameObject ctm;

	void Start()
    {
        detectionPoint = gameObject.transform;
        detectionLayer = LayerMask.GetMask("Chop");
	}

    void Update()
    {
        // Interact with tree using "e"
		if(DetectObject())
        {
            if(InteractInput())
            {
                ctm.GetComponent<ChopTreeManager>().chopDownTree();
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
            return false;
        }
        else
        {
            detectedObject = obj.gameObject;
            return true;
        }
    }
}
