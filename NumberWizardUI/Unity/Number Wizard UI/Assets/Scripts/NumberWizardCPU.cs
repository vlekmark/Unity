using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberWizardCPU : MonoBehaviour
{
    [SerializeField] int max;
    [SerializeField] int min;
    [SerializeField] Text guessDisplay;
    int guess;

    // Start is called before the first frame update
    void Start()
    {
        StartGame(); 
    }
    void StartGame()
    {
        UpdateGuess();
        max = max + 1;
    }

    public void GuessLower()
    {
        max = guess - 1;
        UpdateGuess();
    }

    public void GuessHigher()
    {
        if (guess < 100)
        {
            min = guess + 1;
            UpdateGuess();
        }
        else {
            guessDisplay.text = "Liar!";
        }
    }

    void UpdateGuess()
    {
        guess = Random.Range(min, max);

        if (guess == 69)
        {
            guessDisplay.text = guess.ToString() + " (nice)";
        }
        else
        {
            guessDisplay.text = guess.ToString();
        }
    }
}
