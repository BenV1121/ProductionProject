using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestHealth : MonoBehaviour
{

    public int hp = 1;

    public bool isEnemy = true;

    // Use this for initialization
    void OnTriggerEnter2D(Collider2D collider)
    {
        ShotScript shot = collider.gameObject.GetComponent<ShotScript>();

        if (shot != null)
        {
            if (shot.isEnemyShot != isEnemy)
            {
                hp -= shot.damage;

                Destroy(shot.gameObject);

                if (hp <= 0)
                {
                    Destroy(gameObject);
                }
            }
        }
    }

}
