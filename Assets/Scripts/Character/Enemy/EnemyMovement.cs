
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float amplitude, ySpeed, alphaDelta;
    float alpha, xStartPos;
    private void Start()
    {
        xStartPos = transform.position.x;
    }
    private void Update()
    {
        transform.position = new Vector3(amplitude * Mathf.Sin(alpha) + xStartPos, transform.position.y - ySpeed * Time.deltaTime, transform.position.z);
        alpha += (alphaDelta + Time.deltaTime) / 1000;

    }
}
