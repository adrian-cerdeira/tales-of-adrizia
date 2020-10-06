using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{
    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        long score = LevelController.Score;
        long highScore = (long)PlayerPrefs.GetFloat("HighScore", 0);
        
        if(score > highScore)
        {
            PlayerPrefs.SetFloat("HighScore", score);
        }

        scoreText.text = "Score: " + score.ToString();    
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }
}
