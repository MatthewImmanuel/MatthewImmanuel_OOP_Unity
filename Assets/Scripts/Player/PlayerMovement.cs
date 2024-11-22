using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    [SerializeField] Vector2 maxSpeed;
    [SerializeField] Vector2 timeToFullSpeed;
    [SerializeField] Vector2 timeToStop;
    [SerializeField] Vector2 stopClamp;

    Vector2 moveDirection;
    Vector2 moveVelocity;
    Vector2 moveFriction;
    Vector2 stopFriction;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        moveVelocity = Vector2.zero;

        moveVelocity = 2 * maxSpeed / timeToFullSpeed;
        moveFriction = -2 * maxSpeed / (timeToFullSpeed)*(timeToFullSpeed);
        stopFriction = -2 * maxSpeed / (timeToStop)*(timeToStop);
    }

    public void Move()
    {
        moveDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;

        if (moveDirection != Vector2.zero)
        {
            Vector2 targetVelocity = moveDirection * maxSpeed;
            rb.velocity = Vector2.MoveTowards(rb.velocity, targetVelocity, moveVelocity.magnitude * Time.deltaTime);
        }
        else
        {
            Vector2 frictionForce = GetFriction();
            rb.velocity = Vector2.MoveTowards(rb.velocity, Vector2.zero, frictionForce.magnitude * Time.deltaTime);

            if (rb.velocity.magnitude < stopClamp.magnitude)
            {
                rb.velocity = Vector2.zero;
            }
        }

        rb.velocity = new Vector2(
            Mathf.Clamp(rb.velocity.x, -maxSpeed.x, maxSpeed.x),
            Mathf.Clamp(rb.velocity.y, -maxSpeed.y, maxSpeed.y)
        );

        MoveBound();
    }


    Vector2 GetFriction()
    {
        if (IsMoving())
        {
            return moveFriction;
        }
        else
        {
            return stopFriction;
        }
    }


    void MoveBound()
    {   
    // Dapatkan ukuran batas layar dari kamera
    Vector3 screenBottomLeft = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0));
    Vector3 screenTopRight = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 0));

    // Ambil posisi pesawat saat ini
    Vector3 currentPosition = rb.position;

    // Clamp posisi pesawat agar tetap dalam batasan x dari -8.5 ke 8.5 dan y maksimum 4.5
    currentPosition.x = Mathf.Clamp(currentPosition.x, -8.65f, 8.65f);
    currentPosition.y = Mathf.Clamp(currentPosition.y, -5f, 4.5f);

    // Set posisi pesawat yang telah di-clamp
    rb.position = currentPosition;
    }

    public bool IsMoving()
    {
        return rb.velocity.magnitude > 0.01f;
    }
}