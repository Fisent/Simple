using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void toMainMenu()
    {
        Application.LoadLevel("MainMenu");
    }

    public void StartGame()
    {
        Application.LoadLevel("scene1");
    }
}
