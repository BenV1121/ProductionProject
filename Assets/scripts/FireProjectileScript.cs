using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireProjectileScript : MonoBehaviour
{

    public ClassFire cfBuddyFriend;

    /// Projectile prefab for shooting
    public GameObject shotPrefab;

    /// Cooldown in seconds between two shots
    public float shootingRate = 1f;

    public bool shotFlip = false;
    BaseController bc;
    // Cooldown

    private float shootCooldown;

    void Start()
    {
        shootCooldown = 0f;
        bc = GetComponent<BaseController>();
        cfBuddyFriend = gameObject.GetComponent<ClassFire>();

        if (cfBuddyFriend.control.isEnemyAI)
        {
            shotPrefab = (GameObject)Resources.Load("EProjectile");
        }
        else
            shotPrefab = (GameObject)Resources.Load("PProjectile");
    }

    void Update()
    {
        if (shootCooldown > 0)
        {
            shootCooldown -= Time.deltaTime;
        }

        if(bc.isEnemyAI == false)
        {
            if (Input.GetKey(KeyCode.A))
            {
                shotFlip = true;
            }

            if (Input.GetKey(KeyCode.D))
            {
                shotFlip = false;
            }
        }
        
    }

    // 3hooting from another script

    /// Create a new projectile if possible
    public void Attack(bool isEnemy)
    {
        if (CanAttack)
        {
            shootCooldown = shootingRate;

            // Create a new shot
            GameObject shotTransform = Instantiate(shotPrefab);

            // Assign position

            shotTransform.transform.position = transform.position;

            // The is enemy property
            ShotScript shot = shotTransform.gameObject.GetComponent<ShotScript>();
            if (shot != null)
            {
                shot.isEnemyShot = isEnemy;
            }

            //// Make the weapon shot always towards it
            ProjectileMove move = shotTransform.gameObject.GetComponent<ProjectileMove>();
            if (move != null)
            {
                move.direction = this.transform.right;

                if(shotFlip == true)
                {
                    move.direction = -this.transform.right;
                }
            }
        }
    }

    /// <summary>
    /// Is the weapon ready to create a new projectile?
    /// </summary>
    public bool CanAttack
    {
        get
        {
            return shootCooldown <= 0f;
        }
    }
}