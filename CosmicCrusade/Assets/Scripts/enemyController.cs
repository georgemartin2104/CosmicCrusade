using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyController : MonoBehaviour {

	public int health = 30;
    public float speed;
    private Rigidbody2D rb2d;
    float moveHorizontal = 0F;
    float moveVertical = 0F;
    public bool scriptActive = true;
    public bool barrierHit = false;
    public static int formationActive = 0;
    public static bool powerupChk = true;
    private float didDrop;
    public float dropChance;
    public int fallSpeed;
    public GameObject atkSpdPerm;
    public GameObject healthPerm;
    public GameObject lifePerm;
    public GameObject msPerm;
    public GameObject dmgPerm;
    public AudioClip enemyDestroy;
    

    void Start ()
    {
        rb2d = GetComponent<Rigidbody2D>();
        scriptActive = true;
        
    }


    void FixedUpdate ()
    {
        if (scriptActive)
        {
            if (PlayerController.isPlayerRespawning == false)
            {
                Vector2 movement = new Vector2(moveHorizontal, moveVertical);
                rb2d.AddForce(movement * speed);
                if (barrierHit == false)
                {
                    rb2d.gravityScale = 0.4F;
                }
            }
        }
        if (PlayerController.gameEndedDeath || checkEnemies.gameEndedWin)
        {
            scriptActive = false;
        }
        if (PlayerController.isPlayerRespawning == true)
        {
            if (barrierHit == false)
            {
                rb2d.gravityScale = 0;
            }
        }
        if (formationActive < 0)
        {
            formationActive = 0;
        }
        
    }


	void OnTriggerEnter2D(Collider2D other)
	{
        if (scriptActive)
        {
            if (other.gameObject.CompareTag("testPlayerBullet"))
            {
                other.gameObject.SetActive(false);
                health = health - PlayerController.damage;
                checkDeath();
                
            }

            if (other.gameObject.CompareTag("hoverLine"))
            {
                rb2d.gravityScale = 0;
                moveHorizontal = 0.2F;
                barrierHit = true;
                formationActive = formationActive + 1;
                powerupChk = false;
            }
            if (other.gameObject.CompareTag("hoverLeft"))
            {
                moveHorizontal = 0.2F;
            }
            if (other.gameObject.CompareTag("hoverRight"))
            {
                moveHorizontal = -0.2F;
            }
        }
        

}
	void checkDeath ()
	{
		if (health <= 0) {
            
            {
                //Destroy(gameObject);

                gameObject.SetActive(false);

                PlayerController.score = PlayerController.score + 10;
                formationActive = formationActive - 1;
                if (formationActive == 0)
                {
                    if (powerupChk == false)
                    {

                        didDrop = Random.value;
                        if (didDrop <= dropChance)
                        {
                            didDrop = Random.value;
                            if (didDrop <= 0.2)
                            {
                                GameObject v = Instantiate(atkSpdPerm);
                                Rigidbody2D vRbNew = v.GetComponent<Rigidbody2D>();
                                Rigidbody2D vRbThis = GetComponent<Rigidbody2D>();
                                vRbNew.velocity = new Vector2(0, fallSpeed);
                                vRbNew.position = vRbThis.position;
                                v.transform.position = gameObject.transform.position;
                            }
                            if (didDrop > 0.2 && didDrop <= 0.4)
                            {
                                GameObject w = Instantiate(healthPerm);
                                Rigidbody2D wRbNew = w.GetComponent<Rigidbody2D>();
                                Rigidbody2D wRbThis = GetComponent<Rigidbody2D>();
                                wRbNew.velocity = new Vector2(0, fallSpeed);
                                wRbNew.position = wRbThis.position;
                                w.transform.position = gameObject.transform.position;
                            }
                            if (didDrop > 0.4 && didDrop <= 0.6)
                            {
                                GameObject x = Instantiate(lifePerm);
                                Rigidbody2D xRbNew = x.GetComponent<Rigidbody2D>();
                                Rigidbody2D xRbThis = GetComponent<Rigidbody2D>();
                                xRbNew.velocity = new Vector2(0, fallSpeed);
                                xRbNew.position = xRbThis.position;
                                x.transform.position = gameObject.transform.position;
                            }
                            if (didDrop > 0.6 && didDrop <= 0.8)
                            {
                                GameObject y = Instantiate(msPerm);
                                Rigidbody2D yRbNew = y.GetComponent<Rigidbody2D>();
                                Rigidbody2D yRbThis = GetComponent<Rigidbody2D>();
                                yRbNew.velocity = new Vector2(0, fallSpeed);
                                yRbNew.position = yRbThis.position;
                                y.transform.position = gameObject.transform.position;
                            }
                            if (didDrop > 0.8 && didDrop <= 1)
                            {
                                GameObject z = Instantiate(dmgPerm);
                                Rigidbody2D zRbNew = z.GetComponent<Rigidbody2D>();
                                Rigidbody2D zRbThis = GetComponent<Rigidbody2D>();
                                zRbNew.velocity = new Vector2(0, fallSpeed);
                                zRbNew.position = zRbThis.position;
                                z.transform.position = gameObject.transform.position;
                            }
                        }
                    }
                }
            }
         }
	}
}