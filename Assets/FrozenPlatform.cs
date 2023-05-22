using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrozenPlatform : MonoBehaviour
{
    void OnCollisionEnter2D (Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            //call the playerDeath function from the GameManager
            GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManage>().PlayerDeath();
        }
    }
}
