using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))] 

public class WoodPecker : MonoBehaviour
{
    //reference to Waypoints
    public List<Transform> points;
    //public int nextID = 0;
    //private int idChangeValue = 1;
    public float speed = 2;


	public void Reset()
	{
        Init();


	}

	public void Init()
	{
        //Make Box Collider Trigger
        GetComponent<BoxCollider2D>().isTrigger = true;

        //Create Root Object
        GameObject root = new GameObject(name + "_Root");
        root.transform.position = transform.position;
        transform.SetParent(root.transform);

        GameObject waypoints = new GameObject("Waypoints");
        waypoints.transform.SetParent(root.transform);
        waypoints.transform.position = root.transform.position;



        GameObject p1 = new GameObject("Point1");
        p1.transform.SetParent(waypoints.transform);
        p1.transform.position = Vector3.zero;

        GameObject p2 = new GameObject("Point2");
        p2.transform.SetParent(waypoints.transform);
        p2.transform.position = Vector3.zero;


        points = new List<Transform>();
        points.Add(p1.transform);
        points.Add(p2.transform);


    }


    // Update is called once per frame
    public void Update()
    {
        MoveToNextPoint();
    }


    public void MoveToNextPoint()
	{
        Transform goalPoint = points[0];


        transform.position = Vector2.MoveTowards(transform.position, goalPoint.position, speed*Time.deltaTime );
        if (Vector2.Distance(transform.position, goalPoint.position) < 1f)
        {
			transform.position = points[1].position;
        }
    }

    //functions to kill upon impact

    //function to respawn


}
