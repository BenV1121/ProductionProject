using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float speed;

    int nextPoint;

    // Points of destination
    public Vector3[] points;

    //Current point of direction
    void Start ()
    {
        nextPoint = 1;
    }

	// Update is called once per frame
	void Update ()
    {
        float step = speed * Time.deltaTime;

        transform.position = Vector3.MoveTowards(transform.position, points[nextPoint], step);

        Vector3.Distance(transform.position, points[nextPoint]);

        // If object makes it to the point, it goes to the next one.
        if (step >= Vector3.Distance(transform.position, points[nextPoint]))
        {
            nextPoint = (nextPoint + 1) % points.Length;
            
            // The target will return to the first point when it reaches the last destination.
        }
	}
}
