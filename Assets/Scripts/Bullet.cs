using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

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

    void DestroyCheck()
    {
        Vector2 position = Camera.main.WorldToViewportPoint(transform.position);
        //Vector2 position = Camera.main.ScreenToViewportPoint(transform.position);
        if (position.x > 1 || position.x < 0 || position.y > 1 || position.y < 0)
        {
            Destroy(gameObject);
        }
    }
}
