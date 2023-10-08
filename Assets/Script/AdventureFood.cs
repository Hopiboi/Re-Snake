using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class AdventureFood: MonoBehaviour
{

    //Accessing ScoreManager script
    private ScoreManager score;


    void Start()
    {
        //Storing the highscore even reloading the game
        if (PlayerPrefs.HasKey("Highscore"))
          {
             ScoreManager.highScoreNumber = PlayerPrefs.GetInt("Highscore");
          }

    }

    private void Update()
    {

    }

    //Trigger to make the food go into a random position
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Destroy(gameObject);

        }
    }

}
