using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassMirror : ClassBase {

    // The default starting character: Mirror
    public BoxCollider2D mimicCollider;
    public bool canMimic = false;
    public ClassBase otherClass;
    public System.Type otherType;

	// Use this for initialization
	override public void Start ()
    {
        base.Start();

        mimicCollider = gameObject.AddComponent<BoxCollider2D>();
        mimicCollider.isTrigger = true;
        mimicCollider.size = new Vector2(.6f, .2f);

        otherClass = null;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<BaseController>())
        {
            canMimic = true;
            otherClass = other.gameObject.GetComponent<BaseController>().playerClass;
        }
        else
        {
            canMimic = false;
            otherClass = null;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        canMimic = false;
        otherClass = null;
    }

    override public void HandleInput()
    {
        // Use default movement and jump
        base.HandleInput();

        // MIMIC
        if (Input.GetButton("Fire2") && canMimic &&
            control.playerState == BaseController.PlayerState.IDLE)
        {
            control.playerState = BaseController.PlayerState.MIMIC;

            if (otherClass != null)
            {
                control.playerClass = gameObject.AddComponent(otherClass.GetType()) as ClassBase;            

                Destroy(otherClass.gameObject);
                Destroy(this);
            }             
        }

        // ATTACK
        if (Input.GetButton("Fire1"))
        {
            //mirror class can't attack
        }
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    public override void Update()
    {
        base.Update();
    }
}
