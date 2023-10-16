using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AdventurePlayerMovement : MonoBehaviour
{

    public GameObject GameOverScreen;

    //Speed and multiply it, speed * multiply

    [Header("Speed")]
    [SerializeField] private float speed = 20f;
    [SerializeField] private float speedMultiplier = 1f;

    private float nextUpdate;

    //first direction when the game start
    private Vector2 direction = Vector2.right;

    //Segments
    [Header("Snake Segment")]
    [SerializeField] private List<Transform> segments = new List<Transform>();
    [SerializeField] private Transform segmentPrefab;
    [SerializeField] private int initialSize = 1;     //size of the snake at the beginning and adding

    //Input
    private Vector2 input;

    void Start()
    {
        SnakeState();
    }



    //single frame, and for inputs
    void Update()
    {
        Movement();
    }

    private void Movement()
    {

        // Only allow turning up or down while moving in the x-axis
        if (direction.x != 0f)
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                input = Vector2.up;
            }
            else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                input = Vector2.down;
            }
        }
        // Only allow turning left or right while moving in the y-axis
        else if (direction.y != 0f)
        {
            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                input = Vector2.right;
            }
            else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                input = Vector2.left;
            }
        }


    }

    //fixed time, physics
    private void FixedUpdate()
    {
        //next update
        if (Time.time < nextUpdate)
        {
            return;
        }


        if (input != Vector2.zero)
        {
            direction = input;
        }

        //position and following
        for (int i = segments.Count - 1; i > 0; i--)
        {
            segments[i].position = segments[i - 1].position;
        }

        //movement  
        //mathf is about rounding the number if its decimal of an integer
        float x = Mathf.Round(transform.position.x) + direction.x;
        float y = Mathf.Round(transform.position.y) + direction.y;


        //speed of movement of the snake
        transform.position = new Vector2(x, y);
        nextUpdate = Time.time + (1f / (speed * speedMultiplier));
    }



    // Resetting without using button or connect it with button
    private void SnakeState()
    {
        segments.Add(this.transform);

        for (int i = 1; i < this.initialSize; i++)
        {
            segments.Add(Instantiate(this.segmentPrefab));
        }

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Obstacle")
        {
            Destroy(gameObject);
            speed = 0f;
            speedMultiplier = 0f;
            GameOverScreen.gameObject.SetActive(true);
        }

        else if (collision.tag == "Goal")
        {

            SceneManager.LoadScene("Adventure 2");

        }

        else if (collision.tag == "Goal2")
        {

            SceneManager.LoadScene("Adventure 3");

        }

        else if (collision.tag == "Goal3")
        {

            SceneManager.LoadScene("Congratulation");

        }


    }

}


