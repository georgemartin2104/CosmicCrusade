using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class soundToggle : MonoBehaviour {

    public bool soundEnabled;
    public Text buttonText;

	public void soundChanged()
    {
        if (soundEnabled == true)
        {
            buttonText.text = "Sound Off";
            soundEnabled = false;
        }
        else if (soundEnabled == false)
        {
            buttonText.text = "Sound On";
            soundEnabled = true;
        }
    }
}
