using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Text highScore;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(PlayerPrefs.HasKey("HighScore"));
        if (!highScore) { Debug.LogError("TEXT MISSING!"); }
        
        highScore.text = "HIGHSCORE: " + (long)PlayerPrefs.GetFloat("HighScore", 0);
    }

    // Update is called once per frame
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
}
