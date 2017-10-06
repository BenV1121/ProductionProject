using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseController : MonoBehaviour {

    // PlayerController holding most of the variables needed for movement, attacking, etc.

    //State Machine
    public enum PlayerState { IDLE, ATTACK, DEATH, MIMIC };
    public PlayerState playerState;

    public CircleCollider2D myCollider;

    public Rigidbody2D rb;

    public bool isEnemyAI = false;
    public bool isDead = false;

    //Mimic variables
    public const float mimicDuration = 10f;
    public float mimicTimer = 0;

    //Attack variables
    public float attackCooldownTime = 1.5f;
    public float attackTimer = 0f;

    //Movement variables
    public float minJumpForce = 2f;
    public float maxJumpForce = 2f;
    public float fallSpeed = 2.5f;    

    public bool isJumping = false;
    public bool isGrounded = false;

    public bool canDoubleJump = false;
    public ushort maxJumps = 1;

    // Modify this in your enemy code
    public const float walkSpeed = 1f;
    public float maxWalkSpeed = 2.5f;
    public float walkSpeedMult = 1.0f;

    //The changing class which the mimic mechanic relies on
    public ClassBase playerClass;
    

	void Start () {
        myCollider = GetComponent<CircleCollider2D>();

        if (GetComponent<CircleCollider2D>())
            myCollider = GetComponent<CircleCollider2D>();

        if (GetComponent<Rigidbody2D>())
            rb = GetComponent<Rigidbody2D>();

        if (!isEnemyAI || playerClass == null)
        {
            playerClass = (ClassMirror)playerClass;
        }

        playerState = PlayerState.IDLE;


    }
	
	void Update () {

        if (!isDead)
        {
            //Not needed
            //playerClass.Update();

            // Simple State Machine
            // Go back to IDLE after doing actions
            switch (playerState)
            {
                case PlayerState.ATTACK:
                    attackTimer += Time.deltaTime;

                    if (attackTimer >= attackCooldownTime)
                    {
                        attackTimer = 0;
                        playerState = PlayerState.IDLE;
                    }
                    break;

                case PlayerState.MIMIC:
                    attackTimer += Time.deltaTime;

                    if (attackTimer >= attackCooldownTime)
                    {
                        attackTimer = 0;
                        playerState = PlayerState.IDLE;
                    }
                    break;
            }
        }

        //Code to shed away mimic and go back to mirror.
        if (isEnemyAI == false)
        {
            if (Input.GetButton("Fire2"))
            {
                if (!gameObject.GetComponent<ClassMirror>()
                && playerState != PlayerState.MIMIC)
                {
                    if (GetComponent<FireProjectileScript>())
                    {
                        Destroy(GetComponent<FireProjectileScript>());
                    }

                    Destroy(playerClass);                    
                    playerClass = gameObject.AddComponent<ClassMirror>();                    
                }
            }
        }
	}
}
