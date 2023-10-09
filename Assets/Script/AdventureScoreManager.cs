using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class AdventureScoreManager : MonoBehaviour
{

    [Header("Adventure Food Left")]
    [SerializeField] public Text foodLeftText;
    [SerializeField] public static int foodLeftNumber;
    [SerializeField] public static int noFoodLeft;

    [SerializeField] private GameObject blockObstacle;

    private void Start()
    {
        foodLeftNumber = 3;
    }

    private void Update()
    {
        foodLeftText.text = foodLeftNumber.ToString();
    }

    public void SubtractFoodSystem()
    {
        foodLeftNumber -= 1;
        foodLeftText.text = foodLeftNumber.ToString();

        if(foodLeftNumber == 0)
        {
            blockObstacle.gameObject.SetActive(false);
        }
    }



}
