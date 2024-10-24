using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball_movement : MonoBehaviour
{
    public float startspeed;
    public float extraspeed;
    public float maxextraspeed;

    private AudioSource audioSource;

    private int hitcounter = 0;
    private bool isGameOver = false;

    private Rigidbody2D rb;
    private ScoreManager scoreManager;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        rb = GetComponent<Rigidbody2D>();
        scoreManager = FindObjectOfType<ScoreManager>(); // Find the ScoreManager in the scene
        LaunchBall();
    }

    private void Update()
    {
        if (!isGameOver)
        {
            CheckGameOverCondition();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        audioSource.Play();

        if (!isGameOver)
        {
            IncreaseHitCounter();
            AdjustBallSpeed();
            CheckGameOverCondition();
        }
    }

    private void AdjustBallSpeed()
    {
        float ballspeed = startspeed + hitcounter * extraspeed;
        ballspeed = Mathf.Min(ballspeed, startspeed + maxextraspeed);
        rb.velocity = rb.velocity.normalized * ballspeed;
    }

    private void IncreaseHitCounter()
    {
        if (hitcounter * extraspeed < maxextraspeed)
        {
            hitcounter++;
        }
    }

    private void LaunchBall()
    {
        Vector2 launchDirection = new Vector2(-1, 0);
        rb.velocity = launchDirection.normalized * startspeed;
    }

    private void CheckGameOverCondition()
    {
        if (transform.position.y <= -5.0f)
        {
            isGameOver = true;
            scoreManager.GameOver();
            SceneManager.LoadScene(2); // Load the game over scene
        }
    }
}
