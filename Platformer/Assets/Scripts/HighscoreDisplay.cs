using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighscoreDisplay : MonoBehaviour
{
    public Text scoreText;
    int savedScore = 0;

    private void Start()
    {
        savedScore = PlayerPrefs.GetInt("Highscore");

        scoreText.text = "Highscore: " + savedScore.ToString();
    }
}
