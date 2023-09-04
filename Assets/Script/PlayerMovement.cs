using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    private Animator anim;
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

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Start()
    {
        ResetState();
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
                anim.Play("SnakeUp");
            }
            else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                input = Vector2.down;
                anim.Play("SnakeDown");
            }
        }
        // Only allow turning left or right while moving in the y-axis
        else if (direction.y != 0f)
        {
            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                input = Vector2.right;
                anim.Play("SnakeRight");
            }
            else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                input = Vector2.left;
                anim.Play("SnakeLeft");
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

    //growing the snake
    private void Grow()
    {
        //instantiate or appearing
        Transform segment = Instantiate(this.segmentPrefab);

        //position
        segment.position = segments[segments.Count - 1].position;
        segments.Add(segment);
    }

    // Resetting without using button or connect it with button
    private void ResetState()
    {
        for (int i = 1; i < segments.Count; i++)
        {
            Destroy(segments[i].gameObject);
        }

        segments.Clear();
        segments.Add(this.transform);

        for (int i = 1; i < this.initialSize; i++)
        {
            segments.Add(Instantiate(this.segmentPrefab));
        }

        this.transform.position = Vector3.zero;

    }

    public bool Occupies(float x, float y)
    {
        foreach (Transform segment in segments)
        {
            if (segment.position.x == x && segment.position.y == y)
            {
                return true;
            }
        }

        return false;
    }

    //snake collide food, snake will grow
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Food")
        {
            Grow();
            Debug.Log("Grow");
        }

        else if (collision.tag == "Obstacle")
        {
            Debug.Log("Lose");
            Destroy(gameObject);
            speed = 0f;
            speedMultiplier = 0f;
            GameOverScreen.gameObject.SetActive(true);
        }

        else if (collision.gameObject.CompareTag("Wall"))
        {

            Debug.Log("Walktrough");

            //right
            Vector3 position = transform.position;

            if (direction.x != 0f)
            {
                position.x = -collision.transform.position.x + direction.x;
            }
            //top
            else if (direction.y != 0f)
            {
                position.y = -collision.transform.position.y + direction.y;
            }

            transform.position = position;
        }
    }
}


