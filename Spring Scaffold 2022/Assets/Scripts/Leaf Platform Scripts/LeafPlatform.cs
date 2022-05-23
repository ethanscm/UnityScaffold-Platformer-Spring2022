using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafPlatform : MonoBehaviour
{
    //public GameObject platComp;
    public GameObject detector;
    private LeafPlatformDetector detectScript;
    [HideInInspector] public Rigidbody2D m_RigidBody2D;
    public float StartingHeight;

    void Start()
    {
        detectScript = detector.GetComponent<LeafPlatformDetector>();
        m_RigidBody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        checkStepped();
    }

    void checkStepped()
    {
        if(detectScript.stepped)
        {
            m_RigidBody2D.velocity = new Vector2(0, -5);
        }
        else
        {
            if (transform.position.y >= StartingHeight)
            {
                m_RigidBody2D.velocity = new Vector2(0, 0);
            }
            else
            {
                m_RigidBody2D.velocity = new Vector2(0, 0.5f);
            }
            
        }
    }
}
