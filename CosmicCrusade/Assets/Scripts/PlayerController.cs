using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public float speed;
    public static int playerHealth = 100;
    public static int playerLives = 3;
    public Text gameOverText;
    public static bool gameEndedDeath = false;
    private Rigidbody2D rb2d;
    public bool scriptActive = true;
    public float delay;
    public float timeHolder;
    public static bool isGameOpen = true;
    public static bool isPlayerRespawning = false;
    public float respawnDelay;
    public float respawnHolder;
    public Vector2 respawnPosition = new Vector2(0, -6);
    public Slider healthBar;
    public static int score;
    public Text scoreText;
    public static int damage = 15;
    public AudioClip playerDestroy;
    public AudioClip permCollect;
    public AudioClip playerHit;
    private AudioSource source;
    


    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        gameOverText.text = "";
        GameOver();
        gameEndedDeath = false;
        scriptActive = true;
        healthBar.maxValue = 100;
        healthBar.minValue = 0;
        score = 0;
        scoreText.text = "Score: " + score;
        source = GetComponent<AudioSource>();
    }


    

    void FixedUpdate()
    {
        if (Time.time > respawnHolder)
        {
            isPlayerRespawning = false;
        }

        healthBar.value = playerHealth;

        if (scriptActive)
            scoreText.text = "Score: " + score;
        if (isPlayerRespawning == false)
            {
                {
                    rb2d.drag = 4;
                    float moveHorizontal = Input.GetAxis("Horizontal");
                    float moveVertical = Input.GetAxis("Vertical");
                    Vector2 movement = new Vector2(moveHorizontal, moveVertical);
                    rb2d.AddForce(movement * speed);
                }
            }
        if (checkEnemies.gameEndedWin)
        {
            scriptActive = false;
        }
        if (isGameOpen == true)
        {
            timeHolder = Time.time;
            timeHolder = timeHolder + delay;
        }
        if (isGameOpen == false)
        {
            if (Time.time > timeHolder)
            {
                //Application.Quit();
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (scriptActive)
        {
            if (other.gameObject.CompareTag("testEnemyBullet"))
            {
                other.gameObject.SetActive(false);
                playerHealth = playerHealth - 10;
                source.PlayOneShot(playerHit);
                GameOver();
            }
            if (other.gameObject.CompareTag("fastEnemyBullet"))
            {
                other.gameObject.SetActive(false);
                playerHealth = playerHealth - 5;
                source.PlayOneShot(playerHit);
                GameOver();
            }
            if (other.gameObject.CompareTag("strongEnemyBullet"))
            {
                other.gameObject.SetActive(false);
                playerHealth = playerHealth - 25;
                source.PlayOneShot(playerHit);
                GameOver();
            }
            if (other.gameObject.CompareTag("testEnemyShip"))
            {
                other.gameObject.SetActive(false);
                playerHealth = playerHealth - 100;
                GameOver();
                enemyController.formationActive = enemyController.formationActive - 1;
            }
            if (other.gameObject.CompareTag("atkSpdPerm"))
            {
                Destroy(other.gameObject);
                //other.gameObject.SetActive(false);
                //Shooter.fireRate = Shooter.fireRate - 3F;
                atkSpeedBuff.storedAtk = atkSpeedBuff.storedAtk - 0.1F;
            }
            if (other.gameObject.CompareTag("healthPerm"))
            {
                Destroy(other.gameObject);
                playerHealth = 100;
                source.PlayOneShot(permCollect);
            }
            if (other.gameObject.CompareTag("lifePerm"))
            {
                Destroy(other.gameObject);
                playerLives = playerLives + 1;
                source.PlayOneShot(permCollect);
            }
            if (other.gameObject.CompareTag("msPerm"))
            {
                Destroy(other.gameObject);
                speed = speed + 10;
                source.PlayOneShot(permCollect);
            }
            if (other.gameObject.CompareTag("dmgPerm"))
            {
                Destroy(other.gameObject);
                damage = damage + 10;
                source.PlayOneShot(permCollect);
            }
            /*if (other.gameObject.CompareTag("atkPowerUp"))
            {
                //Destroy(other.gameObject);
                other.gameObject.SetActive(false);
            }*/
        }
        
    }

    void GameOver()
    {
        if (playerHealth <= 0)
        {
            playerLives = playerLives - 1;
            checkLives();
            score = score - 50;
            source.PlayOneShot(playerDestroy);
        }
    }
    
    void checkLives()
    {
        if (playerLives <= 0)
        {
            gameOverText.text = "Game Over!";
            scriptActive = false;
            gameEndedDeath = true;
            gameObject.SetActive(false);
            isGameOpen = false;
        }
        if (playerLives >= 1)
        {
            isPlayerRespawning = true;
            respawnHolder = Time.time;
            respawnHolder = respawnHolder + respawnDelay;
            playerHealth = 100;
            transform.position = respawnPosition;
            rb2d.drag = 100;
        }
    }
    
       
}

