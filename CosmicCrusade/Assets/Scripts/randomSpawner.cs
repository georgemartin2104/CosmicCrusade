using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomSpawner : MonoBehaviour {

    public bool scriptActive = true;
    public float timeHolder;
    public float spawnDelay;
    public bool isPowerupAvailable = false;
    public GameObject atkSpeedPowerupPrefab;

	// Use this for initialization
	void Start ()
    {
        scriptActive = true;
        isPowerupAvailable = false;
        timeHolder = 0;
        timeHolder = timeHolder + spawnDelay;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (scriptActive)
        {
            if (PlayerController.isPlayerRespawning == true)
            {
                isPowerupAvailable = true;
            }
            if (PlayerController.isPlayerRespawning == false)
            {
                isPowerupAvailable = false;
            }
            if (isPowerupAvailable == false)
            {
                if (Time.time > timeHolder)
                {
                    timeHolder = Time.time;
                    GameObject x = Instantiate(atkSpeedPowerupPrefab);
                    Rigidbody2D rbNew = x.GetComponent<Rigidbody2D>();
                    rbNew.position = new Vector2 (Random.Range(-10, 10), Random.Range(-2, 7));
                    timeHolder = Time.time;
                    timeHolder = timeHolder + spawnDelay;
                }
            }
        }

        if (PlayerController.gameEndedDeath || checkEnemies.gameEndedWin)
        {
            scriptActive = false;
        }
    }
}
