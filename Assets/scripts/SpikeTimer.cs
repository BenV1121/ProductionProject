using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTimer : MonoBehaviour
{
    public float timer;
    float refillTimer;

    public float activateTimer = 0;
    float refillActiveTimer = 5;

    // Use this for initialization
    void Start ()
    {
        ////timer = 5;
        ////refillTimer = 5;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            timer = refillTimer;

            gameObject.SetActive(false);

            activateTimer -= Time.deltaTime;
        }

        if (activateTimer <= 0)
        {
            activateTimer = refillActiveTimer;

            gameObject.SetActive(true);
        }
	}
}
