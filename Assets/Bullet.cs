using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D (Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            //call the playerDeath function from the GameManager
            GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManage>().PlayerDeath();
        } else if (col.gameObject.tag == "Wall") {
            Destroy(gameObject);
        }
    }


}
