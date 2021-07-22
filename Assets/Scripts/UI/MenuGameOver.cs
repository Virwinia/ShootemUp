using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/*
    UI COLOR GUIDE ----

    Red ------- 234, 58, 109
    Dark Red -- 76, 34, 38
    Blue -----  90, 248, 218
    Dark Blue - 23, 58, 56

*/

public class MenuGameOver : MonoBehaviour
{
    [Space]
    [SerializeField] Text txtGameOver;

    [Space]
    [SerializeField] Text recordTitle;
    public Text maxScore;

    private void Start()
    {
        recordTitle.color = new Color32(90, 248, 218, 255);
    }

    public void RecordWasBeaten(bool isBeaten)
    {
        recordTitle.text = isBeaten ? "You beat the record!" : "Yet, unbeatable...";
    }

    public void GoToScene(string sceneName) // --- not used yet
    {
        SceneManager.LoadScene(sceneName);
    }

    public void ReloadScene()               // --- not used yet - Play Again
    {
        // Check if the name of the current Active Scene is your first Scene.
        if (SceneManager.GetActiveScene().name != StaticValues.SCENE_GAME)
            GoToScene(StaticValues.SCENE_GAME);
    }

    // BUTTON --- Call on click the following events
    public void PlayGame()                  // Call from button Play in scene SpaceScene
    {
        GoToScene(StaticValues.SCENE_GAME);
    }

    public void QuitGame()                  // Call from button Quit in scene SpaceScene
    {
        Application.Quit();
    }
    //------------------
}
