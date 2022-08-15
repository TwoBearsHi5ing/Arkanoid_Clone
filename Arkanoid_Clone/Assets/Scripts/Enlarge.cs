using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enlarge : MonoBehaviour
{
    private int speed = 3;
    

    private SpriteRenderer sp;

    private void Start()
    {
        sp = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            sp.enabled = false;
            if (Player.instance.currentEnlargeTime + Settings.instance.EnlargeTime > Settings.instance.EnlargeTime)
            {
                Player.instance.currentEnlargeTime = Settings.instance.EnlargeTime;
            }
            else
            {
                Player.instance.currentEnlargeTime = Settings.instance.EnlargeTime;
            }
           


            //StartCoroutine(ApplyEffect()); 
        }
    }
    private void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y - speed * Time.deltaTime, transform.position.z);
    }

    /* public IEnumerator ApplyEffect()
     {
         Player.instance.transform.localScale = new Vector3(Settings.instance.enlargedScale, 1.5f, 1);

         yield return new WaitForSeconds(Settings.instance.EnlargeTime);

         Player.instance.transform.localScale = new Vector3(Settings.instance.normalScale, 1.5f, 1);

         Destroy(gameObject);
     }
    */

}
