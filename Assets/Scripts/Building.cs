using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour {

    public GameObject ruins;
    public GameObject singleEnemy;
    public int singleEnemyCount;
    public GameObject respawnableEnemy;
    public float respawnableEnemyFrequency;
    public float hp = 10f;

    private GameObject thumpSound;

	// Use this for initialization
	void Start () 
    {
        thumpSound = GameObject.Find("ThumpSound");
		Invoke ("SpawnSingle", 1f);
        InvokeRepeating("SpawnRepeatly", 3f, respawnableEnemyFrequency);
	}
	
	// Update is called once per frame
	void Update () 
    {
        
	}

    public void SpawnSingle()
    {
		
        if(singleEnemy!=null)
        {
            
            Vector3 spawnPosition = new Vector3(transform.parent.position.x, transform.parent.position.y -1f, 0f);
            for (int i = 0; i < singleEnemyCount; i++)
            {
                GameObject enemy = Instantiate(singleEnemy, spawnPosition, Quaternion.identity) as GameObject;
            }
        }
    }

    public void SpawnRepeatly()
    {
        if(respawnableEnemy!=null)
        {

            Vector3 spawnPosition = new Vector3(transform.parent.position.x, transform.parent.position.y - 1f, 0f);
            GameObject enemy = Instantiate(respawnableEnemy, spawnPosition, Quaternion.identity) as GameObject;
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        Bullet projectile = coll.gameObject.GetComponent<Bullet>();
        if (projectile != null && projectile.friendly)
        {
            thumpSound.GetComponent<AudioSource>().Play();
            GetComponent<ParticleSystem>().Play();

            hp--;
            if (hp < 0)
            {
				GameObject go = Instantiate(ruins, transform.position, Quaternion.identity) as GameObject;
				go.transform.parent = transform.parent;
                Destroy(gameObject);
            }
        }
    }
}
