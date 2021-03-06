﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseController : MonoBehaviour {

    // PlayerController holding most of the variables needed for movement, attacking, etc.

    //State Machine
    public enum PlayerState { IDLE, ATTACK, DEATH, MIMIC };
    public PlayerState playerState;

    public BoxCollider2D myCollider;

    public Rigidbody2D rb;

    public bool isEnemyAI = false;
    public bool isDead = false;

    //Prefab mirror for some variable information
    GameObject prefab;

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

    public bool isMirror = true;

    // Modify this in your enemy code
    public const float walkSpeed = 1f;
    public float maxWalkSpeed = 2.5f;
    public float walkSpeedMult = 1.0f;

    //The changing class which the mimic mechanic relies on
    public ClassBase playerClass;
    Sprite mirror;

	void Start () {
        myCollider = GetComponent<BoxCollider2D>();

        mirror = Resources.Load<Sprite>("Textures/MirrorSprite") as Sprite;

        if (GetComponent<BoxCollider2D>())
            myCollider = GetComponent<BoxCollider2D>();

        if (GetComponent<Rigidbody2D>())
            rb = GetComponent<Rigidbody2D>();

        if (!isEnemyAI || playerClass == null)
        {
            playerClass = (ClassMirror)playerClass;
        }

        playerState = PlayerState.IDLE;

        prefab = (GameObject)Resources.Load("MirrorGuy");

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
                bool isMirrorGuy = GetComponent<ClassMirror>();

                if (isMirrorGuy == false && playerState != PlayerState.MIMIC)
                {
                    if (GetComponent<FireProjectileScript>())
                    {
                        Destroy(GetComponent<FireProjectileScript>());
                    }

                    Destroy(playerClass);                    
                    playerClass = gameObject.AddComponent<ClassMirror>();
                    playerClass.sprite = GetComponentInChildren<SpriteRenderer>();
                    playerClass.sprite.transform.localScale = new Vector2(.22f, .22f);
                    playerClass.sprite.sprite = mirror;
                    
                    transform.localScale = new Vector2(.80f, .80f);                                        

                    myCollider.offset = new Vector2();
                    myCollider.size = new Vector2(1.2f, 1.96f);                    
                }
            }
        }
	}
}
