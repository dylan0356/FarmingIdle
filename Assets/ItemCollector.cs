using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemCollector : MonoBehaviour
{
    public int numStars = 0;
    [SerializeField] private TextMeshProUGUI starText;
    [SerializeField] private TextMeshProUGUI gameOverStarText;

    private void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.CompareTag("Star")) {
            Destroy(col.gameObject);
            numStars++;
            starText.text = "Stars: " + numStars;
            SoundManager.PlaySound("star");
        }
    }
}
