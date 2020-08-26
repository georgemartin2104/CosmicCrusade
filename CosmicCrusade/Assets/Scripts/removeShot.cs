using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class removeShot : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("hoverBullet"))
		{
			Destroy (gameObject);
		}
	}
}