using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour {

    classBEnvironment wallType;
    public GameObject prefab;

    public ParticleSystem part;

	// Use this for initialization
	void Start () {
        wallType = GetComponent<classBEnvironment>();

        if (wallType.thiswallis == classBEnvironment.walltyp.ROCK)
            prefab = (GameObject)Resources.Load("Particles/StoneDestroy");
        else
            prefab = (GameObject)Resources.Load("Particles/WoodDestroy");

        prefab = Instantiate(prefab, gameObject.transform);

        part = prefab.GetComponent<ParticleSystem>();
        //part.Stop();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (wallType.thiswallis == classBEnvironment.walltyp.ROCK &&
   collider.gameObject.GetComponent<Rock_Enemy>() &&
   collider.gameObject.GetComponent<BaseController>().playerState == BaseController.PlayerState.ATTACK)
        {
            part.Play();
        }
        
        if (wallType.thiswallis == classBEnvironment.walltyp.WOOD &&
           collider.gameObject.tag == "FireBall")
        {
            part.Play();
        }
    }
}
