using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarScript : MonoBehaviour
{
    public int numStars = 0;

    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.tag == "Player") {
            Destroy(gameObject);
            Debug.Log("Player hit a star!");
            numStars += 1;
        }
    }
}
