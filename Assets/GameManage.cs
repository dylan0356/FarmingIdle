using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManage : MonoBehaviour
{

    [SerializeField] private GameObject gameOverCanvas;
    [SerializeField] private GameObject mainCanvas;

    public float lastPlayerY = 0f;
    [SerializeField] private float currentPlayerY = 0f;

    [SerializeField] private GameObject levelLight;




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

    private void Start() {
        //find gameobject LevelLight
        levelLight = GameObject.FindGameObjectWithTag("LevelLight");


    }

    private void FixedUpdate() {
        //set the currentPlayerY to the absolute value of the player's y position
        currentPlayerY = Mathf.Abs(GameObject.FindGameObjectWithTag("Player").transform.position.y);

        //set the currentPlayerY to the inverse -50%
        currentPlayerY = 0.5f - (currentPlayerY / 500);

        //change the LevelLight objects m_Intensity to the lastPlayerY
        levelLight.GetComponent<UnityEngine.Rendering.Universal.Light2D>().intensity = currentPlayerY;

        
        
        
    }

}
