using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterScript : MonoBehaviour 
{

    public GameObject bullet;
    public GameObject soundSystem;
    public float bulletSpeed = 10f;

	// Use this for initialization
	void Start () 
    {
		
	}
	
	// Update is called once per frame
	void Update () 
    {
        RotateEveryFrame();
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot();
        }
	}

    void RotateEveryFrame()
    {
        Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.rotation = Quaternion.LookRotation(Vector3.forward, mouse - transform.position);
    }

    void Shoot()
    {
        soundSystem.GetComponent<AudioSource>().Play();
        Vector2 myPos = transform.position;
        Vector3 spawnPos = new Vector3(myPos.x, myPos.y, 0.5f);
        Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = cursorPos - myPos;
        direction.Normalize();

        GameObject missile = Instantiate(bullet, spawnPos, Quaternion.identity) as GameObject;
        missile.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
    }
}
