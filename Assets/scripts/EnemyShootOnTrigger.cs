using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootOnTrigger : MonoBehaviour
{
    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other)
    {
        FireProjectileScript weapon = GetComponent<FireProjectileScript>();

        if (other.gameObject.tag == "Player")
        {
            weapon.Attack(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        FireProjectileScript weapon = GetComponent<FireProjectileScript>();

        if (other.gameObject.tag == "Player")
        {
            weapon.Attack(false);
        }
    }
}