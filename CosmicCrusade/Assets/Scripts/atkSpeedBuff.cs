using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class atkSpeedBuff : MonoBehaviour {

    public bool scriptActive = true;
    public int isActiveAtkStack = 0;
    public float atkDelay;
    public float atkTimeHolder;
    public static float storedAtk;
    public AudioClip powerupCollect;
    private AudioSource source;

	// Use this for initialization
	void Start ()
    {
        scriptActive = true;
        isActiveAtkStack = 0;
        Shooter.fireRate = 0.4F;
        storedAtk = 0.4F;
        source = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (scriptActive)
        {
            if (PlayerController.isPlayerRespawning == true)
            {
                isActiveAtkStack = 0;
            }
            if (PlayerController.isPlayerRespawning == false)
            {
                if (isActiveAtkStack > 0)
                {
                    if (Time.time > atkTimeHolder)
                    {
                        isActiveAtkStack = isActiveAtkStack - 1;
                    }
                }
                if (isActiveAtkStack == 0)
                {
                    Shooter.fireRate = storedAtk;
                }
            }
        }
        if (PlayerController.gameEndedDeath || checkEnemies.gameEndedWin)
        {
            scriptActive = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (scriptActive)
        {
            if(other.gameObject.CompareTag("atkPowerUp"))
            {
                source.PlayOneShot(powerupCollect);
                storedAtk = Shooter.fireRate;
                Shooter.fireRate = Shooter.fireRate - 0.2F;
                if (Shooter.fireRate <= 0)
                {
                    Shooter.fireRate = 0.02F;
                }
                isActiveAtkStack = isActiveAtkStack + 1;
                atkTimeHolder = Time.time;
                atkTimeHolder = atkTimeHolder + atkDelay;
                other.gameObject.SetActive(false);
            }
        }
    }

}
