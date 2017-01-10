using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ProjectileAbstract : MonoBehaviour {

	public int damage;

	public void DestroyCheck()
	{
		Vector2 position = Camera.main.WorldToViewportPoint(transform.position);
		//Vector2 position = Camera.main.ScreenToViewportPoint(transform.position);
		if (position.x > 1 || position.x < 0 || position.y > 1 || position.y < 0)
		{
			Destroy(gameObject);
		}
	}

	public virtual int Hit ()
	{
		return damage;
	}
}
