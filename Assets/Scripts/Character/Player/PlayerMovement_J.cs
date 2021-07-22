using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement_J : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] GameObject canvasStick;
    [ReadOnly] [SerializeField] float xLeftLimit, xRightLimit, yDownLimit, yUpLimit;
    float speed, horizontalMovement, verticalMovement;
    Vector2 shipVelocity;
    JoyStickControlsMobile joystickMobile;

    private void Start()
    {
        if (canvasStick != null)
            if (!joystickMobile.gameObject.activeInHierarchy) canvasStick.SetActive(true);
            else Debug.Log("Missing reference for " + joystickMobile.name + " in " + this.gameObject.name);

        joystickMobile = canvasStick.GetComponentInChildren<JoyStickControlsMobile>();

        SetSpeedInPlayer();
    }

    // private void OnEnable()
    // {
    //     if (canvasStick != null)
    //         canvasStick.SetActive(true);
    // }

    public void SetSpeedInPlayer()
    {
        speed = PlayerDataHandler.playerDataInstance.speed;
    }

    private void Update()
    {
        horizontalMovement = joystickMobile.horizontal;
        verticalMovement = joystickMobile.vertical;
        shipVelocity = new Vector2(horizontalMovement, verticalMovement).normalized;
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, xLeftLimit, xRightLimit), Mathf.Clamp(transform.position.y, yDownLimit, yUpLimit), 0);
    }

    private void FixedUpdate()
    {
        rb.velocity = shipVelocity * speed;
        rb.position = new Vector2(Mathf.Clamp(rb.position.x, xLeftLimit, xRightLimit), Mathf.Clamp(rb.position.y, yDownLimit, yUpLimit));
    }

}
