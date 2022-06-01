using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoppingPlatform : Switch
{
    [SerializeField] private float speed = 2;
    private int startingPoint = 0;
    public Transform[] points;

    private int i;
    void Start()
    {
        transform.position = points[startingPoint].position;
    }

    
    void Update()
    {
        if (switchChange == true)
        {
            if (Vector2.Distance(transform.position, points[i].position) < 0.02f)
                {
                    i++;
                    Debug.Log("Heading to 1");
                    if (i == points.Length)
                    {
                        i = 0;
                        Debug.Log("Heading to 0");
                    }
                }

                transform.position = Vector2.MoveTowards(transform.position, points[i].position, speed * Time.deltaTime);
        }
    }

    
}
