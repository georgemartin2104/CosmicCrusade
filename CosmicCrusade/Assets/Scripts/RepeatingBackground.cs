using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBackground : MonoBehaviour {

    private BoxCollider2D backgroundCollider;
    private float backgroundHeight;
    public bool scriptActive = true;
    
    // Use this for initialization
	void Start ()
    {
        backgroundCollider = GetComponent<BoxCollider2D>();
        backgroundHeight = backgroundCollider.size.y;
        scriptActive = true;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (scriptActive)
        {
            if (transform.position.y < -backgroundHeight)
                RepeatBackground();
        }
        if (PlayerController.gameEndedDeath || checkEnemies.gameEndedWin)
        {
            scriptActive = false;
        }
    }

    void RepeatBackground()
    {
        Vector2 BGoffset = new Vector2(0, backgroundHeight * 2f * this.transform.localScale.y);
        transform.position = (Vector2)transform.position + BGoffset;
    }

}
