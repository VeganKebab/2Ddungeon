using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour
{
    public Text text;

    private void Start()
    {
        Time.timeScale = 0f;
        text.text = "Game over \n Your score: " + ScoreScript.score.ToString("0");
    }
}
