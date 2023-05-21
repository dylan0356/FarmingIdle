using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    public int numStars = 0;

    private void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.CompareTag("Star")) {
            Destroy(col.gameObject);
            numStars++;
            Debug.Log("Stars: " + numStars);
        }
    }
}
