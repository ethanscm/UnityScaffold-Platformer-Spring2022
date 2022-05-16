using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BushInteraction : MonoBehaviour
{
    private Transform detectionPoint;
    private const float detectionRadius = 0.2f;
    private LayerMask detectionLayer;
    private GameObject detectedObject;
    [SerializeField] private GameObject bushPuzzleManager;

	void Start()
    {
        detectionPoint = gameObject.transform;
        detectionLayer = LayerMask.GetMask("Bush");
	}

	// Update is called once per frame
    void Update()
    {
        // Interact with bush on ground using "e"
		if(DetectObject())
        {
            if(InteractInput())
            {
                Debug.Log("INTERACT");
                detectedObject.GetComponent<Bush>().UnravelBush();
                bushPuzzleManager.GetComponent<BushPuzzleLogic>().UpdateBush(ref detectedObject);
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
