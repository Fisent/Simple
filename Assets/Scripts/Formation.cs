using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Formation : MonoBehaviour {


	public int startDelay = 200;
	public GameObject[] buildings;


	private int delay;
	private int timer;
	// Use this for initialization
	void Start () 
	{
		delay = startDelay;
		timer = 0;
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		timer++;
		if (timer % delay == 0) {
			Spawn ();
		}
	}

	public void Spawn()
	{
		Transform[] tab = new Transform [transform.childCount];
		int i = 0;
		int spawnNumber = 0;
		foreach (Transform go in transform) 
		{
			tab [i] = go;

			i++;
			spawnNumber = Random.Range (0, transform.childCount);
		}
		Transform spawn = tab [spawnNumber];
		int buildingNumber = Random.Range (0, buildings.Length);

		if (spawn.childCount != 0) {
			
			Destroy(spawn.GetChild (0));
		}
		GameObject building = Instantiate (buildings [buildingNumber], spawn.position, Quaternion.identity);
		building.transform.parent = spawn;
		delay = Mathf.Max (delay - 1, 50);
	}


}
