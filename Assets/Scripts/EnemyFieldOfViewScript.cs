using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFieldOfViewScript : MonoBehaviour 
{

    public Enemy enemy;

	// Use this for initialization
	void Start () 
    {
		
	}
	
	// Update is called once per frame
	void Update () 
    {
		
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        Player pl = coll.gameObject.GetComponent<Player>();
        if (pl!=null)
        {
            enemy.Trigger(coll.gameObject);
        }
    }
}
