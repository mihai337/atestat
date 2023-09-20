using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public float jumpForce;
    public Rigidbody2D rb;
    public Transform player;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Vector2 movement = new Vector2(rb.velocity.x, jumpForce);
            rb.velocity = movement;
        }
    }
}
