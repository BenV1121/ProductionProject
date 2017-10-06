using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour {

    // Miscellaneous Juice Machine Maker

    BaseController control;
    GameObject jumpPoof;
    public ParticleSystem part;
    Vector2 origin;
    TrailRenderer trail;
    public Material trailMaterial;
    SpriteRenderer sprite;
    public Vector2 originalScale;

	// Use this for initialization
	void Start () {
        StartCoroutine(LateStart(1f));
    }    

    IEnumerator LateStart(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        //Your Function You Want to Call
        trail = gameObject.AddComponent<TrailRenderer>();
        trail.endWidth = 0.5f;
        trail.startWidth = 0.75f;
        trail.startColor = Color.white;
        trail.time = .5f;
        trail.material = trailMaterial;
        sprite = GetComponentInChildren<SpriteRenderer>();

        originalScale = transform.localScale;

        jumpPoof = (GameObject)Resources.Load("Particles/JumpPoof");
        control = GetComponent<BaseController>();
        jumpPoof = Instantiate(jumpPoof, transform);
        part = jumpPoof.GetComponent<ParticleSystem>();

        origin = part.transform.position;
    }

    // Update is called once per frame
    void Update () {
		if (Input.GetButton("Jump"))
        {            
            part.Play();
            origin = part.transform.position;
        }

        if (!part.isPlaying)
        {
            origin = transform.position;
        }

        if (Input.GetAxis("Vertical") < 0)
        {
            //originalScale = transform.localScale;
            transform.localScale = new Vector2(originalScale.x, originalScale.y / 4f);
        }
        if (Input.GetAxis("Vertical") >= 0)
        {
            transform.localScale = originalScale;
        }

        if (Input.GetAxis("Horizontal") > 0)
        {
            sprite.flipX = false;
        }

        if (Input.GetAxis("Horizontal") < 0)
        {
            sprite.flipX = true;
        }
    }
}
