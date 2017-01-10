using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : ProjectileAbstract {

    public bool friendly;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        DestroyCheck();
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        Destroy(gameObject);
    }
}
