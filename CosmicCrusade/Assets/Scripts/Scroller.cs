using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroller : MonoBehaviour {

    private Rigidbody2D rigidbody;
    private float speed = -1.5f;
    [SerializeField] private bool stopScrolling;
    public bool scriptActive = true;

	// Use this for initialization
	void Start ()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.velocity = new Vector2(0, speed);
        scriptActive = true;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (scriptActive)
        {


            if (stopScrolling)
                rigidbody.velocity = Vector2.zero;
            else
                rigidbody.velocity = new Vector2(0, speed);
        }
        if (PlayerController.gameEndedDeath || checkEnemies.gameEndedWin)
        {
            scriptActive = false;
        }
    }
}
