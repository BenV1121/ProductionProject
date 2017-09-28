using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseController : MonoBehaviour {

    // PlayerController holding most of the variables needed for movement, attacking, etc.

    //State Machine
    public enum PlayerState { IDLE, ATTACK, DEATH, MIMIC };
    public PlayerState playerState;

    public SphereCollider myCollider;

    public bool isEnemyAI = false;

    //Mimic variables
    public const float mimicDuration = 10f;
    public float mimicTimer = 0;

    //Movement variables
    public float maxJumpForce = 2f;
    public bool isJumping = false;
    public bool canDoubleJump = false;
    public const ushort maxJumps = 1;

    //The changing class which the mimic mechanic relies on
    public ClassBase playerClass;

	void Start () {
        myCollider = GetComponent<SphereCollider>();
        playerClass = (ClassMirror)playerClass;
        playerState = PlayerState.IDLE;
    }
	
	void Update () {
        
        playerClass.Update();

	}    
}
