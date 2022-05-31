using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LadderDetector : MonoBehaviour
{
    private Transform detectionPoint;
    private const float detectionRadius = 0.2f;
    private LayerMask detectionLayer;
    private GameObject detectedObject;
    private bool built;
    [SerializeField] private GameObject ladder;
    [SerializeField] private GameObject helper;
    [SerializeField] private GameObject detector;

	void Start()
    {
        detectionPoint = gameObject.transform;
        detectionLayer = LayerMask.GetMask("Ladder");
        helper.SetActive(false);
        ladder.SetActive(false);
        built = false;
	}

    void Update()
    {
        // Interact with tree using "e"
		if(DetectObject())
        {
            if(InteractInput())
            {
                helper.SetActive(false);
                ladder.SetActive(true);
                if (built)
                {
                    Debug.Log("NextLevel");
                    SceneManager.LoadScene(1);
                }
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
            helper.SetActive(false);
            return false;
        }
        else
        {
            detectedObject = obj.gameObject;
            if (!built)
            {
                helper.SetActive(true);
            }
            return true;
        }
    }
}