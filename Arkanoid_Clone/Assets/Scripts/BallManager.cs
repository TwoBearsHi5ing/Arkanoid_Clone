using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    public static BallManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        { 
            Destroy(gameObject);
        }
    }
    public void SpawnBall(Transform spawnPosition)
    {
        Instantiate(Settings.instance.ballPrefab, spawnPosition.position, Quaternion.identity);
    }

    private void Start()
    {
        SpawnBall(GameManager.instance.startingBallPosition);
    }
}
