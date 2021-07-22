using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
    UI COLOR GUIDE ----

    Red ------- 234, 58, 109
    Dark Red -- 76, 34, 38
    Blue -----  90, 248, 218
    Dark Blue - 23, 58, 56

*/

public class MenuInGame : MonoBehaviour
{
    [Space]
    [Tooltip("Text shows in game, on top left side of the screen.")]
    public Text scoreRecord;
    [Range(0, 255)]
    [Tooltip("Value Zero (0) returns the max transparency to the text, while 255 returns the max opacity.")]
    [SerializeField] float alphaRecord;

    [Space]
    [Tooltip("Text shows in game, on top left side of the screen, under Scrore Record.")]
    public Text myScore;
    [Range(0, 255)]
    [Tooltip("Value Zero (0) returns the max transparency to the text, while 255 returns the max opacity.")]
    [SerializeField] float alphaMyScore;

    [Space]
    [SerializeField] GameObject textNoPause;
    [SerializeField] GameObject buttonPause;
    [SerializeField] GameObject buttonPauseFake;
    [SerializeField] GameObject buttonConfirmation;
    FadeIn fadeIn;
    bool isPaused;
    bool hasConfirmation;   // button confirmation is shown

    private void Start()
    {
        scoreRecord.color = new Color32(234, 58, 109, (byte)(alphaRecord)); // Record inks in red.
        myScore.color = new Color32(234, 58, 109, (byte)(alphaMyScore));    // Red color for scoring lower than record.

        fadeIn = textNoPause.GetComponent<FadeIn>();
        fadeIn.FadeIsDone += ShowButtonConfirmation;    // Event listener - call is in the script named FadeIn.

        if (buttonConfirmation.activeInHierarchy) buttonConfirmation.SetActive(false);
        if (buttonPauseFake.activeInHierarchy) buttonPauseFake.SetActive(false);
    }

    public void MyScoreBreaksTheRecord()
    {
        myScore.color = new Color32(90, 248, 218, (byte)(alphaMyScore));    // Blue color when reaches the record.
    }

    public void MyScore(int score)
    {
        myScore.text = "Score: " + score.ToString();
    }

    public void Record(int score)
    {
        scoreRecord.text = "Record: " + score.ToString();
    }

    public void ReplaceByFakeButton()       // Called in event OnClick for both buttonPause and buttonPauseFake. First of them is actived when starting the game.
    {
        isPaused = !isPaused;

        if (isPaused) buttonPause.GetComponent<Button>().interactable = false;  // If The Player clicks on buttonPause, in order to avoid double-clicks and unexpected issues with FadeIn,                                                                      
        else                                //  it will remain not interactive while textNoPause fades in. 
        {                                   // When Fade is done, buttonPause is replaced by buttonPauseFake. Now, if player clicks on it,
            fadeIn.SetAlphaValueToZero();   // Fade values set to zero,
            ShowButtonConfirmation();       // and buttons, buttonPauseFake and buttonPause, are switched again.
        }
    }

    void ShowButtonConfirmation()   // Listener - delegate is in FadeIn script and is released when fading (textNoPause) is done.
    {                               // Delegate is the first to call this method. Second time is if the Player clicks on buttonPauseFake.
        hasConfirmation = !hasConfirmation;

        buttonConfirmation.SetActive(hasConfirmation);  // Show button confirmation to quit.
        buttonPauseFake.SetActive(hasConfirmation);     // Show buttonPauseFake.

        buttonPause.SetActive(!hasConfirmation);                // Hide buttonPauseFake.
        buttonPause.GetComponent<Button>().interactable = true; // Return back interactable behaviour to buttonPause (said after hiding button to avoid misbehaviours if Player quickly and continually click on button)
    }

    private void OnDisable()
    {
        fadeIn.FadeIsDone -= ShowButtonConfirmation;
    }
}
