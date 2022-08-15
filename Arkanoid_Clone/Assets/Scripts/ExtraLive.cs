using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraLive : MonoBehaviour
{
    private int speed = 3;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameManager.instance.Lifes++;
            Destroy(gameObject);
        }
    }
   
    private void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y - speed * Time.deltaTime, transform.position.z);
    }


}
