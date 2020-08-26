using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

    public GameObject shotPrefab;
	public static float fireRate = 0.4F;
	public float nextFire = 0.0F;
    public bool scriptActive = true;
    public int bulletSpeed;
    public AudioClip playerShoot;
    private AudioSource source;
    public float vol;

    void Start()
    {
        scriptActive = true;
        source = GetComponent<AudioSource>();
    }


    // Update is called once per frame
    void Update ()
    {
        if (scriptActive)
        {
            if (PlayerController.isPlayerRespawning == false)
            {
                if (Input.GetKey("space") && Time.time > nextFire)
                {
                    nextFire = Time.time + fireRate;
                    GameObject x = Instantiate(shotPrefab);
                    Rigidbody2D rbNew = x.GetComponent<Rigidbody2D>();
                    Rigidbody2D rbThis = GetComponent<Rigidbody2D>();
                    rbNew.velocity = new Vector2(0, bulletSpeed);
                    rbNew.position = rbThis.position;
                    x.transform.position = gameObject.transform.position;
                    source.PlayOneShot(playerShoot, vol);
                }
            }
        }
        if (PlayerController.gameEndedDeath || checkEnemies.gameEndedWin)
        {
            scriptActive = false;
        }
	}
}
