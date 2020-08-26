using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonActive3 : MonoBehaviour {

    
    public GameObject menuButton;
    public GameObject quitGame;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (checkEnemies.gameEndedWin == false)
        {
            
            menuButton.SetActive(false);
            quitGame.SetActive(false);
        }
        if (checkEnemies.gameEndedWin == true)
        {
            
            menuButton.SetActive(true);
            quitGame.SetActive(true);
        }
        if (PlayerController.gameEndedDeath)
        {
            menuButton.SetActive(true);
            quitGame.SetActive(true);
        }
    }
}
