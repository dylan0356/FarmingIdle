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
            //get the object gamemanager and call the playerdeath function
            GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManage>().PlayerDeath();
            
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

    private void Start() {
        //get the shader cmaterial from current object
        Material mat = GetComponent<Renderer>().material;

        //create a new color that is R value 255 and random G and B values
        Color surfaceInput = new Color(5, Random.Range(0, 10), Random.Range(0, 10));

        //set the surfaceInput glow color to a random color where R is 255
        mat.SetColor("_GlowColor", surfaceInput);

    }
}
