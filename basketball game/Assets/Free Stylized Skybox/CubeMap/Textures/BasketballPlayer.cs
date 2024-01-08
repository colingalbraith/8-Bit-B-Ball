using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketballPlayer : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    public int maxJumps = 3;
    public float groundBounceForce = 10f;

    private Rigidbody2D rb;
    private int remainingJumps;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        remainingJumps = maxJumps;
    }

    private void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");

        Vector2 movement = new Vector2(moveHorizontal, rb.velocity.y);
        rb.velocity = movement * moveSpeed;

        if (Input.GetKeyDown(KeyCode.Space) && remainingJumps > 0)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            remainingJumps--;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Vector2 bounceDirection = Vector2.Reflect(rb.velocity, collision.contacts[0].normal);
            rb.velocity = bounceDirection.normalized * groundBounceForce;
            remainingJumps = maxJumps;
        }
    }
}

