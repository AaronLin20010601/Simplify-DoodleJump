using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// The big size monster
public class BigMonster : MonoBehaviour
{
    public float jumpForce = 12f;
    public float speed = 1.5f;
    public float leftbound = -2.7f;
    public float rightbound = 2.7f;
    private int direction = 1;
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
        else if (collision.gameObject.CompareTag("HatActivePlayer") || collision.gameObject.CompareTag("RocketActivePlayer"))
        {
            transform.gameObject.SetActive(false);
        }
    }
    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(direction * speed * Time.deltaTime, 0.0f, 0.0f);
        if (transform.position.x <= leftbound)
        {
            direction = 1; // change the direction to right (1)
        }
        else if (transform.position.x >= rightbound)
        {
            direction = -1; // change the direction to left (-1)
        }
    }
}
