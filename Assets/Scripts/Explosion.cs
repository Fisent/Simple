﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Invoke("Delete", 2f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Delete()
    {
        Destroy(gameObject);
    }
}
