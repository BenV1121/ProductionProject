using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotScript : MonoBehaviour
{
    public int damage = 1;

    public bool isEnemyShot = false;

    // Use this for initialization
    void Start()
    {
        Destroy(gameObject, 20);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isEnemyShot == false)
            if (other.gameObject.GetComponent<classBEnvironment>())
                if (other.gameObject.GetComponent<classBEnvironment>().thiswallis == classBEnvironment.walltyp.WOOD)
                {
                    Destroy(gameObject);
                }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
