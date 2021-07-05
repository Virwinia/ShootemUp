using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationMovement : MonoBehaviour
{
    [Space]
    [Tooltip("Rotation angle per second")]
    [SerializeField] int rotationSpeed = 100;
    Vector3 startPosition;

    private void Awake()
    {
        startPosition = this.transform.position;
    }

    void Update()
    {
        //REPASAR SCRIPT, QUIERO QUE ROTE SOBRE EJE X

        //Handle rotation
        transform.Rotate(Vector3.left, rotationSpeed * Time.deltaTime, Space.Self);
    }
}
