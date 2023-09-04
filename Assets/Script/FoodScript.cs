using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class FoodScript : MonoBehaviour
{
    //Collider
    public Collider2D gridArea;

    //The way to access another script
    private PlayerMovement snake;

    [Header("Score")]
    [SerializeField] private Text scoreText;
    [SerializeField] public static int scoreNumber;
    [SerializeField] private Text highScoreText;
    [SerializeField] private static int highScoreNumber;

    void Start()
    {
        //Storing the highscore even reloading the game
        if (PlayerPrefs.HasKey("Highscore"))
        {
           highScoreNumber = PlayerPrefs.GetInt("Highscore");
        }


        snake = FindObjectOfType<PlayerMovement>();
    }

    private void Update()
    {
        HighScoreSystem();
    }

    private void RandomFoodPosition()
    {
        //GridArea
        Bounds bounds = gridArea.bounds;

        //random position or location
        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);

        //Rounding off the numbers
        x = Mathf.Round(x);
        y = Mathf.Round(y);


        // Prevent food from spawning on the snake
        while (snake.Occupies(x, y))
        {
            x++;

            if (x > bounds.max.x)
            {
                x = bounds.min.x;
                y++;

                if (y > bounds.max.y)
                {
                    y = bounds.min.y;
                }
            }
        }

        //position change
        this.transform.position = new Vector3(Mathf.Round(x), Mathf.Round(y), 0);
    }

    //Trigger to make the food go into a random position
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            RandomFoodPosition();

            ScoreSystem();

        }
    }

    //Scoring System
    private void ScoreSystem()
    {
        scoreNumber += 1;
        scoreText.text = "Score: " + scoreNumber;
    }

    //Highscore system
    private void HighScoreSystem()
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
