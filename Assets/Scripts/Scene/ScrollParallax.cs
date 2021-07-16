
using UnityEngine;

public class ScrollParallax : MonoBehaviour
{
    [SerializeField] float parallaxVelocity;
    Renderer rend;
    float value;
    bool isGameOver;

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
