using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// The platform that will disappear immediately after player step on
public class PlatformDisappear : MonoBehaviour
{
    public float jumpForce = 10f;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.y <= 0f && collision.gameObject.CompareTag("Player"))
        {
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                Vector2 velocity = rb.velocity;
                velocity.y = jumpForce;
                rb.velocity = velocity;
                transform.gameObject.SetActive(false);
            }            
        }
    }
}
