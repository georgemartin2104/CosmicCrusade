using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class life2script : MonoBehaviour
{

    public SpriteRenderer sprender;


    // Use this for initialization
    void Start()
    {
        sprender = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerController.playerLives >= 3)
        {
            sprender.enabled = true;
        }
        if (PlayerController.playerLives < 3)
        {
            sprender.enabled = false;
        }
    }
}
