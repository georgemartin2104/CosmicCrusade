using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endLevelButtons2 : MonoBehaviour {

	public void nextLevelClick()
    {
        SceneManager.LoadScene("level3");
    }
    public void backToMenu()
    {
        SceneManager.LoadScene("menu");
    }
    public void Quit()
    {
        Application.Quit();
    }
}
