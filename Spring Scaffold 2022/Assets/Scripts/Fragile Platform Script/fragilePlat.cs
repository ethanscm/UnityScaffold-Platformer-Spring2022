using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fragilePlat : MonoBehaviour
{
    public GameObject platComp;
    public GameObject detector;
    private fragilePlatDetector detectScript;
    private float despawnTimer = 0.25f;
    private float respawnTimer = 5f;
    private float currentTime = 0f;
    private bool respawning = false;

    void Start()
    {
        detectScript = detector.GetComponent<fragilePlatDetector>();
        currentTime = despawnTimer;
    }

    void Update()
    {
        checkStepped();
        checkRespawn();
    }

    private void checkStepped()
    {
        if (detectScript.stepped)
        {
            currentTime -= Time.deltaTime;
            if (currentTime <= 0)
            {
                platComp.SetActive(false);
                respawning = true;
                detectScript.stepped = false;
                currentTime = respawnTimer;
            }
        }
    }

    private void checkRespawn()
    {
        if (respawning)
        {
            currentTime -= Time.deltaTime;
            if (currentTime <= 0)
            {
                platComp.SetActive(true);
                currentTime = despawnTimer;
                respawning = false;
            }
        }
    }
}
