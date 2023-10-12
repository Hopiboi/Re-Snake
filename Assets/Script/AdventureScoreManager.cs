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

    [Header("Adventure Food Left2")]
    [SerializeField] public Text foodLeftText2;
    [SerializeField] public static int foodLeftNumber2;
    [SerializeField] public static int noFoodLeft2;


    [Header("Game Object")]
    [SerializeField] private GameObject blockObstacle;

    private void Start()
    {
        foodLeftNumber = 3;
        foodLeftNumber2 = 4;
    }

    private void Update()
    {
        
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

    public void SubtractFoodSystem2()
    {
        foodLeftNumber2 -= 1;
        foodLeftText2.text = foodLeftNumber2.ToString();

        if (foodLeftNumber2 == 0)
        {
            blockObstacle.gameObject.SetActive(false);
        }
    }

}
