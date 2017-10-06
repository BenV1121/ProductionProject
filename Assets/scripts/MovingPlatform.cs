using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float speed;

    public float step;

    public int nextPoint;

    // Points of destination
    public Vector2[] points;

    //Current point of direction
    void Start ()
    {
        nextPoint = 1;
    }

	// Update is called once per frame
	void Update ()
    {
        step = speed * Time.deltaTime;

        transform.position = Vector2.MoveTowards(transform.position, points[nextPoint], step);

        Vector2.Distance(transform.position, points[nextPoint]);

        // If object makes it to the point, it goes to the next one.
        if (step >= Vector2.Distance(transform.position, points[nextPoint]))
        {
            nextPoint = (nextPoint + 1) % points.Length;
            
            // The target will return to the first point when it reaches the last destination.
        }
	}

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other. transform.position = Vector2.MoveTowards(other.transform.position, points[nextPoint], step);

        }
    }
}
