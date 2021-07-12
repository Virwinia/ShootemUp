using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuGameOver : MonoBehaviour
{
    // SCENES ---
    public void GoToScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void ReloadScene()
    {
        // Check if the name of the current Active Scene is your first Scene.
        if (SceneManager.GetActiveScene().name != StaticValues.SCENE_GAME)
            GoToScene(StaticValues.SCENE_GAME);
    }


}
