using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuSelector : MonoBehaviour
{

    private FoodScript score;

    // Start is called before the first frame update
    void Start()
    {
        score = FindObjectOfType<FoodScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RetryScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        FoodScript.scoreNumber = 0;
    }

    public void ClassicLevel()
    {
        SceneManager.LoadScene("Classic");
    }

    public void BackScene()
    {
        SceneManager.LoadScene("Re Snake");
    }

    public void QuitButton()
    {
        Debug.Log("Quit");
    }
}
