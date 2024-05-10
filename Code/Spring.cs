using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// The spring object on the platform which make the player step on can jump higher
public class Spring : MonoBehaviour
{
    public float jumpForce = 15f;
    public SpriteRenderer spriteRenderer;
    public Sprite normal;
    public Sprite step;
    public bool on_step = false;
    private float timer = 0;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.y <= 0f && collision.gameObject.CompareTag("Player"))
        {
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            spriteRenderer = GetComponent<SpriteRenderer>();           
            if (rb != null)
            {
                Vector2 velocity = rb.velocity;
                velocity.y = jumpForce;
                rb.velocity = velocity;
                spriteRenderer.sprite = step;
                on_step = true;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (on_step == true)
        {
            timer += Time.deltaTime;
            if (timer >= 0.15f)
            {
                spriteRenderer.sprite = normal;
                timer = 0f;
                on_step = false;
            }
        }       
    }
}
