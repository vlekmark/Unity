using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberWizard : MonoBehaviour
{
    [SerializeField] int max;
    [SerializeField] int min;
    [SerializeField] Text response;
    [SerializeField] Text guess;
    private int number;

    // Start is called before the first frame update
    void Start()
    {
        StartGame();
    }

    // All of the initialization of the game
    void StartGame()
    {
        number = Random.Range(min, max);
    }

    // Checks if your guess is equal to, lower or higher that the computer's number
    public void CheckGuess()
    {
        if (int.Parse(guess.text) == number)
        {
            response.text = "You guessed correctly!";
        }
        else if (int.Parse(guess.text) < number)
        {
            response.text = "Guess higher!";
        }
        else if (int.Parse(guess.text) > number)
        {
            response.text = "Guess lower!";
        }

        if (int.Parse(guess.text) == 69)
        {
            response.text = response.text + " (nice)";
        }
    }
}
