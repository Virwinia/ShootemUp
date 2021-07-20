using System.Collections;
using UnityEngine;

public class FadeIn : MonoBehaviour
{
    [SerializeField] float fadeTime = 1;
    CanvasGroup canvasGroup;

    private void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        canvasGroup.interactable = false;
        SetAlphaValueToZero();
    }

    public void SetAlphaValueToZero()
    {
        canvasGroup.alpha = 0;
    }

    // Called in Inspector > Canvas > ButtonryMenu > Button Info > OnClick.
    // Also referenced from MM for chained FadeIn.
    public void FadeInCall()
    {
        StartCoroutine(DoFade());
    }

    IEnumerator DoFade()
    {
        while (canvasGroup.alpha < 1)
        {
            canvasGroup.alpha += Time.deltaTime / fadeTime;
            yield return null;
        }
        EventCallFadeDone();
    }

    // Event Call - listener is in MainMenu -----
    public delegate void FadeInDelegate();
    // public event FadeInDelegate FadeIsCall;
    public event FadeInDelegate FadeIsDone;
    public void EventCallFadeDone()
    {
        if (FadeIsDone != null) FadeIsDone();
    }
}
