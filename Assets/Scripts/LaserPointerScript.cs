using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserPointerScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
    {
        Vector2 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(mouse.x, mouse.y, -2f);
	}
}
