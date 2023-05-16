using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingPlatform : MonoBehaviour
{
    private bool moving = true;
    [SerializeField] float speed = 5f;
    [SerializeField] float direction = 1;
    [SerializeField] float leftLimit = -9;
    [SerializeField] float rightLimit = 9;

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.tag == "Player") {
            //MAKE BETTER PLAYER KILLING CODE LOL
            Destroy(collision.gameObject);
            Debug.Log("Player has been killed");
            
        }
    }

    private void FixedUpdate() 
    {
        if (moving)
        {
            if (transform.position.x > rightLimit)
            {
                direction = -1;
            }
            else if (transform.position.x < leftLimit)
            {
                direction = 1;
            }
            transform.Translate(Vector2.right * speed * direction * Time.deltaTime);
        }
    }
}
