using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManage : MonoBehaviour
{

    [SerializeField] private GameObject gameOverCanvas;
    [SerializeField] private GameObject mainCanvas;

    public float lastPlayerY = 0f;
    [SerializeField] private float currentPlayerY = 0f;

    [SerializeField] private GameObject levelLight;

    [SerializeField] private TextMeshProUGUI starsText;
    [SerializeField] private TextMeshProUGUI percentageCompletionText;
    [SerializeField] private TextMeshProUGUI percentageCompletionTextMainCanvas;
    private GameObject player;




    public void PlayerDeath() {

        //set the lastPlayerY to the absolute value of the player's y position
        lastPlayerY = Mathf.Abs(GameObject.FindGameObjectWithTag("Player").transform.position.y);

        //set stars on GameOverCanvas to the stars from the Player item collector script
        starsText.text = "Stars: " + player.GetComponent<ItemCollector>().numStars.ToString() + "/3";

        //set text Completion on GameOverCanvas to PercentageCompletion text from main cavas
        percentageCompletionText.text = "Completion: " + percentageCompletionTextMainCanvas.text;

        SoundManager.PlaySound("playerDeath");

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

        //find gameobject Player
        player = GameObject.FindGameObjectWithTag("Player");


    }

    private void FixedUpdate() {
        //set the currentPlayerY to the absolute value of the player's y position
        currentPlayerY = Mathf.Abs(GameObject.FindGameObjectWithTag("Player").transform.position.y);

        //set the currentPlayerY to the inverse -50%
        currentPlayerY = 0.5f - (currentPlayerY / 500);

        //change the LevelLight objects m_Intensity to the lastPlayerY
        levelLight.GetComponent<UnityEngine.Rendering.Universal.Light2D>().intensity = currentPlayerY; 
    }

    public void RestartLevel() {
        //reload the current scene
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }

}
