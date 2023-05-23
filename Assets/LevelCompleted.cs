using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCompleted : MonoBehaviour
{

    [SerializeField] private GameObject levelCompletedCanvas;
    [SerializeField] private GameObject mainCanvas;

    public void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.CompareTag("Player")) {
            SoundManager.PlaySound("levelComplete");
            //set player to inactive
            col.gameObject.SetActive(false);
            //set the LevelCompletedCanvas to active
            levelCompletedCanvas.SetActive(true);
            //set the MainCanvas to inactive
            mainCanvas.SetActive(false);

        }
    }
}
