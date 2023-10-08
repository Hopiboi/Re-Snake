using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class AdventureScoreManager : MonoBehaviour
{
    //Variables

    [Header("Adventure Food Left")]
    [SerializeField] private Text foodLeftText;
    [SerializeField] public static int foodLefNumber;

    public void ScoreSystem()
    {
        foodLefNumber -= 1;
        foodLeftText.text = "Score: " + foodLefNumber;
    }



}
