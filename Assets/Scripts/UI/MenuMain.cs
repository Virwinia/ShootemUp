
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuMain : MonoBehaviour
{
    // [SerializeField] GameObject canvasMain;
    // [SerializeField] GameObject canvasSplash;

    public void GoToPlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    // public void ReloadScene()
    // {
    //     // Check if the name of the current Active Scene is your first Scene.
    //     if (SceneManager.GetActiveScene().name != StaticValues.SCENE_GAME)
    //         GoToScene(StaticValues.SCENE_GAME);
    // }
}
