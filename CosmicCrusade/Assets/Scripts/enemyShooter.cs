using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyShooter : MonoBehaviour {

	public GameObject enemyShotPrefab;
	public float fireRate = 0.5F;
	public float nextFire = 0.0F;
    public int canFire = 0;
    public bool scriptActive = true;
    public int enemyBulletSpeed;
    public bool barrierHit = false;

    void Start()
    {
        scriptActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (scriptActive)
        {
            if (PlayerController.isPlayerRespawning == true)
            {
                canFire = 0;
            }
            if (canFire == 1)
            {


                if (Time.time > nextFire)
                {
                    nextFire = Time.time + fireRate;
                    GameObject x = Instantiate(enemyShotPrefab);
                    Rigidbody2D rbNew = x.GetComponent<Rigidbody2D>();
                    Rigidbody2D rbThis = GetComponent<Rigidbody2D>();
                    rbNew.velocity = new Vector2(0, enemyBulletSpeed);
                    rbNew.position = rbThis.position;
                    x.transform.position = gameObject.transform.position;

                }
            }
            if (PlayerController.isPlayerRespawning == false)
            {
                if (barrierHit == true)
                {
                    canFire = 1;
                }
            }
        }
        if (PlayerController.gameEndedDeath || checkEnemies.gameEndedWin)
        {
            scriptActive = false;
        }
    }


    void OnTriggerEnter2D (Collider2D other)
    {
        if (scriptActive)
        {


            if (other.gameObject.CompareTag("hoverLine"))
            {
                canFire = 1;
                barrierHit = true;
            }
        }
    }

}
