using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    private Transform detectionPoint;
    private const float detectionRadius = 0.2f;
    private LayerMask detectionLayer;
    private GameObject detectedObject;
    protected bool switchChange = false;

    void Start()
    {
        detectionPoint = gameObject.transform;
        detectionLayer = LayerMask.GetMask("Switch");
    }

    // Update is called once per frame
    void Update()
    {
        if (DetectObject() && InteractInput())
        {
            FindObjectOfType<Switch>().switchChange = true;
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
