using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class FourCornersFoodScript : MonoBehaviour
{
    //Collider
    public Collider2D gridArea;

    //Accessing ScoreManager script
    private ScoreManager score;

    //The way to access another script
    private PlayerMovement snake;


    void Start()
    {
        //Storing the highscore even reloading the game
          if (PlayerPrefs.HasKey("FourCornersHighscore"))
          {
            ScoreManager.noWallHighScoreNumber = PlayerPrefs.GetInt("FourCornersHighscore   ");
          }   

        snake = FindObjectOfType<PlayerMovement>();
        score = FindAnyObjectByType<ScoreManager>();
    }

    private void Update()
    {
        score.FourCornersHighScoreSystem();
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

            score.FourCornersScoreSystem();

        }
    }

}
