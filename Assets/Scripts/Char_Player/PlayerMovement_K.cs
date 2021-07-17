using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement_K : MonoBehaviour
{
    [Space] [SerializeField] Rigidbody2D rb;
    [SerializeField] GameObject canvasStick;

    [ReadOnly] [SerializeField] float xLeftLimit, xRightLimit, yDownLimit, yUpLimit;

    float speed, horizontalMovement, verticalMovement;
    Vector2 shipVelocity;

    private void Start()
    {
        speed = PlayerDataHandler.playerDataInstance.speed;
    }

    private void Update() //--> controla frames
    {
        horizontalMovement = Input.GetAxis(StaticValues.AXIS_HORIZONTAL);
        verticalMovement = Input.GetAxis(StaticValues.AXIS_VERTICAL);
        shipVelocity = new Vector2(horizontalMovement, verticalMovement).normalized;
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, xLeftLimit, xRightLimit), Mathf.Clamp(transform.position.y, yDownLimit, yUpLimit), 0);
    }

    private void FixedUpdate() // --> controla la parte de físicas
    {
        rb.velocity = shipVelocity * speed;
        rb.position = new Vector3(Mathf.Clamp(rb.position.x, xLeftLimit, xRightLimit), Mathf.Clamp(rb.position.y, yDownLimit, yUpLimit), 0);
    }

    private void OnEnable()
    {
        if (canvasStick != null)
            canvasStick.SetActive(false);
    }

}