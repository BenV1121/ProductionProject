using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public Button replay;
    public Button quit;

    public GameObject cube;
    public GameObject player;

    public float timer;

    public RawImage GameOver;

    public string scene;

    BaseController control;

	// Use this for initialization
	void Start ()
    {
        GameOver.gameObject.SetActive(false);
        control = player.GetComponent<BaseController>();
	}
	
	// Update is called once per frame
	void Update ()
    {

        //timer -= Time.deltaTime;
	    if (control.isDead == true) //<---- fix this
        {
            GameOver.gameObject.SetActive(true);
            cube.gameObject.SetActive(false);
        }	
	}

    public void Replay()
    {
        SceneManager.LoadScene(scene);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
