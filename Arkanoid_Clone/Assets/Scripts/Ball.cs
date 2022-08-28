using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float ballSpeed;
    public bool inPlay;
    public float timeToFullSpeed;

    private float currentBallDirection_y;
    private float currentBallDirection_x;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        inPlay = false;
    }

    void Update()
    {

        if (Settings.instance.playerControlls.KeyBoard.Launch.triggered && Time.timeScale != 0)
        {
            if (!inPlay)
            {
                Launch();
            }

        }
        if (!inPlay)
        {
            transform.position = new Vector3(GameManager.instance.startingBallPosition.position.x,
                                             GameManager.instance.startingBallPosition.position.y,
                                             GameManager.instance.startingBallPosition.position.z);
        }
    }

    private void FixedUpdate()
    {
        if (inPlay)
        {
            if (rb.velocity.y < ballSpeed || rb.velocity.y > ballSpeed)
            {
                if (rb.velocity.y > 0)
                {
                    currentBallDirection_y = 1;
                }
                else if (rb.velocity.y < 0)
                {
                    currentBallDirection_y = -1;
                }
                else
                {
                    currentBallDirection_y = 0;
                }

                rb.velocity = new Vector2(rb.velocity.x, Mathf.SmoothStep(rb.velocity.y, ballSpeed * currentBallDirection_y, 2));
            }     

        }
    }


    private void Launch()
    {

        inPlay = true;
        float ballDirection = Player.instance.GetComponent<Rigidbody2D>().velocity.normalized.x;
        // Debug.Log($"Ball direction on launch {ballDirection}");
        rb.velocity = new Vector2(ballDirection * ballSpeed, ballSpeed);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        SoundManager.PlaySound(Settings.instance.ballBounce, "BallBounce");

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "DeathWall")
        {
            SoundManager.PlaySound(Settings.instance.deathSound, "GameOverSound");

            GameManager.instance.Lifes--;

            if (GameManager.instance.Lifes != 0)
            {
                BallManager.instance.SpawnBall(GameManager.instance.startingBallPosition);
            }

            DestroyBall();
        }
    }

    public void DestroyBall()
    {
        Destroy(gameObject);
    }


}
