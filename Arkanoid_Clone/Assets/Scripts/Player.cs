using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour , IDataPersistence
{
    public static Player instance;

    public float playerSpeed;
  
    public float currentEnlargeTime = -1;

    private float moveDirection;

    public bool boostPlayer = false;

    private Vector3 startingPositiion;
    private Rigidbody2D rb;

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
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        startingPositiion = transform.position;
    }

    void Update()
    {
        moveDirection = Settings.instance.playerControlls.KeyBoard.Move.ReadValue<float>();

       /*
       if (Settings.instance.playerControlls.KeyBoard.TestKey.triggered)
       {
           Instantiate(Settings.instance.enlargePowerUpPrefab, GameManager.instance.test.position, Quaternion.identity);
       }
      */
        if (currentEnlargeTime > 0)
        {
            currentEnlargeTime -= Time.deltaTime;
            EnlargeFor();
        }
    }
 
    private void FixedUpdate()
    {
        HandleInputKeyboard();
    }

    public void EnlargeFor()
    {
        if (instance.currentEnlargeTime > 0)
        {
            instance.transform.localScale = new Vector3(Settings.instance.enlargedScale, 1.5f, 1);
        }
        else
        {
            instance.transform.localScale = new Vector3(Settings.instance.normalScale, 1.5f, 1);
        }

      
    }
    private void HandleInputKeyboard()
    {
        rb.velocity = new Vector2 (moveDirection * playerSpeed, transform.position.y);
    }
   
    public void LoadData(GameData data)
    {
        this.transform.position = data.playerPosition;
        this.transform.localScale = data.playerScale;
        this.currentEnlargeTime = data.currentEnlargeTimeData;
       
    }

    public void SaveData( GameData data)
    {
        data.playerPosition = this.transform.position;

        data.playerScale = this.transform.localScale;

        data.currentEnlargeTimeData = this.currentEnlargeTime;

    }
}
