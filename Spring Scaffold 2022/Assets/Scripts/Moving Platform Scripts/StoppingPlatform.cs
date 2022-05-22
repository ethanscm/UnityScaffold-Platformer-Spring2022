using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoppingPlatform : Switch
{
    private float speed = 2;
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
                    if (i == points.Length)
                    {
                        i = 0;
                    }
                }

                transform.position = Vector2.MoveTowards(transform.position, points[i].position, speed * Time.deltaTime);
        }
    }

    
}
