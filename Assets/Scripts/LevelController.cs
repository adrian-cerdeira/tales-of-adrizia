using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{
    public static long Score;
    public static AudioSource LevelAudio;

    public Text scoreText;
    
    private float _scoreTimer = 0.5f;
    private float _curTimer = 0.0f;

    private void Start()
    {
        Score = 0;
        LevelAudio = GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {
        if (PlayerController.IsDead) { return; }

        if(_curTimer < _scoreTimer)
        {
            _curTimer += Time.fixedDeltaTime;
        }
        else
        {
            _curTimer = 0.0f;
            Score += 1;
            scoreText.text = Score.ToString().PadLeft(12, '0');
        }
    }
}