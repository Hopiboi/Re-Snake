using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class AdventureFood: MonoBehaviour
{

    public GameObject blockObstacle;

    //Accessing ScoreManager script
    private AdventureScoreManager adventureScore;


    void Start()
    {
        adventureScore = FindAnyObjectByType<AdventureScoreManager>();
    }

    private void Update()
    {

    }

    //Trigger to make the food go into a random position
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {

            adventureScore.SubtractFoodSystem();

            //blockObstacle.gameObject.SetActive(false);
            Destroy(gameObject);

        }
    }

}
