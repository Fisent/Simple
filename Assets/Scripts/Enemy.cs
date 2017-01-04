﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public GameObject player;
    public GameObject bullet;
    public GameObject corpse;
    public GameObject soundSystem;
    public float bulletSpeed = 200f;
    public float probabilityOfShoot;

	// Use this for initialization
	void Start () 
    {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Random.value > probabilityOfShoot)
        {
            ShootAtPlayer();
        }
        MoveTowardsPlayer();
	}

    public void Trigger(GameObject pl)
    {
        player = pl;
    }

    void ShootAtPlayer()
    {
        if (player != null)
        {
            soundSystem.GetComponent<AudioSource>().Play();
            Vector2 myPos = transform.position;
            Vector3 spawnPos = new Vector3(myPos.x, myPos.y, 0.5f);
            Vector2 PlayerPos = player.transform.position;
            Vector2 direction = PlayerPos - myPos;
            direction.Normalize();

            GameObject missile = Instantiate(bullet, myPos, Quaternion.identity) as GameObject;
            missile.GetComponent<Rigidbody2D>().AddForce(direction * bulletSpeed);
        }
    }

    void MoveTowardsPlayer()
    {
        if (player != null)
        {
            Vector2 myPos = transform.position;
            Vector3 spawnPos = new Vector3(myPos.x, myPos.y, 0.5f);
            Vector2 PlayerPos = player.transform.position;
            Vector2 direction = PlayerPos - myPos;
            direction.Normalize();

            transform.GetComponent<Rigidbody2D>().velocity = direction;
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        Bullet projectile = coll.gameObject.GetComponent<Bullet>();
        if (projectile != null)
        {
            Instantiate(corpse, new Vector3(transform.position.x, transform.position.y, 0.5f), Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
