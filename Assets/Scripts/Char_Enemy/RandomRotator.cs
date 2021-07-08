
using UnityEngine;

public class RandomRotator : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float tumble;

    void Start()
    {
        rb.angularVelocity = Random.insideUnitSphere.x * tumble;
    }
}
