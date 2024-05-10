using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// The platform which move up and down looply
public class PlatformStraightMove : MonoBehaviour
{
    public float jumpForce = 10f;
    public float speed = 2.0f;
    private int direction = 1;
    private float timer = 1.25f;
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
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0.0f, direction * speed * Time.deltaTime, 0.0f);
        timer += Time.deltaTime;
        if (timer >= 2.5f)
        {
            if (direction == 1)
            {
                direction = -1; // change the direction to down (-1)
            }
            else if (direction == -1)
            {
                direction = 1; // change the direction to up (1)
            }            
            timer = 0f;
        }
    }
}
