using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuSelector : MonoBehaviour
{

    private ScoreManager score;

    void Start()
    {
        score = FindObjectOfType<ScoreManager>();
    }

    void Update()
    {
        
    }

    public void RetryScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        ScoreManager.scoreNumber = 0;
        ScoreManager.noWallScoreNumber = 0;
        ScoreManager.fourCornersScoreNumber = 0;
        ScoreManager.circleScoreNumber = 0;
        ScoreManager.middleScoreNumber = 0;
        ScoreManager.trainYardScoreNumber = 0;
    }

    public void ClassicLevel()
    {
        SceneManager.LoadScene("Classic");
    }

    public void NoWallLevel()
    {
        SceneManager.LoadScene("No Wall");
    }
       
    public void FourCornersLevel()
    {
        SceneManager.LoadScene("Four Corners");
    }

    public void CircleLevel()
    {
        SceneManager.LoadScene("Circle");
    }
    public void MiddleLevel()
    {
        SceneManager.LoadScene("Middle");
    }

    public void TrainYardLevel()
    {
        SceneManager.LoadScene("Train Yard");
    }

    public void BackScene()
    {
        SceneManager.LoadScene("Re Snake");
        ScoreManager.scoreNumber = 0;
        ScoreManager.noWallScoreNumber = 0;
        ScoreManager.fourCornersScoreNumber = 0;
        ScoreManager.circleScoreNumber = 0;
        ScoreManager.middleScoreNumber = 0;
        ScoreManager.trainYardScoreNumber = 0;
    }

    public void QuitButton()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
}
