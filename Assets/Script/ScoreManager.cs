using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    //Variables

    [Header("Classic Score and HighScore")]
    [SerializeField] private Text scoreText;
    [SerializeField] private Text highScoreText;
    [SerializeField] public static int scoreNumber;
    [SerializeField] public static int highScoreNumber;

    [Header("No Wall Score and HighScore")]
    [SerializeField] private Text noWallScoreText;
    [SerializeField] private Text noWallHighScoreText;
    [SerializeField] public static int noWallScoreNumber;
    [SerializeField] public static int noWallHighScoreNumber;

    [Header("Four Corners and HighScore")]
    [SerializeField] private Text fourCornersScoreText;
    [SerializeField] private Text fourCornersHighScoreText;
    [SerializeField] public static int fourCornersScoreNumber;
    [SerializeField] public static int fourCornersHighScoreNumber;

    [Header ("Middle Cross and HighScore")]
    [SerializeField] private Text middleCrossScoreText;
    [SerializeField] private Text middleCrossHighScoreText;
    [SerializeField] public static int middleCrossScoreNumber;
    [SerializeField] public static int middleCrossHighScoreNumber;

    [Header("Circle and HighScore")]
    [SerializeField] private Text circleScoreText;
    [SerializeField] private Text circleHighScoreText;
    [SerializeField] public static int circleScoreNumber;
    [SerializeField] public static int circleHighScoreNumber;

    //Function
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


    public void NoWallScoreSystem()
    {

        noWallScoreNumber += 1;
        noWallScoreText.text = "Score: " + noWallScoreNumber;

    }


    public void NoWallHighScoreSystem()
    {
        noWallHighScoreText.text = "Highscore: " + noWallHighScoreNumber;

        if (noWallHighScoreNumber < noWallScoreNumber)
        {
            noWallHighScoreNumber = noWallScoreNumber;
            PlayerPrefs.SetInt("NoWallHighscore", noWallHighScoreNumber);
        }

    }

    public void FourCornersScoreSystem()
    {
        fourCornersScoreNumber += 1;
        fourCornersScoreText.text = "Score: " + fourCornersScoreNumber;
    }

    public void FourCornersHighScoreSystem()
    {

        fourCornersHighScoreText.text = "Highscore: " + fourCornersHighScoreNumber;

        if (fourCornersHighScoreNumber < fourCornersScoreNumber)
        {
            fourCornersHighScoreNumber = fourCornersScoreNumber;
            PlayerPrefs.SetInt("FourCornersHighscore", fourCornersScoreNumber);
        }

    }

    public void CircleScoreSystem()
    {
        circleScoreNumber += 1;
        circleScoreText.text = "Score: " + circleScoreNumber;
    }

    public void CircleHighScoreSystem()
    {

        circleHighScoreText.text = "Highscore: " + circleHighScoreNumber;

        if (circleHighScoreNumber < circleScoreNumber)
        {
            circleHighScoreNumber = circleScoreNumber;
            PlayerPrefs.SetInt("CircleHighscore", circleScoreNumber);
        }

    }



}
