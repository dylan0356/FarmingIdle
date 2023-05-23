using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    public void OpenScene() {
        SceneManager.LoadScene("Level1");
    }

    public void ReturnToLevelSelection() {
        SceneManager.LoadScene("LevelSelection");
    }
}
