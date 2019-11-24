using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoseCollider : MonoBehaviour
{
    public Text scoreText;
    private int score = 0;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(0);
        }
        if (collision.gameObject.tag == "Enemy")
        {
            OnPlayerScored();
        }
    }

    void OnPlayerScored()
    {
        score++;
        scoreText.text = "Score: " + score.ToString();

        int savedScore = PlayerPrefs.GetInt("Highscore");

        if (score > savedScore)
        {
            PlayerPrefs.SetInt("Highscore", score);
        }
    }
}
