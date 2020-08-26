using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour {

    public bool scriptActive = true;

    void Start()
    {
        scriptActive = true;
    }

    void Update ()
    {
        if (scriptActive)
        {
            transform.Rotate(new Vector3(0, 0, 45) * Time.deltaTime);
        }
        if (PlayerController.gameEndedDeath || checkEnemies.gameEndedWin)
        {
            scriptActive = false;
        }
    }
}
