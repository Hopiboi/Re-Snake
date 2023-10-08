using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class AdventureScoreManager : MonoBehaviour
{
    //Variables

    [Header("Classic Score and HighScore")]
    [SerializeField] private Text scoreText;
    [SerializeField] private Text highScoreText;
    [SerializeField] public static int scoreNumber;
    [SerializeField] public static int highScoreNumber;

    public void ScoreSystem()
    {
        scoreNumber += 1;
        scoreText.text = "Score: " + scoreNumber;
    }

    public void HighScoreSystem()
    {
        //printing it
        highScoreText.text = "Highscore: " + highScoreNumber;

        //current highscore is now passed by score
        if (highScoreNumber < scoreNumber)
         {
            highScoreNumber = scoreNumber;
            PlayerPrefs.SetInt("Highscore", highScoreNumber);
         }

    }

}
