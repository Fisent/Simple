using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public GameObject player;
    public GameObject bullet;
    public GameObject corpse;
    public GameObject soundSystem;
    public float bulletSpeed = 200f;
    public float probabilityOfShoot;

	public bool obstacleAvoidRight = true;
	public bool obstacleAvoidUp = true;

    private GameObject hurtSound;
	private float prevX;
	private float prevY;

	// Use this for initialization
	void Start () 
    {
        hurtSound = GameObject.Find("HurtSound");
        soundSystem = GameObject.Find("SoundSystem");
		prevX = 0;
		prevY = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (Random.value > probabilityOfShoot)
        {
            ShootAtPlayer();
        }
        MoveTowardsPlayer();
		ObstacleAvoidCheck ();

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
		ProjectileAbstract projectile = coll.gameObject.GetComponent<ProjectileAbstract>();
        if (projectile != null)
        {
            hurtSound.GetComponent<AudioSource>().Play();
            Instantiate(corpse, new Vector3(transform.position.x, transform.position.y, 0.5f), Quaternion.identity);
            Destroy(gameObject);
        }
    }

	void ObstacleAvoidCheck()
	{
		print (prevX + "," + transform.position.x + "   " + prevY + "," + transform.position.y);
		if (player != null && prevX == transform.position.x && prevY == transform.position.y) {
			if (prevX == transform.position.x) {
				if (obstacleAvoidRight)
					GetComponent<Rigidbody2D> ().velocity += Vector2.right * 5f;
				else
					GetComponent<Rigidbody2D> ().velocity += Vector2.left * 5f;
			}
			if (prevY == transform.position.y) {
				if (obstacleAvoidUp)
					GetComponent<Rigidbody2D> ().velocity += Vector2.up * 5f;
				else
					GetComponent<Rigidbody2D> ().velocity += Vector2.down * 5f;
			}
			prevX = transform.position.x;
			prevY = transform.position.y;
		}
	}
}
