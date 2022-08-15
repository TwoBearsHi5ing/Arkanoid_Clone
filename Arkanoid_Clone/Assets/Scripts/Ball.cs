using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float ballSpeed;
    public bool inPlay;
  

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
        
    }
    private void Launch()
    {
        inPlay = true;
        float ballDirection = Player.instance.GetComponent<Rigidbody2D>().velocity.normalized.x;
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

            Destroy(gameObject);
        }  
    }

    public void DestroyBall()
    {
        Destroy(gameObject);
    }

   
}
