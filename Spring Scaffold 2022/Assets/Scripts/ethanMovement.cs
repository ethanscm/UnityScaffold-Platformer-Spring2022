using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ethanMovement : MonoBehaviour
{
    private Rigidbody2D body;
    private float moveSpeed = 10;
    private float jumpSpeed = 10;
    bool isJumping = false;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        body.velocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, body.velocity.y);

        if (Input.GetKey(KeyCode.Space) && !isJumping)
        {
            body.velocity = new Vector2(body.velocity.x, jumpSpeed);
            isJumping = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }
}