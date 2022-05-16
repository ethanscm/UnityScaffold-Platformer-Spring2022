using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempMovement : MonoBehaviour
{
    private Rigidbody2D body;
    private float moveSpeed = 10;
    private float jumpSpeed = 10;
    bool isJumping = false;

    //for fall detection/respawn
    private Vector3 respawnPoint;
    public GameObject fallDetector;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        //added for setting respawn at start
        respawnPoint = transform.position;
    }

    void Update()
    {
        body.velocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, body.velocity.y);

        if (Input.GetKey(KeyCode.Space) && !isJumping)
        {
            body.velocity = new Vector2(body.velocity.x, jumpSpeed);
            isJumping = true;
        }

        //added for fall detection
        fallDetector.transform.position = new Vector2(transform.position.x, fallDetector.transform.position.y);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
        //added for fall detetion/checkpoints
        if (collision.tag == ("FallDetector"))
            transform.position = respawnPoint;

        if (collision.tag == ("Checkpoint"))
            respawnPoint = transform.position;
    }
}
