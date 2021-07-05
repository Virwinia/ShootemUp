using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollParallax : MonoBehaviour
{
    Renderer rend;

    [SerializeField]
    float parallaxVelocity;

    [SerializeField]
    bool isGameOver;

    [SerializeField]
    float value;

    private void Awake()
    {
        rend = GetComponent<Renderer>();
    }

    void Update()
    {
        if (!isGameOver)
        {
            value += Time.deltaTime;
            rend.material.mainTextureOffset = new Vector2(0, (value) * parallaxVelocity / 100);
        }
    }

    public void GameOver()
    {
        isGameOver = true;
    }
}
