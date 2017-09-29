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

    //Movement variables
    public float maxJumpForce = 2f;

    // Modify gravity in your enemy code
    const float fallSpeed = 5f;
    public float fallSpeedMult = 1.0f;
    public bool isJumping = false;
    public bool isGrounded = false;

    public bool canDoubleJump = false;
    public ushort maxJumps = 1;

    // Modify walkSpeedForce in your enemy code
    public const float walkSpeed = 5f;
    public float walkSpeedMult = 1.0f;

    //The changing class which the mimic mechanic relies on
    public ClassBase playerClass;

	void Start () {
        if (GetComponent<CircleCollider2D>())
            myCollider = GetComponent<CircleCollider2D>();

        if (GetComponent<Rigidbody2D>())
            rb = GetComponent<Rigidbody2D>();

        playerClass = (ClassMirror)playerClass;
        playerState = PlayerState.IDLE;


    }
	
	void Update () {

        if (!isDead)
        {
            playerClass.Update();
        }



        //Code for mimic duration. Disabled for now unless we want it back
        //if (playerClass != (ClassMirror)playerClass)
        //{
        //    mimicTimer += Time.deltaTime;
        //}

        //if (mimicTimer >= mimicDuration)
        //{
        //    playerClass = (ClassMirror)playerClass;
        //    mimicTimer = 0;
        //}

	}    
}
