using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class checkEnemies : MonoBehaviour {

    public int enemiesleft = 0;
    bool killedAllEnemies = false;
    public Text winText;
    public Text enemiesRemaining;
    public bool scriptActive = true;
    public static bool gameEndedWin = false;
    private int enemiesStore;
    public AudioClip enemyDestroy;
    private AudioSource source;

	// Use this for initialization
	void Start () {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("testEnemyShip");
        enemiesleft = enemies.Length;
        enemiesRemaining.text = "";
        winText.text = "";
        scriptActive = true;
        gameEndedWin = false;
        source = GetComponent<AudioSource>();
        enemiesStore = enemiesleft;
	}
	
	// Update is called once per frame
	void Update () {
        if (scriptActive)
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("testEnemyShip");
            enemiesleft = enemies.Length;
            enemiesRemaining.text = "Enemies Left: " + enemiesleft;
            if (enemiesleft == 0)
            {
                endGame();
            }
        }
        if (PlayerController.gameEndedDeath)
        {
            scriptActive = false;
        }
        if (enemiesStore > enemiesleft)
        {
            source.PlayOneShot(enemyDestroy);
            enemiesStore = enemiesleft;
        }
    }


    void endGame()
    {
        killedAllEnemies = true;
        if (finalLevel.finale == false)
        {
            winText.text = "Level Complete!";
        }
        if (finalLevel.finale == true)
        {
            winText.text = "YOU WIN!";
        }
        scriptActive = false;
        gameEndedWin = true;
        PlayerController.isGameOpen = false;
    }




}
