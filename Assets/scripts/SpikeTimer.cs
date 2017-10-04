using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTimer : MonoBehaviour
{
    public GameObject spikes;

    public float timer;
    public float activateTimer;

    float refillTimers = 2;

    // Use this for initialization
    void Start ()
    {
        ////timer = 5;
        ////refillTimer = 5;

        spikes = GameObject.Find("Spikes");
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            spikes.SetActive(false);

            activateTimer -= Time.deltaTime;
        }

        if (activateTimer <= 0)
        {
            activateTimer = refillTimers;

            timer = refillTimers;

            spikes.SetActive(true);
        }
	}
}
