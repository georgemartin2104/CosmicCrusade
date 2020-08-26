using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lifescript3 : MonoBehaviour {

    public SpriteRenderer sprender;
    public Text livesText;
    public int lifeOverflow;


    // Use this for initialization
    void Start()
    {
        sprender = gameObject.GetComponent<SpriteRenderer>();
        sprender.enabled = false;
        livesText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        lifeOverflow = PlayerController.playerLives - 4;
        if (PlayerController.playerLives >= 4)
        {
            sprender.enabled = true;
            livesText.text = "";
        }
        if (PlayerController.playerLives < 4)
        {
            sprender.enabled = false;
            livesText.text = "";
        }
        if (PlayerController.playerLives >= 5)
        {
            livesText.text = "+" + lifeOverflow;
        }
    }
}
