using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassMirror : ClassBase {

    // The default starting character: Mirror
    public CapsuleCollider2D mimicCollider;
    public bool canMimic = false;
    public ClassBase otherClass;
    public System.Type otherType;    



	// Use this for initialization
	override public void Start ()
    {
        base.Start();

        mimicCollider = gameObject.AddComponent<CapsuleCollider2D>();
        mimicCollider.isTrigger = true;
        mimicCollider.direction = CapsuleDirection2D.Horizontal;
        mimicCollider.size = new Vector2(4f, 2f);

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

    void OnTriggerStay2D(Collider2D other)
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
                //Reference for sanity
                SpriteRenderer other = otherClass.GetComponentInChildren<SpriteRenderer>();                
                BoxCollider2D otherBox = otherClass.control.myCollider;

                //Transfer Class type
                control.playerClass = gameObject.AddComponent(otherClass.GetType()) as ClassBase;

                //Transfer sprites and collision box sizes and whatever
                sprite.sprite = other.sprite;
                sprite.transform.localScale = other.transform.localScale;
                //transform.localScale = other.GetComponentInParent<Transform>().localScale;
                gameObject.transform.localScale = otherBox.gameObject.transform.localScale;

                control.myCollider.offset = otherBox.offset;
                control.myCollider.size = otherBox.size;

                Destroy(otherClass.gameObject);
                Destroy(mimicCollider);
                Destroy(this);
            }             
        }

        // ATTACK
        if (Input.GetButton("Fire1"))
        {
            //mirror class can't attack
        }
    }

    public override void Update()
    {
        base.Update();
    }
}
