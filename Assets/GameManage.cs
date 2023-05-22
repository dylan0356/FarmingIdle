using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManage : MonoBehaviour
{

    [SerializeField] private GameObject gameOverCanvas;
    [SerializeField] private GameObject mainCanvas;

    public float lastPlayerY = 0f;




    public void PlayerDeath() {

        //set the lastPlayerY to the absolute value of the player's y position
        lastPlayerY = Mathf.Abs(GameObject.FindGameObjectWithTag("Player").transform.position.y);
        
        //set the player to inactive
        GameObject.FindGameObjectWithTag("Player").SetActive(false);
        //set the GameOverCanvas to active
        gameOverCanvas.SetActive(true);
        //hide the MainCanvas
        mainCanvas.SetActive(false);

        
    }

}
