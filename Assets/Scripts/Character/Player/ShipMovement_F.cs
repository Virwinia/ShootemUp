using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement_F : MonoBehaviour
{
    [Space]     [SerializeField] float moveSpeed = 150f;
    // [SerializeField] float maxSpeed = 20f;  //DEPRECTAED
    float speed;
    Vector3 touchPosition;
    Rigidbody2D rb;
    Vector3 direction;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        SetSpeedInPlayer();
    }

    private void Update()
    {
        ShipMove();
    }

    public void SetSpeedInPlayer()
    {
        speed = PlayerDataHandler.playerDataInstance.speed;
    }

    void ShipMove()
    {
        if (Input.touchCount > 0)
        {
            Touch t = Input.GetTouch(0);

            touchPosition = Camera.main.ScreenToWorldPoint(t.position) + new Vector3(0, 1f, 0);
            touchPosition.z = 0;
            direction = (touchPosition - transform.position);
            rb.velocity = new Vector2(direction.x, direction.y) * Time.deltaTime * moveSpeed;

            if (rb.velocity.magnitude > speed)
            {
                rb.velocity = Vector3.ClampMagnitude(rb.velocity, speed);
            }

            if (t.phase == TouchPhase.Ended)
                rb.velocity = Vector2.zero;
        }
    }
}
