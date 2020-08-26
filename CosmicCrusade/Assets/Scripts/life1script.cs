using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class life1script : MonoBehaviour {

    public SpriteRenderer sprender;


	// Use this for initialization
	void Start ()
    {
        sprender = gameObject.GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		if (PlayerController.playerLives >= 2)
        {
            sprender.enabled = true;
        }
        if (PlayerController.playerLives < 2)
        {
            sprender.enabled = false;
        }
	}
}
