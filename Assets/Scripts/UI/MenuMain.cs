
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuMain : MonoBehaviour
{
    [Space]
    [Header("Assets in Canvas MainMenu")]
    [SerializeField] GameObject buttonryMenu;

    [Space]
    [Header("Assets in Canvas Info")]
    [SerializeField] GameObject panelInfo;
    [SerializeField] GameObject textInfo, buttonryInfo;
    [SerializeField] float timeToShowButtonInfo = 2f;
    FadeIn fadeIn;
    bool isFirstTime;   // is the info panel shown for fist time?

    private void Start()
    {
        CanvasSwitcher(buttonryInfo, 0);

        fadeIn = panelInfo.gameObject.GetComponent<FadeIn>();
        fadeIn.FadeIsDone += ListenerFadeIn;    // Event listener - call is in the script named FadeIn.
    }

    // BUTTONS IN GAME ---
    public void GoToGame()              // Called in Inspector > Canvas > ButtonPlay > OnClick.
    {
        SceneManager.LoadScene(1);
        AudioManager.audioManagerInstance.PlaySound(0);
    }

    public void QuitGame()              // Called in Inspector > Canvas > ButtonQuit > OnClick.
    {
        Application.Quit();
        AudioManager.audioManagerInstance.PlaySound(1);
    }

    public void HideButtonryMenu()      // Called in Inspector > Canvas > ButtonryMenu > Button Info > OnClick.
    {
        CanvasSwitcher(buttonryMenu, 0);
        AudioManager.audioManagerInstance.PlaySound(0);
    }

    public void ReturnBackToMainMenu()  // Called in Inspector > Canvas > ButtonryInfo > Button Back > OnClick.
    {
        FadeIn[] fades = this.gameObject.GetComponentsInChildren<FadeIn>();
        foreach (FadeIn fade in fades)
        {
            fade.SetAlphaValueToZero();
        }
        CanvasSwitcher(buttonryInfo, 0);
        CanvasSwitcher(buttonryMenu, 1);

        AudioManager.audioManagerInstance.PlaySound(1);
    }
    // --------------

    void CanvasSwitcher(GameObject obj, float i)
    {
        bool isActive = i > 0 ? true : false;   // Switcher --> 1 is Active // 0 is Disable.
        obj.SetActive(isActive);
    }

    // Listener for Delegate ---
    void ListenerFadeIn()
    {
        textInfo.GetComponent<FadeIn>().FadeInCall();

        timeToShowButtonInfo = isFirstTime ? 0 : timeToShowButtonInfo;  // IOD: first time the Player clicks on info, in order to prompt the reading, the buttons will take a time to show.
        Invoke("ShowButtonsInfo", timeToShowButtonInfo);                // After the first reading, buttons will show immediatly to avoid unnecessary waiting time.
    }

    void ShowButtonsInfo()
    {
        CanvasSwitcher(buttonryInfo, 1);
        isFirstTime = true;
    }
    // ------------

    private void OnDisable()
    {
        fadeIn.FadeIsDone -= ListenerFadeIn;    // Event listener - call is in FadeIn script ----
    }





}
