using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public float speed = 500f;





	//range from 0 to 3;
	// 0 - pistol
	// 1 - machine gun
	// 2 - laser gun
	// 3 - rocket launcher
	private int level;



	// Use this for initialization
	void Start () 
    {
		
	}
	
	// Update is called once per frame
	void Update () 
    {
        InputCheck();
	}

    public void InputCheck()
    {
        Rigidbody2D body = GetComponent<Rigidbody2D>();
        if (Input.GetKey(KeyCode.A))
        {
            body.AddForce(Vector3.left * speed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            body.AddForce(Vector3.right * speed);
        }
        if (Input.GetKey(KeyCode.W))
        {
            body.AddForce(Vector3.up * speed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            body.AddForce(Vector3.down * speed);
        }

    }

    void OnCollisionEnter2D(Collision2D coll)
    {
		ProjectileAbstract projectile = coll.gameObject.GetComponent<ProjectileAbstract>();
        if (projectile != null)
        {
            Destroy(gameObject);

        }
        //print(coll.gameObject);
    }


}
