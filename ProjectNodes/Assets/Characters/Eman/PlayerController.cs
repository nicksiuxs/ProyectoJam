using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Range(0, 0.3f)] private float m_MovementSmoothing = 0.02f;
    private Rigidbody2D rigidBody;
    private Vector3 m_velocity = Vector3.zero;

    float horizontalMove = 0f;
    public float runSpeed = 40f;

    public float jumpForce;
    private bool isGrounded = false;

    public void setIsGrounded(bool isGrounded)
    {
        this.isGrounded = isGrounded;
    }

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float inputMovement = Input.GetAxisRaw("Horizontal");
        horizontalMove = inputMovement * runSpeed;

        if (Input.GetButtonDown("Jump"))
        {
            rigidBody.AddForce(new Vector2(0f, jumpForce));
        }
    }

    private void FixedUpdate()
    {
        move(horizontalMove * Time.fixedDeltaTime);
    }
    public void move(float move)
    {
        Vector3 targetVelocity = new Vector2(move * 10f, rigidBody.velocity.y);
        rigidBody.velocity = Vector3.SmoothDamp(rigidBody.velocity, targetVelocity, ref m_velocity, m_MovementSmoothing);
    }
}
